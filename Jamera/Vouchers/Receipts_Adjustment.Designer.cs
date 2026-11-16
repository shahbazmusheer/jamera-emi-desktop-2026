namespace Jamera.Vouchers
{
    partial class Receipts_Adjustment
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receipts_Adjustment));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery3 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery4 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.list = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sr_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.due_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.due_amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rec_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.emi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rec_amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.balance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.entries_counter = new System.Windows.Forms.Label();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.save_btn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.store_name_lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ref_lbl = new DevExpress.XtraEditors.LabelControl();
            this.cust_name_lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.prev_bal_lbl = new DevExpress.XtraEditors.LabelControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(962, 510);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.list);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 47);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(958, 413);
            this.panelControl4.TabIndex = 2;
            // 
            // list
            // 
            this.list.DataMember = "Query_3";
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.Location = new System.Drawing.Point(2, 2);
            this.list.MainView = this.gridView1;
            this.list.Name = "list";
            this.list.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemDateEdit1});
            this.list.Size = new System.Drawing.Size(954, 409);
            this.list.TabIndex = 4;
            this.list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.list.Click += new System.EventHandler(this.list_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.sr_no,
            this.due_date,
            this.due_amount,
            this.rec_date,
            this.emi,
            this.rec_amount,
            this.balance,
            this.gridColumn1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.list;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsFilter.MRUColumnFilterListCount = 7;
            this.gridView1.OptionsFilter.MRUFilterListCount = 7;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 10;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.ColumnChanged += new System.EventHandler(this.gridView1_ColumnChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
            // 
            // sr_no
            // 
            this.sr_no.Caption = "Sr.No";
            this.sr_no.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sr_no.FieldName = "Sr.No";
            this.sr_no.MaxWidth = 120;
            this.sr_no.MinWidth = 100;
            this.sr_no.Name = "sr_no";
            this.sr_no.Visible = true;
            this.sr_no.VisibleIndex = 1;
            this.sr_no.Width = 100;
            // 
            // due_date
            // 
            this.due_date.Caption = "Due Date";
            this.due_date.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.due_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.due_date.FieldName = "Due Date";
            this.due_date.MinWidth = 130;
            this.due_date.Name = "due_date";
            this.due_date.Visible = true;
            this.due_date.VisibleIndex = 2;
            this.due_date.Width = 151;
            // 
            // due_amount
            // 
            this.due_amount.Caption = "Due Amount";
            this.due_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.due_amount.FieldName = "Due Amount";
            this.due_amount.MinWidth = 140;
            this.due_amount.Name = "due_amount";
            this.due_amount.Visible = true;
            this.due_amount.VisibleIndex = 3;
            this.due_amount.Width = 148;
            // 
            // rec_date
            // 
            this.rec_date.AppearanceCell.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rec_date.AppearanceCell.BackColor2 = System.Drawing.Color.MidnightBlue;
            this.rec_date.AppearanceCell.ForeColor = System.Drawing.Color.White;
            this.rec_date.AppearanceCell.Options.UseBackColor = true;
            this.rec_date.AppearanceCell.Options.UseForeColor = true;
            this.rec_date.Caption = "Reciept Date";
            this.rec_date.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.rec_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rec_date.FieldName = "Reciept Date";
            this.rec_date.MinWidth = 130;
            this.rec_date.Name = "rec_date";
            this.rec_date.Visible = true;
            this.rec_date.VisibleIndex = 4;
            this.rec_date.Width = 130;
            // 
            // emi
            // 
            this.emi.AppearanceCell.BackColor = System.Drawing.Color.DarkSlateGray;
            this.emi.AppearanceCell.BackColor2 = System.Drawing.Color.DarkTurquoise;
            this.emi.AppearanceCell.BorderColor = System.Drawing.Color.MidnightBlue;
            this.emi.AppearanceCell.ForeColor = System.Drawing.Color.White;
            this.emi.AppearanceCell.Options.UseBackColor = true;
            this.emi.AppearanceCell.Options.UseBorderColor = true;
            this.emi.AppearanceCell.Options.UseForeColor = true;
            this.emi.Caption = "EMI #";
            this.emi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.emi.FieldName = "EMI #";
            this.emi.MinWidth = 100;
            this.emi.Name = "emi";
            this.emi.Visible = true;
            this.emi.VisibleIndex = 5;
            this.emi.Width = 100;
            // 
            // rec_amount
            // 
            this.rec_amount.AppearanceCell.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rec_amount.AppearanceCell.BackColor2 = System.Drawing.Color.MidnightBlue;
            this.rec_amount.AppearanceCell.ForeColor = System.Drawing.Color.White;
            this.rec_amount.AppearanceCell.Options.UseBackColor = true;
            this.rec_amount.AppearanceCell.Options.UseForeColor = true;
            this.rec_amount.Caption = "Recieved Amount";
            this.rec_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rec_amount.FieldName = "Recieved Amount";
            this.rec_amount.MinWidth = 150;
            this.rec_amount.Name = "rec_amount";
            this.rec_amount.Visible = true;
            this.rec_amount.VisibleIndex = 6;
            this.rec_amount.Width = 161;
            // 
            // balance
            // 
            this.balance.Caption = "Balance";
            this.balance.FieldName = "Balance";
            this.balance.MinWidth = 130;
            this.balance.Name = "balance";
            this.balance.Visible = true;
            this.balance.VisibleIndex = 7;
            this.balance.Width = 130;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Remarks";
            this.gridColumn1.MinWidth = 200;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 200;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            serializableAppearanceObject5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            serializableAppearanceObject5.BackColor2 = System.Drawing.Color.Red;
            serializableAppearanceObject5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject5.ForeColor = System.Drawing.Color.White;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject5.Options.UseFont = true;
            serializableAppearanceObject5.Options.UseForeColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Maroon;
            serializableAppearanceObject6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            serializableAppearanceObject6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject6.ForeColor = System.Drawing.Color.White;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject6.Options.UseFont = true;
            serializableAppearanceObject6.Options.UseForeColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Maroon;
            serializableAppearanceObject7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            serializableAppearanceObject7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject7.ForeColor = System.Drawing.Color.White;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject7.Options.UseFont = true;
            serializableAppearanceObject7.Options.UseForeColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Maroon;
            serializableAppearanceObject8.BackColor2 = System.Drawing.Color.Maroon;
            serializableAppearanceObject8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject8.ForeColor = System.Drawing.Color.White;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject8.Options.UseFont = true;
            serializableAppearanceObject8.Options.UseForeColor = true;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "X", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.HideSelection = false;
            this.repositoryItemButtonEdit1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.repositoryItemButtonEdit1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemButtonEdit1.MaxLength = -1;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemComboBox1.Appearance.Options.UseFont = true;
            this.repositoryItemComboBox1.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemComboBox1.AppearanceDisabled.Options.UseFont = true;
            this.repositoryItemComboBox1.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemComboBox1.AppearanceDropDown.Options.UseFont = true;
            this.repositoryItemComboBox1.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemComboBox1.AppearanceFocused.Options.UseFont = true;
            this.repositoryItemComboBox1.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemComboBox1.AppearanceReadOnly.Options.UseFont = true;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "W.S",
            "R.P",
            "C.P"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.tableLayoutPanel6);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 460);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(958, 48);
            this.panelControl3.TabIndex = 13;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel6.Controls.Add(this.entries_counter, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cancel_btn, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.save_btn, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(954, 42);
            this.tableLayoutPanel6.TabIndex = 15;
            // 
            // entries_counter
            // 
            this.entries_counter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.entries_counter.AutoSize = true;
            this.entries_counter.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entries_counter.ForeColor = System.Drawing.Color.RoyalBlue;
            this.entries_counter.Location = new System.Drawing.Point(3, 12);
            this.entries_counter.Name = "entries_counter";
            this.entries_counter.Size = new System.Drawing.Size(147, 18);
            this.entries_counter.TabIndex = 15;
            this.entries_counter.Text = "Receipts Count :  0";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cancel_btn.Appearance.Options.UseFont = true;
            this.cancel_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancel_btn.ImageOptions.Image")));
            this.cancel_btn.Location = new System.Drawing.Point(837, 3);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(114, 35);
            this.cancel_btn.TabIndex = 18;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.save_btn.Appearance.Options.UseFont = true;
            this.save_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("save_btn.ImageOptions.Image")));
            this.save_btn.Location = new System.Drawing.Point(718, 3);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(113, 35);
            this.save_btn.TabIndex = 15;
            this.save_btn.Text = "Apply";
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl6);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(958, 45);
            this.panelControl2.TabIndex = 0;
            // 
            // panelControl6
            // 
            this.panelControl6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(229)))));
            this.panelControl6.Appearance.Options.UseBackColor = true;
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelControl6.Controls.Add(this.tableLayoutPanel3);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl6.Location = new System.Drawing.Point(2, 2);
            this.panelControl6.LookAndFeel.SkinName = "Office 2007 Green";
            this.panelControl6.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(954, 40);
            this.panelControl6.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.store_name_lbl, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl3, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.ref_lbl, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.cust_name_lbl, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl6, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl1, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.prev_bal_lbl, 7, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(950, 36);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // store_name_lbl
            // 
            this.store_name_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.store_name_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store_name_lbl.Appearance.Options.UseFont = true;
            this.store_name_lbl.AutoEllipsis = true;
            this.store_name_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.store_name_lbl.Location = new System.Drawing.Point(67, 9);
            this.store_name_lbl.Name = "store_name_lbl";
            this.store_name_lbl.Size = new System.Drawing.Size(190, 18);
            this.store_name_lbl.TabIndex = 17;
            this.store_name_lbl.Text = "null";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(3, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 18);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Store :";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(464, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 18);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Customer :";
            // 
            // ref_lbl
            // 
            this.ref_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ref_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ref_lbl.Appearance.Options.UseFont = true;
            this.ref_lbl.AutoEllipsis = true;
            this.ref_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.ref_lbl.Location = new System.Drawing.Point(333, 9);
            this.ref_lbl.Name = "ref_lbl";
            this.ref_lbl.Size = new System.Drawing.Size(125, 18);
            this.ref_lbl.TabIndex = 17;
            this.ref_lbl.Text = "null";
            // 
            // cust_name_lbl
            // 
            this.cust_name_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cust_name_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cust_name_lbl.Appearance.Options.UseFont = true;
            this.cust_name_lbl.AutoEllipsis = true;
            this.cust_name_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.cust_name_lbl.Location = new System.Drawing.Point(544, 9);
            this.cust_name_lbl.Name = "cust_name_lbl";
            this.cust_name_lbl.Size = new System.Drawing.Size(190, 18);
            this.cust_name_lbl.TabIndex = 17;
            this.cust_name_lbl.Text = "null";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(263, 9);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 18);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Ref. No :";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(740, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Prev. Bal :";
            // 
            // prev_bal_lbl
            // 
            this.prev_bal_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.prev_bal_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prev_bal_lbl.Appearance.Options.UseFont = true;
            this.prev_bal_lbl.AutoEllipsis = true;
            this.prev_bal_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.prev_bal_lbl.Location = new System.Drawing.Point(820, 9);
            this.prev_bal_lbl.Name = "prev_bal_lbl";
            this.prev_bal_lbl.Size = new System.Drawing.Size(127, 18);
            this.prev_bal_lbl.TabIndex = 17;
            this.prev_bal_lbl.Text = "null";
            // 
            // dockManager1
            // 
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "JAMERA_CONNECTION";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery3.Name = "Members_List";
            customSqlQuery3.Sql = resources.GetString("customSqlQuery3.Sql");
            customSqlQuery4.Name = "Query";
            customSqlQuery4.Sql = resources.GetString("customSqlQuery4.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery3,
            customSqlQuery4});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Code";
            this.gridColumn2.MinWidth = 120;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 120;
            // 
            // Receipts_Adjustment
            // 
            this.ClientSize = new System.Drawing.Size(962, 510);
            this.Controls.Add(this.panelControl1);
            this.Name = "Receipts_Adjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipts Adjustment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Receipts_Adjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.GridControl list;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.SimpleButton save_btn;
        private System.Windows.Forms.Label entries_counter;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl store_name_lbl;
        private DevExpress.XtraEditors.LabelControl ref_lbl;
        private DevExpress.XtraEditors.LabelControl cust_name_lbl;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Columns.GridColumn sr_no;
        private DevExpress.XtraGrid.Columns.GridColumn due_date;
        private DevExpress.XtraGrid.Columns.GridColumn due_amount;
        private DevExpress.XtraGrid.Columns.GridColumn rec_amount;
        private DevExpress.XtraGrid.Columns.GridColumn rec_date;
        private DevExpress.XtraGrid.Columns.GridColumn emi;
        private DevExpress.XtraGrid.Columns.GridColumn balance;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl prev_bal_lbl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}