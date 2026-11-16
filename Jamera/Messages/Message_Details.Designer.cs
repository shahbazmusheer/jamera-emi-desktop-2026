namespace Jamera.Messages
{
    partial class Message_Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Message_Details));
            this.queryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.queryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.resend_btn = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.messages_type_cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.phone_inp = new DevExpress.XtraEditors.ButtonEdit();
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.progress_panel = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.sms_gateway_cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.message_inp = new System.Windows.Forms.RichTextBox();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chrators_count_lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.delete_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messages_type_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phone_inp.Properties)).BeginInit();
            this.progress_panel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sms_gateway_cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
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
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // queryBindingSource1
            // 
            this.queryBindingSource1.DataMember = "Query";
            this.queryBindingSource1.DataSource = this.sqlDataSource1;
            // 
            // resend_btn
            // 
            this.resend_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resend_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.resend_btn.Appearance.Options.UseFont = true;
            this.resend_btn.Image = ((System.Drawing.Image)(resources.GetObject("resend_btn.Image")));
            this.resend_btn.Location = new System.Drawing.Point(583, 5);
            this.resend_btn.Name = "resend_btn";
            this.resend_btn.Size = new System.Drawing.Size(122, 35);
            this.resend_btn.TabIndex = 25;
            this.resend_btn.Text = "Resend";
            this.resend_btn.Click += new System.EventHandler(this.resend_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(84, 11);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(152, 20);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Messages Sending ...";
            // 
            // messages_type_cmb
            // 
            this.messages_type_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.messages_type_cmb.EditValue = "English";
            this.messages_type_cmb.Location = new System.Drawing.Point(425, 12);
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
            this.messages_type_cmb.Size = new System.Drawing.Size(128, 24);
            this.messages_type_cmb.TabIndex = 39;
            this.messages_type_cmb.SelectedIndexChanged += new System.EventHandler(this.search_filter_cmb_SelectedIndexChanged);
            // 
            // phone_inp
            // 
            this.phone_inp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.phone_inp.Location = new System.Drawing.Point(130, 12);
            this.phone_inp.Name = "phone_inp";
            this.phone_inp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_inp.Properties.Appearance.Options.UseFont = true;
            this.phone_inp.Properties.ReadOnly = true;
            this.phone_inp.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.phone_inp_Properties_ButtonClick);
            this.phone_inp.Size = new System.Drawing.Size(173, 24);
            this.phone_inp.TabIndex = 38;
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(3, 15);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(112, 18);
            this.label.TabIndex = 37;
            this.label.Text = "Phone Number. :";
            // 
            // progress_panel
            // 
            this.progress_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progress_panel.Controls.Add(this.pictureBox1);
            this.progress_panel.Controls.Add(this.labelControl6);
            this.progress_panel.Location = new System.Drawing.Point(311, 2);
            this.progress_panel.Name = "progress_panel";
            this.progress_panel.Size = new System.Drawing.Size(247, 41);
            this.progress_panel.TabIndex = 29;
            this.progress_panel.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(309, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 18);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "Message Type :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.messages_type_cmb, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.phone_inp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl25, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.sms_gateway_cmb, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 49);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // labelControl25
            // 
            this.labelControl25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl25.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl25.Location = new System.Drawing.Point(567, 15);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(140, 18);
            this.labelControl25.TabIndex = 42;
            this.labelControl25.Text = "Send SMS Through  :";
            // 
            // sms_gateway_cmb
            // 
            this.sms_gateway_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sms_gateway_cmb.EditValue = "API";
            this.sms_gateway_cmb.Enabled = false;
            this.sms_gateway_cmb.Location = new System.Drawing.Point(713, 12);
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
            this.sms_gateway_cmb.Size = new System.Drawing.Size(130, 24);
            this.sms_gateway_cmb.TabIndex = 43;
            this.sms_gateway_cmb.SelectedIndexChanged += new System.EventHandler(this.sms_gateway_cmb_SelectedIndexChanged);
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.tableLayoutPanel1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(846, 49);
            this.panelControl4.TabIndex = 0;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.message_inp);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl6.Location = new System.Drawing.Point(0, 0);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(846, 393);
            this.panelControl6.TabIndex = 4;
            // 
            // message_inp
            // 
            this.message_inp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.message_inp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.message_inp.Font = new System.Drawing.Font("Jameel Noori Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.message_inp.Location = new System.Drawing.Point(2, 2);
            this.message_inp.MaxLength = 160;
            this.message_inp.Name = "message_inp";
            this.message_inp.Size = new System.Drawing.Size(842, 389);
            this.message_inp.TabIndex = 4;
            this.message_inp.Text = "";
            this.message_inp.TextChanged += new System.EventHandler(this.message_inp_TextChanged);
            this.message_inp.Leave += new System.EventHandler(this.message_inp_Leave);
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.panelControl6);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(2, 51);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(846, 393);
            this.panelControl5.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.panelControl5);
            this.panelControl3.Controls.Add(this.panelControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(850, 446);
            this.panelControl3.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(854, 495);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chrators_count_lbl);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.delete_btn);
            this.panelControl2.Controls.Add(this.progress_panel);
            this.panelControl2.Controls.Add(this.resend_btn);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 448);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(850, 45);
            this.panelControl2.TabIndex = 0;
            // 
            // chrators_count_lbl
            // 
            this.chrators_count_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chrators_count_lbl.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chrators_count_lbl.Location = new System.Drawing.Point(156, 5);
            this.chrators_count_lbl.Name = "chrators_count_lbl";
            this.chrators_count_lbl.Size = new System.Drawing.Size(10, 18);
            this.chrators_count_lbl.TabIndex = 35;
            this.chrators_count_lbl.Text = "0";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl3.Location = new System.Drawing.Point(12, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(138, 18);
            this.labelControl3.TabIndex = 34;
            this.labelControl3.Text = "Characters Count :";
            // 
            // delete_btn
            // 
            this.delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_btn.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_btn.Appearance.Options.UseFont = true;
            this.delete_btn.Image = ((System.Drawing.Image)(resources.GetObject("delete_btn.Image")));
            this.delete_btn.Location = new System.Drawing.Point(714, 5);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(127, 35);
            this.delete_btn.TabIndex = 30;
            this.delete_btn.Text = "Delete";
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // Message_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 495);
            this.Controls.Add(this.panelControl1);
            this.Name = "Message_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Message_Details_FormClosing);
            this.Load += new System.EventHandler(this.Message_Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messages_type_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phone_inp.Properties)).EndInit();
            this.progress_panel.ResumeLayout(false);
            this.progress_panel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sms_gateway_cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource queryBindingSource;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private System.Windows.Forms.BindingSource queryBindingSource1;
        private DevExpress.XtraEditors.SimpleButton resend_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit messages_type_cmb;
        public DevExpress.XtraEditors.ButtonEdit phone_inp;
        private DevExpress.XtraEditors.LabelControl label;
        private System.Windows.Forms.Panel progress_panel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private System.Windows.Forms.RichTextBox message_inp;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.ComboBoxEdit sms_gateway_cmb;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton delete_btn;
        private DevExpress.XtraEditors.LabelControl chrators_count_lbl;
    }
}