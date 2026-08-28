namespace AttendanceCollector
{
    partial class DevicesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevicesForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.button_close = new System.Windows.Forms.Button();
            this.lblHeaderDescription = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlDeviceCard = new System.Windows.Forms.Panel();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.txtDeviceCode = new System.Windows.Forms.TextBox();
            this.numPassword = new System.Windows.Forms.TextBox();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.lblDeviceCode = new System.Windows.Forms.Label();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.cmbConnectionType = new System.Windows.Forms.ComboBox();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlListHeader = new System.Windows.Forms.Panel();
            this.lblDevicesCount = new System.Windows.Forms.Label();
            this.lblDevicesList = new System.Windows.Forms.Label();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConnectionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlDeviceCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.pnlListHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.pnlHeader.Controls.Add(this.button_close);
            this.pnlHeader.Controls.Add(this.lblHeaderDescription);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(820, 92);
            this.pnlHeader.TabIndex = 0;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.button_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            this.button_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.button_close.Location = new System.Drawing.Point(12, 27);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(55, 38);
            this.button_close.TabIndex = 16;
            this.button_close.Text = "خروج";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // lblHeaderDescription
            // 
            this.lblHeaderDescription.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHeaderDescription.AutoSize = true;
            this.lblHeaderDescription.Font = new System.Drawing.Font("Cairo", 8.5F);
            this.lblHeaderDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(235)))), ((int)(((byte)(226)))));
            this.lblHeaderDescription.Location = new System.Drawing.Point(407, 54);
            this.lblHeaderDescription.Name = "lblHeaderDescription";
            this.lblHeaderDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHeaderDescription.Size = new System.Drawing.Size(385, 23);
            this.lblHeaderDescription.TabIndex = 1;
            this.lblHeaderDescription.Text = "إضافة أجهزة البصمة وتحديد رمز ثابت لكل جهاز والاتصال عبر Local أو Public IP";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(610, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHeaderTitle.Size = new System.Drawing.Size(201, 42);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "إدارة أجهزة البصمة";
            // 
            // pnlDeviceCard
            // 
            this.pnlDeviceCard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlDeviceCard.BackColor = System.Drawing.Color.White;
            this.pnlDeviceCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeviceCard.Controls.Add(this.lblDeviceName);
            this.pnlDeviceCard.Controls.Add(this.txtDeviceCode);
            this.pnlDeviceCard.Controls.Add(this.numPassword);
            this.pnlDeviceCard.Controls.Add(this.txtDeviceName);
            this.pnlDeviceCard.Controls.Add(this.lblDeviceCode);
            this.pnlDeviceCard.Controls.Add(this.lblConnectionType);
            this.pnlDeviceCard.Controls.Add(this.cmbConnectionType);
            this.pnlDeviceCard.Controls.Add(this.lblIPAddress);
            this.pnlDeviceCard.Controls.Add(this.txtIPAddress);
            this.pnlDeviceCard.Controls.Add(this.lblPort);
            this.pnlDeviceCard.Controls.Add(this.numPort);
            this.pnlDeviceCard.Controls.Add(this.lblPassword);
            this.pnlDeviceCard.Controls.Add(this.chkActive);
            this.pnlDeviceCard.Controls.Add(this.btnSave);
            this.pnlDeviceCard.Controls.Add(this.btnTestConnection);
            this.pnlDeviceCard.Controls.Add(this.btnClear);
            this.pnlDeviceCard.Location = new System.Drawing.Point(23, 110);
            this.pnlDeviceCard.Name = "pnlDeviceCard";
            this.pnlDeviceCard.Size = new System.Drawing.Size(775, 286);
            this.pnlDeviceCard.TabIndex = 1;
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblDeviceName.Location = new System.Drawing.Point(680, 18);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDeviceName.Size = new System.Drawing.Size(83, 30);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "اسم الجهاز";
            // 
            // txtDeviceCode
            // 
            this.txtDeviceCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceCode.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceCode.Location = new System.Drawing.Point(223, 48);
            this.txtDeviceCode.Name = "txtDeviceCode";
            this.txtDeviceCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDeviceCode.Size = new System.Drawing.Size(181, 37);
            this.txtDeviceCode.TabIndex = 1;
            // 
            // numPassword
            // 
            this.numPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPassword.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPassword.Location = new System.Drawing.Point(19, 148);
            this.numPassword.Name = "numPassword";
            this.numPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numPassword.Size = new System.Drawing.Size(175, 37);
            this.numPassword.TabIndex = 1;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceName.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceName.Location = new System.Drawing.Point(478, 49);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDeviceName.Size = new System.Drawing.Size(280, 37);
            this.txtDeviceName.TabIndex = 1;
            // 
            // lblDeviceCode
            // 
            this.lblDeviceCode.AutoSize = true;
            this.lblDeviceCode.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblDeviceCode.Location = new System.Drawing.Point(334, 15);
            this.lblDeviceCode.Name = "lblDeviceCode";
            this.lblDeviceCode.Size = new System.Drawing.Size(74, 30);
            this.lblDeviceCode.TabIndex = 2;
            this.lblDeviceCode.Text = "رمز الجهاز";
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblConnectionType.Location = new System.Drawing.Point(93, 18);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(106, 30);
            this.lblConnectionType.TabIndex = 4;
            this.lblConnectionType.Text = "طريقة الاتصال";
            // 
            // cmbConnectionType
            // 
            this.cmbConnectionType.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnectionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbConnectionType.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConnectionType.FormattingEnabled = true;
            this.cmbConnectionType.Items.AddRange(new object[] {
            "Local",
            "Public"});
            this.cmbConnectionType.Location = new System.Drawing.Point(19, 47);
            this.cmbConnectionType.Name = "cmbConnectionType";
            this.cmbConnectionType.Size = new System.Drawing.Size(175, 38);
            this.cmbConnectionType.TabIndex = 5;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblIPAddress.Location = new System.Drawing.Point(664, 113);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(99, 30);
            this.lblIPAddress.TabIndex = 6;
            this.lblIPAddress.Text = "IP / Public IP";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPAddress.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPAddress.Location = new System.Drawing.Point(478, 148);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(280, 37);
            this.txtIPAddress.TabIndex = 7;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblPort.Location = new System.Drawing.Point(357, 113);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(56, 30);
            this.lblPort.TabIndex = 8;
            this.lblPort.Text = "المنفذ";
            // 
            // numPort
            // 
            this.numPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPort.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPort.Location = new System.Drawing.Point(223, 148);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(185, 37);
            this.numPort.TabIndex = 9;
            this.numPort.Value = new decimal(new int[] {
            4370,
            0,
            0,
            0});
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblPassword.Location = new System.Drawing.Point(121, 113);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 30);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "كلمة السر";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.chkActive.Location = new System.Drawing.Point(498, 21);
            this.chkActive.Name = "chkActive";
            this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkActive.Size = new System.Drawing.Size(85, 24);
            this.chkActive.TabIndex = 12;
            this.chkActive.Text = "الجهاز مفعّل";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(478, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(280, 38);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "حفظ \\ تحديث  الجهاز";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnTestConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnTestConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.btnTestConnection.Location = new System.Drawing.Point(223, 231);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(185, 38);
            this.btnTestConnection.TabIndex = 14;
            this.btnTestConnection.Text = "اختبار الاتصال";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnClear.Location = new System.Drawing.Point(19, 231);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(175, 38);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "مسح الحقول";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlListHeader
            // 
            this.pnlListHeader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlListHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.pnlListHeader.Controls.Add(this.lblDevicesCount);
            this.pnlListHeader.Controls.Add(this.lblDevicesList);
            this.pnlListHeader.Location = new System.Drawing.Point(23, 402);
            this.pnlListHeader.Name = "pnlListHeader";
            this.pnlListHeader.Size = new System.Drawing.Size(773, 46);
            this.pnlListHeader.TabIndex = 1;
            // 
            // lblDevicesCount
            // 
            this.lblDevicesCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDevicesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.lblDevicesCount.Location = new System.Drawing.Point(0, 0);
            this.lblDevicesCount.Name = "lblDevicesCount";
            this.lblDevicesCount.Size = new System.Drawing.Size(420, 46);
            this.lblDevicesCount.TabIndex = 0;
            this.lblDevicesCount.Text = "0 جهاز";
            this.lblDevicesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDevicesList
            // 
            this.lblDevicesList.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDevicesList.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblDevicesList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblDevicesList.Location = new System.Drawing.Point(420, 0);
            this.lblDevicesList.Name = "lblDevicesList";
            this.lblDevicesList.Size = new System.Drawing.Size(353, 46);
            this.lblDevicesList.TabIndex = 1;
            this.lblDevicesList.Text = "الأجهزة المسجلة";
            this.lblDevicesList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDevices
            // 
            this.dgvDevices.AllowUserToAddRows = false;
            this.dgvDevices.AllowUserToDeleteRows = false;
            this.dgvDevices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.dgvDevices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDevices.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dgvDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevices.BackgroundColor = System.Drawing.Color.White;
            this.dgvDevices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDevices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDevices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cairo", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDevices.ColumnHeadersHeight = 40;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDeviceName,
            this.colDeviceCode,
            this.colConnectionType,
            this.colIp,
            this.colPort,
            this.colStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cairo", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(239)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevices.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDevices.EnableHeadersVisualStyles = false;
            this.dgvDevices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvDevices.Location = new System.Drawing.Point(28, 460);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.ReadOnly = true;
            this.dgvDevices.RowHeadersVisible = false;
            this.dgvDevices.RowTemplate.Height = 36;
            this.dgvDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevices.Size = new System.Drawing.Size(768, 318);
            this.dgvDevices.TabIndex = 0;
            this.dgvDevices.SelectionChanged += new System.EventHandler(this.dgvDevices_SelectionChanged);
            this.dgvDevices.DoubleClick += new System.EventHandler(this.dgvDevices_DoubleClick);
            // 
            // colId
            // 
            this.colId.FillWeight = 40F;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colDeviceName
            // 
            this.colDeviceName.FillWeight = 130F;
            this.colDeviceName.HeaderText = "اسم الجهاز";
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.ReadOnly = true;
            // 
            // colDeviceCode
            // 
            this.colDeviceCode.FillWeight = 120F;
            this.colDeviceCode.HeaderText = "رمز الجهاز";
            this.colDeviceCode.Name = "colDeviceCode";
            this.colDeviceCode.ReadOnly = true;
            // 
            // colConnectionType
            // 
            this.colConnectionType.FillWeight = 80F;
            this.colConnectionType.HeaderText = "الاتصال";
            this.colConnectionType.Name = "colConnectionType";
            this.colConnectionType.ReadOnly = true;
            // 
            // colIp
            // 
            this.colIp.FillWeight = 120F;
            this.colIp.HeaderText = "IP / Host";
            this.colIp.Name = "colIp";
            this.colIp.ReadOnly = true;
            // 
            // colPort
            // 
            this.colPort.FillWeight = 60F;
            this.colPort.HeaderText = "Port";
            this.colPort.Name = "colPort";
            this.colPort.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 80F;
            this.colStatus.HeaderText = "الحالة";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // DevicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(820, 790);
            this.Controls.Add(this.dgvDevices);
            this.Controls.Add(this.pnlListHeader);
            this.Controls.Add(this.pnlDeviceCard);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Cairo", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DevicesForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة أجهزة البصمة";
            this.Load += new System.EventHandler(this.DevicesForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDeviceCard.ResumeLayout(false);
            this.pnlDeviceCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.pnlListHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderDescription;

        private System.Windows.Forms.Panel pnlDeviceCard;

        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.TextBox txtDeviceName;

        private System.Windows.Forms.Label lblDeviceCode;

        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.ComboBox cmbConnectionType;

        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.TextBox txtIPAddress;

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;

        private System.Windows.Forms.Label lblPassword;

        private System.Windows.Forms.CheckBox chkActive;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.Panel pnlListHeader;
        private System.Windows.Forms.Label lblDevicesList;
        private System.Windows.Forms.Label lblDevicesCount;

        private System.Windows.Forms.DataGridView dgvDevices;

        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConnectionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.TextBox txtDeviceCode;
        private System.Windows.Forms.TextBox numPassword;
        private System.Windows.Forms.Button button_close;
    }
}