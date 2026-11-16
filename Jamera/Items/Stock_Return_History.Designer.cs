namespace Jamera.Items
{
    partial class Stock_Return_History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock_Return_History));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery4 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.list = new DevExpress.XtraGrid.GridControl();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuelExp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.refresh_btn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.by_store_check = new DevExpress.XtraEditors.CheckEdit();
            this.by_date_check = new DevExpress.XtraEditors.CheckEdit();
            this.store_search_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.query_1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.from_date_picker = new DevExpress.XtraEditors.DateEdit();
            this.to_date_picker = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.search_btn = new DevExpress.XtraEditors.SimpleButton();
            this.query_1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.by_store_check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.by_date_check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.store_search_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.query_1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.query_1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(820, 508);
            this.panelControl1.TabIndex = 3;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.list);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 45);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(816, 416);
            this.panelControl4.TabIndex = 2;
            // 
            // list
            // 
            this.list.DataMember = "Query";
            this.list.DataSource = this.sqlDataSource1;
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.Location = new System.Drawing.Point(0, 0);
            this.list.MainView = this.gridView1;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(816, 416);
            this.list.TabIndex = 3;
            this.list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "JAMERA_CONNECTION";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery3.Name = "Query";
            customSqlQuery3.Sql = resources.GetString("customSqlQuery3.Sql");
            customSqlQuery4.Name = "Query_1";
            customSqlQuery4.Sql = "SELECT id as \'Code\',name as \'Name\',area_code as \'Area Code\',phone as \'Phone\' from" +
    " stores;\r\n\r\n\r\n\r\n";
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
            this.colDate,
            this.colCode,
            this.colName,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.colFuelExp,
            this.colPaidBy});
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
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 10;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.MaxWidth = 140;
            this.colDate.MinWidth = 130;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            this.colDate.Width = 130;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.MaxWidth = 110;
            this.colCode.MinWidth = 90;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 90;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 250;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 250;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Store.Code";
            this.gridColumn1.MaxWidth = 120;
            this.gridColumn1.MinWidth = 110;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 110;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Store.Name";
            this.gridColumn2.MinWidth = 250;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 250;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "Area.Code";
            this.gridColumn3.MaxWidth = 140;
            this.gridColumn3.MinWidth = 120;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 120;
            // 
            // colFuelExp
            // 
            this.colFuelExp.FieldName = "Fuel Exp";
            this.colFuelExp.MaxWidth = 150;
            this.colFuelExp.MinWidth = 120;
            this.colFuelExp.Name = "colFuelExp";
            this.colFuelExp.Visible = true;
            this.colFuelExp.VisibleIndex = 6;
            this.colFuelExp.Width = 120;
            // 
            // colPaidBy
            // 
            this.colPaidBy.FieldName = "Paid By";
            this.colPaidBy.MinWidth = 180;
            this.colPaidBy.Name = "colPaidBy";
            this.colPaidBy.Visible = true;
            this.colPaidBy.VisibleIndex = 7;
            this.colPaidBy.Width = 214;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.panelControl3.Appearance.Options.UseFont = true;
            this.panelControl3.Controls.Add(this.refresh_btn);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 461);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(816, 45);
            this.panelControl3.TabIndex = 1;
            // 
            // refresh_btn
            // 
            this.refresh_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.refresh_btn.Appearance.Options.UseFont = true;
            this.refresh_btn.Image = ((System.Drawing.Image)(resources.GetObject("refresh_btn.Image")));
            this.refresh_btn.Location = new System.Drawing.Point(678, 5);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(132, 35);
            this.refresh_btn.TabIndex = 4;
            this.refresh_btn.Text = "Refresh List";
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(816, 43);
            this.panelControl2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel1.Controls.Add(this.by_store_check, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.by_date_check, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.store_search_cmb, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.from_date_picker, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.to_date_picker, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.search_btn, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 43);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // by_store_check
            // 
            this.by_store_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.by_store_check.EnterMoveNextControl = true;
            this.by_store_check.Location = new System.Drawing.Point(3, 9);
            this.by_store_check.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.by_store_check.Name = "by_store_check";
            this.by_store_check.Properties.AllowFocused = false;
            this.by_store_check.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_store_check.Properties.Appearance.Options.UseFont = true;
            this.by_store_check.Properties.Caption = "Store :";
            this.by_store_check.Size = new System.Drawing.Size(67, 22);
            this.by_store_check.TabIndex = 0;
            this.by_store_check.CheckedChanged += new System.EventHandler(this.by_store_check_CheckedChanged);
            // 
            // by_date_check
            // 
            this.by_date_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.by_date_check.EnterMoveNextControl = true;
            this.by_date_check.Location = new System.Drawing.Point(256, 10);
            this.by_date_check.Name = "by_date_check";
            this.by_date_check.Properties.AllowFocused = false;
            this.by_date_check.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_date_check.Properties.Appearance.Options.UseFont = true;
            this.by_date_check.Properties.Caption = "Date From :";
            this.by_date_check.Size = new System.Drawing.Size(101, 22);
            this.by_date_check.TabIndex = 2;
            this.by_date_check.CheckedChanged += new System.EventHandler(this.by_date_check_CheckedChanged);
            // 
            // store_search_cmb
            // 
            this.store_search_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.store_search_cmb.EditValue = "";
            this.store_search_cmb.Enabled = false;
            this.store_search_cmb.EnterMoveNextControl = true;
            this.store_search_cmb.Location = new System.Drawing.Point(76, 9);
            this.store_search_cmb.Name = "store_search_cmb";
            this.store_search_cmb.Properties.AllowFocused = false;
            this.store_search_cmb.Properties.AllowMouseWheel = false;
            this.store_search_cmb.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store_search_cmb.Properties.Appearance.Options.UseFont = true;
            this.store_search_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.store_search_cmb.Properties.DataSource = this.query_1BindingSource1;
            this.store_search_cmb.Properties.DisplayMember = "Name";
            this.store_search_cmb.Properties.NullText = "";
            this.store_search_cmb.Properties.PopupFormSize = new System.Drawing.Size(0, 280);
            this.store_search_cmb.Properties.ShowFooter = false;
            this.store_search_cmb.Properties.ValueMember = "Code";
            this.store_search_cmb.Properties.View = this.gridView4;
            this.store_search_cmb.Size = new System.Drawing.Size(174, 24);
            this.store_search_cmb.TabIndex = 1;
            // 
            // query_1BindingSource1
            // 
            this.query_1BindingSource1.DataMember = "Query_1";
            this.query_1BindingSource1.DataSource = this.sqlDataSource1;
            // 
            // gridView4
            // 
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode1,
            this.colName1,
            this.colAreaCode,
            this.colPhone});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsFind.AlwaysVisible = true;
            this.gridView4.OptionsFind.FindDelay = 100;
            this.gridView4.OptionsFind.SearchInPreview = true;
            this.gridView4.OptionsFind.ShowCloseButton = false;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            this.gridView4.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            // 
            // colCode1
            // 
            this.colCode1.AppearanceCell.Options.UseTextOptions = true;
            this.colCode1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCode1.FieldName = "Code";
            this.colCode1.MaxWidth = 110;
            this.colCode1.MinWidth = 90;
            this.colCode1.Name = "colCode1";
            this.colCode1.Visible = true;
            this.colCode1.VisibleIndex = 0;
            this.colCode1.Width = 90;
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.MinWidth = 250;
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 1;
            this.colName1.Width = 250;
            // 
            // colAreaCode
            // 
            this.colAreaCode.FieldName = "Area Code";
            this.colAreaCode.MaxWidth = 150;
            this.colAreaCode.MinWidth = 120;
            this.colAreaCode.Name = "colAreaCode";
            this.colAreaCode.Visible = true;
            this.colAreaCode.VisibleIndex = 2;
            this.colAreaCode.Width = 120;
            // 
            // colPhone
            // 
            this.colPhone.FieldName = "Phone";
            this.colPhone.MaxWidth = 150;
            this.colPhone.MinWidth = 120;
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 3;
            this.colPhone.Width = 120;
            // 
            // from_date_picker
            // 
            this.from_date_picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.from_date_picker.EditValue = null;
            this.from_date_picker.Enabled = false;
            this.from_date_picker.EnterMoveNextControl = true;
            this.from_date_picker.Location = new System.Drawing.Point(363, 9);
            this.from_date_picker.Name = "from_date_picker";
            this.from_date_picker.Properties.AllowFocused = false;
            this.from_date_picker.Properties.AllowMouseWheel = false;
            this.from_date_picker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_date_picker.Properties.Appearance.Options.UseFont = true;
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
            this.from_date_picker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.from_date_picker.Size = new System.Drawing.Size(129, 24);
            this.from_date_picker.TabIndex = 3;
            // 
            // to_date_picker
            // 
            this.to_date_picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.to_date_picker.EditValue = null;
            this.to_date_picker.Enabled = false;
            this.to_date_picker.EnterMoveNextControl = true;
            this.to_date_picker.Location = new System.Drawing.Point(543, 9);
            this.to_date_picker.Name = "to_date_picker";
            this.to_date_picker.Properties.AllowFocused = false;
            this.to_date_picker.Properties.AllowMouseWheel = false;
            this.to_date_picker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date_picker.Properties.Appearance.Options.UseFont = true;
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
            this.to_date_picker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.to_date_picker.Size = new System.Drawing.Size(129, 24);
            this.to_date_picker.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(506, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "To :";
            // 
            // search_btn
            // 
            this.search_btn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.search_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.search_btn.Appearance.Options.UseFont = true;
            this.search_btn.Image = ((System.Drawing.Image)(resources.GetObject("search_btn.Image")));
            this.search_btn.Location = new System.Drawing.Point(680, 4);
            this.search_btn.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(121, 35);
            this.search_btn.TabIndex = 5;
            this.search_btn.Text = "Search";
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // query_1BindingSource
            // 
            this.query_1BindingSource.DataMember = "Query_1";
            this.query_1BindingSource.DataSource = this.sqlDataSource1;
            // 
            // Stock_Return_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "Stock_Return_History";
            this.Size = new System.Drawing.Size(820, 508);
            this.SizeChanged += new System.EventHandler(this.Stock_Return_History_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.by_store_check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.by_date_check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.store_search_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.query_1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date_picker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_date_picker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.query_1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.GridControl list;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton refresh_btn;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton search_btn;
        private DevExpress.XtraEditors.CheckEdit by_store_check;
        private DevExpress.XtraEditors.CheckEdit by_date_check;
        private DevExpress.XtraEditors.SearchLookUpEdit store_search_cmb;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.DateEdit from_date_picker;
        private DevExpress.XtraEditors.DateEdit to_date_picker;
        private System.Windows.Forms.Label label2;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private System.Windows.Forms.BindingSource query_1BindingSource;
        private System.Windows.Forms.BindingSource query_1BindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colFuelExp;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colAreaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
    }
}
