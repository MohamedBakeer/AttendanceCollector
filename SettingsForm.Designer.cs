namespace AttendanceCollector
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderDescription = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlAutoSync = new System.Windows.Forms.Panel();
            this.lblAutoSyncTitle = new System.Windows.Forms.Label();
            this.lblAutoSyncDescription = new System.Windows.Forms.Label();
            this.chkAutoSync = new System.Windows.Forms.CheckBox();
            this.lblAutoSyncMinutes = new System.Windows.Forms.Label();
            this.numAutoSyncMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.pnlN8n = new System.Windows.Forms.Panel();
            this.btnPreviewSample = new System.Windows.Forms.Button();
            this.lblN8nSectionTitle = new System.Windows.Forms.Label();
            this.lblN8nDescription = new System.Windows.Forms.Label();
            this.chkN8nEnabled = new System.Windows.Forms.CheckBox();
            this.lblWebhookUrl = new System.Windows.Forms.Label();
            this.txtWebhookUrl = new System.Windows.Forms.TextBox();
            this.btnTestN8n = new System.Windows.Forms.Button();
            this.lblN8nTestStatus = new System.Windows.Forms.Label();
            this.pnlProgram = new System.Windows.Forms.Panel();
            this.chkRunInBackground = new System.Windows.Forms.CheckBox();
            this.lblProgramTitle = new System.Windows.Forms.Label();
            this.lblProgramDescription = new System.Windows.Forms.Label();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlAutoSync.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSyncMinutes)).BeginInit();
            this.pnlN8n.SuspendLayout();
            this.pnlProgram.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.pnlHeader.Controls.Add(this.lblHeaderDescription);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(820, 90);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblHeaderDescription
            // 
            this.lblHeaderDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(235)))), ((int)(((byte)(226)))));
            this.lblHeaderDescription.Location = new System.Drawing.Point(330, 53);
            this.lblHeaderDescription.Name = "lblHeaderDescription";
            this.lblHeaderDescription.Size = new System.Drawing.Size(474, 25);
            this.lblHeaderDescription.TabIndex = 1;
            this.lblHeaderDescription.Text = "إعدادات السحب التلقائي والربط مع n8n وتشغيل البرنامج";
            this.lblHeaderDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(560, 10);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(244, 42);
            this.lblHeaderTitle.TabIndex = 2;
            this.lblHeaderTitle.Text = "إعدادات النظام";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAutoSync
            // 
            this.pnlAutoSync.BackColor = System.Drawing.Color.White;
            this.pnlAutoSync.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAutoSync.Controls.Add(this.lblAutoSyncTitle);
            this.pnlAutoSync.Controls.Add(this.lblAutoSyncDescription);
            this.pnlAutoSync.Controls.Add(this.chkAutoSync);
            this.pnlAutoSync.Controls.Add(this.lblAutoSyncMinutes);
            this.pnlAutoSync.Controls.Add(this.numAutoSyncMinutes);
            this.pnlAutoSync.Controls.Add(this.lblMinutes);
            this.pnlAutoSync.Location = new System.Drawing.Point(16, 105);
            this.pnlAutoSync.Name = "pnlAutoSync";
            this.pnlAutoSync.Size = new System.Drawing.Size(788, 160);
            this.pnlAutoSync.TabIndex = 3;
            // 
            // lblAutoSyncTitle
            // 
            this.lblAutoSyncTitle.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.lblAutoSyncTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblAutoSyncTitle.Location = new System.Drawing.Point(520, 12);
            this.lblAutoSyncTitle.Name = "lblAutoSyncTitle";
            this.lblAutoSyncTitle.Size = new System.Drawing.Size(245, 30);
            this.lblAutoSyncTitle.TabIndex = 0;
            this.lblAutoSyncTitle.Text = "السحب التلقائي";
            this.lblAutoSyncTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAutoSyncDescription
            // 
            this.lblAutoSyncDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblAutoSyncDescription.Location = new System.Drawing.Point(320, 43);
            this.lblAutoSyncDescription.Name = "lblAutoSyncDescription";
            this.lblAutoSyncDescription.Size = new System.Drawing.Size(445, 25);
            this.lblAutoSyncDescription.TabIndex = 1;
            this.lblAutoSyncDescription.Text = "سحب سجلات أجهزة البصمة تلقائيًا حسب الفترة المحددة";
            this.lblAutoSyncDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAutoSync
            // 
            this.chkAutoSync.AutoSize = true;
            this.chkAutoSync.Location = new System.Drawing.Point(634, 85);
            this.chkAutoSync.Name = "chkAutoSync";
            this.chkAutoSync.Size = new System.Drawing.Size(126, 24);
            this.chkAutoSync.TabIndex = 2;
            this.chkAutoSync.Text = "تفعيل السحب التلقائي";
            this.chkAutoSync.UseVisualStyleBackColor = true;
            this.chkAutoSync.CheckedChanged += new System.EventHandler(this.chkAutoSync_CheckedChanged);
            // 
            // lblAutoSyncMinutes
            // 
            this.lblAutoSyncMinutes.AutoSize = true;
            this.lblAutoSyncMinutes.Location = new System.Drawing.Point(492, 88);
            this.lblAutoSyncMinutes.Name = "lblAutoSyncMinutes";
            this.lblAutoSyncMinutes.Size = new System.Drawing.Size(57, 20);
            this.lblAutoSyncMinutes.TabIndex = 3;
            this.lblAutoSyncMinutes.Text = "السحب كل";
            // 
            // numAutoSyncMinutes
            // 
            this.numAutoSyncMinutes.Location = new System.Drawing.Point(362, 84);
            this.numAutoSyncMinutes.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numAutoSyncMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAutoSyncMinutes.Name = "numAutoSyncMinutes";
            this.numAutoSyncMinutes.Size = new System.Drawing.Size(110, 28);
            this.numAutoSyncMinutes.TabIndex = 4;
            this.numAutoSyncMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numAutoSyncMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(307, 88);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(37, 20);
            this.lblMinutes.TabIndex = 5;
            this.lblMinutes.Text = "دقيقة";
            // 
            // pnlN8n
            // 
            this.pnlN8n.BackColor = System.Drawing.Color.White;
            this.pnlN8n.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlN8n.Controls.Add(this.btnPreviewSample);
            this.pnlN8n.Controls.Add(this.lblN8nSectionTitle);
            this.pnlN8n.Controls.Add(this.lblN8nDescription);
            this.pnlN8n.Controls.Add(this.chkN8nEnabled);
            this.pnlN8n.Controls.Add(this.lblWebhookUrl);
            this.pnlN8n.Controls.Add(this.txtWebhookUrl);
            this.pnlN8n.Controls.Add(this.btnTestN8n);
            this.pnlN8n.Controls.Add(this.lblN8nTestStatus);
            this.pnlN8n.Location = new System.Drawing.Point(16, 280);
            this.pnlN8n.Name = "pnlN8n";
            this.pnlN8n.Size = new System.Drawing.Size(788, 245);
            this.pnlN8n.TabIndex = 2;
            // 
            // btnPreviewSample
            // 
            this.btnPreviewSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnPreviewSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewSample.ForeColor = System.Drawing.Color.White;
            this.btnPreviewSample.Location = new System.Drawing.Point(485, 188);
            this.btnPreviewSample.Name = "btnPreviewSample";
            this.btnPreviewSample.Size = new System.Drawing.Size(87, 38);
            this.btnPreviewSample.TabIndex = 7;
            this.btnPreviewSample.Text = "تناول عينة";
            this.btnPreviewSample.UseVisualStyleBackColor = false;
            this.btnPreviewSample.Click += new System.EventHandler(this.btnPreviewSample_Click);
            // 
            // lblN8nSectionTitle
            // 
            this.lblN8nSectionTitle.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.lblN8nSectionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblN8nSectionTitle.Location = new System.Drawing.Point(520, 12);
            this.lblN8nSectionTitle.Name = "lblN8nSectionTitle";
            this.lblN8nSectionTitle.Size = new System.Drawing.Size(245, 30);
            this.lblN8nSectionTitle.TabIndex = 0;
            this.lblN8nSectionTitle.Text = "الربط مع n8n";
            this.lblN8nSectionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblN8nDescription
            // 
            this.lblN8nDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblN8nDescription.Location = new System.Drawing.Point(250, 43);
            this.lblN8nDescription.Name = "lblN8nDescription";
            this.lblN8nDescription.Size = new System.Drawing.Size(515, 25);
            this.lblN8nDescription.TabIndex = 1;
            this.lblN8nDescription.Text = "إرسال السجلات الجديدة إلى Workflow المركزي في n8n";
            this.lblN8nDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkN8nEnabled
            // 
            this.chkN8nEnabled.AutoSize = true;
            this.chkN8nEnabled.Location = new System.Drawing.Point(634, 82);
            this.chkN8nEnabled.Name = "chkN8nEnabled";
            this.chkN8nEnabled.Size = new System.Drawing.Size(126, 24);
            this.chkN8nEnabled.TabIndex = 2;
            this.chkN8nEnabled.Text = "تفعيل الإرسال إلى n8n";
            this.chkN8nEnabled.UseVisualStyleBackColor = true;
            this.chkN8nEnabled.CheckedChanged += new System.EventHandler(this.chkN8nEnabled_CheckedChanged);
            // 
            // lblWebhookUrl
            // 
            this.lblWebhookUrl.AutoSize = true;
            this.lblWebhookUrl.Location = new System.Drawing.Point(680, 120);
            this.lblWebhookUrl.Name = "lblWebhookUrl";
            this.lblWebhookUrl.Size = new System.Drawing.Size(75, 20);
            this.lblWebhookUrl.TabIndex = 3;
            this.lblWebhookUrl.Text = "Webhook URL";
            // 
            // txtWebhookUrl
            // 
            this.txtWebhookUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWebhookUrl.Location = new System.Drawing.Point(20, 145);
            this.txtWebhookUrl.Name = "txtWebhookUrl";
            this.txtWebhookUrl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWebhookUrl.Size = new System.Drawing.Size(745, 28);
            this.txtWebhookUrl.TabIndex = 4;
            // 
            // btnTestN8n
            // 
            this.btnTestN8n.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnTestN8n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestN8n.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnTestN8n.Location = new System.Drawing.Point(585, 188);
            this.btnTestN8n.Name = "btnTestN8n";
            this.btnTestN8n.Size = new System.Drawing.Size(180, 38);
            this.btnTestN8n.TabIndex = 5;
            this.btnTestN8n.Text = "اختبار الاتصال";
            this.btnTestN8n.UseVisualStyleBackColor = false;
            this.btnTestN8n.Click += new System.EventHandler(this.btnTestN8n_Click);
            // 
            // lblN8nTestStatus
            // 
            this.lblN8nTestStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblN8nTestStatus.Location = new System.Drawing.Point(20, 190);
            this.lblN8nTestStatus.Name = "lblN8nTestStatus";
            this.lblN8nTestStatus.Size = new System.Drawing.Size(452, 35);
            this.lblN8nTestStatus.TabIndex = 6;
            this.lblN8nTestStatus.Text = "لم يتم الاختبار";
            this.lblN8nTestStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlProgram
            // 
            this.pnlProgram.BackColor = System.Drawing.Color.White;
            this.pnlProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgram.Controls.Add(this.chkRunInBackground);
            this.pnlProgram.Controls.Add(this.lblProgramTitle);
            this.pnlProgram.Controls.Add(this.lblProgramDescription);
            this.pnlProgram.Controls.Add(this.chkStartWithWindows);
            this.pnlProgram.Controls.Add(this.chkStartMinimized);
            this.pnlProgram.Location = new System.Drawing.Point(16, 540);
            this.pnlProgram.Name = "pnlProgram";
            this.pnlProgram.Size = new System.Drawing.Size(788, 140);
            this.pnlProgram.TabIndex = 1;
            // 
            // chkRunInBackground
            // 
            this.chkRunInBackground.AutoSize = true;
            this.chkRunInBackground.Location = new System.Drawing.Point(103, 85);
            this.chkRunInBackground.Name = "chkRunInBackground";
            this.chkRunInBackground.Size = new System.Drawing.Size(160, 24);
            this.chkRunInBackground.TabIndex = 4;
            this.chkRunInBackground.Text = "العمل في الخلفية عند الإغلاق";
            // 
            // lblProgramTitle
            // 
            this.lblProgramTitle.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.lblProgramTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblProgramTitle.Location = new System.Drawing.Point(520, 12);
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.Size = new System.Drawing.Size(245, 30);
            this.lblProgramTitle.TabIndex = 0;
            this.lblProgramTitle.Text = "تشغيل البرنامج";
            this.lblProgramTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgramDescription
            // 
            this.lblProgramDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblProgramDescription.Location = new System.Drawing.Point(320, 42);
            this.lblProgramDescription.Name = "lblProgramDescription";
            this.lblProgramDescription.Size = new System.Drawing.Size(445, 25);
            this.lblProgramDescription.TabIndex = 1;
            this.lblProgramDescription.Text = "إعداد طريقة تشغيل Collector على جهاز الموقع";
            this.lblProgramDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(492, 85);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(154, 24);
            this.chkStartWithWindows.TabIndex = 2;
            this.chkStartWithWindows.Text = "تشغيل البرنامج مع Windows";
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.Location = new System.Drawing.Point(323, 85);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(109, 24);
            this.chkStartMinimized.TabIndex = 3;
            this.chkStartMinimized.Text = "بدء البرنامج مصغرًا";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Location = new System.Drawing.Point(16, 695);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(788, 70);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(585, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "حفظ الإعدادات";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(385, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "إغلاق";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(820, 790);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlProgram);
            this.Controls.Add(this.pnlN8n);
            this.Controls.Add(this.pnlAutoSync);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Cairo", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "الإعدادات";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlAutoSync.ResumeLayout(false);
            this.pnlAutoSync.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSyncMinutes)).EndInit();
            this.pnlN8n.ResumeLayout(false);
            this.pnlN8n.PerformLayout();
            this.pnlProgram.ResumeLayout(false);
            this.pnlProgram.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderDescription;
        private System.Windows.Forms.Label lblHeaderTitle;

        private System.Windows.Forms.Panel pnlAutoSync;
        private System.Windows.Forms.Label lblAutoSyncTitle;
        private System.Windows.Forms.Label lblAutoSyncDescription;
        private System.Windows.Forms.CheckBox chkAutoSync;
        private System.Windows.Forms.Label lblAutoSyncMinutes;
        private System.Windows.Forms.NumericUpDown numAutoSyncMinutes;
        private System.Windows.Forms.Label lblMinutes;

        private System.Windows.Forms.Panel pnlN8n;
        private System.Windows.Forms.Label lblN8nSectionTitle;
        private System.Windows.Forms.Label lblN8nDescription;
        private System.Windows.Forms.CheckBox chkN8nEnabled;
        private System.Windows.Forms.Label lblWebhookUrl;
        private System.Windows.Forms.TextBox txtWebhookUrl;
        private System.Windows.Forms.Button btnTestN8n;
        private System.Windows.Forms.Label lblN8nTestStatus;

        private System.Windows.Forms.Panel pnlProgram;
        private System.Windows.Forms.Label lblProgramTitle;
        private System.Windows.Forms.Label lblProgramDescription;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.CheckBox chkStartMinimized;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPreviewSample;
        private System.Windows.Forms.CheckBox chkRunInBackground;
    }
}