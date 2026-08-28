namespace AttendanceCollector
{
    partial class TimeSheetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSheetForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeaderDescription = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblFingerprintTitle = new System.Windows.Forms.Label();
            this.lblFingerprintValue = new System.Windows.Forms.Label();
            this.lblPeriodTitle = new System.Windows.Forms.Label();
            this.lblPeriodValue = new System.Windows.Forms.Label();
            this.lblTotalDaysTitle = new System.Windows.Forms.Label();
            this.lblTotalDaysValue = new System.Windows.Forms.Label();
            this.pnlListHeader = new System.Windows.Forms.Panel();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.dgvTimeSheet = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstPunch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastPunch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPunchCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlListHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSheet)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblHeaderDescription);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(820, 90);
            this.pnlHeader.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnClose.Location = new System.Drawing.Point(16, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHeaderDescription
            // 
            this.lblHeaderDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(235)))), ((int)(((byte)(226)))));
            this.lblHeaderDescription.Location = new System.Drawing.Point(330, 53);
            this.lblHeaderDescription.Name = "lblHeaderDescription";
            this.lblHeaderDescription.Size = new System.Drawing.Size(474, 25);
            this.lblHeaderDescription.TabIndex = 1;
            this.lblHeaderDescription.Text = "Time Sheet - عرض أول وآخر بصمة وعدد الحركات اليومية";
            this.lblHeaderDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(481, 10);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(323, 42);
            this.lblHeaderTitle.TabIndex = 2;
            this.lblHeaderTitle.Text = "كشف حركة الموظف";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblFingerprintTitle);
            this.pnlInfo.Controls.Add(this.lblFingerprintValue);
            this.pnlInfo.Controls.Add(this.lblPeriodTitle);
            this.pnlInfo.Controls.Add(this.lblPeriodValue);
            this.pnlInfo.Controls.Add(this.lblTotalDaysTitle);
            this.pnlInfo.Controls.Add(this.lblTotalDaysValue);
            this.pnlInfo.Location = new System.Drawing.Point(16, 105);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(788, 120);
            this.pnlInfo.TabIndex = 3;
            // 
            // lblFingerprintTitle
            // 
            this.lblFingerprintTitle.Font = new System.Drawing.Font("Cairo", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFingerprintTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblFingerprintTitle.Location = new System.Drawing.Point(555, 15);
            this.lblFingerprintTitle.Name = "lblFingerprintTitle";
            this.lblFingerprintTitle.Size = new System.Drawing.Size(200, 25);
            this.lblFingerprintTitle.TabIndex = 0;
            this.lblFingerprintTitle.Text = "USER ID / رقم الموظف";
            this.lblFingerprintTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFingerprintValue
            // 
            this.lblFingerprintValue.Font = new System.Drawing.Font("Cairo", 15F, System.Drawing.FontStyle.Bold);
            this.lblFingerprintValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblFingerprintValue.Location = new System.Drawing.Point(555, 40);
            this.lblFingerprintValue.Name = "lblFingerprintValue";
            this.lblFingerprintValue.Size = new System.Drawing.Size(200, 45);
            this.lblFingerprintValue.TabIndex = 1;
            this.lblFingerprintValue.Text = "--";
            this.lblFingerprintValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPeriodTitle
            // 
            this.lblPeriodTitle.Font = new System.Drawing.Font("Cairo", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPeriodTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblPeriodTitle.Location = new System.Drawing.Point(235, 15);
            this.lblPeriodTitle.Name = "lblPeriodTitle";
            this.lblPeriodTitle.Size = new System.Drawing.Size(280, 25);
            this.lblPeriodTitle.TabIndex = 2;
            this.lblPeriodTitle.Text = "الفترة";
            this.lblPeriodTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPeriodValue
            // 
            this.lblPeriodValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblPeriodValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblPeriodValue.Location = new System.Drawing.Point(235, 43);
            this.lblPeriodValue.Name = "lblPeriodValue";
            this.lblPeriodValue.Size = new System.Drawing.Size(280, 40);
            this.lblPeriodValue.TabIndex = 3;
            this.lblPeriodValue.Text = "--";
            this.lblPeriodValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDaysTitle
            // 
            this.lblTotalDaysTitle.Font = new System.Drawing.Font("Cairo", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalDaysTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalDaysTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTotalDaysTitle.Name = "lblTotalDaysTitle";
            this.lblTotalDaysTitle.Size = new System.Drawing.Size(170, 25);
            this.lblTotalDaysTitle.TabIndex = 4;
            this.lblTotalDaysTitle.Text = "أيام بها حركة";
            this.lblTotalDaysTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDaysValue
            // 
            this.lblTotalDaysValue.Font = new System.Drawing.Font("Cairo", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalDaysValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblTotalDaysValue.Location = new System.Drawing.Point(25, 40);
            this.lblTotalDaysValue.Name = "lblTotalDaysValue";
            this.lblTotalDaysValue.Size = new System.Drawing.Size(170, 45);
            this.lblTotalDaysValue.TabIndex = 5;
            this.lblTotalDaysValue.Text = "0";
            this.lblTotalDaysValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlListHeader
            // 
            this.pnlListHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlListHeader.Controls.Add(this.lblRecordCount);
            this.pnlListHeader.Controls.Add(this.lblListTitle);
            this.pnlListHeader.Location = new System.Drawing.Point(16, 240);
            this.pnlListHeader.Name = "pnlListHeader";
            this.pnlListHeader.Size = new System.Drawing.Size(788, 45);
            this.pnlListHeader.TabIndex = 2;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecordCount.ForeColor = System.Drawing.Color.Gray;
            this.lblRecordCount.Location = new System.Drawing.Point(0, 0);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(488, 45);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "0 يوم";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblListTitle
            // 
            this.lblListTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblListTitle.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.Location = new System.Drawing.Point(488, 0);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(300, 45);
            this.lblListTitle.TabIndex = 1;
            this.lblListTitle.Text = "الحركة اليومية";
            this.lblListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvTimeSheet
            // 
            this.dgvTimeSheet.AllowUserToAddRows = false;
            this.dgvTimeSheet.AllowUserToDeleteRows = false;
            this.dgvTimeSheet.AllowUserToResizeRows = false;
            this.dgvTimeSheet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimeSheet.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimeSheet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTimeSheet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTimeSheet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cairo", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTimeSheet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimeSheet.ColumnHeadersHeight = 42;
            this.dgvTimeSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTimeSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colFirstPunch,
            this.colLastPunch,
            this.colPunchCount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cairo", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(239)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimeSheet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTimeSheet.EnableHeadersVisualStyles = false;
            this.dgvTimeSheet.Location = new System.Drawing.Point(16, 285);
            this.dgvTimeSheet.MultiSelect = false;
            this.dgvTimeSheet.Name = "dgvTimeSheet";
            this.dgvTimeSheet.ReadOnly = true;
            this.dgvTimeSheet.RowHeadersVisible = false;
            this.dgvTimeSheet.RowTemplate.Height = 36;
            this.dgvTimeSheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeSheet.Size = new System.Drawing.Size(788, 420);
            this.dgvTimeSheet.TabIndex = 1;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "التاريخ";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colFirstPunch
            // 
            this.colFirstPunch.HeaderText = "أول بصمة";
            this.colFirstPunch.Name = "colFirstPunch";
            this.colFirstPunch.ReadOnly = true;
            // 
            // colLastPunch
            // 
            this.colLastPunch.HeaderText = "آخر بصمة";
            this.colLastPunch.Name = "colLastPunch";
            this.colLastPunch.ReadOnly = true;
            // 
            // colPunchCount
            // 
            this.colPunchCount.HeaderText = "عدد البصمات";
            this.colPunchCount.Name = "colPunchCount";
            this.colPunchCount.ReadOnly = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnExportExcel);
            this.pnlFooter.Controls.Add(this.btnPrint);
            this.pnlFooter.Location = new System.Drawing.Point(16, 718);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(788, 55);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(588, 8);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(180, 38);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "تصدير Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnPrint.Location = new System.Drawing.Point(390, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(180, 38);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "طباعة / PDF";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // TimeSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(820, 790);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.dgvTimeSheet);
            this.Controls.Add(this.pnlListHeader);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Cairo", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "TimeSheetForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Time Sheet";
            this.Load += new System.EventHandler(this.TimeSheetForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlListHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSheet)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeaderDescription;
        private System.Windows.Forms.Label lblHeaderTitle;

        private System.Windows.Forms.Panel pnlInfo;

        private System.Windows.Forms.Label lblFingerprintTitle;
        private System.Windows.Forms.Label lblFingerprintValue;

        private System.Windows.Forms.Label lblPeriodTitle;
        private System.Windows.Forms.Label lblPeriodValue;

        private System.Windows.Forms.Label lblTotalDaysTitle;
        private System.Windows.Forms.Label lblTotalDaysValue;

        private System.Windows.Forms.Panel pnlListHeader;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblRecordCount;

        private System.Windows.Forms.DataGridView dgvTimeSheet;

        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstPunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastPunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPunchCount;

        private System.Windows.Forms.Panel pnlFooter;

        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnPrint;
    }
}