namespace Jamera.Items
{
    partial class Items
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Items));
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.items_list = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnicode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPacking = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReorder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl12 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.total_value_lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.total_stock_lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.create_new_btn = new DevExpress.XtraEditors.SimpleButton();
            this.refresh_btn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.is_active_item_chkbx = new DevExpress.XtraEditors.CheckEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.search_filter_cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.search_inp = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.items_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).BeginInit();
            this.panelControl12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.is_active_item_chkbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_filter_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_inp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "JAMERA_CONNECTION";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Items_List";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(890, 469);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.items_list);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 35);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(886, 344);
            this.panelControl4.TabIndex = 2;
            // 
            // items_list
            // 
            this.items_list.DataMember = "Items_List";
            this.items_list.DataSource = this.sqlDataSource1;
            this.items_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.items_list.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.items_list.Location = new System.Drawing.Point(0, 0);
            this.items_list.MainView = this.gridView1;
            this.items_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.items_list.Name = "items_list";
            this.items_list.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.items_list.Size = new System.Drawing.Size(886, 344);
            this.items_list.TabIndex = 1;
            this.items_list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.items_list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.items_list_KeyDown);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colUnicode,
            this.colModel,
            this.colUnit,
            this.colPacking,
            this.colPurchaseRate,
            this.colSaleRate,
            this.colUnitCost,
            this.colSaleDiscount,
            this.colActive,
            this.colReorder,
            this.colManufacturer,
            this.colGroup,
            this.colCategory,
            this.colItemStock,
            this.colStockValue});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.items_list;
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.MaxWidth = 100;
            this.colCode.MinWidth = 90;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 90;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 250;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 250;
            // 
            // colUnicode
            // 
            this.colUnicode.AppearanceCell.Options.UseTextOptions = true;
            this.colUnicode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colUnicode.FieldName = "Unicode";
            this.colUnicode.MinWidth = 250;
            this.colUnicode.Name = "colUnicode";
            this.colUnicode.Visible = true;
            this.colUnicode.VisibleIndex = 2;
            this.colUnicode.Width = 250;
            // 
            // colModel
            // 
            this.colModel.FieldName = "Model";
            this.colModel.MaxWidth = 170;
            this.colModel.MinWidth = 120;
            this.colModel.Name = "colModel";
            this.colModel.Visible = true;
            this.colModel.VisibleIndex = 3;
            this.colModel.Width = 120;
            // 
            // colUnit
            // 
            this.colUnit.FieldName = "Unit";
            this.colUnit.MaxWidth = 170;
            this.colUnit.MinWidth = 120;
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 4;
            this.colUnit.Width = 120;
            // 
            // colPacking
            // 
            this.colPacking.FieldName = "Packing";
            this.colPacking.MaxWidth = 120;
            this.colPacking.MinWidth = 100;
            this.colPacking.Name = "colPacking";
            this.colPacking.Visible = true;
            this.colPacking.VisibleIndex = 5;
            this.colPacking.Width = 100;
            // 
            // colPurchaseRate
            // 
            this.colPurchaseRate.FieldName = "Purchase Rate";
            this.colPurchaseRate.MaxWidth = 170;
            this.colPurchaseRate.MinWidth = 120;
            this.colPurchaseRate.Name = "colPurchaseRate";
            this.colPurchaseRate.Visible = true;
            this.colPurchaseRate.VisibleIndex = 6;
            this.colPurchaseRate.Width = 120;
            // 
            // colSaleRate
            // 
            this.colSaleRate.FieldName = "Sale Rate";
            this.colSaleRate.MaxWidth = 170;
            this.colSaleRate.MinWidth = 120;
            this.colSaleRate.Name = "colSaleRate";
            this.colSaleRate.Visible = true;
            this.colSaleRate.VisibleIndex = 7;
            this.colSaleRate.Width = 120;
            // 
            // colUnitCost
            // 
            this.colUnitCost.FieldName = "Unit Cost";
            this.colUnitCost.MaxWidth = 170;
            this.colUnitCost.MinWidth = 120;
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.Visible = true;
            this.colUnitCost.VisibleIndex = 8;
            this.colUnitCost.Width = 120;
            // 
            // colSaleDiscount
            // 
            this.colSaleDiscount.FieldName = "Sale Discount";
            this.colSaleDiscount.MaxWidth = 170;
            this.colSaleDiscount.MinWidth = 120;
            this.colSaleDiscount.Name = "colSaleDiscount";
            this.colSaleDiscount.Visible = true;
            this.colSaleDiscount.VisibleIndex = 9;
            this.colSaleDiscount.Width = 120;
            // 
            // colActive
            // 
            this.colActive.FieldName = "Active";
            this.colActive.MaxWidth = 90;
            this.colActive.MinWidth = 80;
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 10;
            this.colActive.Width = 80;
            // 
            // colReorder
            // 
            this.colReorder.FieldName = "Reorder";
            this.colReorder.MaxWidth = 140;
            this.colReorder.MinWidth = 100;
            this.colReorder.Name = "colReorder";
            this.colReorder.Visible = true;
            this.colReorder.VisibleIndex = 11;
            this.colReorder.Width = 100;
            // 
            // colManufacturer
            // 
            this.colManufacturer.FieldName = "Manufacturer";
            this.colManufacturer.MaxWidth = 170;
            this.colManufacturer.MinWidth = 120;
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.Visible = true;
            this.colManufacturer.VisibleIndex = 12;
            this.colManufacturer.Width = 120;
            // 
            // colGroup
            // 
            this.colGroup.FieldName = "Group";
            this.colGroup.MaxWidth = 170;
            this.colGroup.MinWidth = 120;
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 13;
            this.colGroup.Width = 120;
            // 
            // colCategory
            // 
            this.colCategory.FieldName = "Category";
            this.colCategory.MaxWidth = 170;
            this.colCategory.MinWidth = 120;
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 14;
            this.colCategory.Width = 120;
            // 
            // colItemStock
            // 
            this.colItemStock.FieldName = "Item Stock";
            this.colItemStock.MaxWidth = 170;
            this.colItemStock.MinWidth = 120;
            this.colItemStock.Name = "colItemStock";
            this.colItemStock.Visible = true;
            this.colItemStock.VisibleIndex = 15;
            this.colItemStock.Width = 120;
            // 
            // colStockValue
            // 
            this.colStockValue.FieldName = "Stock Value";
            this.colStockValue.MaxWidth = 170;
            this.colStockValue.MinWidth = 120;
            this.colStockValue.Name = "colStockValue";
            this.colStockValue.Visible = true;
            this.colStockValue.VisibleIndex = 16;
            this.colStockValue.Width = 120;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.panelControl3.Appearance.Options.UseFont = true;
            this.panelControl3.Controls.Add(this.panelControl12);
            this.panelControl3.Controls.Add(this.total_value_lbl);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.total_stock_lbl);
            this.panelControl3.Controls.Add(this.labelControl8);
            this.panelControl3.Controls.Add(this.create_new_btn);
            this.panelControl3.Controls.Add(this.refresh_btn);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 379);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(886, 88);
            this.panelControl3.TabIndex = 1;
            // 
            // panelControl12
            // 
            this.panelControl12.Controls.Add(this.labelControl9);
            this.panelControl12.Controls.Add(this.labelControl23);
            this.panelControl12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl12.Location = new System.Drawing.Point(2, 45);
            this.panelControl12.LookAndFeel.SkinName = "Office 2007 Green";
            this.panelControl12.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl12.Name = "panelControl12";
            this.panelControl12.Size = new System.Drawing.Size(882, 41);
            this.panelControl12.TabIndex = 42;
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(22, 1);
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
            this.labelControl23.Appearance.Options.UseFont = true;
            this.labelControl23.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl23.Location = new System.Drawing.Point(107, 5);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(753, 32);
            this.labelControl23.TabIndex = 0;
            this.labelControl23.Text = "[F1] -> Focus List      [F2,ENTER] -> Edit list item     [F3, CTRL + F] -> Search" +
    "     [F7] -> Change search filter     [F6,CTRL + N] -> Create New     [F5,CTRL +" +
    " R] -> Refresh List";
            // 
            // total_value_lbl
            // 
            this.total_value_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_value_lbl.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.total_value_lbl.Appearance.Options.UseFont = true;
            this.total_value_lbl.Appearance.Options.UseForeColor = true;
            this.total_value_lbl.Location = new System.Drawing.Point(313, 14);
            this.total_value_lbl.Name = "total_value_lbl";
            this.total_value_lbl.Size = new System.Drawing.Size(35, 19);
            this.total_value_lbl.TabIndex = 40;
            this.total_value_lbl.Text = "0.00";
            this.total_value_lbl.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(215, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 18);
            this.labelControl1.TabIndex = 41;
            this.labelControl1.Text = "Total Value :";
            this.labelControl1.Visible = false;
            // 
            // total_stock_lbl
            // 
            this.total_stock_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_stock_lbl.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.total_stock_lbl.Appearance.Options.UseFont = true;
            this.total_stock_lbl.Appearance.Options.UseForeColor = true;
            this.total_stock_lbl.Location = new System.Drawing.Point(104, 13);
            this.total_stock_lbl.Name = "total_stock_lbl";
            this.total_stock_lbl.Size = new System.Drawing.Size(10, 19);
            this.total_stock_lbl.TabIndex = 38;
            this.total_stock_lbl.Text = "0";
            this.total_stock_lbl.Visible = false;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(7, 13);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(93, 18);
            this.labelControl8.TabIndex = 39;
            this.labelControl8.Text = "Total Stock :";
            this.labelControl8.Visible = false;
            // 
            // create_new_btn
            // 
            this.create_new_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.create_new_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.create_new_btn.Appearance.Options.UseFont = true;
            this.create_new_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("create_new_btn.ImageOptions.Image")));
            this.create_new_btn.Location = new System.Drawing.Point(616, 5);
            this.create_new_btn.Name = "create_new_btn";
            this.create_new_btn.Size = new System.Drawing.Size(129, 35);
            this.create_new_btn.TabIndex = 3;
            this.create_new_btn.Text = "Create New";
            this.create_new_btn.Click += new System.EventHandler(this.create_new_btn_Click);
            // 
            // refresh_btn
            // 
            this.refresh_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.refresh_btn.Appearance.Options.UseFont = true;
            this.refresh_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("refresh_btn.ImageOptions.Image")));
            this.refresh_btn.Location = new System.Drawing.Point(751, 5);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(130, 35);
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
            this.panelControl2.Size = new System.Drawing.Size(886, 33);
            this.panelControl2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tableLayoutPanel1.Controls.Add(this.is_active_item_chkbx, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.search_filter_cmb, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.search_inp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 33);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // is_active_item_chkbx
            // 
            this.is_active_item_chkbx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.is_active_item_chkbx.EditValue = true;
            this.is_active_item_chkbx.Location = new System.Drawing.Point(548, 5);
            this.is_active_item_chkbx.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.is_active_item_chkbx.Name = "is_active_item_chkbx";
            this.is_active_item_chkbx.Properties.AllowFocused = false;
            this.is_active_item_chkbx.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.is_active_item_chkbx.Properties.Appearance.Options.UseFont = true;
            this.is_active_item_chkbx.Properties.Caption = "Is Active Item";
            this.is_active_item_chkbx.Size = new System.Drawing.Size(105, 22);
            this.is_active_item_chkbx.TabIndex = 5;
            this.is_active_item_chkbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.is_active_item_chkbx_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Search :";
            // 
            // search_filter_cmb
            // 
            this.search_filter_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.search_filter_cmb.EditValue = "*";
            this.search_filter_cmb.EnterMoveNextControl = true;
            this.search_filter_cmb.Location = new System.Drawing.Point(403, 4);
            this.search_filter_cmb.Name = "search_filter_cmb";
            this.search_filter_cmb.Properties.AllowFocused = false;
            this.search_filter_cmb.Properties.AllowMouseWheel = false;
            this.search_filter_cmb.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_filter_cmb.Properties.Appearance.Options.UseFont = true;
            this.search_filter_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_filter_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.search_filter_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_filter_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.search_filter_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_filter_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.search_filter_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_filter_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.search_filter_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.search_filter_cmb.Properties.Items.AddRange(new object[] {
            "*",
            "Name",
            "Group",
            "Category",
            "Manufacturer"});
            this.search_filter_cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.search_filter_cmb.Size = new System.Drawing.Size(134, 24);
            this.search_filter_cmb.TabIndex = 1;
            this.search_filter_cmb.SelectedIndexChanged += new System.EventHandler(this.search_filter_cmb_SelectedIndexChanged);
            this.search_filter_cmb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_filter_cmb_KeyDown);
            // 
            // search_inp
            // 
            this.search_inp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.search_inp.EnterMoveNextControl = true;
            this.search_inp.Location = new System.Drawing.Point(77, 4);
            this.search_inp.Name = "search_inp";
            this.search_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_inp.Properties.Appearance.Options.UseFont = true;
            this.search_inp.Size = new System.Drawing.Size(239, 24);
            this.search_inp.TabIndex = 0;
            this.search_inp.EditValueChanged += new System.EventHandler(this.search_inp_EditValueChanged);
            this.search_inp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_inp_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(329, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Filter By :";
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "Items";
            this.Size = new System.Drawing.Size(890, 469);
            this.Load += new System.EventHandler(this.Items_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.items_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).EndInit();
            this.panelControl12.ResumeLayout(false);
            this.panelControl12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.is_active_item_chkbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_filter_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_inp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit search_filter_cmb;
        private DevExpress.XtraEditors.TextEdit search_inp;
        private DevExpress.XtraEditors.CheckEdit is_active_item_chkbx;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton create_new_btn;
        private DevExpress.XtraEditors.SimpleButton refresh_btn;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraGrid.GridControl items_list;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.LabelControl total_stock_lbl;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl total_value_lbl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnicode;
        private DevExpress.XtraGrid.Columns.GridColumn colModel;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colPacking;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseRate;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleRate;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colReorder;
        private DevExpress.XtraGrid.Columns.GridColumn colManufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colItemStock;
        private DevExpress.XtraGrid.Columns.GridColumn colStockValue;
    }
}
