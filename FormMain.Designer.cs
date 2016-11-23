namespace lorakon
{
    partial class FormSampleInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSampleInput));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbSIdent = new System.Windows.Forms.TextBox();
            this.tbSTitle = new System.Windows.Forms.TextBox();
            this.panelSampleQuant = new System.Windows.Forms.Panel();
            this.tbSQuantErr = new System.Windows.Forms.TextBox();
            this.tbSQuant = new System.Windows.Forms.TextBox();
            this.cboxLocation = new System.Windows.Forms.ComboBox();
            this.tbSLoctn = new System.Windows.Forms.TextBox();
            this.panelCoords = new System.Windows.Forms.Panel();
            this.tbAltitude = new System.Windows.Forms.TextBox();
            this.tbLongitude = new System.Windows.Forms.TextBox();
            this.tbLatitude = new System.Windows.Forms.TextBox();
            this.lblCommunity = new System.Windows.Forms.Label();
            this.cboxCommunity = new System.Windows.Forms.ComboBox();
            this.panelReferenceDate = new System.Windows.Forms.Panel();
            this.dtpSTime = new System.Windows.Forms.DateTimePicker();
            this.dtpSDate = new System.Windows.Forms.DateTimePicker();
            this.panelError = new System.Windows.Forms.Panel();
            this.tbSSysterr = new System.Windows.Forms.TextBox();
            this.tbSSyserr = new System.Windows.Forms.TextBox();
            this.lblSysErrSystErr = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lblSampleComponent = new System.Windows.Forms.Label();
            this.panelSampleType = new System.Windows.Forms.Panel();
            this.cboxSampleType = new System.Windows.Forms.ComboBox();
            this.panelUnitGeom = new System.Windows.Forms.Panel();
            this.cboxSGeomtry = new System.Windows.Forms.ComboBox();
            this.cboxSUnits = new System.Windows.Forms.ComboBox();
            this.panelLab = new System.Windows.Forms.Panel();
            this.tbScollName = new System.Windows.Forms.TextBox();
            this.tbLab = new System.Windows.Forms.TextBox();
            this.cboxComponent = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSampleID = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLabOperator = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSampleType = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.lblQuantityQuantErr = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.lblQuantityUnitGeometry = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.lblRefDate = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblCoords = new System.Windows.Forms.Label();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCoordsClear = new System.Windows.Forms.Button();
            this.btnBrowseSampleType = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnImportSampReg = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.panelSampleQuant.SuspendLayout();
            this.panelCoords.SuspendLayout();
            this.panelReferenceDate.SuspendLayout();
            this.panelError.SuspendLayout();
            this.panelSampleType.SuspendLayout();
            this.panelUnitGeom.SuspendLayout();
            this.panelLab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tools.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnCancel.Location = new System.Drawing.Point(543, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 32);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Avbryt";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnOk.Location = new System.Drawing.Point(667, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(117, 32);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutMain.Controls.Add(this.tbSIdent, 1, 2);
            this.tableLayoutMain.Controls.Add(this.tbSTitle, 1, 1);
            this.tableLayoutMain.Controls.Add(this.panelSampleQuant, 1, 9);
            this.tableLayoutMain.Controls.Add(this.cboxLocation, 0, 7);
            this.tableLayoutMain.Controls.Add(this.tbSLoctn, 1, 7);
            this.tableLayoutMain.Controls.Add(this.panelCoords, 1, 6);
            this.tableLayoutMain.Controls.Add(this.lblCommunity, 0, 5);
            this.tableLayoutMain.Controls.Add(this.cboxCommunity, 1, 5);
            this.tableLayoutMain.Controls.Add(this.panelReferenceDate, 1, 11);
            this.tableLayoutMain.Controls.Add(this.panelError, 1, 13);
            this.tableLayoutMain.Controls.Add(this.lblSysErrSystErr, 0, 13);
            this.tableLayoutMain.Controls.Add(this.label9, 0, 14);
            this.tableLayoutMain.Controls.Add(this.tbComment, 1, 14);
            this.tableLayoutMain.Controls.Add(this.lblSampleComponent, 0, 4);
            this.tableLayoutMain.Controls.Add(this.panelSampleType, 1, 3);
            this.tableLayoutMain.Controls.Add(this.panelUnitGeom, 1, 10);
            this.tableLayoutMain.Controls.Add(this.panelLab, 1, 0);
            this.tableLayoutMain.Controls.Add(this.cboxComponent, 1, 4);
            this.tableLayoutMain.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutMain.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutMain.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutMain.Controls.Add(this.panel5, 0, 9);
            this.tableLayoutMain.Controls.Add(this.panel6, 0, 10);
            this.tableLayoutMain.Controls.Add(this.panel7, 0, 11);
            this.tableLayoutMain.Controls.Add(this.lblProject, 0, 1);
            this.tableLayoutMain.Controls.Add(this.lblCoords, 0, 6);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 16;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.Size = new System.Drawing.Size(784, 488);
            this.tableLayoutMain.TabIndex = 1;
            // 
            // tbSIdent
            // 
            this.tbSIdent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSIdent.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tbSIdent.Location = new System.Drawing.Point(243, 67);
            this.tbSIdent.MaxLength = 16;
            this.tbSIdent.Name = "tbSIdent";
            this.tbSIdent.Size = new System.Drawing.Size(538, 23);
            this.tbSIdent.TabIndex = 3;
            // 
            // tbSTitle
            // 
            this.tbSTitle.BackColor = System.Drawing.SystemColors.Window;
            this.tbSTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSTitle.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tbSTitle.Location = new System.Drawing.Point(243, 35);
            this.tbSTitle.MaxLength = 64;
            this.tbSTitle.Name = "tbSTitle";
            this.tbSTitle.Size = new System.Drawing.Size(538, 23);
            this.tbSTitle.TabIndex = 2;
            // 
            // panelSampleQuant
            // 
            this.panelSampleQuant.Controls.Add(this.tbSQuantErr);
            this.panelSampleQuant.Controls.Add(this.tbSQuant);
            this.panelSampleQuant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSampleQuant.Location = new System.Drawing.Point(243, 279);
            this.panelSampleQuant.Name = "panelSampleQuant";
            this.panelSampleQuant.Size = new System.Drawing.Size(538, 26);
            this.panelSampleQuant.TabIndex = 11;
            this.panelSampleQuant.TabStop = true;
            // 
            // tbSQuantErr
            // 
            this.tbSQuantErr.BackColor = System.Drawing.SystemColors.Window;
            this.tbSQuantErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSQuantErr.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tbSQuantErr.Location = new System.Drawing.Point(246, 0);
            this.tbSQuantErr.MaxLength = 16;
            this.tbSQuantErr.Name = "tbSQuantErr";
            this.tbSQuantErr.Size = new System.Drawing.Size(292, 23);
            this.tbSQuantErr.TabIndex = 1;
            // 
            // tbSQuant
            // 
            this.tbSQuant.BackColor = System.Drawing.SystemColors.Window;
            this.tbSQuant.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSQuant.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tbSQuant.Location = new System.Drawing.Point(0, 0);
            this.tbSQuant.MaxLength = 16;
            this.tbSQuant.Name = "tbSQuant";
            this.tbSQuant.Size = new System.Drawing.Size(246, 23);
            this.tbSQuant.TabIndex = 0;
            // 
            // cboxLocation
            // 
            this.cboxLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLocation.DropDownWidth = 300;
            this.cboxLocation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxLocation.FormattingEnabled = true;
            this.cboxLocation.Location = new System.Drawing.Point(3, 227);
            this.cboxLocation.MaxLength = 255;
            this.cboxLocation.Name = "cboxLocation";
            this.cboxLocation.Size = new System.Drawing.Size(234, 23);
            this.cboxLocation.TabIndex = 9;
            this.cboxLocation.SelectedIndexChanged += new System.EventHandler(this.cboxLocation_SelectedIndexChanged);
            // 
            // tbSLoctn
            // 
            this.tbSLoctn.BackColor = System.Drawing.SystemColors.Window;
            this.tbSLoctn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSLoctn.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tbSLoctn.Location = new System.Drawing.Point(243, 227);
            this.tbSLoctn.MaxLength = 78;
            this.tbSLoctn.Name = "tbSLoctn";
            this.tbSLoctn.Size = new System.Drawing.Size(538, 23);
            this.tbSLoctn.TabIndex = 10;
            // 
            // panelCoords
            // 
            this.panelCoords.Controls.Add(this.tbAltitude);
            this.panelCoords.Controls.Add(this.tbLongitude);
            this.panelCoords.Controls.Add(this.tbLatitude);
            this.panelCoords.Controls.Add(this.btnCoordsClear);
            this.panelCoords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCoords.Location = new System.Drawing.Point(243, 195);
            this.panelCoords.Name = "panelCoords";
            this.panelCoords.Size = new System.Drawing.Size(538, 26);
            this.panelCoords.TabIndex = 8;
            // 
            // tbAltitude
            // 
            this.tbAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAltitude.Location = new System.Drawing.Point(346, 0);
            this.tbAltitude.MaxLength = 16;
            this.tbAltitude.Name = "tbAltitude";
            this.tbAltitude.Size = new System.Drawing.Size(166, 23);
            this.tbAltitude.TabIndex = 2;
            // 
            // tbLongitude
            // 
            this.tbLongitude.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbLongitude.Location = new System.Drawing.Point(173, 0);
            this.tbLongitude.MaxLength = 16;
            this.tbLongitude.Name = "tbLongitude";
            this.tbLongitude.Size = new System.Drawing.Size(173, 23);
            this.tbLongitude.TabIndex = 1;
            // 
            // tbLatitude
            // 
            this.tbLatitude.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbLatitude.Location = new System.Drawing.Point(0, 0);
            this.tbLatitude.MaxLength = 16;
            this.tbLatitude.Name = "tbLatitude";
            this.tbLatitude.Size = new System.Drawing.Size(173, 23);
            this.tbLatitude.TabIndex = 0;
            // 
            // lblCommunity
            // 
            this.lblCommunity.AutoSize = true;
            this.lblCommunity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommunity.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblCommunity.Location = new System.Drawing.Point(3, 160);
            this.lblCommunity.Name = "lblCommunity";
            this.lblCommunity.Size = new System.Drawing.Size(234, 32);
            this.lblCommunity.TabIndex = 32;
            this.lblCommunity.Text = "Kommune / Fylke";
            this.lblCommunity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboxCommunity
            // 
            this.cboxCommunity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboxCommunity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboxCommunity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxCommunity.FormattingEnabled = true;
            this.cboxCommunity.Location = new System.Drawing.Point(243, 163);
            this.cboxCommunity.MaxLength = 255;
            this.cboxCommunity.Name = "cboxCommunity";
            this.cboxCommunity.Size = new System.Drawing.Size(538, 24);
            this.cboxCommunity.Sorted = true;
            this.cboxCommunity.TabIndex = 6;
            this.cboxCommunity.Leave += new System.EventHandler(this.cboxCommunity_Leave);
            // 
            // panelReferenceDate
            // 
            this.panelReferenceDate.Controls.Add(this.dtpSTime);
            this.panelReferenceDate.Controls.Add(this.dtpSDate);
            this.panelReferenceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReferenceDate.Location = new System.Drawing.Point(243, 343);
            this.panelReferenceDate.Name = "panelReferenceDate";
            this.panelReferenceDate.Size = new System.Drawing.Size(538, 26);
            this.panelReferenceDate.TabIndex = 14;
            this.panelReferenceDate.TabStop = true;
            // 
            // dtpSTime
            // 
            this.dtpSTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpSTime.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.dtpSTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSTime.Location = new System.Drawing.Point(246, 0);
            this.dtpSTime.Name = "dtpSTime";
            this.dtpSTime.ShowUpDown = true;
            this.dtpSTime.Size = new System.Drawing.Size(292, 23);
            this.dtpSTime.TabIndex = 1;
            // 
            // dtpSDate
            // 
            this.dtpSDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpSDate.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.dtpSDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSDate.Location = new System.Drawing.Point(0, 0);
            this.dtpSDate.Name = "dtpSDate";
            this.dtpSDate.Size = new System.Drawing.Size(246, 23);
            this.dtpSDate.TabIndex = 0;
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.tbSSysterr);
            this.panelError.Controls.Add(this.tbSSyserr);
            this.panelError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelError.Location = new System.Drawing.Point(243, 395);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(538, 26);
            this.panelError.TabIndex = 16;
            this.panelError.TabStop = true;
            // 
            // tbSSysterr
            // 
            this.tbSSysterr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSSysterr.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tbSSysterr.Location = new System.Drawing.Point(246, 0);
            this.tbSSysterr.MaxLength = 8;
            this.tbSSysterr.Name = "tbSSysterr";
            this.tbSSysterr.Size = new System.Drawing.Size(292, 23);
            this.tbSSysterr.TabIndex = 1;
            // 
            // tbSSyserr
            // 
            this.tbSSyserr.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSSyserr.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tbSSyserr.Location = new System.Drawing.Point(0, 0);
            this.tbSSyserr.MaxLength = 8;
            this.tbSSyserr.Name = "tbSSyserr";
            this.tbSSyserr.Size = new System.Drawing.Size(246, 23);
            this.tbSSyserr.TabIndex = 0;
            // 
            // lblSysErrSystErr
            // 
            this.lblSysErrSystErr.AutoSize = true;
            this.lblSysErrSystErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSysErrSystErr.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblSysErrSystErr.Location = new System.Drawing.Point(3, 392);
            this.lblSysErrSystErr.Name = "lblSysErrSystErr";
            this.lblSysErrSystErr.Size = new System.Drawing.Size(234, 32);
            this.lblSysErrSystErr.TabIndex = 17;
            this.lblSysErrSystErr.Text = "Tilf. / Syst. Feil (%)";
            this.lblSysErrSystErr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Arial", 9.5F);
            this.label9.Location = new System.Drawing.Point(3, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(234, 32);
            this.label9.TabIndex = 37;
            this.label9.Text = "Kommentar";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbComment
            // 
            this.tbComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbComment.Location = new System.Drawing.Point(243, 427);
            this.tbComment.MaxLength = 78;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(538, 23);
            this.tbComment.TabIndex = 17;
            // 
            // lblSampleComponent
            // 
            this.lblSampleComponent.AutoSize = true;
            this.lblSampleComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSampleComponent.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblSampleComponent.Location = new System.Drawing.Point(3, 128);
            this.lblSampleComponent.Name = "lblSampleComponent";
            this.lblSampleComponent.Size = new System.Drawing.Size(234, 32);
            this.lblSampleComponent.TabIndex = 39;
            this.lblSampleComponent.Text = "Prøve komponent";
            this.lblSampleComponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSampleType
            // 
            this.panelSampleType.Controls.Add(this.cboxSampleType);
            this.panelSampleType.Controls.Add(this.btnBrowseSampleType);
            this.panelSampleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSampleType.Location = new System.Drawing.Point(243, 99);
            this.panelSampleType.Name = "panelSampleType";
            this.panelSampleType.Size = new System.Drawing.Size(538, 26);
            this.panelSampleType.TabIndex = 4;
            // 
            // cboxSampleType
            // 
            this.cboxSampleType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboxSampleType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxSampleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSampleType.FormattingEnabled = true;
            this.cboxSampleType.Location = new System.Drawing.Point(0, 0);
            this.cboxSampleType.MaxLength = 255;
            this.cboxSampleType.Name = "cboxSampleType";
            this.cboxSampleType.Size = new System.Drawing.Size(512, 24);
            this.cboxSampleType.Sorted = true;
            this.cboxSampleType.TabIndex = 0;
            this.cboxSampleType.SelectedIndexChanged += new System.EventHandler(this.cboxSampleType_SelectedIndexChanged);
            this.cboxSampleType.Leave += new System.EventHandler(this.cboxSampleType_Leave);
            // 
            // panelUnitGeom
            // 
            this.panelUnitGeom.Controls.Add(this.cboxSGeomtry);
            this.panelUnitGeom.Controls.Add(this.cboxSUnits);
            this.panelUnitGeom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnitGeom.Location = new System.Drawing.Point(243, 311);
            this.panelUnitGeom.Name = "panelUnitGeom";
            this.panelUnitGeom.Size = new System.Drawing.Size(538, 26);
            this.panelUnitGeom.TabIndex = 12;
            // 
            // cboxSGeomtry
            // 
            this.cboxSGeomtry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSGeomtry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSGeomtry.FormattingEnabled = true;
            this.cboxSGeomtry.Location = new System.Drawing.Point(246, 0);
            this.cboxSGeomtry.MaxLength = 16;
            this.cboxSGeomtry.Name = "cboxSGeomtry";
            this.cboxSGeomtry.Size = new System.Drawing.Size(292, 24);
            this.cboxSGeomtry.Sorted = true;
            this.cboxSGeomtry.TabIndex = 1;
            // 
            // cboxSUnits
            // 
            this.cboxSUnits.BackColor = System.Drawing.SystemColors.Window;
            this.cboxSUnits.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboxSUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSUnits.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cboxSUnits.FormattingEnabled = true;
            this.cboxSUnits.Items.AddRange(new object[] {
            "Kg",
            "g",
            "L"});
            this.cboxSUnits.Location = new System.Drawing.Point(0, 0);
            this.cboxSUnits.MaxLength = 16;
            this.cboxSUnits.Name = "cboxSUnits";
            this.cboxSUnits.Size = new System.Drawing.Size(246, 24);
            this.cboxSUnits.TabIndex = 0;
            // 
            // panelLab
            // 
            this.panelLab.Controls.Add(this.tbScollName);
            this.panelLab.Controls.Add(this.tbLab);
            this.panelLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLab.Location = new System.Drawing.Point(243, 3);
            this.panelLab.Name = "panelLab";
            this.panelLab.Size = new System.Drawing.Size(538, 26);
            this.panelLab.TabIndex = 0;
            // 
            // tbScollName
            // 
            this.tbScollName.BackColor = System.Drawing.SystemColors.Window;
            this.tbScollName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbScollName.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tbScollName.Location = new System.Drawing.Point(246, 0);
            this.tbScollName.MaxLength = 24;
            this.tbScollName.Name = "tbScollName";
            this.tbScollName.Size = new System.Drawing.Size(292, 23);
            this.tbScollName.TabIndex = 1;
            // 
            // tbLab
            // 
            this.tbLab.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbLab.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLab.Location = new System.Drawing.Point(0, 0);
            this.tbLab.MaxLength = 16;
            this.tbLab.Name = "tbLab";
            this.tbLab.Size = new System.Drawing.Size(246, 22);
            this.tbLab.TabIndex = 0;
            // 
            // cboxComponent
            // 
            this.cboxComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxComponent.FormattingEnabled = true;
            this.cboxComponent.Location = new System.Drawing.Point(243, 131);
            this.cboxComponent.MaxLength = 255;
            this.cboxComponent.Name = "cboxComponent";
            this.cboxComponent.Size = new System.Drawing.Size(538, 24);
            this.cboxComponent.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblSampleID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 26);
            this.panel2.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(56, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(15, 22);
            this.label4.TabIndex = 42;
            this.label4.Text = "*";
            // 
            // lblSampleID
            // 
            this.lblSampleID.AutoSize = true;
            this.lblSampleID.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSampleID.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblSampleID.Location = new System.Drawing.Point(0, 0);
            this.lblSampleID.Name = "lblSampleID";
            this.lblSampleID.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblSampleID.Size = new System.Drawing.Size(56, 19);
            this.lblSampleID.TabIndex = 41;
            this.lblSampleID.Text = "Prøve ID";
            this.lblSampleID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblLabOperator);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 26);
            this.panel3.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(145, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(15, 22);
            this.label5.TabIndex = 24;
            this.label5.Text = "*";
            // 
            // lblLabOperator
            // 
            this.lblLabOperator.AutoSize = true;
            this.lblLabOperator.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLabOperator.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabOperator.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLabOperator.Location = new System.Drawing.Point(0, 0);
            this.lblLabOperator.Name = "lblLabOperator";
            this.lblLabOperator.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblLabOperator.Size = new System.Drawing.Size(145, 19);
            this.lblLabOperator.TabIndex = 23;
            this.lblLabOperator.Text = "Laboratorium / Operatør";
            this.lblLabOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lblSampleType);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 99);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(234, 26);
            this.panel4.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(65, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label6.Size = new System.Drawing.Size(15, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "*";
            // 
            // lblSampleType
            // 
            this.lblSampleType.AutoSize = true;
            this.lblSampleType.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSampleType.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblSampleType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSampleType.Location = new System.Drawing.Point(0, 0);
            this.lblSampleType.Name = "lblSampleType";
            this.lblSampleType.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblSampleType.Size = new System.Drawing.Size(65, 19);
            this.lblSampleType.TabIndex = 10;
            this.lblSampleType.Text = "Prøvetype";
            this.lblSampleType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.lblQuantityQuantErr);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 279);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(234, 26);
            this.panel5.TabIndex = 45;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(133, 0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label13.Size = new System.Drawing.Size(15, 22);
            this.label13.TabIndex = 15;
            this.label13.Text = "*";
            // 
            // lblQuantityQuantErr
            // 
            this.lblQuantityQuantErr.AutoSize = true;
            this.lblQuantityQuantErr.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQuantityQuantErr.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblQuantityQuantErr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQuantityQuantErr.Location = new System.Drawing.Point(0, 0);
            this.lblQuantityQuantErr.Name = "lblQuantityQuantErr";
            this.lblQuantityQuantErr.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblQuantityQuantErr.Size = new System.Drawing.Size(133, 19);
            this.lblQuantityQuantErr.TabIndex = 14;
            this.lblQuantityQuantErr.Text = "Mengde / Abs. Usikk.";
            this.lblQuantityQuantErr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.lblQuantityUnitGeometry);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 311);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(234, 26);
            this.panel6.TabIndex = 46;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(141, 0);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label15.Size = new System.Drawing.Size(15, 22);
            this.label15.TabIndex = 16;
            this.label15.Text = "*";
            // 
            // lblQuantityUnitGeometry
            // 
            this.lblQuantityUnitGeometry.AutoSize = true;
            this.lblQuantityUnitGeometry.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQuantityUnitGeometry.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblQuantityUnitGeometry.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQuantityUnitGeometry.Location = new System.Drawing.Point(0, 0);
            this.lblQuantityUnitGeometry.Name = "lblQuantityUnitGeometry";
            this.lblQuantityUnitGeometry.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblQuantityUnitGeometry.Size = new System.Drawing.Size(141, 19);
            this.lblQuantityUnitGeometry.TabIndex = 15;
            this.lblQuantityUnitGeometry.Text = "Mengde enhet / Geom.";
            this.lblQuantityUnitGeometry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.lblRefDate);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 343);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(234, 26);
            this.panel7.TabIndex = 47;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(91, 0);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label16.Size = new System.Drawing.Size(15, 22);
            this.label16.TabIndex = 19;
            this.label16.Text = "*";
            // 
            // lblRefDate
            // 
            this.lblRefDate.AutoSize = true;
            this.lblRefDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRefDate.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblRefDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRefDate.Location = new System.Drawing.Point(0, 0);
            this.lblRefDate.Name = "lblRefDate";
            this.lblRefDate.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblRefDate.Size = new System.Drawing.Size(91, 19);
            this.lblRefDate.TabIndex = 18;
            this.lblRefDate.Text = "Referansedato";
            this.lblRefDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProject.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblProject.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProject.Location = new System.Drawing.Point(3, 32);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(56, 32);
            this.lblProject.TabIndex = 9;
            this.lblProject.Text = "Prosjekt";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCoords
            // 
            this.lblCoords.AutoSize = true;
            this.lblCoords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCoords.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblCoords.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCoords.Location = new System.Drawing.Point(3, 192);
            this.lblCoords.Name = "lblCoords";
            this.lblCoords.Size = new System.Drawing.Size(234, 32);
            this.lblCoords.TabIndex = 0;
            this.lblCoords.Text = "Br.grad / Len.grad / MOH";
            this.lblCoords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tools
            // 
            this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(784, 25);
            this.tools.TabIndex = 0;
            this.tools.Text = "toolStrip1";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(0, 545);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(784, 22);
            this.status.SizingGrip = false;
            this.status.TabIndex = 2;
            this.status.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.Font = new System.Drawing.Font("Arial", 9F);
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(86, 17);
            this.statusLabel.Text = "<statusLabel>";
            // 
            // btnCoordsClear
            // 
            this.btnCoordsClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCoordsClear.Image = global::lorakon.Properties.Resources.clear_16;
            this.btnCoordsClear.Location = new System.Drawing.Point(512, 0);
            this.btnCoordsClear.Name = "btnCoordsClear";
            this.btnCoordsClear.Size = new System.Drawing.Size(26, 26);
            this.btnCoordsClear.TabIndex = 3;
            this.btnCoordsClear.UseVisualStyleBackColor = true;
            this.btnCoordsClear.Click += new System.EventHandler(this.linkClearCoords_Click);
            // 
            // btnBrowseSampleType
            // 
            this.btnBrowseSampleType.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseSampleType.Image = global::lorakon.Properties.Resources.tree_16;
            this.btnBrowseSampleType.Location = new System.Drawing.Point(512, 0);
            this.btnBrowseSampleType.Name = "btnBrowseSampleType";
            this.btnBrowseSampleType.Size = new System.Drawing.Size(26, 26);
            this.btnBrowseSampleType.TabIndex = 1;
            this.btnBrowseSampleType.Text = "...";
            this.btnBrowseSampleType.UseVisualStyleBackColor = true;
            this.btnBrowseSampleType.Click += new System.EventHandler(this.btnBrowseSampleType_Click);
            // 
            // btnImport
            // 
            this.btnImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportSampReg});
            this.btnImport.Enabled = false;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(102, 22);
            this.btnImport.Text = "Import fra fil";
            // 
            // btnImportSampReg
            // 
            this.btnImportSampReg.Name = "btnImportSampReg";
            this.btnImportSampReg.Size = new System.Drawing.Size(203, 22);
            this.btnImportSampReg.Text = "Sample registration logg";
            // 
            // FormSampleInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 567);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.status);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSampleInput";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prøveinformasjon";
            this.Load += new System.EventHandler(this.FormSampleInput_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSampleInput_Paint);
            this.Resize += new System.EventHandler(this.FormSampleInput_Resize);
            this.panel1.ResumeLayout(false);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.panelSampleQuant.ResumeLayout(false);
            this.panelSampleQuant.PerformLayout();
            this.panelCoords.ResumeLayout(false);
            this.panelCoords.PerformLayout();
            this.panelReferenceDate.ResumeLayout(false);
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            this.panelSampleType.ResumeLayout(false);
            this.panelUnitGeom.ResumeLayout(false);
            this.panelLab.ResumeLayout(false);
            this.panelLab.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Label lblSampleType;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TextBox tbScollName;
        private System.Windows.Forms.Label lblQuantityQuantErr;
        private System.Windows.Forms.Label lblSysErrSystErr;
        private System.Windows.Forms.Label lblQuantityUnitGeometry;
        private System.Windows.Forms.Label lblRefDate;
        private System.Windows.Forms.TextBox tbSTitle;
        private System.Windows.Forms.TextBox tbSIdent;
        private System.Windows.Forms.TextBox tbSLoctn;
        private System.Windows.Forms.TextBox tbSQuant;
        private System.Windows.Forms.TextBox tbSQuantErr;
        private System.Windows.Forms.ComboBox cboxSUnits;
        private System.Windows.Forms.TextBox tbSSyserr;
        private System.Windows.Forms.TextBox tbSSysterr;
        private System.Windows.Forms.Panel panelReferenceDate;
        private System.Windows.Forms.DateTimePicker dtpSTime;
        private System.Windows.Forms.DateTimePicker dtpSDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.Panel panelSampleQuant;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ComboBox cboxLocation;
        private System.Windows.Forms.ComboBox cboxSGeomtry;
        private System.Windows.Forms.ToolStripDropDownButton btnImport;
        private System.Windows.Forms.ToolStripMenuItem btnImportSampReg;
        private System.Windows.Forms.Label lblLabOperator;
        private System.Windows.Forms.TextBox tbLab;
        private System.Windows.Forms.Panel panelCoords;
        private System.Windows.Forms.TextBox tbLongitude;
        private System.Windows.Forms.TextBox tbLatitude;
        private System.Windows.Forms.ComboBox cboxCommunity;
        private System.Windows.Forms.Label lblCommunity;
        private System.Windows.Forms.ComboBox cboxSampleType;
        private System.Windows.Forms.TextBox tbAltitude;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lblSampleComponent;
        private System.Windows.Forms.ComboBox cboxComponent;
        private System.Windows.Forms.Panel panelSampleType;
        private System.Windows.Forms.Button btnBrowseSampleType;
        private System.Windows.Forms.Panel panelUnitGeom;
        private System.Windows.Forms.Label lblCoords;
        private System.Windows.Forms.Panel panelLab;
        private System.Windows.Forms.Label lblSampleID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnCoordsClear;
    }
}

