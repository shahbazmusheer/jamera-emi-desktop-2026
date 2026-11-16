namespace Jamera.Messages
{
    partial class Import_Phone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import_Phone));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.account_cmb = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.queryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOfficePhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHomePhone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.account_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Query";
            this.bindingSource1.DataSource = this.sqlDataSource1;
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
            // account_cmb
            // 
            this.account_cmb.Dock = System.Windows.Forms.DockStyle.Top;
            this.account_cmb.EditValue = "";
            this.account_cmb.Location = new System.Drawing.Point(0, 0);
            this.account_cmb.Margin = new System.Windows.Forms.Padding(0);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 24, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 24, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("account_cmb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Ok (Enter)", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 24, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("account_cmb.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Cancel (Esc)", null, null, true)});
            this.account_cmb.Properties.DataSource = this.queryBindingSource;
            this.account_cmb.Properties.DisplayMember = "Name";
            this.account_cmb.Properties.NullText = "Select account";
            this.account_cmb.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.account_cmb.Properties.PopupFindMode = DevExpress.XtraEditors.FindMode.Always;
            this.account_cmb.Properties.PopupFormMinSize = new System.Drawing.Size(502, 280);
            this.account_cmb.Properties.ShowFooter = false;
            this.account_cmb.Properties.ValueMember = "Code";
            this.account_cmb.Properties.View = this.searchLookUpEdit1View;
            this.account_cmb.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.account_cmb_Properties_ButtonClick);
            this.account_cmb.Size = new System.Drawing.Size(745, 24);
            this.account_cmb.TabIndex = 0;
            this.account_cmb.EditValueChanged += new System.EventHandler(this.account_cmb_EditValueChanged);
            this.account_cmb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Import_Phone_KeyDown);
            // 
            // queryBindingSource
            // 
            this.queryBindingSource.DataMember = "Query";
            this.queryBindingSource.DataSource = this.sqlDataSource1;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.Row.Options.UseTextOptions = true;
            this.searchLookUpEdit1View.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colAreaCode,
            this.colArea,
            this.colGroup,
            this.colCode,
            this.colName,
            this.colOfficePhone,
            this.colHomePhone});
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
            this.gridColumn1.FieldName = "Store.Code";
            this.gridColumn1.MaxWidth = 120;
            this.gridColumn1.MinWidth = 90;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // colAreaCode
            // 
            this.colAreaCode.FieldName = "Area Code";
            this.colAreaCode.MaxWidth = 120;
            this.colAreaCode.MinWidth = 90;
            this.colAreaCode.Name = "colAreaCode";
            this.colAreaCode.Visible = true;
            this.colAreaCode.VisibleIndex = 1;
            this.colAreaCode.Width = 101;
            // 
            // colArea
            // 
            this.colArea.FieldName = "Area";
            this.colArea.MaxWidth = 190;
            this.colArea.MinWidth = 140;
            this.colArea.Name = "colArea";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 2;
            this.colArea.Width = 144;
            // 
            // colGroup
            // 
            this.colGroup.FieldName = "Group";
            this.colGroup.MaxWidth = 180;
            this.colGroup.MinWidth = 130;
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 3;
            this.colGroup.Width = 136;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.MaxWidth = 120;
            this.colCode.MinWidth = 80;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 4;
            this.colCode.Width = 82;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 230;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 5;
            this.colName.Width = 271;
            // 
            // colOfficePhone
            // 
            this.colOfficePhone.FieldName = "Office Phone";
            this.colOfficePhone.MaxWidth = 130;
            this.colOfficePhone.MinWidth = 120;
            this.colOfficePhone.Name = "colOfficePhone";
            this.colOfficePhone.Visible = true;
            this.colOfficePhone.VisibleIndex = 6;
            this.colOfficePhone.Width = 130;
            // 
            // colHomePhone
            // 
            this.colHomePhone.FieldName = "Home Phone";
            this.colHomePhone.MaxWidth = 130;
            this.colHomePhone.MinWidth = 120;
            this.colHomePhone.Name = "colHomePhone";
            this.colHomePhone.Visible = true;
            this.colHomePhone.VisibleIndex = 7;
            this.colHomePhone.Width = 130;
            // 
            // Import_Phone
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 24);
            this.Controls.Add(this.account_cmb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Import_Phone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Phone";
            this.Load += new System.EventHandler(this.Import_Phone_Load);
            this.Shown += new System.EventHandler(this.Import_Phone_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Import_Phone_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.account_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraEditors.SearchLookUpEdit account_cmb;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.BindingSource queryBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colAreaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOfficePhone;
        private DevExpress.XtraGrid.Columns.GridColumn colHomePhone;
    }
}