using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Jamera.Properties;
using DevExpress.LookAndFeel;

namespace Jamera.Application_Settings
{
    public partial class Skin_Style_Customizations : DevExpress.XtraEditors.XtraForm
    {
        //String Message_Title = "Error Alert";
        public String Skin_Name = Settings.Default.App_Default_Skin;
        public Skin_Style_Customizations()
        {
            InitializeComponent();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Skin_Name = UserLookAndFeel.Default.SkinName;
            Settings.Default.App_Default_Skin = Skin_Name;
            Settings.Default.Save();
            //XtraMessageBox.Show("UI skin saved, suyccessfully!");
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle(Settings.Default.App_Default_Skin);
            this.Close();
        }
    }
}