namespace AttendanceCollector
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSystemStatus = new System.Windows.Forms.Panel();
            this.pnlInternetStatus = new System.Windows.Forms.Panel();
            this.lblInternetStatus = new System.Windows.Forms.Label();
            this.lblInternetTitle = new System.Windows.Forms.Label();
            this.pnlN8nStatus = new System.Windows.Forms.Panel();
            this.lblN8nStatus = new System.Windows.Forms.Label();
            this.lblN8nTitle = new System.Windows.Forms.Label();
            this.pnlPendingStatus = new System.Windows.Forms.Panel();
            this.lblPendingValue = new System.Windows.Forms.Label();
            this.lblPendingTitle = new System.Windows.Forms.Label();
            this.pnlDevicesStatus = new System.Windows.Forms.Panel();
            this.lblDevicesStatus = new System.Windows.Forms.Label();
            this.lblDevicesTitle = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlPunchesCard = new System.Windows.Forms.Panel();
            this.lblPunchesValue = new System.Windows.Forms.Label();
            this.lblPunchesTitle = new System.Windows.Forms.Label();
            this.pnlEmployeesCard = new System.Windows.Forms.Panel();
            this.lblEmployeesValue = new System.Windows.Forms.Label();
            this.lblEmployeesTitle = new System.Windows.Forms.Label();
            this.pnlTodayDevicesCard = new System.Windows.Forms.Panel();
            this.lblTodayDevicesValue = new System.Windows.Forms.Label();
            this.lblTodayDevicesTitle = new System.Windows.Forms.Label();
            this.pnlSentCard = new System.Windows.Forms.Panel();
            this.lblSentValue = new System.Windows.Forms.Label();
            this.lblSentTitle = new System.Windows.Forms.Label();
            this.pnlTodayPendingCard = new System.Windows.Forms.Panel();
            this.lblTodayPendingValue = new System.Windows.Forms.Label();
            this.lblTodayPendingTitle = new System.Windows.Forms.Label();
            this.pnlLastPunchCard = new System.Windows.Forms.Panel();
            this.lblLastPunchValue = new System.Windows.Forms.Label();
            this.lblLastPunchTitle = new System.Windows.Forms.Label();
            this.pnlTableHeader = new System.Windows.Forms.Panel();
            this.lblTodayStatus = new System.Windows.Forms.Label();
            this.dgvToday = new System.Windows.Forms.DataGridView();
            this.colFingerprintId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstPunch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastPunch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPunchCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnPullNow = new System.Windows.Forms.Button();
            this.btnTodayStatistics = new System.Windows.Forms.Button();
            this.btnAttendanceLogs = new System.Windows.Forms.Button();
            this.btnDevices = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnRetryPending = new System.Windows.Forms.Button();
            this.progressBar_PullStatus = new System.Windows.Forms.ProgressBar();
            this.pnlHeader.SuspendLayout();
            this.pnlSystemStatus.SuspendLayout();
            this.pnlInternetStatus.SuspendLayout();
            this.pnlN8nStatus.SuspendLayout();
            this.pnlPendingStatus.SuspendLayout();
            this.pnlDevicesStatus.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlPunchesCard.SuspendLayout();
            this.pnlEmployeesCard.SuspendLayout();
            this.pnlTodayDevicesCard.SuspendLayout();
            this.pnlSentCard.SuspendLayout();
            this.pnlTodayPendingCard.SuspendLayout();
            this.pnlLastPunchCard.SuspendLayout();
            this.pnlTableHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToday)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblLastUpdate);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(820, 90);
            this.pnlHeader.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnClose.Location = new System.Drawing.Point(20, 28);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(235)))), ((int)(((byte)(226)))));
            this.lblLastUpdate.Location = new System.Drawing.Point(533, 55);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLastUpdate.Size = new System.Drawing.Size(266, 20);
            this.lblLastUpdate.TabIndex = 1;
            this.lblLastUpdate.Text = "آخر تحديث: --";
            this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(533, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 43);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Attendance Collector";
            // 
            // pnlSystemStatus
            // 
            this.pnlSystemStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSystemStatus.BackColor = System.Drawing.Color.White;
            this.pnlSystemStatus.Controls.Add(this.pnlInternetStatus);
            this.pnlSystemStatus.Controls.Add(this.pnlN8nStatus);
            this.pnlSystemStatus.Controls.Add(this.pnlPendingStatus);
            this.pnlSystemStatus.Controls.Add(this.pnlDevicesStatus);
            this.pnlSystemStatus.Location = new System.Drawing.Point(21, 105);
            this.pnlSystemStatus.Name = "pnlSystemStatus";
            this.pnlSystemStatus.Size = new System.Drawing.Size(779, 75);
            this.pnlSystemStatus.TabIndex = 4;
            // 
            // pnlInternetStatus
            // 
            this.pnlInternetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInternetStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.pnlInternetStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInternetStatus.Controls.Add(this.lblInternetStatus);
            this.pnlInternetStatus.Controls.Add(this.lblInternetTitle);
            this.pnlInternetStatus.Location = new System.Drawing.Point(637, 8);
            this.pnlInternetStatus.Name = "pnlInternetStatus";
            this.pnlInternetStatus.Size = new System.Drawing.Size(122, 58);
            this.pnlInternetStatus.TabIndex = 0;
            // 
            // lblInternetStatus
            // 
            this.lblInternetStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInternetStatus.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblInternetStatus.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblInternetStatus.Location = new System.Drawing.Point(0, 20);
            this.lblInternetStatus.Name = "lblInternetStatus";
            this.lblInternetStatus.Size = new System.Drawing.Size(120, 36);
            this.lblInternetStatus.TabIndex = 0;
            this.lblInternetStatus.Text = "جاري الفحص...";
            this.lblInternetStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInternetTitle
            // 
            this.lblInternetTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInternetTitle.Location = new System.Drawing.Point(0, 0);
            this.lblInternetTitle.Name = "lblInternetTitle";
            this.lblInternetTitle.Size = new System.Drawing.Size(120, 20);
            this.lblInternetTitle.TabIndex = 1;
            this.lblInternetTitle.Text = "الإنترنت";
            this.lblInternetTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlN8nStatus
            // 
            this.pnlN8nStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlN8nStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.pnlN8nStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlN8nStatus.Controls.Add(this.lblN8nStatus);
            this.pnlN8nStatus.Controls.Add(this.lblN8nTitle);
            this.pnlN8nStatus.Location = new System.Drawing.Point(431, 8);
            this.pnlN8nStatus.Name = "pnlN8nStatus";
            this.pnlN8nStatus.Size = new System.Drawing.Size(122, 58);
            this.pnlN8nStatus.TabIndex = 1;
            // 
            // lblN8nStatus
            // 
            this.lblN8nStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblN8nStatus.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblN8nStatus.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblN8nStatus.Location = new System.Drawing.Point(0, 20);
            this.lblN8nStatus.Name = "lblN8nStatus";
            this.lblN8nStatus.Size = new System.Drawing.Size(120, 36);
            this.lblN8nStatus.TabIndex = 0;
            this.lblN8nStatus.Text = "غير مفعلة";
            this.lblN8nStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblN8nTitle
            // 
            this.lblN8nTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblN8nTitle.Location = new System.Drawing.Point(0, 0);
            this.lblN8nTitle.Name = "lblN8nTitle";
            this.lblN8nTitle.Size = new System.Drawing.Size(120, 20);
            this.lblN8nTitle.TabIndex = 1;
            this.lblN8nTitle.Text = "مزامنة n8n";
            this.lblN8nTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPendingStatus
            // 
            this.pnlPendingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPendingStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.pnlPendingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendingStatus.Controls.Add(this.lblPendingValue);
            this.pnlPendingStatus.Controls.Add(this.lblPendingTitle);
            this.pnlPendingStatus.Location = new System.Drawing.Point(225, 8);
            this.pnlPendingStatus.Name = "pnlPendingStatus";
            this.pnlPendingStatus.Size = new System.Drawing.Size(122, 58);
            this.pnlPendingStatus.TabIndex = 2;
            // 
            // lblPendingValue
            // 
            this.lblPendingValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPendingValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblPendingValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblPendingValue.Location = new System.Drawing.Point(0, 20);
            this.lblPendingValue.Name = "lblPendingValue";
            this.lblPendingValue.Size = new System.Drawing.Size(120, 36);
            this.lblPendingValue.TabIndex = 0;
            this.lblPendingValue.Text = "0";
            this.lblPendingValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPendingTitle
            // 
            this.lblPendingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPendingTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPendingTitle.Name = "lblPendingTitle";
            this.lblPendingTitle.Size = new System.Drawing.Size(120, 20);
            this.lblPendingTitle.TabIndex = 1;
            this.lblPendingTitle.Text = "المعلق للإرسال";
            this.lblPendingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDevicesStatus
            // 
            this.pnlDevicesStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDevicesStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.pnlDevicesStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDevicesStatus.Controls.Add(this.lblDevicesStatus);
            this.pnlDevicesStatus.Controls.Add(this.lblDevicesTitle);
            this.pnlDevicesStatus.Location = new System.Drawing.Point(19, 8);
            this.pnlDevicesStatus.Name = "pnlDevicesStatus";
            this.pnlDevicesStatus.Size = new System.Drawing.Size(122, 58);
            this.pnlDevicesStatus.TabIndex = 3;
            // 
            // lblDevicesStatus
            // 
            this.lblDevicesStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDevicesStatus.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblDevicesStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblDevicesStatus.Location = new System.Drawing.Point(0, 20);
            this.lblDevicesStatus.Name = "lblDevicesStatus";
            this.lblDevicesStatus.Size = new System.Drawing.Size(120, 36);
            this.lblDevicesStatus.TabIndex = 0;
            this.lblDevicesStatus.Text = "0 / 0";
            this.lblDevicesStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDevicesTitle
            // 
            this.lblDevicesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDevicesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDevicesTitle.Name = "lblDevicesTitle";
            this.lblDevicesTitle.Size = new System.Drawing.Size(120, 20);
            this.lblDevicesTitle.TabIndex = 1;
            this.lblDevicesTitle.Text = "الأجهزة";
            this.lblDevicesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCards
            // 
            this.pnlCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCards.BackColor = System.Drawing.Color.White;
            this.pnlCards.Controls.Add(this.pnlPunchesCard);
            this.pnlCards.Controls.Add(this.pnlEmployeesCard);
            this.pnlCards.Controls.Add(this.pnlTodayDevicesCard);
            this.pnlCards.Controls.Add(this.pnlSentCard);
            this.pnlCards.Controls.Add(this.pnlTodayPendingCard);
            this.pnlCards.Controls.Add(this.pnlLastPunchCard);
            this.pnlCards.Location = new System.Drawing.Point(21, 195);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(779, 195);
            this.pnlCards.TabIndex = 3;
            // 
            // pnlPunchesCard
            // 
            this.pnlPunchesCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlPunchesCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPunchesCard.Controls.Add(this.lblPunchesValue);
            this.pnlPunchesCard.Controls.Add(this.lblPunchesTitle);
            this.pnlPunchesCard.Location = new System.Drawing.Point(549, 5);
            this.pnlPunchesCard.Name = "pnlPunchesCard";
            this.pnlPunchesCard.Size = new System.Drawing.Size(209, 85);
            this.pnlPunchesCard.TabIndex = 0;
            // 
            // lblPunchesValue
            // 
            this.lblPunchesValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPunchesValue.Font = new System.Drawing.Font("Cairo", 20F, System.Drawing.FontStyle.Bold);
            this.lblPunchesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblPunchesValue.Location = new System.Drawing.Point(0, 32);
            this.lblPunchesValue.Name = "lblPunchesValue";
            this.lblPunchesValue.Size = new System.Drawing.Size(207, 51);
            this.lblPunchesValue.TabIndex = 0;
            this.lblPunchesValue.Text = "0";
            this.lblPunchesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPunchesTitle
            // 
            this.lblPunchesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPunchesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPunchesTitle.Name = "lblPunchesTitle";
            this.lblPunchesTitle.Size = new System.Drawing.Size(207, 32);
            this.lblPunchesTitle.TabIndex = 1;
            this.lblPunchesTitle.Text = "إجمالي بصمات اليوم";
            this.lblPunchesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlEmployeesCard
            // 
            this.pnlEmployeesCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlEmployeesCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEmployeesCard.Controls.Add(this.lblEmployeesValue);
            this.pnlEmployeesCard.Controls.Add(this.lblEmployeesTitle);
            this.pnlEmployeesCard.Location = new System.Drawing.Point(282, 5);
            this.pnlEmployeesCard.Name = "pnlEmployeesCard";
            this.pnlEmployeesCard.Size = new System.Drawing.Size(209, 85);
            this.pnlEmployeesCard.TabIndex = 1;
            // 
            // lblEmployeesValue
            // 
            this.lblEmployeesValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmployeesValue.Font = new System.Drawing.Font("Cairo", 20F, System.Drawing.FontStyle.Bold);
            this.lblEmployeesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblEmployeesValue.Location = new System.Drawing.Point(0, 32);
            this.lblEmployeesValue.Name = "lblEmployeesValue";
            this.lblEmployeesValue.Size = new System.Drawing.Size(207, 51);
            this.lblEmployeesValue.TabIndex = 0;
            this.lblEmployeesValue.Text = "0";
            this.lblEmployeesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmployeesTitle
            // 
            this.lblEmployeesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployeesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblEmployeesTitle.Name = "lblEmployeesTitle";
            this.lblEmployeesTitle.Size = new System.Drawing.Size(207, 32);
            this.lblEmployeesTitle.TabIndex = 1;
            this.lblEmployeesTitle.Text = "أرقام البصمة النشطة اليوم";
            this.lblEmployeesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTodayDevicesCard
            // 
            this.pnlTodayDevicesCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlTodayDevicesCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTodayDevicesCard.Controls.Add(this.lblTodayDevicesValue);
            this.pnlTodayDevicesCard.Controls.Add(this.lblTodayDevicesTitle);
            this.pnlTodayDevicesCard.Location = new System.Drawing.Point(15, 5);
            this.pnlTodayDevicesCard.Name = "pnlTodayDevicesCard";
            this.pnlTodayDevicesCard.Size = new System.Drawing.Size(209, 85);
            this.pnlTodayDevicesCard.TabIndex = 2;
            // 
            // lblTodayDevicesValue
            // 
            this.lblTodayDevicesValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTodayDevicesValue.Font = new System.Drawing.Font("Cairo", 20F, System.Drawing.FontStyle.Bold);
            this.lblTodayDevicesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblTodayDevicesValue.Location = new System.Drawing.Point(0, 32);
            this.lblTodayDevicesValue.Name = "lblTodayDevicesValue";
            this.lblTodayDevicesValue.Size = new System.Drawing.Size(207, 51);
            this.lblTodayDevicesValue.TabIndex = 0;
            this.lblTodayDevicesValue.Text = "0";
            this.lblTodayDevicesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTodayDevicesTitle
            // 
            this.lblTodayDevicesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTodayDevicesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTodayDevicesTitle.Name = "lblTodayDevicesTitle";
            this.lblTodayDevicesTitle.Size = new System.Drawing.Size(207, 32);
            this.lblTodayDevicesTitle.TabIndex = 1;
            this.lblTodayDevicesTitle.Text = "الأجهزة التي أرسلت بصمات اليوم";
            this.lblTodayDevicesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSentCard
            // 
            this.pnlSentCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlSentCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSentCard.Controls.Add(this.lblSentValue);
            this.pnlSentCard.Controls.Add(this.lblSentTitle);
            this.pnlSentCard.Location = new System.Drawing.Point(549, 101);
            this.pnlSentCard.Name = "pnlSentCard";
            this.pnlSentCard.Size = new System.Drawing.Size(209, 85);
            this.pnlSentCard.TabIndex = 3;
            // 
            // lblSentValue
            // 
            this.lblSentValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSentValue.Font = new System.Drawing.Font("Cairo", 20F, System.Drawing.FontStyle.Bold);
            this.lblSentValue.ForeColor = System.Drawing.Color.Green;
            this.lblSentValue.Location = new System.Drawing.Point(0, 32);
            this.lblSentValue.Name = "lblSentValue";
            this.lblSentValue.Size = new System.Drawing.Size(207, 51);
            this.lblSentValue.TabIndex = 0;
            this.lblSentValue.Text = "0";
            this.lblSentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSentTitle
            // 
            this.lblSentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSentTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSentTitle.Name = "lblSentTitle";
            this.lblSentTitle.Size = new System.Drawing.Size(207, 32);
            this.lblSentTitle.TabIndex = 1;
            this.lblSentTitle.Text = "المرسل إلى n8n اليوم";
            this.lblSentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTodayPendingCard
            // 
            this.pnlTodayPendingCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlTodayPendingCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTodayPendingCard.Controls.Add(this.lblTodayPendingValue);
            this.pnlTodayPendingCard.Controls.Add(this.lblTodayPendingTitle);
            this.pnlTodayPendingCard.Location = new System.Drawing.Point(282, 101);
            this.pnlTodayPendingCard.Name = "pnlTodayPendingCard";
            this.pnlTodayPendingCard.Size = new System.Drawing.Size(209, 85);
            this.pnlTodayPendingCard.TabIndex = 4;
            // 
            // lblTodayPendingValue
            // 
            this.lblTodayPendingValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTodayPendingValue.Font = new System.Drawing.Font("Cairo", 20F, System.Drawing.FontStyle.Bold);
            this.lblTodayPendingValue.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTodayPendingValue.Location = new System.Drawing.Point(0, 32);
            this.lblTodayPendingValue.Name = "lblTodayPendingValue";
            this.lblTodayPendingValue.Size = new System.Drawing.Size(207, 51);
            this.lblTodayPendingValue.TabIndex = 0;
            this.lblTodayPendingValue.Text = "0";
            this.lblTodayPendingValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTodayPendingTitle
            // 
            this.lblTodayPendingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTodayPendingTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTodayPendingTitle.Name = "lblTodayPendingTitle";
            this.lblTodayPendingTitle.Size = new System.Drawing.Size(207, 32);
            this.lblTodayPendingTitle.TabIndex = 1;
            this.lblTodayPendingTitle.Text = "المعلق اليوم";
            this.lblTodayPendingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLastPunchCard
            // 
            this.pnlLastPunchCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlLastPunchCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLastPunchCard.Controls.Add(this.lblLastPunchValue);
            this.pnlLastPunchCard.Controls.Add(this.lblLastPunchTitle);
            this.pnlLastPunchCard.Location = new System.Drawing.Point(15, 101);
            this.pnlLastPunchCard.Name = "pnlLastPunchCard";
            this.pnlLastPunchCard.Size = new System.Drawing.Size(209, 85);
            this.pnlLastPunchCard.TabIndex = 5;
            // 
            // lblLastPunchValue
            // 
            this.lblLastPunchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastPunchValue.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.lblLastPunchValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.lblLastPunchValue.Location = new System.Drawing.Point(0, 32);
            this.lblLastPunchValue.Name = "lblLastPunchValue";
            this.lblLastPunchValue.Size = new System.Drawing.Size(207, 51);
            this.lblLastPunchValue.TabIndex = 0;
            this.lblLastPunchValue.Text = "--";
            this.lblLastPunchValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastPunchTitle
            // 
            this.lblLastPunchTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLastPunchTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLastPunchTitle.Name = "lblLastPunchTitle";
            this.lblLastPunchTitle.Size = new System.Drawing.Size(207, 32);
            this.lblLastPunchTitle.TabIndex = 1;
            this.lblLastPunchTitle.Text = "آخر بصمة اليوم";
            this.lblLastPunchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTableHeader
            // 
            this.pnlTableHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTableHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlTableHeader.Controls.Add(this.lblTodayStatus);
            this.pnlTableHeader.Location = new System.Drawing.Point(21, 405);
            this.pnlTableHeader.Name = "pnlTableHeader";
            this.pnlTableHeader.Size = new System.Drawing.Size(779, 45);
            this.pnlTableHeader.TabIndex = 2;
            // 
            // lblTodayStatus
            // 
            this.lblTodayStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTodayStatus.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblTodayStatus.Location = new System.Drawing.Point(0, 0);
            this.lblTodayStatus.Name = "lblTodayStatus";
            this.lblTodayStatus.Size = new System.Drawing.Size(779, 45);
            this.lblTodayStatus.TabIndex = 0;
            this.lblTodayStatus.Text = "البصمات المسجلة اليوم";
            this.lblTodayStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvToday
            // 
            this.dgvToday.AllowUserToAddRows = false;
            this.dgvToday.AllowUserToDeleteRows = false;
            this.dgvToday.AllowUserToResizeRows = false;
            this.dgvToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvToday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToday.BackgroundColor = System.Drawing.Color.White;
            this.dgvToday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvToday.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvToday.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cairo", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvToday.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvToday.ColumnHeadersHeight = 40;
            this.dgvToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvToday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFingerprintId,
            this.colBranch,
            this.colDevice,
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
            this.dgvToday.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvToday.EnableHeadersVisualStyles = false;
            this.dgvToday.Location = new System.Drawing.Point(21, 450);
            this.dgvToday.MultiSelect = false;
            this.dgvToday.Name = "dgvToday";
            this.dgvToday.ReadOnly = true;
            this.dgvToday.RowHeadersVisible = false;
            this.dgvToday.RowTemplate.Height = 36;
            this.dgvToday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToday.Size = new System.Drawing.Size(779, 240);
            this.dgvToday.TabIndex = 1;
            // 
            // colFingerprintId
            // 
            this.colFingerprintId.HeaderText = "رقم البصمة";
            this.colFingerprintId.Name = "colFingerprintId";
            this.colFingerprintId.ReadOnly = true;
            // 
            // colBranch
            // 
            this.colBranch.HeaderText = "رمز الفرع";
            this.colBranch.Name = "colBranch";
            this.colBranch.ReadOnly = true;
            // 
            // colDevice
            // 
            this.colDevice.HeaderText = "الجهاز";
            this.colDevice.Name = "colDevice";
            this.colDevice.ReadOnly = true;
            // 
            // colFirstPunch
            // 
            this.colFirstPunch.HeaderText = "أول بصمة اليوم";
            this.colFirstPunch.Name = "colFirstPunch";
            this.colFirstPunch.ReadOnly = true;
            // 
            // colLastPunch
            // 
            this.colLastPunch.HeaderText = "آخر بصمة اليوم";
            this.colLastPunch.Name = "colLastPunch";
            this.colLastPunch.ReadOnly = true;
            // 
            // colPunchCount
            // 
            this.colPunchCount.HeaderText = "عدد البصمات";
            this.colPunchCount.Name = "colPunchCount";
            this.colPunchCount.ReadOnly = true;
            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlActions.Controls.Add(this.btnPullNow);
            this.pnlActions.Controls.Add(this.btnTodayStatistics);
            this.pnlActions.Controls.Add(this.btnAttendanceLogs);
            this.pnlActions.Controls.Add(this.btnDevices);
            this.pnlActions.Controls.Add(this.btnSettings);
            this.pnlActions.Controls.Add(this.btnRetryPending);
            this.pnlActions.Location = new System.Drawing.Point(21, 705);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(779, 65);
            this.pnlActions.TabIndex = 0;
            // 
            // btnPullNow
            // 
            this.btnPullNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnPullNow.FlatAppearance.BorderSize = 0;
            this.btnPullNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPullNow.ForeColor = System.Drawing.Color.White;
            this.btnPullNow.Location = new System.Drawing.Point(650, 13);
            this.btnPullNow.Name = "btnPullNow";
            this.btnPullNow.Size = new System.Drawing.Size(113, 40);
            this.btnPullNow.TabIndex = 0;
            this.btnPullNow.Text = "سحب الآن";
            this.btnPullNow.UseVisualStyleBackColor = false;
            this.btnPullNow.Click += new System.EventHandler(this.btnPullNow_Click);
            // 
            // btnTodayStatistics
            // 
            this.btnTodayStatistics.BackColor = System.Drawing.Color.White;
            this.btnTodayStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodayStatistics.Location = new System.Drawing.Point(523, 13);
            this.btnTodayStatistics.Name = "btnTodayStatistics";
            this.btnTodayStatistics.Size = new System.Drawing.Size(113, 40);
            this.btnTodayStatistics.TabIndex = 1;
            this.btnTodayStatistics.Text = "إحصائيات اليوم";
            this.btnTodayStatistics.UseVisualStyleBackColor = false;
            this.btnTodayStatistics.Click += new System.EventHandler(this.btnTodayStatistics_Click);
            // 
            // btnAttendanceLogs
            // 
            this.btnAttendanceLogs.BackColor = System.Drawing.Color.White;
            this.btnAttendanceLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendanceLogs.Location = new System.Drawing.Point(396, 13);
            this.btnAttendanceLogs.Name = "btnAttendanceLogs";
            this.btnAttendanceLogs.Size = new System.Drawing.Size(113, 40);
            this.btnAttendanceLogs.TabIndex = 2;
            this.btnAttendanceLogs.Text = "سجل الحضور";
            this.btnAttendanceLogs.UseVisualStyleBackColor = false;
            this.btnAttendanceLogs.Click += new System.EventHandler(this.btnAttendanceLogs_Click);
            // 
            // btnDevices
            // 
            this.btnDevices.BackColor = System.Drawing.Color.White;
            this.btnDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevices.Location = new System.Drawing.Point(269, 13);
            this.btnDevices.Name = "btnDevices";
            this.btnDevices.Size = new System.Drawing.Size(113, 40);
            this.btnDevices.TabIndex = 2;
            this.btnDevices.Text = "إدارة الأجهزة";
            this.btnDevices.UseVisualStyleBackColor = false;
            this.btnDevices.Click += new System.EventHandler(this.btnDevices_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(142, 13);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(113, 40);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "الإعدادات";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRetryPending
            // 
            this.btnRetryPending.BackColor = System.Drawing.Color.White;
            this.btnRetryPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetryPending.Location = new System.Drawing.Point(15, 13);
            this.btnRetryPending.Name = "btnRetryPending";
            this.btnRetryPending.Size = new System.Drawing.Size(113, 40);
            this.btnRetryPending.TabIndex = 4;
            this.btnRetryPending.Text = "إعادة إرسال المعلق";
            this.btnRetryPending.UseVisualStyleBackColor = false;
            this.btnRetryPending.Click += new System.EventHandler(this.btnRetryPending_Click);
            // 
            // progressBar_PullStatus
            // 
            this.progressBar_PullStatus.Location = new System.Drawing.Point(21, 776);
            this.progressBar_PullStatus.Name = "progressBar_PullStatus";
            this.progressBar_PullStatus.Size = new System.Drawing.Size(779, 11);
            this.progressBar_PullStatus.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(820, 790);
            this.Controls.Add(this.progressBar_PullStatus);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.dgvToday);
            this.Controls.Add(this.pnlTableHeader);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlSystemStatus);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Cairo", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Collector";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSystemStatus.ResumeLayout(false);
            this.pnlInternetStatus.ResumeLayout(false);
            this.pnlN8nStatus.ResumeLayout(false);
            this.pnlPendingStatus.ResumeLayout(false);
            this.pnlDevicesStatus.ResumeLayout(false);
            this.pnlCards.ResumeLayout(false);
            this.pnlPunchesCard.ResumeLayout(false);
            this.pnlEmployeesCard.ResumeLayout(false);
            this.pnlTodayDevicesCard.ResumeLayout(false);
            this.pnlSentCard.ResumeLayout(false);
            this.pnlTodayPendingCard.ResumeLayout(false);
            this.pnlLastPunchCard.ResumeLayout(false);
            this.pnlTableHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvToday)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel pnlSystemStatus;

        private System.Windows.Forms.Panel pnlInternetStatus;
        private System.Windows.Forms.Label lblInternetTitle;
        private System.Windows.Forms.Label lblInternetStatus;

        private System.Windows.Forms.Panel pnlN8nStatus;
        private System.Windows.Forms.Label lblN8nTitle;
        private System.Windows.Forms.Label lblN8nStatus;

        private System.Windows.Forms.Panel pnlPendingStatus;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Label lblPendingValue;

        private System.Windows.Forms.Panel pnlDevicesStatus;
        private System.Windows.Forms.Label lblDevicesTitle;
        private System.Windows.Forms.Label lblDevicesStatus;

        private System.Windows.Forms.Panel pnlCards;

        private System.Windows.Forms.Panel pnlPunchesCard;
        private System.Windows.Forms.Label lblPunchesTitle;
        private System.Windows.Forms.Label lblPunchesValue;

        private System.Windows.Forms.Panel pnlEmployeesCard;
        private System.Windows.Forms.Label lblEmployeesTitle;
        private System.Windows.Forms.Label lblEmployeesValue;

        private System.Windows.Forms.Panel pnlTodayDevicesCard;
        private System.Windows.Forms.Label lblTodayDevicesTitle;
        private System.Windows.Forms.Label lblTodayDevicesValue;

        private System.Windows.Forms.Panel pnlSentCard;
        private System.Windows.Forms.Label lblSentTitle;
        private System.Windows.Forms.Label lblSentValue;

        private System.Windows.Forms.Panel pnlTodayPendingCard;
        private System.Windows.Forms.Label lblTodayPendingTitle;
        private System.Windows.Forms.Label lblTodayPendingValue;

        private System.Windows.Forms.Panel pnlLastPunchCard;
        private System.Windows.Forms.Label lblLastPunchTitle;
        private System.Windows.Forms.Label lblLastPunchValue;

        private System.Windows.Forms.Panel pnlTableHeader;
        private System.Windows.Forms.Label lblTodayStatus;

        private System.Windows.Forms.DataGridView dgvToday;

        private System.Windows.Forms.DataGridViewTextBoxColumn colFingerprintId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstPunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastPunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPunchCount;

        private System.Windows.Forms.Panel pnlActions;

        private System.Windows.Forms.Button btnPullNow;
        private System.Windows.Forms.Button btnTodayStatistics;
        private System.Windows.Forms.Button btnDevices;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnRetryPending;
        private System.Windows.Forms.ProgressBar progressBar_PullStatus;
        private System.Windows.Forms.Button btnAttendanceLogs;
    }
}