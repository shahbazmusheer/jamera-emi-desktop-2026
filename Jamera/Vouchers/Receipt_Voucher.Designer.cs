namespace Jamera.Vouchers
{
    partial class Receipt_Voucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receipt_Voucher));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.account_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.queryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.date_picker = new DevExpress.XtraEditors.DateEdit();
            this.balance_inp = new DevExpress.XtraEditors.LabelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.description_inp = new System.Windows.Forms.RichTextBox();
            this.ref_no_inp = new DevExpress.XtraEditors.TextEdit();
            this.amount_inp = new DevExpress.XtraEditors.TextEdit();
            this.payment_type_cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.save_and_print_btn = new DevExpress.XtraEditors.SimpleButton();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.new_btn = new DevExpress.XtraEditors.SimpleButton();
            this.save_btn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.account_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ref_no_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount_inp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payment_type_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(619, 376);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.account_cmb);
            this.panelControl4.Controls.Add(this.date_picker);
            this.panelControl4.Controls.Add(this.balance_inp);
            this.panelControl4.Controls.Add(this.panelControl5);
            this.panelControl4.Controls.Add(this.ref_no_inp);
            this.panelControl4.Controls.Add(this.amount_inp);
            this.panelControl4.Controls.Add(this.payment_type_cmb);
            this.panelControl4.Controls.Add(this.labelControl6);
            this.panelControl4.Controls.Add(this.labelControl4);
            this.panelControl4.Controls.Add(this.labelControl5);
            this.panelControl4.Controls.Add(this.labelControl7);
            this.panelControl4.Controls.Add(this.labelControl3);
            this.panelControl4.Controls.Add(this.labelControl1);
            this.panelControl4.Controls.Add(this.labelControl2);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 17);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(615, 312);
            this.panelControl4.TabIndex = 2;
            this.panelControl4.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl4_Paint);
            // 
            // account_cmb
            // 
            this.account_cmb.EditValue = "";
            this.account_cmb.EnterMoveNextControl = true;
            this.account_cmb.Location = new System.Drawing.Point(108, 58);
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
            this.account_cmb.Properties.PopupFormSize = new System.Drawing.Size(0, 280);
            this.account_cmb.Properties.ShowFooter = false;
            this.account_cmb.Properties.ValueMember = "Code";
            this.account_cmb.Properties.View = this.searchLookUpEdit1View;
            this.account_cmb.Size = new System.Drawing.Size(237, 24);
            this.account_cmb.TabIndex = 3;
            this.account_cmb.EditValueChanged += new System.EventHandler(this.account_cmb_EditValueChanged);
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
    "ounts where id!=\'2001\' and id != \'2002\';";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
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
            this.colCode,
            this.colName,
            this.colPhone,
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
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 174;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 425;
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
            this.colBalance.Width = 298;
            // 
            // date_picker
            // 
            this.date_picker.EditValue = null;
            this.date_picker.EnterMoveNextControl = true;
            this.date_picker.Location = new System.Drawing.Point(108, 17);
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
            this.date_picker.Size = new System.Drawing.Size(237, 24);
            this.date_picker.TabIndex = 1;
            this.date_picker.EditValueChanged += new System.EventHandler(this.date_picker_EditValueChanged);
            // 
            // balance_inp
            // 
            this.balance_inp.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balance_inp.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.balance_inp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.balance_inp.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.balance_inp.Location = new System.Drawing.Point(418, 58);
            this.balance_inp.Name = "balance_inp";
            this.balance_inp.Size = new System.Drawing.Size(187, 23);
            this.balance_inp.TabIndex = 18;
            this.balance_inp.Text = "0.00";
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.description_inp);
            this.panelControl5.Location = new System.Drawing.Point(108, 141);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(497, 120);
            this.panelControl5.TabIndex = 5;
            // 
            // description_inp
            // 
            this.description_inp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.description_inp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.description_inp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description_inp.Location = new System.Drawing.Point(2, 2);
            this.description_inp.Name = "description_inp";
            this.description_inp.Size = new System.Drawing.Size(493, 116);
            this.description_inp.TabIndex = 5;
            this.description_inp.Text = "";
            this.description_inp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.description_inp_KeyDown);
            // 
            // ref_no_inp
            // 
            this.ref_no_inp.EnterMoveNextControl = true;
            this.ref_no_inp.Location = new System.Drawing.Point(108, 100);
            this.ref_no_inp.Name = "ref_no_inp";
            this.ref_no_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ref_no_inp.Properties.Appearance.Options.UseFont = true;
            this.ref_no_inp.Size = new System.Drawing.Size(237, 24);
            this.ref_no_inp.TabIndex = 4;
            // 
            // amount_inp
            // 
            this.amount_inp.EnterMoveNextControl = true;
            this.amount_inp.Location = new System.Drawing.Point(108, 280);
            this.amount_inp.Name = "amount_inp";
            this.amount_inp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount_inp.Properties.Appearance.Options.UseFont = true;
            this.amount_inp.Size = new System.Drawing.Size(237, 24);
            this.amount_inp.TabIndex = 6;
            this.amount_inp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_inp_KeyPress);
            // 
            // payment_type_cmb
            // 
            this.payment_type_cmb.EditValue = "Cash";
            this.payment_type_cmb.EnterMoveNextControl = true;
            this.payment_type_cmb.Location = new System.Drawing.Point(474, 20);
            this.payment_type_cmb.Name = "payment_type_cmb";
            this.payment_type_cmb.Properties.AllowFocused = false;
            this.payment_type_cmb.Properties.AllowMouseWheel = false;
            this.payment_type_cmb.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_type_cmb.Properties.Appearance.Options.UseFont = true;
            this.payment_type_cmb.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_type_cmb.Properties.AppearanceDisabled.Options.UseFont = true;
            this.payment_type_cmb.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_type_cmb.Properties.AppearanceDropDown.Options.UseFont = true;
            this.payment_type_cmb.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_type_cmb.Properties.AppearanceFocused.Options.UseFont = true;
            this.payment_type_cmb.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_type_cmb.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.payment_type_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.payment_type_cmb.Properties.Items.AddRange(new object[] {
            "Cash",
            "Bank"});
            this.payment_type_cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.payment_type_cmb.Size = new System.Drawing.Size(131, 24);
            this.payment_type_cmb.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(10, 143);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(83, 18);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "Description :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(351, 61);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 18);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Balance :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(10, 282);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(59, 18);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Amount :";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(10, 103);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(59, 18);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Ref. No :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(10, 61);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(93, 18);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Account Title :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(351, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(117, 18);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Receipt Through :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(10, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 18);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Date :";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.save_and_print_btn);
            this.panelControl3.Controls.Add(this.cancel_btn);
            this.panelControl3.Controls.Add(this.new_btn);
            this.panelControl3.Controls.Add(this.save_btn);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 329);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(615, 45);
            this.panelControl3.TabIndex = 7;
            // 
            // save_and_print_btn
            // 
            this.save_and_print_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save_and_print_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.save_and_print_btn.Appearance.Options.UseFont = true;
            this.save_and_print_btn.Image = ((System.Drawing.Image)(resources.GetObject("save_and_print_btn.Image")));
            this.save_and_print_btn.Location = new System.Drawing.Point(329, 5);
            this.save_and_print_btn.Name = "save_and_print_btn";
            this.save_and_print_btn.Size = new System.Drawing.Size(160, 35);
            this.save_and_print_btn.TabIndex = 8;
            this.save_and_print_btn.Text = "Save && Print";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cancel_btn.Appearance.Options.UseFont = true;
            this.cancel_btn.Image = ((System.Drawing.Image)(resources.GetObject("cancel_btn.Image")));
            this.cancel_btn.Location = new System.Drawing.Point(495, 5);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(115, 35);
            this.cancel_btn.TabIndex = 9;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.new_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.new_btn.Appearance.Options.UseFont = true;
            this.new_btn.Image = ((System.Drawing.Image)(resources.GetObject("new_btn.Image")));
            this.new_btn.Location = new System.Drawing.Point(94, 5);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(108, 35);
            this.new_btn.TabIndex = 6;
            this.new_btn.Text = "New";
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.save_btn.Appearance.Options.UseFont = true;
            this.save_btn.Image = ((System.Drawing.Image)(resources.GetObject("save_btn.Image")));
            this.save_btn.Location = new System.Drawing.Point(208, 5);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(115, 35);
            this.save_btn.TabIndex = 7;
            this.save_btn.Text = "Save";
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(615, 15);
            this.panelControl2.TabIndex = 0;
            // 
            // Receipt_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 376);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Receipt_Voucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt Voucher";
            this.Load += new System.EventHandler(this.Receipt_Voucher_Load);
            this.Shown += new System.EventHandler(this.Receipt_Voucher_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.account_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ref_no_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount_inp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payment_type_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit payment_type_cmb;
        private DevExpress.XtraEditors.TextEdit amount_inp;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private System.Windows.Forms.RichTextBox description_inp;
        private DevExpress.XtraEditors.LabelControl balance_inp;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.SimpleButton new_btn;
        private DevExpress.XtraEditors.SimpleButton save_btn;
        private DevExpress.XtraEditors.DateEdit date_picker;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private System.Windows.Forms.BindingSource queryBindingSource;
        private DevExpress.XtraEditors.SearchLookUpEdit account_cmb;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton save_and_print_btn;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit ref_no_inp;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
    }
}