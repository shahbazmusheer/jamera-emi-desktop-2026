namespace Jamera
{
    partial class UC_Opener_Form
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
            this.contents_container = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.contents_container)).BeginInit();
            this.SuspendLayout();
            // 
            // contents_container
            // 
            this.contents_container.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.contents_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contents_container.Location = new System.Drawing.Point(0, 0);
            this.contents_container.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.contents_container.Name = "contents_container";
            this.contents_container.Size = new System.Drawing.Size(814, 562);
            this.contents_container.TabIndex = 0;
            // 
            // UC_Opener_Form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 562);
            this.Controls.Add(this.contents_container);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_Opener_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Larger_Second_Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UC_Opener_Form_FormClosing);
            this.Load += new System.EventHandler(this.Larger_Second_Window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contents_container)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl contents_container;
    }
}