namespace AttendanceCollector
{
    partial class WelcomeForm
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblPoweredBy = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 61);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 75);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Attendance Collector";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblSubtitle.Location = new System.Drawing.Point(60, 159);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(700, 45);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "نظام تجميع ومزامنة سجلات الحضور";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Cairo", 10.5F);
            this.lblDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblDescription.Location = new System.Drawing.Point(80, 201);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(660, 40);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "ربط أجهزة البصمة • تجميع السجلات • المزامنة التلقائية";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(250, 271);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(320, 60);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "ابدأ";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.Font = new System.Drawing.Font("Cairo", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDeveloper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblDeveloper.Location = new System.Drawing.Point(160, 366);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(500, 32);
            this.lblDeveloper.TabIndex = 5;
            this.lblDeveloper.Text = "Developed by Mohamed Nouri Bakeer";
            this.lblDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoweredBy
            // 
            this.lblPoweredBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPoweredBy.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblPoweredBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblPoweredBy.Location = new System.Drawing.Point(160, 401);
            this.lblPoweredBy.Name = "lblPoweredBy";
            this.lblPoweredBy.Size = new System.Drawing.Size(500, 32);
            this.lblPoweredBy.TabIndex = 6;
            this.lblPoweredBy.Text = "Powered by ITXVX  •  me.itxvx.ly";
            this.lblPoweredBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPoweredBy.Click += new System.EventHandler(this.lblPoweredBy_Click);
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.pnlLine.Location = new System.Drawing.Point(310, 139);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(200, 3);
            this.pnlLine.TabIndex = 2;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 530);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblDeveloper);
            this.Controls.Add(this.lblPoweredBy);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WelcomeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Collector";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblPoweredBy;
        private System.Windows.Forms.Panel pnlLine;
    }
}