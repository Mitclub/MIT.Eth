using MIT.Eth.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIT.eth.Tool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            try
            {
                dtmLock.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
        }
    }
}
