namespace Jamera.Items
{
    partial class Stock_Transaction_Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock_Transaction_Details));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.delete_btn = new DevExpress.XtraEditors.SimpleButton();
            this.view_details_rad = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.print_btn = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.code_lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.to_store_lbl = new DevExpress.XtraEditors.LabelControl();
            this.date_picker_lbl = new DevExpress.XtraEditors.LabelControl();
            this.from_store_lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.name_lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gatepass_lbl = new DevExpress.XtraEditors.LabelControl();
            this.remarks_label = new DevExpress.XtraEditors.TextEdit();
            this.total_quantity_lbl = new DevExpress.XtraEditors.TextEdit();
            this.no_of_items_lbl = new DevExpress.XtraEditors.TextEdit();
            this.update_btn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.edit_details_rad = new System.Windows.Forms.RadioButton();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.remarks_lbl = new DevExpress.XtraEditors.PanelControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Items_list_Container = new DevExpress.XtraGrid.GridControl();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remarks_label.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_quantity_lbl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.no_of_items_lbl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remarks_lbl)).BeginInit();
            this.remarks_lbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Items_list_Container)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // delete_btn
            // 
            this.delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_btn.Appearance.Options.UseFont = true;
            this.delete_btn.Enabled = false;
            this.delete_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("delete_btn.ImageOptions.Image")));
            this.delete_btn.Location = new System.Drawing.Point(684, 4);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(127, 35);
            this.delete_btn.TabIndex = 35;
            this.delete_btn.Text = "Delete";
            // 
            // view_details_rad
            // 
            this.view_details_rad.AutoSize = true;
            this.view_details_rad.Checked = true;
            this.view_details_rad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_details_rad.Location = new System.Drawing.Point(17, 11);
            this.view_details_rad.Name = "view_details_rad";
            this.view_details_rad.Size = new System.Drawing.Size(102, 22);
            this.view_details_rad.TabIndex = 0;
            this.view_details_rad.TabStop = true;
            this.view_details_rad.Text = "View Details";
            this.view_details_rad.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(814, 2);
            this.tableLayoutPanel2.TabIndex = 1;
            this.tableLayoutPanel2.Visible = false;
            // 
            // print_btn
            // 
            this.print_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.print_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.print_btn.Appearance.Options.UseFont = true;
            this.print_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("print_btn.ImageOptions.Image")));
            this.print_btn.Location = new System.Drawing.Point(720, 6);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(91, 35);
            this.print_btn.TabIndex = 25;
            this.print_btn.Text = "Print";
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26531F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26531F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.36735F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26531F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.code_lbl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.to_store_lbl, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.date_picker_lbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.from_store_lbl, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.name_lbl, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl7, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gatepass_lbl, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 79);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(3, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 18);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Date";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(127, 21);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 18);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Code";
            // 
            // code_lbl
            // 
            this.code_lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.code_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code_lbl.Appearance.Options.UseFont = true;
            this.code_lbl.Location = new System.Drawing.Point(132, 51);
            this.code_lbl.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.code_lbl.Name = "code_lbl";
            this.code_lbl.Size = new System.Drawing.Size(31, 18);
            this.code_lbl.TabIndex = 0;
            this.code_lbl.Text = "Null";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(681, 21);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(57, 18);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "To Store";
            // 
            // to_store_lbl
            // 
            this.to_store_lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.to_store_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_store_lbl.Appearance.Options.UseFont = true;
            this.to_store_lbl.Location = new System.Drawing.Point(686, 51);
            this.to_store_lbl.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.to_store_lbl.Name = "to_store_lbl";
            this.to_store_lbl.Size = new System.Drawing.Size(31, 18);
            this.to_store_lbl.TabIndex = 0;
            this.to_store_lbl.Text = "Null";
            // 
            // date_picker_lbl
            // 
            this.date_picker_lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.date_picker_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_picker_lbl.Appearance.Options.UseFont = true;
            this.date_picker_lbl.Location = new System.Drawing.Point(8, 51);
            this.date_picker_lbl.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.date_picker_lbl.Name = "date_picker_lbl";
            this.date_picker_lbl.Size = new System.Drawing.Size(31, 18);
            this.date_picker_lbl.TabIndex = 0;
            this.date_picker_lbl.Text = "Null";
            // 
            // from_store_lbl
            // 
            this.from_store_lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.from_store_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_store_lbl.Appearance.Options.UseFont = true;
            this.from_store_lbl.Location = new System.Drawing.Point(562, 51);
            this.from_store_lbl.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.from_store_lbl.Name = "from_store_lbl";
            this.from_store_lbl.Size = new System.Drawing.Size(31, 18);
            this.from_store_lbl.TabIndex = 0;
            this.from_store_lbl.Text = "Null";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(557, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 18);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "From Store";
            // 
            // name_lbl
            // 
            this.name_lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.name_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_lbl.Appearance.Options.UseFont = true;
            this.name_lbl.Location = new System.Drawing.Point(428, 51);
            this.name_lbl.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(31, 18);
            this.name_lbl.TabIndex = 0;
            this.name_lbl.Text = "Null";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(423, 21);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(39, 18);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Name";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(251, 21);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 18);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Gatepass.No";
            // 
            // gatepass_lbl
            // 
            this.gatepass_lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gatepass_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gatepass_lbl.Appearance.Options.UseFont = true;
            this.gatepass_lbl.Location = new System.Drawing.Point(256, 51);
            this.gatepass_lbl.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.gatepass_lbl.Name = "gatepass_lbl";
            this.gatepass_lbl.Size = new System.Drawing.Size(31, 18);
            this.gatepass_lbl.TabIndex = 0;
            this.gatepass_lbl.Text = "Null";
            // 
            // remarks_label
            // 
            this.remarks_label.Location = new System.Drawing.Point(520, 10);
            this.remarks_label.Name = "remarks_label";
            this.remarks_label.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remarks_label.Properties.Appearance.Options.UseFont = true;
            this.remarks_label.Properties.ReadOnly = true;
            this.remarks_label.Size = new System.Drawing.Size(190, 24);
            this.remarks_label.TabIndex = 13;
            // 
            // total_quantity_lbl
            // 
            this.total_quantity_lbl.Location = new System.Drawing.Point(316, 10);
            this.total_quantity_lbl.Name = "total_quantity_lbl";
            this.total_quantity_lbl.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_quantity_lbl.Properties.Appearance.Options.UseFont = true;
            this.total_quantity_lbl.Properties.ReadOnly = true;
            this.total_quantity_lbl.Size = new System.Drawing.Size(119, 24);
            this.total_quantity_lbl.TabIndex = 13;
            // 
            // no_of_items_lbl
            // 
            this.no_of_items_lbl.Location = new System.Drawing.Point(103, 10);
            this.no_of_items_lbl.Name = "no_of_items_lbl";
            this.no_of_items_lbl.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_of_items_lbl.Properties.Appearance.Options.UseFont = true;
            this.no_of_items_lbl.Properties.ReadOnly = true;
            this.no_of_items_lbl.Size = new System.Drawing.Size(96, 24);
            this.no_of_items_lbl.TabIndex = 13;
            // 
            // update_btn
            // 
            this.update_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.update_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_btn.Appearance.Options.UseFont = true;
            this.update_btn.Enabled = false;
            this.update_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("update_btn.ImageOptions.Image")));
            this.update_btn.Location = new System.Drawing.Point(558, 4);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(120, 35);
            this.update_btn.TabIndex = 34;
            this.update_btn.Text = "Update";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(447, 13);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(67, 18);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Remarks :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.tableLayoutPanel2);
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(818, 85);
            this.panelControl2.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.delete_btn);
            this.panelControl3.Controls.Add(this.update_btn);
            this.panelControl3.Controls.Add(this.edit_details_rad);
            this.panelControl3.Controls.Add(this.view_details_rad);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 4);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(814, 10);
            this.panelControl3.TabIndex = 2;
            this.panelControl3.Visible = false;
            // 
            // edit_details_rad
            // 
            this.edit_details_rad.AutoSize = true;
            this.edit_details_rad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_details_rad.Location = new System.Drawing.Point(153, 11);
            this.edit_details_rad.Name = "edit_details_rad";
            this.edit_details_rad.Size = new System.Drawing.Size(96, 22);
            this.edit_details_rad.TabIndex = 0;
            this.edit_details_rad.Text = "Edit Details";
            this.edit_details_rad.UseVisualStyleBackColor = true;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(211, 13);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(103, 18);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Total Quantity :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "No. of Items :";
            // 
            // remarks_lbl
            // 
            this.remarks_lbl.Controls.Add(this.remarks_label);
            this.remarks_lbl.Controls.Add(this.total_quantity_lbl);
            this.remarks_lbl.Controls.Add(this.no_of_items_lbl);
            this.remarks_lbl.Controls.Add(this.print_btn);
            this.remarks_lbl.Controls.Add(this.labelControl10);
            this.remarks_lbl.Controls.Add(this.labelControl11);
            this.remarks_lbl.Controls.Add(this.labelControl1);
            this.remarks_lbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.remarks_lbl.Location = new System.Drawing.Point(2, 414);
            this.remarks_lbl.Name = "remarks_lbl";
            this.remarks_lbl.Size = new System.Drawing.Size(818, 46);
            this.remarks_lbl.TabIndex = 1;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemCode,
            this.colItemName,
            this.colModel,
            this.colSaleRate,
            this.colQuantity,
            this.gridColumn2,
            this.gridColumn1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.Items_list_Container;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.SearchInPreview = true;
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
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // colItemCode
            // 
            this.colItemCode.FieldName = "Item Code";
            this.colItemCode.MaxWidth = 120;
            this.colItemCode.MinWidth = 100;
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.OptionsColumn.AllowEdit = false;
            this.colItemCode.OptionsColumn.ReadOnly = true;
            this.colItemCode.Visible = true;
            this.colItemCode.VisibleIndex = 0;
            this.colItemCode.Width = 100;
            // 
            // colItemName
            // 
            this.colItemName.FieldName = "Item Name";
            this.colItemName.MinWidth = 250;
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.ReadOnly = true;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 1;
            this.colItemName.Width = 250;
            // 
            // colModel
            // 
            this.colModel.FieldName = "Model";
            this.colModel.MaxWidth = 180;
            this.colModel.MinWidth = 140;
            this.colModel.Name = "colModel";
            this.colModel.OptionsColumn.AllowEdit = false;
            this.colModel.OptionsColumn.ReadOnly = true;
            this.colModel.Visible = true;
            this.colModel.VisibleIndex = 2;
            this.colModel.Width = 140;
            // 
            // colSaleRate
            // 
            this.colSaleRate.FieldName = "Sale Rate";
            this.colSaleRate.MaxWidth = 120;
            this.colSaleRate.MinWidth = 110;
            this.colSaleRate.Name = "colSaleRate";
            this.colSaleRate.OptionsColumn.AllowEdit = false;
            this.colSaleRate.OptionsColumn.ReadOnly = true;
            this.colSaleRate.Visible = true;
            this.colSaleRate.VisibleIndex = 3;
            this.colSaleRate.Width = 110;
            // 
            // colQuantity
            // 
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MaxWidth = 150;
            this.colQuantity.MinWidth = 120;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.OptionsColumn.ReadOnly = true;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            this.colQuantity.Width = 120;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Remarks";
            this.gridColumn1.MinWidth = 450;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 450;
            // 
            // Items_list_Container
            // 
            this.Items_list_Container.DataMember = "Query";
            this.Items_list_Container.DataSource = this.sqlDataSource1;
            this.Items_list_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Items_list_Container.Location = new System.Drawing.Point(2, 2);
            this.Items_list_Container.MainView = this.gridView1;
            this.Items_list_Container.Name = "Items_list_Container";
            this.Items_list_Container.Size = new System.Drawing.Size(814, 323);
            this.Items_list_Container.TabIndex = 3;
            this.Items_list_Container.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.Items_list_Container);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 87);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(818, 327);
            this.panelControl4.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.remarks_lbl);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(822, 462);
            this.panelControl1.TabIndex = 5;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Returned";
            this.gridColumn2.MaxWidth = 120;
            this.gridColumn2.MinWidth = 100;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 100;
            // 
            // Stock_Transaction_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 462);
            this.Controls.Add(this.panelControl1);
            this.MinimumSize = new System.Drawing.Size(824, 494);
            this.Name = "Stock_Transaction_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Transaction Details";
            this.Load += new System.EventHandler(this.Stock_Transaction_Details_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remarks_label.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_quantity_lbl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.no_of_items_lbl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remarks_lbl)).EndInit();
            this.remarks_lbl.ResumeLayout(false);
            this.remarks_lbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Items_list_Container)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton delete_btn;
        private System.Windows.Forms.RadioButton view_details_rad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton print_btn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl code_lbl;
        private DevExpress.XtraEditors.TextEdit remarks_label;
        private DevExpress.XtraEditors.TextEdit total_quantity_lbl;
        private DevExpress.XtraEditors.TextEdit no_of_items_lbl;
        private DevExpress.XtraEditors.SimpleButton update_btn;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl remarks_lbl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl Items_list_Container;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl name_lbl;
        private DevExpress.XtraEditors.LabelControl from_store_lbl;
        private DevExpress.XtraEditors.LabelControl to_store_lbl;
        private System.Windows.Forms.RadioButton edit_details_rad;
        private DevExpress.XtraEditors.LabelControl date_picker_lbl;
        private DevExpress.XtraGrid.Columns.GridColumn colItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colModel;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleRate;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraEditors.LabelControl gatepass_lbl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}