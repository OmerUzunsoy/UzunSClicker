using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UzunSClicker
{
    public partial class Form1 : Form
    {
        // Windows API fonksiyonları
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        // Mouse click sabitleri
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        // Hotkey sabitleri
        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID = 9000;

        // Değişkenvar
        private Timer clickTimer;
        private Timer holdCheckTimer;
        private bool isClicking = false;
        private bool isEnabled = false;
        private bool isHoldMode = false;
        private bool isLeftClick = true;
        private int clicksPerSecond = 10;
        private Keys currentHotkey = Keys.F6;
        private bool isWaitingForHotkey = false;

        // Kontroller
        private NumericUpDown numClickSpeed;
        private Button btnSetHotkey;
        private Button btnReset;
        private Button btnToggle;
        private RadioButton rbLeftClick;
        private RadioButton rbRightClick;
        private RadioButton rbToggleMode;
        private RadioButton rbHoldMode;
        private Label lblStatus;
        private Label lblSpeedLevel;

        public Form1()
        {
            InitializeComponent();

            // Klavye olaylarını dinle
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendikten sonra kontrolleri başlat
            InitializeControls();
            SetupTimer();
            RegisterCurrentHotkey();
            UpdateSpeedColorCoding();
        }

        private void InitializeControls()
        {
            // Kontrolleri bul
            numClickSpeed = (NumericUpDown)this.Controls.Find("numClickSpeed", true)[0];
            btnSetHotkey = (Button)this.Controls.Find("btnSetHotkey", true)[0];
            btnReset = (Button)this.Controls.Find("btnReset", true)[0];
            btnToggle = (Button)this.Controls.Find("btnToggle", true)[0];
            rbLeftClick = (RadioButton)this.Controls.Find("rbLeftClick", true)[0];
            rbRightClick = (RadioButton)this.Controls.Find("rbRightClick", true)[0];
            rbToggleMode = (RadioButton)this.Controls.Find("rbToggleMode", true)[0];
            rbHoldMode = (RadioButton)this.Controls.Find("rbHoldMode", true)[0];
            lblStatus = (Label)this.Controls.Find("lblStatus", true)[0];
            lblSpeedLevel = (Label)this.Controls.Find("lblSpeedLevel", true)[0];

            // Event handler'ları ekle
            btnToggle.Click += BtnToggle_Click;
            btnReset.Click += BtnReset_Click;
            btnSetHotkey.Click += BtnSetHotkey_Click;
            numClickSpeed.ValueChanged += NumClickSpeed_ValueChanged;
            rbLeftClick.CheckedChanged += RbMouseButton_CheckedChanged;
            rbRightClick.CheckedChanged += RbMouseButton_CheckedChanged;
            rbToggleMode.CheckedChanged += RbClickMode_CheckedChanged;
            rbHoldMode.CheckedChanged += RbClickMode_CheckedChanged;
        }

        private void SetupTimer()
        {
            // Click timer
            clickTimer = new Timer();
            clickTimer.Tick += ClickTimer_Tick;
            UpdateTimerInterval();

            // Hold check timer - Basılı tut modu için
            holdCheckTimer = new Timer();
            holdCheckTimer.Interval = 50;
            holdCheckTimer.Tick += HoldCheckTimer_Tick;
        }

        private void UpdateTimerInterval()
        {
            clicksPerSecond = (int)numClickSpeed.Value;

            // HATA DÜZELTİLDİ: Minimum 1ms interval garantisi
            int interval = 1000 / clicksPerSecond;
            if (interval <= 0)
                interval = 1; // En az 1ms

            clickTimer.Interval = interval;
        }

        private void UpdateSpeedColorCoding()
        {
            int speed = (int)numClickSpeed.Value;

            if (speed >= 1 && speed <= 2000)
            {
                // 🟢 YEŞİL - Güvenli
                numClickSpeed.BackColor = Color.FromArgb(40, 150, 40);
                lblSpeedLevel.Text = "🟢 ☺ GÜVENLİ";
                lblSpeedLevel.ForeColor = Color.FromArgb(40, 150, 40);
            }
            else if (speed > 2000 && speed <= 50000)
            {
                // 🟠 TURUNCU - Orta
                numClickSpeed.BackColor = Color.FromArgb(255, 140, 0);
                lblSpeedLevel.Text = "🟠 ◉ ORTA";
                lblSpeedLevel.ForeColor = Color.FromArgb(255, 140, 0);
            }
            else if (speed > 50000 && speed <= 999999)
            {
                // 🔴 KIRMIZI - Yüksek
                numClickSpeed.BackColor = Color.FromArgb(220, 20, 20);
                lblSpeedLevel.Text = "🔴 ⚠ YÜKSEK";
                lblSpeedLevel.ForeColor = Color.FromArgb(220, 20, 20);
            }
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            isEnabled = !isEnabled;

            if (isEnabled)
            {
                btnToggle.Text = "🟢 AÇIK";
                btnToggle.BackColor = Color.FromArgb(76, 175, 80);

                if (isHoldMode)
                {
                    lblStatus.Text = "✅ Açık - Kısayol tuşunu basılı tutun";
                    holdCheckTimer.Start();
                }
                else
                {
                    lblStatus.Text = "✅ Açık - Kısayol tuşuna basın";
                }
            }
            else
            {
                btnToggle.Text = "🔴 KAPALI";
                btnToggle.BackColor = Color.FromArgb(185, 30, 30);
                lblStatus.Text = "⭕ Kapalı - Önce AÇIK yapın";
                StopClicking();
                holdCheckTimer.Stop();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            StopClicking();
            holdCheckTimer.Stop();

            numClickSpeed.Value = 10;
            rbLeftClick.Checked = true;
            rbToggleMode.Checked = true;
            isEnabled = false;

            btnToggle.Text = "🔴 KAPALI";
            btnToggle.BackColor = Color.FromArgb(185, 30, 30);
            lblStatus.Text = "🔄 Ayarlar sıfırlandı";

            UnregisterHotKey(this.Handle, HOTKEY_ID);
            currentHotkey = Keys.F6;
            btnSetHotkey.Text = "F6 (Varsayılan) - Tıklayın";
            btnSetHotkey.BackColor = Color.FromArgb(0, 122, 204);
            RegisterCurrentHotkey();

            UpdateSpeedColorCoding(); // SAĞ GÖSTERGEYİ DE GÜNCELLİYOR

            MessageBox.Show("Tüm ayarlar sıfırlandı!", "UzunSClicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSetHotkey_Click(object sender, EventArgs e)
        {
            isWaitingForHotkey = true;
            btnSetHotkey.Text = "Yeni tuşa basın...";
            btnSetHotkey.BackColor = Color.FromArgb(255, 165, 0);
            lblStatus.Text = "🎯 Yeni kısayol tuşuna basın...";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isWaitingForHotkey)
            {
                // Eski hotkey'i kaldır
                UnregisterHotKey(this.Handle, HOTKEY_ID);

                // Yeni hotkey'i ayarla
                currentHotkey = e.KeyCode;
                btnSetHotkey.Text = currentHotkey.ToString();
                btnSetHotkey.BackColor = Color.FromArgb(76, 175, 80);

                // Yeni hotkey'i kaydet
                RegisterCurrentHotkey();

                isWaitingForHotkey = false;
                lblStatus.Text = $"🎯 Hotkey değiştirildi: {currentHotkey}";

                e.Handled = true;
            }
        }

        private void NumClickSpeed_ValueChanged(object sender, EventArgs e)
        {
            UpdateTimerInterval();

            // HEM SAĞ HEM ALT GÖSTERGEYİ GÜNCELLE
            UpdateSpeedColorCoding(); // Sağ göstergeyi günceller

            int speed = (int)numClickSpeed.Value;
            string speedLevel = "";
            string emoji = "";

            if (speed <= 2000)
            {
                speedLevel = "GÜVENLİ";
                emoji = "☺";
            }
            else if (speed <= 50000)
            {
                speedLevel = "ORTA";
                emoji = "◉";
            }
            else
            {
                speedLevel = "YÜKSEK";
                emoji = "⚠";
            }

            lblStatus.Text = $"⚡ Hız: {speed}/sn ({emoji} {speedLevel})"; // Alt göstergeyi günceller
        }

        private void RbMouseButton_CheckedChanged(object sender, EventArgs e)
        {
            isLeftClick = rbLeftClick.Checked;
            string clickType = isLeftClick ? "Sol" : "Sağ";
            lblStatus.Text = $"🖱️ {clickType} tık seçildi";
        }

        private void RbClickMode_CheckedChanged(object sender, EventArgs e)
        {
            isHoldMode = rbHoldMode.Checked;
            string mode = isHoldMode ? "Basılı Tut" : "Aç/Kapa";
            lblStatus.Text = $"⚙️ Mod değiştirildi: {mode}";

            if (isEnabled)
            {
                if (isHoldMode)
                {
                    holdCheckTimer.Start();
                    lblStatus.Text = "✅ Açık - Kısayol tuşunu basılı tutun";
                }
                else
                {
                    holdCheckTimer.Stop();
                    lblStatus.Text = "✅ Açık - Kısayol tuşuna basın";
                }
            }
        }

        private void RegisterCurrentHotkey()
        {
            RegisterHotKey(this.Handle, HOTKEY_ID, 0, (int)currentHotkey);
        }

        private void HoldCheckTimer_Tick(object sender, EventArgs e)
        {
            if (!isEnabled || !isHoldMode) return;

            bool isKeyPressed = (GetAsyncKeyState((int)currentHotkey) & 0x8000) != 0;

            if (isKeyPressed && !isClicking)
            {
                StartClicking();
            }
            else if (!isKeyPressed && isClicking)
            {
                StopClicking();
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                if (!isEnabled)
                {
                    lblStatus.Text = "⚠️ Önce AÇIK yapın!";
                    return;
                }

                if (!isHoldMode)
                {
                    if (!isClicking)
                        StartClicking();
                    else
                        StopClicking();
                }
            }
        }

        private void StartClicking()
        {
            if (!isEnabled) return;

            isClicking = true;
            clickTimer.Start();
            lblStatus.Text = $"🎯 Çalışıyor! {clicksPerSecond}/sn";
        }

        private void StopClicking()
        {
            isClicking = false;
            clickTimer.Stop();
            if (isEnabled)
            {
                if (isHoldMode)
                    lblStatus.Text = "✋ Durdu - Kısayol tuşunu basılı tutun";
                else
                    lblStatus.Text = "✋ Durdu - Tekrar başlatmak için kısayol tuşuna basın";
            }
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            if (!isClicking) return;

            Point cursorPos = Cursor.Position;

            if (isLeftClick)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
            }
            else
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopClicking();
            holdCheckTimer.Stop();
            UnregisterHotKey(this.Handle, HOTKEY_ID);
            base.OnFormClosing(e);
        }
    }
}