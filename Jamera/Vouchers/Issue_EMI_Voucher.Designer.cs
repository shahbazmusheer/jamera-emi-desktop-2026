namespace Jamera.Vouchers
{
    partial class Issue_EMI_Voucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Issue_EMI_Voucher));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.description_inp = new System.Windows.Forms.RichTextBox();
            this.start_serial = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.save_btn = new DevExpress.XtraEditors.SimpleButton();
            this.end_serial = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.store_search_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.queryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.date_picker = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.queryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.start_serial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.end_serial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.store_search_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.description_inp);
            this.panelControl5.Location = new System.Drawing.Point(99, 98);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(447, 114);
            this.panelControl5.TabIndex = 5;
            // 
            // description_inp
            // 
            this.description_inp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.description_inp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.description_inp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description_inp.Location = new System.Drawing.Point(2, 2);
            this.description_inp.Name = "description_inp";
            this.description_inp.Size = new System.Drawing.Size(443, 110);
            this.description_inp.TabIndex = 5;
            this.description_inp.Text = "";
            // 
            // start_serial
            // 
            this.start_serial.EnterMoveNextControl = true;
            this.start_serial.Location = new System.Drawing.Point(99, 57);
            this.start_serial.Name = "start_serial";
            this.start_serial.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_serial.Properties.Appearance.Options.UseFont = true;
            this.start_serial.Size = new System.Drawing.Size(173, 24);
            this.start_serial.TabIndex = 3;
            this.start_serial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.start_serial_KeyPress);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.cancel_btn);
            this.panelControl3.Controls.Add(this.save_btn);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 222);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(558, 44);
            this.panelControl3.TabIndex = 0;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_btn.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Appearance.Options.UseFont = true;
            this.cancel_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancel_btn.ImageOptions.Image")));
            this.cancel_btn.Location = new System.Drawing.Point(429, 5);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(115, 35);
            this.cancel_btn.TabIndex = 28;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save_btn.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Appearance.Options.UseFont = true;
            this.save_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("save_btn.ImageOptions.Image")));
            this.save_btn.Location = new System.Drawing.Point(302, 5);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(121, 36);
            this.save_btn.TabIndex = 27;
            this.save_btn.Text = "Save";
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // end_serial
            // 
            this.end_serial.Location = new System.Drawing.Point(367, 57);
            this.end_serial.Name = "end_serial";
            this.end_serial.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_serial.Properties.Appearance.Options.UseFont = true;
            this.end_serial.Size = new System.Drawing.Size(179, 24);
            this.end_serial.TabIndex = 4;
            this.end_serial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.end_serial_KeyDown);
            this.end_serial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.end_serial_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Serial :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description :";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.store_search_cmb);
            this.panelControl4.Controls.Add(this.date_picker);
            this.panelControl4.Controls.Add(this.panelControl5);
            this.panelControl4.Controls.Add(this.start_serial);
            this.panelControl4.Controls.Add(this.end_serial);
            this.panelControl4.Controls.Add(this.label4);
            this.panelControl4.Controls.Add(this.label7);
            this.panelControl4.Controls.Add(this.label2);
            this.panelControl4.Controls.Add(this.label3);
            this.panelControl4.Controls.Add(this.label1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(558, 222);
            this.panelControl4.TabIndex = 0;
            // 
            // store_search_cmb
            // 
            this.store_search_cmb.EditValue = "";
            this.store_search_cmb.EnterMoveNextControl = true;
            this.store_search_cmb.Location = new System.Drawing.Point(367, 21);
            this.store_search_cmb.Name = "store_search_cmb";
            this.store_search_cmb.Properties.AllowFocused = false;
            this.store_search_cmb.Properties.AllowMouseWheel = false;
            this.store_search_cmb.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store_search_cmb.Properties.Appearance.Options.UseFont = true;
            this.store_search_cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.store_search_cmb.Properties.DataSource = this.queryBindingSource1;
            this.store_search_cmb.Properties.DisplayMember = "Name";
            this.store_search_cmb.Properties.NullText = "";
            this.store_search_cmb.Properties.PopupFormSize = new System.Drawing.Size(0, 280);
            this.store_search_cmb.Properties.PopupView = this.gridView4;
            this.store_search_cmb.Properties.ShowFooter = false;
            this.store_search_cmb.Properties.ValueMember = "Code";
            this.store_search_cmb.Size = new System.Drawing.Size(179, 24);
            this.store_search_cmb.TabIndex = 2;
            // 
            // queryBindingSource1
            // 
            this.queryBindingSource1.DataMember = "Query";
            this.queryBindingSource1.DataSource = this.sqlDataSource1;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "JAMERA_CONNECTION";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery2.Name = "Query";
            customSqlQuery2.Sql = "SELECT id as \'Code\',name as \'Name\',area_code as \'Area Code\',phone as \'Phone\' from" +
    " stores;\r\n";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // gridView4
            // 
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.Appearance.Row.Options.UseTextOptions = true;
            this.gridView4.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.colPhone});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsBehavior.ReadOnly = true;
            this.gridView4.OptionsCustomization.AllowColumnMoving = false;
            this.gridView4.OptionsCustomization.AllowColumnResizing = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView4.OptionsFind.AlwaysVisible = true;
            this.gridView4.OptionsFind.FindDelay = 100;
            this.gridView4.OptionsFind.SearchInPreview = true;
            this.gridView4.OptionsFind.ShowCloseButton = false;
            this.gridView4.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView4.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView4.OptionsMenu.EnableColumnMenu = false;
            this.gridView4.OptionsMenu.EnableFooterMenu = false;
            this.gridView4.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            this.gridView4.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
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
            // date_picker
            // 
            this.date_picker.EditValue = new System.DateTime(2019, 9, 15, 0, 0, 0, 0);
            this.date_picker.EnterMoveNextControl = true;
            this.date_picker.Location = new System.Drawing.Point(99, 21);
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
            this.date_picker.Properties.MaskSettings.Set("mask", "d");
            this.date_picker.Properties.NullDate = new System.DateTime(2019, 9, 29, 10, 1, 37, 635);
            this.date_picker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.date_picker.Size = new System.Drawing.Size(173, 24);
            this.date_picker.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(278, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Store :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(278, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "End Serial :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date :";
            // 
            // queryBindingSource
            // 
            this.queryBindingSource.DataMember = "Query";
            this.queryBindingSource.DataSource = this.sqlDataSource1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(558, 266);
            this.panelControl1.TabIndex = 4;
            // 
            // Issue_EMI_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 266);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Issue_EMI_Voucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue EMI Voucher";
            this.Load += new System.EventHandler(this.Issue_EMI_Voucher_Load);
            this.Shown += new System.EventHandler(this.Issue_EMI_Voucher_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Issue_EMI_Voucher_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.start_serial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.end_serial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.store_search_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_picker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton save_btn;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private System.Windows.Forms.RichTextBox description_inp;
        private DevExpress.XtraEditors.TextEdit start_serial;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.TextEdit end_serial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit date_picker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SearchLookUpEdit store_search_cmb;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.BindingSource queryBindingSource;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private System.Windows.Forms.BindingSource queryBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
    }
}