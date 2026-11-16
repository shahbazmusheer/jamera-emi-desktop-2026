namespace Jamera.Employees
{
    partial class Edit_Employee
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
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_Employee));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pay_date_cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.basic_salary_inp = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.role_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.query_1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.store_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.queryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.advance_payment_inp = new DevExpress.XtraEditors.TextEdit();
            this.phone_inp = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.address_inp = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.name_inp = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.update_btn = new DevExpress.XtraEditors.SimpleButton();
            this.delete_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pay_date_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basic_salary_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.role_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.query_1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.store_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advance_payment_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phone_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.name_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(535, 426);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.panelControl3.Controls.Add(this.pay_date_cmb);
            this.panelControl3.Controls.Add(this.basic_salary_inp);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.role_cmb);
            this.panelControl3.Controls.Add(this.store_cmb);
            this.panelControl3.Controls.Add(this.advance_payment_inp);
            this.panelControl3.Controls.Add(this.phone_inp);
            this.panelControl3.Controls.Add(this.label8);
            this.panelControl3.Controls.Add(this.address_inp);
            this.panelControl3.Controls.Add(this.label5);
            this.panelControl3.Controls.Add(this.name_inp);
            this.panelControl3.Controls.Add(this.label7);
            this.panelControl3.Controls.Add(this.label4);
            this.panelControl3.Controls.Add(this.label6);
            this.panelControl3.Controls.Add(this.label3);
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(535, 381);
            this.panelControl3.TabIndex = 1;
            // 
            // pay_date_cmb
            // 
            this.pay_date_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pay_date_cmb.EditValue = "01";
            this.pay_date_cmb.EnterMoveNextControl = true;
            this.pay_date_cmb.Location = new System.Drawing.Point(130, 229);
            this.pay_date_cmb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pay_date_cmb.Name = "pay_date_cmb";
            this.pay_date_cmb.Properties.AllowFocused = false;
            this.pay_date_cmb.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay_date_cmb.Properties.Appearance.Options.UseFont = true;
            this.pay_date_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay_date_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.pay_date_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay_date_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.pay_date_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay_date_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.pay_date_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay_date_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.pay_date_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pay_date_cmb.Properties.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.pay_date_cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.pay_date_cmb.Size = new System.Drawing.Size(395, 24);
            this.pay_date_cmb.TabIndex = 5;
            // 
            // basic_salary_inp
            // 
            this.basic_salary_inp.EditValue = "";
            this.basic_salary_inp.EnterMoveNextControl = true;
            this.basic_salary_inp.Location = new System.Drawing.Point(130, 311);
            this.basic_salary_inp.Name = "basic_salary_inp";
            this.basic_salary_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.basic_salary_inp.Properties.Appearance.Options.UseFont = true;
            this.basic_salary_inp.Size = new System.Drawing.Size(395, 24);
            this.basic_salary_inp.TabIndex = 7;
            this.basic_salary_inp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.basic_salary_inp_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 67;
            this.label1.Text = "Basic Salary :";
            // 
            // role_cmb
            // 
            this.role_cmb.EditValue = "";
            this.role_cmb.EnterMoveNextControl = true;
            this.role_cmb.Location = new System.Drawing.Point(130, 66);
            this.role_cmb.Name = "role_cmb";
            this.role_cmb.Properties.AllowFocused = false;
            this.role_cmb.Properties.AllowMouseWheel = false;
            this.role_cmb.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role_cmb.Properties.Appearance.Options.UseFont = true;
            this.role_cmb.Properties.Appearance.Options.UseTextOptions = true;
            this.role_cmb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.role_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.role_cmb.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.role_cmb.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.role_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.role_cmb.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.role_cmb.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.role_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.role_cmb.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.role_cmb.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.role_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.role_cmb.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.role_cmb.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.role_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.role_cmb.Properties.DataSource = this.query_1BindingSource;
            this.role_cmb.Properties.DisplayMember = "Role";
            this.role_cmb.Properties.NullText = "";
            this.role_cmb.Properties.ShowFooter = false;
            this.role_cmb.Properties.ValueMember = "Code";
            this.role_cmb.Properties.View = this.gridView2;
            this.role_cmb.Size = new System.Drawing.Size(395, 24);
            this.role_cmb.TabIndex = 1;
            this.role_cmb.TabStop = false;
            this.role_cmb.EditValueChanged += new System.EventHandler(this.role_cmb_EditValueChanged);
            // 
            // query_1BindingSource
            // 
            this.query_1BindingSource.DataMember = "Query_1";
            this.query_1BindingSource.DataSource = this.sqlDataSource1;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "JAMERA_CONNECTION";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = "SELECT id as \'Code\',name as \'Name\',area_code as \'Area Code\',phone as \'Phone\' from" +
    " stores;\r\n\r\n";
            customSqlQuery2.Name = "Query_1";
            customSqlQuery2.Sql = "select \"roles\".\"id\" as \'Code\', \"roles\".\"name\" as \'Role\'\r\n  from \"dbo\".\"roles\" \"ro" +
    "les\"\r\n";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            customSqlQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.Row.Options.UseTextOptions = true;
            this.gridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colRole});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowColumnResizing = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsFind.FindDelay = 100;
            this.gridView2.OptionsFind.SearchInPreview = true;
            this.gridView2.OptionsFind.ShowCloseButton = false;
            this.gridView2.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView2.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsMenu.EnableFooterMenu = false;
            this.gridView2.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 497;
            // 
            // colRole
            // 
            this.colRole.FieldName = "Role";
            this.colRole.Name = "colRole";
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 1;
            this.colRole.Width = 671;
            // 
            // store_cmb
            // 
            this.store_cmb.EditValue = "";
            this.store_cmb.EnterMoveNextControl = true;
            this.store_cmb.Location = new System.Drawing.Point(130, 27);
            this.store_cmb.Name = "store_cmb";
            this.store_cmb.Properties.AllowFocused = false;
            this.store_cmb.Properties.AllowMouseWheel = false;
            this.store_cmb.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store_cmb.Properties.Appearance.Options.UseFont = true;
            this.store_cmb.Properties.Appearance.Options.UseTextOptions = true;
            this.store_cmb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.store_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.store_cmb.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.store_cmb.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.store_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.store_cmb.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.store_cmb.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.store_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.store_cmb.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.store_cmb.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.store_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.store_cmb.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.store_cmb.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.store_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.store_cmb.Properties.DataSource = this.queryBindingSource;
            this.store_cmb.Properties.DisplayMember = "Name";
            this.store_cmb.Properties.NullText = "";
            this.store_cmb.Properties.ShowFooter = false;
            this.store_cmb.Properties.ValueMember = "Code";
            this.store_cmb.Properties.View = this.gridView1;
            this.store_cmb.Size = new System.Drawing.Size(393, 24);
            this.store_cmb.TabIndex = 0;
            this.store_cmb.TabStop = false;
            this.store_cmb.EditValueChanged += new System.EventHandler(this.store_cmb_EditValueChanged);
            // 
            // queryBindingSource
            // 
            this.queryBindingSource.DataMember = "Query";
            this.queryBindingSource.DataSource = this.sqlDataSource1;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.colPhone});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            // 
            // gridColumn9
            // 
            this.gridColumn9.FieldName = "Code";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 198;
            // 
            // gridColumn10
            // 
            this.gridColumn10.FieldName = "Name";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 409;
            // 
            // gridColumn11
            // 
            this.gridColumn11.FieldName = "Area Code";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 279;
            // 
            // colPhone
            // 
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 3;
            this.colPhone.Width = 282;
            // 
            // advance_payment_inp
            // 
            this.advance_payment_inp.EnterMoveNextControl = true;
            this.advance_payment_inp.Location = new System.Drawing.Point(130, 268);
            this.advance_payment_inp.Name = "advance_payment_inp";
            this.advance_payment_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advance_payment_inp.Properties.Appearance.Options.UseFont = true;
            this.advance_payment_inp.Size = new System.Drawing.Size(395, 24);
            this.advance_payment_inp.TabIndex = 6;
            this.advance_payment_inp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.advance_payment_inp_KeyPress);
            // 
            // phone_inp
            // 
            this.phone_inp.EnterMoveNextControl = true;
            this.phone_inp.Location = new System.Drawing.Point(130, 189);
            this.phone_inp.Name = "phone_inp";
            this.phone_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_inp.Properties.Appearance.Options.UseFont = true;
            this.phone_inp.Size = new System.Drawing.Size(395, 24);
            this.phone_inp.TabIndex = 4;
            this.phone_inp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_inp_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 63;
            this.label8.Text = "Advance Limit :";
            // 
            // address_inp
            // 
            this.address_inp.EnterMoveNextControl = true;
            this.address_inp.Location = new System.Drawing.Point(130, 147);
            this.address_inp.Name = "address_inp";
            this.address_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_inp.Properties.Appearance.Options.UseFont = true;
            this.address_inp.Size = new System.Drawing.Size(395, 24);
            this.address_inp.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 57;
            this.label5.Text = "Pay Date :";
            // 
            // name_inp
            // 
            this.name_inp.EnterMoveNextControl = true;
            this.name_inp.Location = new System.Drawing.Point(130, 108);
            this.name_inp.Name = "name_inp";
            this.name_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_inp.Properties.Appearance.Options.UseFont = true;
            this.name_inp.Size = new System.Drawing.Size(395, 24);
            this.name_inp.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 58;
            this.label7.Text = "Phone No. :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 59;
            this.label4.Text = "Name :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 60;
            this.label6.Text = "Address :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 61;
            this.label3.Text = "Role :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "Store :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.update_btn);
            this.panelControl2.Controls.Add(this.delete_btn);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 381);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(535, 45);
            this.panelControl2.TabIndex = 8;
            // 
            // update_btn
            // 
            this.update_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.update_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_btn.Appearance.Options.UseFont = true;
            this.update_btn.Image = ((System.Drawing.Image)(resources.GetObject("update_btn.Image")));
            this.update_btn.Location = new System.Drawing.Point(276, 5);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(120, 35);
            this.update_btn.TabIndex = 8;
            this.update_btn.Text = "Update";
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_btn.Appearance.Options.UseFont = true;
            this.delete_btn.Image = ((System.Drawing.Image)(resources.GetObject("delete_btn.Image")));
            this.delete_btn.Location = new System.Drawing.Point(402, 5);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(127, 35);
            this.delete_btn.TabIndex = 9;
            this.delete_btn.Text = "Delete";
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // Edit_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 426);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Edit_Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Employee";
            this.Load += new System.EventHandler(this.Edit_Employee_Load);
            this.Shown += new System.EventHandler(this.Edit_Employee_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pay_date_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basic_salary_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.role_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.query_1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.store_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advance_payment_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phone_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.name_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton update_btn;
        private DevExpress.XtraEditors.SimpleButton delete_btn;
        public DevExpress.XtraEditors.SearchLookUpEdit role_cmb;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        public DevExpress.XtraEditors.SearchLookUpEdit store_cmb;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit advance_payment_inp;
        private DevExpress.XtraEditors.TextEdit phone_inp;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit address_inp;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit name_inp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit basic_salary_inp;
        private System.Windows.Forms.Label label1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraEditors.ComboBoxEdit pay_date_cmb;
        private System.Windows.Forms.BindingSource queryBindingSource;
        private System.Windows.Forms.BindingSource query_1BindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
    }
}