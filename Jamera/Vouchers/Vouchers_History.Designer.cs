namespace Jamera.Vouchers
{
    partial class Vouchers_History
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vouchers_History));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.search_btn = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.account_search_check = new DevExpress.XtraEditors.CheckEdit();
            this.by_date_check = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.voucher_type_cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.account_search_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.queryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.from_date_picker = new DevExpress.XtraEditors.DateEdit();
            this.to_date_picker = new DevExpress.XtraEditors.DateEdit();
            this.ref_no_inp = new DevExpress.XtraEditors.TextEdit();
            this.refresh_btn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.list = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.account_search_check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.by_date_check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voucher_type_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.account_search_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_no_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_btn
            // 
            this.search_btn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.search_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.search_btn.Appearance.Options.UseFont = true;
            this.search_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("search_btn.ImageOptions.Image")));
            this.search_btn.Location = new System.Drawing.Point(783, 44);
            this.search_btn.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(110, 35);
            this.search_btn.TabIndex = 6;
            this.search_btn.Text = "Search";
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(787, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 0, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Voucher Type :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(420, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date :";
            // 
            // account_search_check
            // 
            this.account_search_check.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.account_search_check.EnterMoveNextControl = true;
            this.account_search_check.Location = new System.Drawing.Point(414, 12);
            this.account_search_check.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.account_search_check.Name = "account_search_check";
            this.account_search_check.Properties.AllowFocused = false;
            this.account_search_check.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_search_check.Properties.Appearance.Options.UseFont = true;
            this.account_search_check.Properties.Caption = "Account :";
            this.account_search_check.Size = new System.Drawing.Size(82, 22);
            this.account_search_check.TabIndex = 1;
            this.account_search_check.CheckedChanged += new System.EventHandler(this.account_search_check_CheckedChanged);
            // 
            // by_date_check
            // 
            this.by_date_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.by_date_check.EnterMoveNextControl = true;
            this.by_date_check.Location = new System.Drawing.Point(3, 50);
            this.by_date_check.Name = "by_date_check";
            this.by_date_check.Properties.AllowFocused = false;
            this.by_date_check.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_date_check.Properties.Appearance.Options.UseFont = true;
            this.by_date_check.Properties.Caption = "By Date  From :";
            this.by_date_check.Size = new System.Drawing.Size(126, 22);
            this.by_date_check.TabIndex = 4;
            this.by_date_check.CheckedChanged += new System.EventHandler(this.by_date_check_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1177, 83);
            this.panelControl2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.Controls.Add(this.account_search_check, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.voucher_type_cmb, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.account_search_cmb, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.by_date_check, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.from_date_picker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.to_date_picker, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.search_btn, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ref_no_inp, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1177, 83);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // voucher_type_cmb
            // 
            this.voucher_type_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voucher_type_cmb.EditValue = "";
            this.voucher_type_cmb.EnterMoveNextControl = true;
            this.voucher_type_cmb.Location = new System.Drawing.Point(899, 11);
            this.voucher_type_cmb.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.voucher_type_cmb.Name = "voucher_type_cmb";
            this.voucher_type_cmb.Properties.AllowFocused = false;
            this.voucher_type_cmb.Properties.AllowMouseWheel = false;
            this.voucher_type_cmb.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucher_type_cmb.Properties.Appearance.Options.UseFont = true;
            this.voucher_type_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucher_type_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.voucher_type_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucher_type_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.voucher_type_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucher_type_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.voucher_type_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucher_type_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.voucher_type_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.voucher_type_cmb.Properties.Items.AddRange(new object[] {
            "",
            "Journal Voucher",
            "Receipt Voucher",
            "Payment Voucher"});
            this.voucher_type_cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.voucher_type_cmb.Size = new System.Drawing.Size(275, 24);
            this.voucher_type_cmb.TabIndex = 3;
            // 
            // account_search_cmb
            // 
            this.account_search_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.account_search_cmb.EditValue = "";
            this.account_search_cmb.Enabled = false;
            this.account_search_cmb.EnterMoveNextControl = true;
            this.account_search_cmb.Location = new System.Drawing.Point(502, 7);
            this.account_search_cmb.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.account_search_cmb.Name = "account_search_cmb";
            this.account_search_cmb.Properties.AllowFocused = false;
            this.account_search_cmb.Properties.AllowMouseWheel = false;
            this.account_search_cmb.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_search_cmb.Properties.Appearance.Options.UseFont = true;
            this.account_search_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.account_search_cmb.Properties.DataSource = this.queryBindingSource;
            this.account_search_cmb.Properties.DisplayMember = "Name";
            this.account_search_cmb.Properties.NullText = "";
            this.account_search_cmb.Properties.PopupFormSize = new System.Drawing.Size(0, 280);
            this.account_search_cmb.Properties.PopupView = this.gridView2;
            this.account_search_cmb.Properties.ShowFooter = false;
            this.account_search_cmb.Properties.ValueMember = "Code";
            this.account_search_cmb.Size = new System.Drawing.Size(273, 24);
            this.account_search_cmb.TabIndex = 2;
            // 
            // queryBindingSource
            // 
            this.queryBindingSource.DataMember = "Query";
            this.queryBindingSource.DataSource = this.sqlDataSource1;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "JAMERA_CONNECTION";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = "SELECT id as \'Code\',name as \'Name\',phone as \'Phone\',balance as \'Balance\' from acc" +
    "ounts;\r\n\r\n";
            customSqlQuery2.Name = "Query_1";
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            customSqlQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.Row.Options.UseTextOptions = true;
            this.gridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.colName,
            this.colPhone,
            this.colBalance});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowColumnResizing = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsFind.FindDelay = 100;
            this.gridView2.OptionsFind.SearchInPreview = true;
            this.gridView2.OptionsFind.ShowCloseButton = false;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Code";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 169;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 437;
            // 
            // colPhone
            // 
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 2;
            this.colPhone.Width = 271;
            // 
            // colBalance
            // 
            this.colBalance.FieldName = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 3;
            this.colBalance.Width = 291;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ref. No :";
            // 
            // from_date_picker
            // 
            this.from_date_picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.from_date_picker.EditValue = null;
            this.from_date_picker.Enabled = false;
            this.from_date_picker.EnterMoveNextControl = true;
            this.from_date_picker.Location = new System.Drawing.Point(135, 49);
            this.from_date_picker.Name = "from_date_picker";
            this.from_date_picker.Properties.AllowFocused = false;
            this.from_date_picker.Properties.AllowMouseWheel = false;
            this.from_date_picker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date_picker.Properties.Appearance.Options.UseFont = true;
            this.from_date_picker.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date_picker.Properties.AppearanceDropDown.Options.UseFont = true;
            this.from_date_picker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.from_date_picker.Properties.CalendarTimeProperties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.from_date_picker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.from_date_picker.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.from_date_picker.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.from_date_picker.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.from_date_picker.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.from_date_picker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.from_date_picker.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.from_date_picker.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.from_date_picker.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.from_date_picker.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.from_date_picker.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.from_date_picker.Properties.NullDate = new System.DateTime(2019, 9, 29, 10, 1, 37, 635);
            this.from_date_picker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.from_date_picker.Size = new System.Drawing.Size(273, 24);
            this.from_date_picker.TabIndex = 5;
            // 
            // to_date_picker
            // 
            this.to_date_picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.to_date_picker.EditValue = null;
            this.to_date_picker.Enabled = false;
            this.to_date_picker.EnterMoveNextControl = true;
            this.to_date_picker.Location = new System.Drawing.Point(502, 49);
            this.to_date_picker.Name = "to_date_picker";
            this.to_date_picker.Properties.AllowFocused = false;
            this.to_date_picker.Properties.AllowMouseWheel = false;
            this.to_date_picker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date_picker.Properties.Appearance.Options.UseFont = true;
            this.to_date_picker.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date_picker.Properties.AppearanceDropDown.Options.UseFont = true;
            this.to_date_picker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.to_date_picker.Properties.CalendarTimeProperties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.to_date_picker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.to_date_picker.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.to_date_picker.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.to_date_picker.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.to_date_picker.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.to_date_picker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.to_date_picker.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.to_date_picker.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.to_date_picker.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.to_date_picker.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.to_date_picker.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.to_date_picker.Properties.NullDate = new System.DateTime(2019, 9, 29, 10, 1, 37, 635);
            this.to_date_picker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.to_date_picker.Size = new System.Drawing.Size(273, 24);
            this.to_date_picker.TabIndex = 6;
            // 
            // ref_no_inp
            // 
            this.ref_no_inp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ref_no_inp.EnterMoveNextControl = true;
            this.ref_no_inp.Location = new System.Drawing.Point(135, 11);
            this.ref_no_inp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.ref_no_inp.Name = "ref_no_inp";
            this.ref_no_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ref_no_inp.Properties.Appearance.Options.UseFont = true;
            this.ref_no_inp.Size = new System.Drawing.Size(273, 24);
            this.ref_no_inp.TabIndex = 0;
            // 
            // refresh_btn
            // 
            this.refresh_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.refresh_btn.Appearance.Options.UseFont = true;
            this.refresh_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("refresh_btn.ImageOptions.Image")));
            this.refresh_btn.Location = new System.Drawing.Point(1039, 5);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(132, 35);
            this.refresh_btn.TabIndex = 4;
            this.refresh_btn.Text = "Refresh List";
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.list);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 85);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1177, 464);
            this.panelControl4.TabIndex = 2;
            // 
            // list
            // 
            this.list.DataMember = "Query_1";
            this.list.DataSource = this.sqlDataSource1;
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.Location = new System.Drawing.Point(0, 0);
            this.list.MainView = this.gridView1;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(1177, 464);
            this.list.TabIndex = 3;
            this.list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.gridColumn1,
            this.colIssueDate,
            this.colTYPE,
            this.colDebitCode,
            this.colDebitAccount,
            this.colCreditCode,
            this.colCreditAccount,
            this.colDebitDescription,
            this.colCreditDescription,
            this.colAmount});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.list;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 10;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.MinWidth = 80;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Ref.No";
            this.gridColumn1.MinWidth = 100;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 100;
            // 
            // colIssueDate
            // 
            this.colIssueDate.FieldName = "Issue Date";
            this.colIssueDate.MinWidth = 100;
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.Visible = true;
            this.colIssueDate.VisibleIndex = 2;
            this.colIssueDate.Width = 100;
            // 
            // colTYPE
            // 
            this.colTYPE.FieldName = "Type";
            this.colTYPE.MinWidth = 100;
            this.colTYPE.Name = "colTYPE";
            this.colTYPE.Visible = true;
            this.colTYPE.VisibleIndex = 3;
            this.colTYPE.Width = 100;
            // 
            // colDebitCode
            // 
            this.colDebitCode.FieldName = "Debit Code";
            this.colDebitCode.MinWidth = 120;
            this.colDebitCode.Name = "colDebitCode";
            this.colDebitCode.Visible = true;
            this.colDebitCode.VisibleIndex = 4;
            this.colDebitCode.Width = 120;
            // 
            // colDebitAccount
            // 
            this.colDebitAccount.FieldName = "Debit Account";
            this.colDebitAccount.MinWidth = 200;
            this.colDebitAccount.Name = "colDebitAccount";
            this.colDebitAccount.Visible = true;
            this.colDebitAccount.VisibleIndex = 5;
            this.colDebitAccount.Width = 200;
            // 
            // colCreditCode
            // 
            this.colCreditCode.FieldName = "Credit Code";
            this.colCreditCode.MinWidth = 120;
            this.colCreditCode.Name = "colCreditCode";
            this.colCreditCode.Visible = true;
            this.colCreditCode.VisibleIndex = 6;
            this.colCreditCode.Width = 120;
            // 
            // colCreditAccount
            // 
            this.colCreditAccount.FieldName = "Credit Account";
            this.colCreditAccount.MinWidth = 200;
            this.colCreditAccount.Name = "colCreditAccount";
            this.colCreditAccount.Visible = true;
            this.colCreditAccount.VisibleIndex = 7;
            this.colCreditAccount.Width = 200;
            // 
            // colDebitDescription
            // 
            this.colDebitDescription.FieldName = "Debit Description";
            this.colDebitDescription.MinWidth = 140;
            this.colDebitDescription.Name = "colDebitDescription";
            this.colDebitDescription.Visible = true;
            this.colDebitDescription.VisibleIndex = 8;
            this.colDebitDescription.Width = 140;
            // 
            // colCreditDescription
            // 
            this.colCreditDescription.FieldName = "Credit Description";
            this.colCreditDescription.MinWidth = 140;
            this.colCreditDescription.Name = "colCreditDescription";
            this.colCreditDescription.Visible = true;
            this.colCreditDescription.VisibleIndex = 9;
            this.colCreditDescription.Width = 140;
            // 
            // colAmount
            // 
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 140;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 10;
            this.colAmount.Width = 140;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.panelControl3.Appearance.Options.UseFont = true;
            this.panelControl3.Controls.Add(this.refresh_btn);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 549);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1177, 42);
            this.panelControl3.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1181, 593);
            this.panelControl1.TabIndex = 3;
            // 
            // Vouchers_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "Vouchers_History";
            this.Size = new System.Drawing.Size(1181, 593);
            this.SizeChanged += new System.EventHandler(this.Vouchers_History_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.account_search_check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.by_date_check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voucher_type_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.account_search_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_no_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton search_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.CheckEdit account_search_check;
        private DevExpress.XtraEditors.CheckEdit by_date_check;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton refresh_btn;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit voucher_type_cmb;
        private DevExpress.XtraEditors.DateEdit from_date_picker;
        private DevExpress.XtraEditors.DateEdit to_date_picker;
        private DevExpress.XtraEditors.SearchLookUpEdit account_search_cmb;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl list;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private System.Windows.Forms.BindingSource queryBindingSource;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit ref_no_inp;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
    }
}
