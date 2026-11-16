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

namespace Jamera
{
    public partial class Progress_Form : DevExpress.XtraWaitForm.WaitForm
    {
        public Progress_Form()
        {
            InitializeComponent();
        }

        //#region Overrides

        //public override void SetCaption(string caption)
        //{
        //    base.SetCaption(caption);
        //    this.label2.Text = caption;
        //}
        //public override void SetDescription(string description)
        //{
        //    base.SetDescription(description);
        //    this.label2.Text = description;
        //}
        //public override void ProcessCommand(Enum cmd, object arg)
        //{
        //    base.ProcessCommand(cmd, arg);
        //}

        //#endregion

        //public enum WaitFormCommand
        //{
        //}
    }
}