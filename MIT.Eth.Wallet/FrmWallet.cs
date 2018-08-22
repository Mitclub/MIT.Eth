using MIT.Eth.Common;
using MIT.Eth.ETHNethereum;
using MIT.Eth.Model;
using MIT.Eth.UI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MIT.Eth.Common.Consts;

namespace MIT.Eth.Wallet
{
    public partial class FrmWallet : Form
    {
        #region Property
        /// <summary>
        /// 账号是否已创建
        /// </summary>
        private bool m_HasAccount
        {
            get
            {
                return !string.IsNullOrEmpty(ClsNethereum.M_DefultAccount);
            }
        }

        #endregion

        #region Events
        public FrmWallet()
        {
            InitializeComponent();
        }

        private void FrmCommand_Load(object sender, EventArgs e)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;

                // start geth
                ClsConsole.startGeth();

                //bgwkUpdate.RunWorkerAsync();
                timUpdate.Interval = 1000 * 30;
                timUpdate.Start();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPassword ps = new FrmPassword();
                ps.GetPasswordEvent += CreateAccount;
                ps.ShowDialog();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }

        }

        private void btnCopyAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(ClsNethereum.M_DefultAccount, true);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validateForSend())
                {
                    return;
                }

                var unLockResult = ClsNethereum.unLockAccount(this.txtPassword.Text.Trim());
                if (unLockResult.IsSuccess == false)
                {
                    new FrmMessage(M_MessageType.Error, unLockResult.Message, false).ShowDialog();
                    return;
                }

                ResponseModel<string> sendResult = null;

                if (rdoEther.Checked)
                {
                    // send Ether
                    sendResult = ClsNethereum.SendTransaction(ClsNethereum.M_DefultAccount, txtTo.Text.Trim(), Convert.ToDouble(txtAmount.Text));

                }
                else
                {
                    // send MIT
                    sendResult = ClsNethereum.SendMIT(ClsNethereum.M_DefultAccount, txtTo.Text.Trim(), Convert.ToDouble(txtAmount.Text));
                }

                if (sendResult.IsSuccess)
                {
                    new FrmMessage(M_MessageType.Success, sendResult.Data, false).ShowDialog();
                }
                else
                {
                    new FrmMessage(M_MessageType.Error, sendResult.Message, false).ShowDialog();
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }

        }

        private void timUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                if (bgwkUpdate.IsBusy != true)
                {
                    bgwkUpdate.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
        }

        private void bgwkUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DisplayFromAccount();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }

        }

        private bool validateForSend()
        {
            lblError.Hide();

            double dblAmount = 0;
            double.TryParse(txtAmount.Text.Trim(), out dblAmount);
            if (dblAmount <= 0)
            {
                txtAmount.Focus();
                lblError.Text = "";
                lblError.Show();
                return false;
            }

            return true;
        }

        #endregion

        #region Function
        private void DisplayFromAccount()
        {
            if (m_HasAccount)
            {
                this.lblAccount.Text = ClsNethereum.M_DefultAccount;

                // get ether:
                double dBalance = (double)ClsNethereum.GetMyBalance();
                this.lblBalanceEther.Text = dBalance.ToString("N");// Math.Round(dBalance, 5).ToString();

                // get MIT:
                var MIT = ClsNethereum.GetMITBalance(ClsNethereum.M_DefultAccount);
                if (MIT.IsSuccess)
                {
                    double dBalanceMIT = (double)MIT.Data;
                    this.lblBalanceMIT.Text = dBalanceMIT.ToString("N");// Math.Round(dBalanceMIT, 5).ToString("N");
                }

                // get MIT Locked status:
                var lockStatus = ClsNethereum.CheckMITLocked(ClsNethereum.M_DefultAccount);
                if (lockStatus.IsSuccess)
                {
                    this.lblLocked.Text = (!lockStatus.Data).ToString();
                }

                btnAddAccount.Enabled = false;
            }
            else
            {
                btnAddAccount.Enabled = true;
            }
        }

        private void CreateAccount(object sender, FrmPassword.GetPasswordEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(e.M_Password))
                {
                    if (ClsNethereum.createNewAccount(e.M_Password))
                    {
                        DisplayFromAccount();
                    }
                    else
                    {
                        string strMessage = @"The registration process is failed.It may be caused in unstable network environment.Please try again later. For repeated issue, please contact ";
                        FrmMessage msg = new FrmMessage(M_MessageType.Error
                                                        , strMessage
                                                        , true);
                        msg.ShowDialog();

                    }
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
        }

        #endregion
    }
}
