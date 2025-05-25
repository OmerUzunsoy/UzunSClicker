namespace UzunSClicker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form ayarları - EMOJİ KUTUSU İÇİN DAHA GENİŞ
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(620, 540);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UzunSClicker v1.0 - Ömer Uzunsoy";
            this.Load += new System.EventHandler(this.Form1_Load);

            // Click Hızı Label
            var lblClickSpeed = new System.Windows.Forms.Label();
            lblClickSpeed.Text = "⚡ Saniyede Click Sayısı:";
            lblClickSpeed.ForeColor = System.Drawing.Color.White;
            lblClickSpeed.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblClickSpeed.Location = new System.Drawing.Point(40, 30);
            lblClickSpeed.Size = new System.Drawing.Size(190, 25);
            this.Controls.Add(lblClickSpeed);

            // Click Hızı NumericUpDown
            var numClickSpeed = new System.Windows.Forms.NumericUpDown();
            numClickSpeed.Name = "numClickSpeed";
            numClickSpeed.Minimum = 1;
            numClickSpeed.Maximum = 999999;
            numClickSpeed.Value = 10;
            numClickSpeed.Location = new System.Drawing.Point(240, 28);
            numClickSpeed.Size = new System.Drawing.Size(160, 27);
            numClickSpeed.BackColor = System.Drawing.Color.FromArgb(40, 150, 40);
            numClickSpeed.ForeColor = System.Drawing.Color.White;
            numClickSpeed.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Controls.Add(numClickSpeed);

            // Speed Level Label - EMOJİ KUTUSU ÇOK GENİŞLETİLDİ
            var lblSpeedLevel = new System.Windows.Forms.Label();
            lblSpeedLevel.Name = "lblSpeedLevel";
            lblSpeedLevel.Text = "🟢 ☺ GÜVENLİ";
            lblSpeedLevel.ForeColor = System.Drawing.Color.FromArgb(40, 150, 40);
            lblSpeedLevel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblSpeedLevel.Location = new System.Drawing.Point(420, 28);
            lblSpeedLevel.Size = new System.Drawing.Size(180, 30);
            lblSpeedLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Controls.Add(lblSpeedLevel);

            // Hotkey Label
            var lblHotkey = new System.Windows.Forms.Label();
            lblHotkey.Text = "🎯 Kısayol Tuşu (Tıklayın):";
            lblHotkey.ForeColor = System.Drawing.Color.White;
            lblHotkey.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblHotkey.Location = new System.Drawing.Point(40, 80);
            lblHotkey.Size = new System.Drawing.Size(180, 25);
            this.Controls.Add(lblHotkey);

            // Hotkey Button - GENİŞLETİLDİ
            var btnSetHotkey = new System.Windows.Forms.Button();
            btnSetHotkey.Name = "btnSetHotkey";
            btnSetHotkey.Text = "F6 (Varsayılan) - Tıklayın";
            btnSetHotkey.Location = new System.Drawing.Point(230, 78);
            btnSetHotkey.Size = new System.Drawing.Size(310, 32);
            btnSetHotkey.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnSetHotkey.ForeColor = System.Drawing.Color.White;
            btnSetHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSetHotkey.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnSetHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Controls.Add(btnSetHotkey);

            // Reset Button - GENİŞLETİLDİ
            var btnReset = new System.Windows.Forms.Button();
            btnReset.Name = "btnReset";
            btnReset.Text = "🔄 Ayarları Sıfırla";
            btnReset.Location = new System.Drawing.Point(40, 130);
            btnReset.Size = new System.Drawing.Size(500, 40);
            btnReset.BackColor = System.Drawing.Color.FromArgb(185, 30, 30);
            btnReset.ForeColor = System.Drawing.Color.White;
            btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Controls.Add(btnReset);

            // Ana AÇIK/KAPALI Button - GENİŞLETİLDİ
            var btnToggle = new System.Windows.Forms.Button();
            btnToggle.Name = "btnToggle";
            btnToggle.Text = "🔴 KAPALI";
            btnToggle.Location = new System.Drawing.Point(40, 190);
            btnToggle.Size = new System.Drawing.Size(500, 65);
            btnToggle.BackColor = System.Drawing.Color.FromArgb(185, 30, 30);
            btnToggle.ForeColor = System.Drawing.Color.White;
            btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnToggle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            btnToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Controls.Add(btnToggle);

            // Mouse Button GroupBox
            var gbMouseButton = new System.Windows.Forms.GroupBox();
            gbMouseButton.Text = "🖱️ Mouse Tuşu";
            gbMouseButton.ForeColor = System.Drawing.Color.White;
            gbMouseButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            gbMouseButton.Location = new System.Drawing.Point(40, 280);
            gbMouseButton.Size = new System.Drawing.Size(200, 110);

            var rbLeftClick = new System.Windows.Forms.RadioButton();
            rbLeftClick.Name = "rbLeftClick";
            rbLeftClick.Text = "👆 Sol Tık";
            rbLeftClick.ForeColor = System.Drawing.Color.White;
            rbLeftClick.Font = new System.Drawing.Font("Segoe UI", 12F);
            rbLeftClick.Location = new System.Drawing.Point(25, 35);
            rbLeftClick.Size = new System.Drawing.Size(160, 30);
            rbLeftClick.Checked = true;
            rbLeftClick.AutoSize = false;

            var rbRightClick = new System.Windows.Forms.RadioButton();
            rbRightClick.Name = "rbRightClick";
            rbRightClick.Text = "👉 Sağ Tık";
            rbRightClick.ForeColor = System.Drawing.Color.White;
            rbRightClick.Font = new System.Drawing.Font("Segoe UI", 12F);
            rbRightClick.Location = new System.Drawing.Point(25, 70);
            rbRightClick.Size = new System.Drawing.Size(160, 30);
            rbRightClick.AutoSize = false;

            gbMouseButton.Controls.Add(rbLeftClick);
            gbMouseButton.Controls.Add(rbRightClick);
            this.Controls.Add(gbMouseButton);

            // Click Mode GroupBox - KONUMU AYARLANDI
            var gbClickMode = new System.Windows.Forms.GroupBox();
            gbClickMode.Text = "⚙️ Çalışma Modu";
            gbClickMode.ForeColor = System.Drawing.Color.White;
            gbClickMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            gbClickMode.Location = new System.Drawing.Point(270, 280);
            gbClickMode.Size = new System.Drawing.Size(270, 110);

            var rbToggleMode = new System.Windows.Forms.RadioButton();
            rbToggleMode.Name = "rbToggleMode";
            rbToggleMode.Text = "🔄 Aç/Kapa";
            rbToggleMode.ForeColor = System.Drawing.Color.White;
            rbToggleMode.Font = new System.Drawing.Font("Segoe UI", 12F);
            rbToggleMode.Location = new System.Drawing.Point(25, 35);
            rbToggleMode.Size = new System.Drawing.Size(220, 30);
            rbToggleMode.Checked = true;
            rbToggleMode.AutoSize = false;

            var rbHoldMode = new System.Windows.Forms.RadioButton();
            rbHoldMode.Name = "rbHoldMode";
            rbHoldMode.Text = "⏸️ Basılı Tut";
            rbHoldMode.ForeColor = System.Drawing.Color.White;
            rbHoldMode.Font = new System.Drawing.Font("Segoe UI", 12F);
            rbHoldMode.Location = new System.Drawing.Point(25, 70);
            rbHoldMode.Size = new System.Drawing.Size(220, 30);
            rbHoldMode.AutoSize = false;

            gbClickMode.Controls.Add(rbToggleMode);
            gbClickMode.Controls.Add(rbHoldMode);
            this.Controls.Add(gbClickMode);

            // Status Label - GENİŞLETİLDİ
            var lblStatus = new System.Windows.Forms.Label();
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "⭕ Kapalı - Önce AÇIK yapın";
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblStatus.Location = new System.Drawing.Point(40, 410);
            lblStatus.Size = new System.Drawing.Size(500, 30);
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(lblStatus);

            // Created By Label - KONUMU AYARLANDI
            var lblCreatedBy = new System.Windows.Forms.Label();
            lblCreatedBy.Text = "Created by Ömer Uzunsoy - 2025";
            lblCreatedBy.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblCreatedBy.Location = new System.Drawing.Point(320, 500);
            lblCreatedBy.Size = new System.Drawing.Size(280, 20);
            lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Controls.Add(lblCreatedBy);

            this.ResumeLayout(false);
        }

        #endregion
    }
}