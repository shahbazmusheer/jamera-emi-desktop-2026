namespace Jamera.Employees
{
    partial class Employee_Advance_Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee_Advance_Payment));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.date_picker = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.amount_inp = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.employee_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.queryBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdvanceLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.balance_inp = new DevExpress.XtraEditors.LabelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.description_inp = new System.Windows.Forms.RichTextBox();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.message_inp = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.characters_count_lbl = new DevExpress.XtraEditors.LabelControl();
            this.messages_type_cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.sms_gateway_cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.send_msg_chkbx = new DevExpress.XtraEditors.CheckEdit();
            this.new_btn = new DevExpress.XtraEditors.SimpleButton();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.save_btn = new DevExpress.XtraEditors.SimpleButton();
            this.queryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.queryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employee_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messages_type_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sms_gateway_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.send_msg_chkbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(621, 272);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.panelControl3.Controls.Add(this.tableLayoutPanel1);
            this.panelControl3.Controls.Add(this.panelControl6);
            this.panelControl3.Controls.Add(this.labelControl11);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(621, 176);
            this.panelControl3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.date_picker, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.amount_inp, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.employee_cmb, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.balance_inp, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(617, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 40;
            this.label5.Text = "Date :";
            // 
            // date_picker
            // 
            this.date_picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.date_picker.EditValue = null;
            this.date_picker.EnterMoveNextControl = true;
            this.date_picker.Location = new System.Drawing.Point(98, 16);
            this.date_picker.Name = "date_picker";
            this.date_picker.Properties.AllowFocused = false;
            this.date_picker.Properties.AllowMouseWheel = false;
            this.date_picker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_picker.Properties.Appearance.Options.UseFont = true;
            this.date_picker.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_picker.Properties.AppearanceDropDown.Options.UseFont = true;
            this.date_picker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_picker.Properties.CalendarTimeProperties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.date_picker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_picker.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.date_picker.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_picker.Properties.CalendarTimeProperties.EditFormat.FormatString = "d";
            this.date_picker.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_picker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.date_picker.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.date_picker.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_picker.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.date_picker.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_picker.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.date_picker.Properties.NullDate = new System.DateTime(2019, 9, 29, 10, 1, 37, 635);
            this.date_picker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.date_picker.Size = new System.Drawing.Size(169, 24);
            this.date_picker.TabIndex = 0;
            this.date_picker.EditValueChanged += new System.EventHandler(this.date_picker_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 40;
            this.label2.Text = "Amount :";
            // 
            // amount_inp
            // 
            this.amount_inp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.amount_inp.EditValue = "";
            this.amount_inp.EnterMoveNextControl = true;
            this.amount_inp.Location = new System.Drawing.Point(356, 51);
            this.amount_inp.Name = "amount_inp";
            this.amount_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount_inp.Properties.Appearance.Options.UseFont = true;
            this.amount_inp.Size = new System.Drawing.Size(258, 24);
            this.amount_inp.TabIndex = 2;
            this.amount_inp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_inp_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Employee :";
            // 
            // employee_cmb
            // 
            this.employee_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employee_cmb.EditValue = "";
            this.employee_cmb.EnterMoveNextControl = true;
            this.employee_cmb.Location = new System.Drawing.Point(356, 16);
            this.employee_cmb.Name = "employee_cmb";
            this.employee_cmb.Properties.AllowFocused = false;
            this.employee_cmb.Properties.AllowMouseWheel = false;
            this.employee_cmb.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_cmb.Properties.Appearance.Options.UseFont = true;
            this.employee_cmb.Properties.Appearance.Options.UseTextOptions = true;
            this.employee_cmb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.employee_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.employee_cmb.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.employee_cmb.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.employee_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.employee_cmb.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.employee_cmb.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.employee_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.employee_cmb.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.employee_cmb.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.employee_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.employee_cmb.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.employee_cmb.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.employee_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.employee_cmb.Properties.DataSource = this.queryBindingSource2;
            this.employee_cmb.Properties.DisplayMember = "Name";
            this.employee_cmb.Properties.NullText = "";
            this.employee_cmb.Properties.PopupFormMinSize = new System.Drawing.Size(600, 300);
            this.employee_cmb.Properties.PopupView = this.gridView2;
            this.employee_cmb.Properties.ShowFooter = false;
            this.employee_cmb.Properties.ValueMember = "Code";
            this.employee_cmb.Size = new System.Drawing.Size(258, 24);
            this.employee_cmb.TabIndex = 1;
            // 
            // queryBindingSource2
            // 
            this.queryBindingSource2.DataMember = "Query";
            this.queryBindingSource2.DataSource = this.sqlDataSource1;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "JAMERA_CONNECTION";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.Row.Options.UseTextOptions = true;
            this.gridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colAreaCode,
            this.colRole,
            this.colAdvanceLimit,
            this.colBalance});
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
            this.colCode.MaxWidth = 100;
            this.colCode.MinWidth = 80;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 100;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 250;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 263;
            // 
            // colAreaCode
            // 
            this.colAreaCode.FieldName = "Area Code";
            this.colAreaCode.MaxWidth = 140;
            this.colAreaCode.MinWidth = 120;
            this.colAreaCode.Name = "colAreaCode";
            this.colAreaCode.Visible = true;
            this.colAreaCode.VisibleIndex = 2;
            this.colAreaCode.Width = 140;
            // 
            // colRole
            // 
            this.colRole.FieldName = "Role";
            this.colRole.MaxWidth = 140;
            this.colRole.MinWidth = 120;
            this.colRole.Name = "colRole";
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 3;
            this.colRole.Width = 140;
            // 
            // colAdvanceLimit
            // 
            this.colAdvanceLimit.FieldName = "Advance Limit";
            this.colAdvanceLimit.MaxWidth = 150;
            this.colAdvanceLimit.MinWidth = 130;
            this.colAdvanceLimit.Name = "colAdvanceLimit";
            this.colAdvanceLimit.Visible = true;
            this.colAdvanceLimit.VisibleIndex = 4;
            this.colAdvanceLimit.Width = 150;
            // 
            // colBalance
            // 
            this.colBalance.FieldName = "Balance";
            this.colBalance.MaxWidth = 150;
            this.colBalance.MinWidth = 120;
            this.colBalance.Name = "colBalance";
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 5;
            this.colBalance.Width = 150;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(0, 60);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 18);
            this.labelControl4.TabIndex = 45;
            this.labelControl4.Text = "Balance :";
            // 
            // balance_inp
            // 
            this.balance_inp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.balance_inp.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balance_inp.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.balance_inp.Appearance.Options.UseFont = true;
            this.balance_inp.Appearance.Options.UseForeColor = true;
            this.balance_inp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.balance_inp.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.balance_inp.Location = new System.Drawing.Point(98, 52);
            this.balance_inp.Name = "balance_inp";
            this.balance_inp.Size = new System.Drawing.Size(169, 23);
            this.balance_inp.TabIndex = 2;
            this.balance_inp.Text = "0.00";
            // 
            // panelControl6
            // 
            this.panelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl6.Controls.Add(this.description_inp);
            this.panelControl6.Location = new System.Drawing.Point(100, 92);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(516, 58);
            this.panelControl6.TabIndex = 3;
            // 
            // description_inp
            // 
            this.description_inp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.description_inp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.description_inp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description_inp.Location = new System.Drawing.Point(2, 2);
            this.description_inp.Name = "description_inp";
            this.description_inp.Size = new System.Drawing.Size(512, 54);
            this.description_inp.TabIndex = 3;
            this.description_inp.Text = "";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(5, 92);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(83, 18);
            this.labelControl11.TabIndex = 43;
            this.labelControl11.Text = "Description :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.tableLayoutPanel9);
            this.panelControl2.Controls.Add(this.send_msg_chkbx);
            this.panelControl2.Controls.Add(this.new_btn);
            this.panelControl2.Controls.Add(this.cancel_btn);
            this.panelControl2.Controls.Add(this.save_btn);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 176);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(621, 96);
            this.panelControl2.TabIndex = 4;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.message_inp);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 33);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(617, 16);
            this.panelControl4.TabIndex = 49;
            this.panelControl4.Visible = false;
            // 
            // message_inp
            // 
            this.message_inp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.message_inp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.message_inp.EnableAutoDragDrop = true;
            this.message_inp.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.message_inp.Location = new System.Drawing.Point(2, 2);
            this.message_inp.MaxLength = 0;
            this.message_inp.Name = "message_inp";
            this.message_inp.Size = new System.Drawing.Size(613, 12);
            this.message_inp.TabIndex = 4;
            this.message_inp.Text = "";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(617, 31);
            this.tableLayoutPanel9.TabIndex = 48;
            this.tableLayoutPanel9.Visible = false;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 7;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel10.Controls.Add(this.characters_count_lbl, 6, 0);
            this.tableLayoutPanel10.Controls.Add(this.messages_type_cmb, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.labelControl10, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.sms_gateway_cmb, 4, 0);
            this.tableLayoutPanel10.Controls.Add(this.labelControl13, 5, 0);
            this.tableLayoutPanel10.Controls.Add(this.labelControl25, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(617, 32);
            this.tableLayoutPanel10.TabIndex = 42;
            // 
            // characters_count_lbl
            // 
            this.characters_count_lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.characters_count_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characters_count_lbl.Appearance.ForeColor = System.Drawing.Color.Black;
            this.characters_count_lbl.Appearance.Options.UseFont = true;
            this.characters_count_lbl.Appearance.Options.UseForeColor = true;
            this.characters_count_lbl.Location = new System.Drawing.Point(556, 7);
            this.characters_count_lbl.Name = "characters_count_lbl";
            this.characters_count_lbl.Size = new System.Drawing.Size(8, 18);
            this.characters_count_lbl.TabIndex = 39;
            this.characters_count_lbl.Text = "0";
            // 
            // messages_type_cmb
            // 
            this.messages_type_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messages_type_cmb.EditValue = "English";
            this.messages_type_cmb.Location = new System.Drawing.Point(231, 4);
            this.messages_type_cmb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messages_type_cmb.Name = "messages_type_cmb";
            this.messages_type_cmb.Properties.AllowFocused = false;
            this.messages_type_cmb.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messages_type_cmb.Properties.Appearance.Options.UseFont = true;
            this.messages_type_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messages_type_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.messages_type_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messages_type_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.messages_type_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messages_type_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.messages_type_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messages_type_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.messages_type_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.messages_type_cmb.Properties.Items.AddRange(new object[] {
            "English",
            "اردو"});
            this.messages_type_cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.messages_type_cmb.Size = new System.Drawing.Size(18, 24);
            this.messages_type_cmb.TabIndex = 40;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(120, 8);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(105, 18);
            this.labelControl10.TabIndex = 37;
            this.labelControl10.Text = "Message Type :";
            // 
            // sms_gateway_cmb
            // 
            this.sms_gateway_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sms_gateway_cmb.EditValue = "API";
            this.sms_gateway_cmb.Location = new System.Drawing.Point(398, 4);
            this.sms_gateway_cmb.Name = "sms_gateway_cmb";
            this.sms_gateway_cmb.Properties.AllowFocused = false;
            this.sms_gateway_cmb.Properties.AllowMouseWheel = false;
            this.sms_gateway_cmb.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sms_gateway_cmb.Properties.Appearance.Options.UseFont = true;
            this.sms_gateway_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sms_gateway_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.sms_gateway_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sms_gateway_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.sms_gateway_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sms_gateway_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.sms_gateway_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sms_gateway_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.sms_gateway_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sms_gateway_cmb.Properties.Items.AddRange(new object[] {
            "API",
            "Android Wifi"});
            this.sms_gateway_cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.sms_gateway_cmb.Size = new System.Drawing.Size(18, 24);
            this.sms_gateway_cmb.TabIndex = 42;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseForeColor = true;
            this.labelControl13.Location = new System.Drawing.Point(422, 7);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(128, 18);
            this.labelControl13.TabIndex = 38;
            this.labelControl13.Text = "Characters Count : ";
            // 
            // labelControl25
            // 
            this.labelControl25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl25.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl25.Appearance.Options.UseFont = true;
            this.labelControl25.Location = new System.Drawing.Point(255, 7);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(140, 18);
            this.labelControl25.TabIndex = 41;
            this.labelControl25.Text = "Send SMS Through  :";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 7);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 20);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "Message :";
            // 
            // send_msg_chkbx
            // 
            this.send_msg_chkbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.send_msg_chkbx.Location = new System.Drawing.Point(86, 62);
            this.send_msg_chkbx.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.send_msg_chkbx.Name = "send_msg_chkbx";
            this.send_msg_chkbx.Properties.AllowFocused = false;
            this.send_msg_chkbx.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send_msg_chkbx.Properties.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.send_msg_chkbx.Properties.Appearance.Options.UseFont = true;
            this.send_msg_chkbx.Properties.Appearance.Options.UseForeColor = true;
            this.send_msg_chkbx.Properties.Caption = "Send Message";
            this.send_msg_chkbx.Size = new System.Drawing.Size(137, 22);
            this.send_msg_chkbx.TabIndex = 47;
            this.send_msg_chkbx.Visible = false;
            // 
            // new_btn
            // 
            this.new_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.new_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.new_btn.Appearance.Options.UseFont = true;
            this.new_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("new_btn.ImageOptions.Image")));
            this.new_btn.Location = new System.Drawing.Point(244, 55);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(108, 35);
            this.new_btn.TabIndex = 4;
            this.new_btn.Text = "New";
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_btn.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Appearance.Options.UseFont = true;
            this.cancel_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancel_btn.ImageOptions.Image")));
            this.cancel_btn.Location = new System.Drawing.Point(489, 55);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(115, 35);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.Text = "Cancel";
            // 
            // save_btn
            // 
            this.save_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_btn.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Appearance.Options.UseFont = true;
            this.save_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("save_btn.ImageOptions.Image")));
            this.save_btn.Location = new System.Drawing.Point(360, 55);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(121, 36);
            this.save_btn.TabIndex = 5;
            this.save_btn.Text = "Save";
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // queryBindingSource1
            // 
            this.queryBindingSource1.DataMember = "Query";
            this.queryBindingSource1.DataSource = this.sqlDataSource1;
            // 
            // queryBindingSource
            // 
            this.queryBindingSource.DataMember = "Query";
            this.queryBindingSource.DataSource = this.sqlDataSource1;
            // 
            // Employee_Advance_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "Employee_Advance_Payment";
            this.Size = new System.Drawing.Size(621, 272);
            this.Load += new System.EventHandler(this.Employee_Advance_Payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employee_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messages_type_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sms_gateway_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.send_msg_chkbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private System.Windows.Forms.RichTextBox description_inp;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        public DevExpress.XtraEditors.SearchLookUpEdit employee_cmb;
        private System.Windows.Forms.BindingSource queryBindingSource;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.TextEdit amount_inp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton new_btn;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.SimpleButton save_btn;
        private System.Windows.Forms.BindingSource queryBindingSource1;
        private DevExpress.XtraEditors.DateEdit date_picker;
        private System.Windows.Forms.BindingSource queryBindingSource2;
        private DevExpress.XtraEditors.LabelControl balance_inp;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAreaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraGrid.Columns.GridColumn colAdvanceLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraEditors.LabelControl characters_count_lbl;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.RichTextBox message_inp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private DevExpress.XtraEditors.ComboBoxEdit messages_type_cmb;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ComboBoxEdit sms_gateway_cmb;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.CheckEdit send_msg_chkbx;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
