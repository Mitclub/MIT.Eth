using MIT.Eth.Common;
using MIT.Eth.ETHNethereum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIT.Eth.Wallet
{
    public partial class FrmAccount : Form
    {
        #region Events
        public FrmAccount()
        {
            InitializeComponent();
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtAccount.Text = ClsNethereum.M_DefultAccount;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtAccount.Text))
                {
                    MessageBox.Show(this, "Please enter your account.", "Account");
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
            }
        }

        #endregion
    }
}
