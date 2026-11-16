namespace Jamera.Accounts
{
    partial class Account_Ledger_Statement
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery3 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery4 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account_Ledger_Statement));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.list = new DevExpress.XtraGrid.GridControl();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClosingBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl12 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.total_debit = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.total_credit = new DevExpress.XtraEditors.TextEdit();
            this.net_activity_inp = new DevExpress.XtraEditors.TextEdit();
            this.textEdit5 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.refresh_btn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.from_date_picker = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.search_btn = new DevExpress.XtraEditors.SimpleButton();
            this.account_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.queryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.to_date_picker = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).BeginInit();
            this.panelControl12.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_debit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_credit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.net_activity_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.account_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1262, 595);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.list);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 43);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1258, 472);
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
            this.list.Size = new System.Drawing.Size(1258, 472);
            this.list.TabIndex = 3;
            this.list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "JAMERA_CONNECTION";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery3.Name = "Query";
            customSqlQuery3.Sql = "SELECT id as \'Code\',name as \'Name\',phone as \'Phone\',address as \'Address\',balance " +
    "as \'Balance\' from accounts;\r\n";
            customSqlQuery4.Name = "Query_1";
            customSqlQuery4.Sql = resources.GetString("customSqlQuery4.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery3,
            customSqlQuery4});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
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
            this.colAccount,
            this.colDate,
            this.colInvoiceNo,
            this.colSource,
            this.colDescription,
            this.colItemName,
            this.colItemquantity,
            this.colDebit,
            this.colCredit,
            this.colClosingBalance});
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
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 10;
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.MaxWidth = 110;
            this.colCode.MinWidth = 100;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 100;
            // 
            // colAccount
            // 
            this.colAccount.FieldName = "Account";
            this.colAccount.MinWidth = 250;
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 1;
            this.colAccount.Width = 250;
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.MaxWidth = 135;
            this.colDate.MinWidth = 130;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;
            this.colDate.Width = 130;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.FieldName = "Invoice No";
            this.colInvoiceNo.MaxWidth = 160;
            this.colInvoiceNo.MinWidth = 120;
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 3;
            this.colInvoiceNo.Width = 120;
            // 
            // colSource
            // 
            this.colSource.FieldName = "Source";
            this.colSource.MaxWidth = 160;
            this.colSource.MinWidth = 120;
            this.colSource.Name = "colSource";
            this.colSource.Visible = true;
            this.colSource.VisibleIndex = 4;
            this.colSource.Width = 120;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            this.colDescription.Width = 200;
            // 
            // colItemName
            // 
            this.colItemName.FieldName = "Item Name";
            this.colItemName.MinWidth = 200;
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 6;
            this.colItemName.Width = 200;
            // 
            // colItemquantity
            // 
            this.colItemquantity.FieldName = "Item Quantity";
            this.colItemquantity.MaxWidth = 130;
            this.colItemquantity.MinWidth = 120;
            this.colItemquantity.Name = "colItemquantity";
            this.colItemquantity.Visible = true;
            this.colItemquantity.VisibleIndex = 7;
            this.colItemquantity.Width = 130;
            // 
            // colDebit
            // 
            this.colDebit.FieldName = "Debit";
            this.colDebit.MaxWidth = 200;
            this.colDebit.MinWidth = 140;
            this.colDebit.Name = "colDebit";
            this.colDebit.Visible = true;
            this.colDebit.VisibleIndex = 8;
            this.colDebit.Width = 140;
            // 
            // colCredit
            // 
            this.colCredit.FieldName = "Credit";
            this.colCredit.MaxWidth = 200;
            this.colCredit.MinWidth = 140;
            this.colCredit.Name = "colCredit";
            this.colCredit.Visible = true;
            this.colCredit.VisibleIndex = 9;
            this.colCredit.Width = 140;
            // 
            // colClosingBalance
            // 
            this.colClosingBalance.FieldName = "Closing Balance";
            this.colClosingBalance.MaxWidth = 200;
            this.colClosingBalance.MinWidth = 150;
            this.colClosingBalance.Name = "colClosingBalance";
            this.colClosingBalance.Visible = true;
            this.colClosingBalance.VisibleIndex = 10;
            this.colClosingBalance.Width = 150;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.panelControl3.Appearance.Options.UseFont = true;
            this.panelControl3.Controls.Add(this.panelControl12);
            this.panelControl3.Controls.Add(this.tableLayoutPanel2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 515);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1258, 78);
            this.panelControl3.TabIndex = 1;
            // 
            // panelControl12
            // 
            this.panelControl12.Controls.Add(this.labelControl9);
            this.panelControl12.Controls.Add(this.labelControl23);
            this.panelControl12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl12.Location = new System.Drawing.Point(2, 49);
            this.panelControl12.LookAndFeel.SkinName = "Office 2007 Green";
            this.panelControl12.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl12.Name = "panelControl12";
            this.panelControl12.Size = new System.Drawing.Size(1254, 27);
            this.panelControl12.TabIndex = 43;
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(19, 3);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(81, 18);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Shortcuts :";
            // 
            // labelControl23
            // 
            this.labelControl23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl23.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl23.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl23.Location = new System.Drawing.Point(104, 5);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(1014, 16);
            this.labelControl23.TabIndex = 0;
            this.labelControl23.Text = "[F1] -> Focus List     [F3, CTRL + F] -> Search     [F5,CTRL + R] -> Refresh List" +
    "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.Controls.Add(this.textEdit1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.total_debit, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.total_credit, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.net_activity_inp, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.textEdit5, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.refresh_btn, 10, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1254, 41);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.EditValue = "0";
            this.textEdit1.Location = new System.Drawing.Point(145, 8);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(100, 24);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.Visible = false;
            this.textEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit1_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Begining Balance :";
            this.label3.Visible = false;
            // 
            // total_debit
            // 
            this.total_debit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.total_debit.EditValue = "0";
            this.total_debit.Location = new System.Drawing.Point(350, 8);
            this.total_debit.MinimumSize = new System.Drawing.Size(43, 24);
            this.total_debit.Name = "total_debit";
            this.total_debit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_debit.Properties.Appearance.Options.UseFont = true;
            this.total_debit.Properties.ReadOnly = true;
            this.total_debit.Size = new System.Drawing.Size(100, 24);
            this.total_debit.TabIndex = 4;
            this.total_debit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.total_debit_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(258, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Total Debit :";
            // 
            // total_credit
            // 
            this.total_credit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.total_credit.EditValue = "0";
            this.total_credit.Location = new System.Drawing.Point(564, 8);
            this.total_credit.MinimumSize = new System.Drawing.Size(43, 24);
            this.total_credit.Name = "total_credit";
            this.total_credit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_credit.Properties.Appearance.Options.UseFont = true;
            this.total_credit.Properties.ReadOnly = true;
            this.total_credit.Size = new System.Drawing.Size(100, 24);
            this.total_credit.TabIndex = 4;
            this.total_credit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.total_credit_KeyDown);
            // 
            // net_activity_inp
            // 
            this.net_activity_inp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.net_activity_inp.EditValue = "0";
            this.net_activity_inp.Location = new System.Drawing.Point(771, 8);
            this.net_activity_inp.MinimumSize = new System.Drawing.Size(43, 24);
            this.net_activity_inp.Name = "net_activity_inp";
            this.net_activity_inp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.net_activity_inp.Properties.Appearance.Options.UseFont = true;
            this.net_activity_inp.Properties.ReadOnly = true;
            this.net_activity_inp.Size = new System.Drawing.Size(100, 24);
            this.net_activity_inp.TabIndex = 4;
            this.net_activity_inp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.net_activity_inp_KeyDown);
            // 
            // textEdit5
            // 
            this.textEdit5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit5.EditValue = "0";
            this.textEdit5.Location = new System.Drawing.Point(1015, 8);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit5.Properties.Appearance.Options.UseFont = true;
            this.textEdit5.Properties.ReadOnly = true;
            this.textEdit5.Size = new System.Drawing.Size(100, 24);
            this.textEdit5.TabIndex = 4;
            this.textEdit5.Visible = false;
            this.textEdit5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit5_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(465, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Credit :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(678, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Net Activity :";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(888, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ending Balance :";
            this.label8.Visible = false;
            // 
            // refresh_btn
            // 
            this.refresh_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.refresh_btn.Appearance.Options.UseFont = true;
            this.refresh_btn.Image = ((System.Drawing.Image)(resources.GetObject("refresh_btn.Image")));
            this.refresh_btn.Location = new System.Drawing.Point(1127, 3);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(124, 35);
            this.refresh_btn.TabIndex = 6;
            this.refresh_btn.Text = "Refresh List";
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1258, 41);
            this.panelControl2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.from_date_picker, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.search_btn, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.account_cmb, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.to_date_picker, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1258, 41);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // from_date_picker
            // 
            this.from_date_picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.from_date_picker.EditValue = null;
            this.from_date_picker.EnterMoveNextControl = true;
            this.from_date_picker.Location = new System.Drawing.Point(65, 8);
            this.from_date_picker.Name = "from_date_picker";
            this.from_date_picker.Properties.AllowFocused = false;
            this.from_date_picker.Properties.AllowMouseWheel = false;
            this.from_date_picker.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.from_date_picker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date_picker.Properties.Appearance.Options.UseFont = true;
            this.from_date_picker.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date_picker.Properties.AppearanceDisabled.Options.UseFont = true;
            this.from_date_picker.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date_picker.Properties.AppearanceDropDown.Options.UseFont = true;
            this.from_date_picker.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date_picker.Properties.AppearanceFocused.Options.UseFont = true;
            this.from_date_picker.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date_picker.Properties.AppearanceReadOnly.Options.UseFont = true;
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
            this.from_date_picker.Properties.NullDateCalendarValue = new System.DateTime(2019, 10, 5, 5, 56, 42, 0);
            this.from_date_picker.Properties.ShowOk = DevExpress.Utils.DefaultBoolean.True;
            this.from_date_picker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.from_date_picker.Size = new System.Drawing.Size(224, 24);
            this.from_date_picker.TabIndex = 1;
            this.from_date_picker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.from_date_picker_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "From :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(578, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(302, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "To :";
            // 
            // search_btn
            // 
            this.search_btn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.search_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.search_btn.Appearance.Options.UseFont = true;
            this.search_btn.Image = ((System.Drawing.Image)(resources.GetObject("search_btn.Image")));
            this.search_btn.Location = new System.Drawing.Point(932, 3);
            this.search_btn.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(123, 35);
            this.search_btn.TabIndex = 4;
            this.search_btn.Text = "Search";
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            this.search_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_btn_KeyDown);
            // 
            // account_cmb
            // 
            this.account_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.account_cmb.EditValue = "";
            this.account_cmb.EnterMoveNextControl = true;
            this.account_cmb.Location = new System.Drawing.Point(654, 8);
            this.account_cmb.Name = "account_cmb";
            this.account_cmb.Properties.AllowFocused = false;
            this.account_cmb.Properties.AllowMouseWheel = false;
            this.account_cmb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.account_cmb.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_cmb.Properties.Appearance.Options.UseFont = true;
            this.account_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.account_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.account_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.account_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.account_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.account_cmb.Properties.DataSource = this.queryBindingSource;
            this.account_cmb.Properties.DisplayMember = "Name";
            this.account_cmb.Properties.NullText = "";
            this.account_cmb.Properties.PopupFormMinSize = new System.Drawing.Size(600, 300);
            this.account_cmb.Properties.ShowFooter = false;
            this.account_cmb.Properties.ValueMember = "Code";
            this.account_cmb.Properties.View = this.searchLookUpEdit1View;
            this.account_cmb.Size = new System.Drawing.Size(270, 24);
            this.account_cmb.TabIndex = 3;
            this.account_cmb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.account_cmb_KeyDown);
            // 
            // queryBindingSource
            // 
            this.queryBindingSource.DataMember = "Query";
            this.queryBindingSource.DataSource = this.sqlDataSource1;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.Row.Options.UseTextOptions = true;
            this.searchLookUpEdit1View.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colName,
            this.colPhone,
            this.colAddress,
            this.colBalance});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsCustomization.AllowColumnMoving = false;
            this.searchLookUpEdit1View.OptionsCustomization.AllowColumnResizing = false;
            this.searchLookUpEdit1View.OptionsCustomization.AllowFilter = false;
            this.searchLookUpEdit1View.OptionsCustomization.AllowGroup = false;
            this.searchLookUpEdit1View.OptionsCustomization.AllowQuickHideColumns = false;
            this.searchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.searchLookUpEdit1View.OptionsFind.FindDelay = 100;
            this.searchLookUpEdit1View.OptionsFind.SearchInPreview = true;
            this.searchLookUpEdit1View.OptionsFind.ShowCloseButton = false;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            this.searchLookUpEdit1View.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.MaxWidth = 100;
            this.gridColumn1.MinWidth = 80;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 250;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 339;
            // 
            // colPhone
            // 
            this.colPhone.FieldName = "Phone";
            this.colPhone.MaxWidth = 130;
            this.colPhone.MinWidth = 120;
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 2;
            this.colPhone.Width = 130;
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 200;
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 3;
            this.colAddress.Width = 225;
            // 
            // colBalance
            // 
            this.colBalance.FieldName = "Balance";
            this.colBalance.MaxWidth = 170;
            this.colBalance.MinWidth = 130;
            this.colBalance.Name = "colBalance";
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 4;
            this.colBalance.Width = 170;
            // 
            // to_date_picker
            // 
            this.to_date_picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.to_date_picker.EditValue = null;
            this.to_date_picker.EnterMoveNextControl = true;
            this.to_date_picker.Location = new System.Drawing.Point(340, 8);
            this.to_date_picker.Name = "to_date_picker";
            this.to_date_picker.Properties.AllowFocused = false;
            this.to_date_picker.Properties.AllowMouseWheel = false;
            this.to_date_picker.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.to_date_picker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date_picker.Properties.Appearance.Options.UseFont = true;
            this.to_date_picker.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date_picker.Properties.AppearanceDisabled.Options.UseFont = true;
            this.to_date_picker.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date_picker.Properties.AppearanceDropDown.Options.UseFont = true;
            this.to_date_picker.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date_picker.Properties.AppearanceFocused.Options.UseFont = true;
            this.to_date_picker.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date_picker.Properties.AppearanceReadOnly.Options.UseFont = true;
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
            this.to_date_picker.Properties.NullDateCalendarValue = new System.DateTime(2019, 10, 5, 5, 56, 42, 0);
            this.to_date_picker.Properties.ShowOk = DevExpress.Utils.DefaultBoolean.True;
            this.to_date_picker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.to_date_picker.Size = new System.Drawing.Size(224, 24);
            this.to_date_picker.TabIndex = 2;
            this.to_date_picker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.to_date_picker_KeyDown);
            // 
            // Account_Ledger_Statement
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Account_Ledger_Statement";
            this.Size = new System.Drawing.Size(1262, 595);
            this.SizeChanged += new System.EventHandler(this.Account_Ledger_Statement_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).EndInit();
            this.panelControl12.ResumeLayout(false);
            this.panelControl12.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_debit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_credit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.net_activity_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.account_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit total_debit;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit total_credit;
        private DevExpress.XtraEditors.TextEdit net_activity_inp;
        private DevExpress.XtraEditors.TextEdit textEdit5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.DateEdit from_date_picker;
        private DevExpress.XtraEditors.SimpleButton refresh_btn;
        private DevExpress.XtraEditors.SimpleButton search_btn;
        private DevExpress.XtraEditors.SearchLookUpEdit account_cmb;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.DateEdit to_date_picker;
        private DevExpress.XtraGrid.GridControl list;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private System.Windows.Forms.BindingSource queryBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colItemquantity;
        private DevExpress.XtraGrid.Columns.GridColumn colDebit;
        private DevExpress.XtraGrid.Columns.GridColumn colCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colClosingBalance;
        private DevExpress.XtraEditors.PanelControl panelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
    }
}
