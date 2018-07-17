using MITFC.Eth.Common;
using MITFC.Eth.ETHNethereum;
using MITFC.Eth.Model;
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
using static MITFC.Eth.Common.Consts;

namespace MITFC.Eth.Wallet
{
    public partial class FrmWallet : Form
    {
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

                bgwkUpdate.RunWorkerAsync();
                timUpdate.Interval = 1000 * 60 * 1;
                timUpdate.Start();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmAccount().ShowDialog();
                DisplayFromAccount();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
            }

        }

        private void btnCopyAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(Consts.M_DefultAccount, true);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
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
                    sendResult = ClsNethereum.SendTransaction(Consts.M_DefultAccount, txtTo.Text.Trim(), Convert.ToDouble(txtAmount.Text));

                }
                else
                {
                    // send MITFC
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
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
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
                ClsCommon.WriteLog(ex.ToString(), Consts.LogType.M_Error);
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
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
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
            if (string.IsNullOrWhiteSpace(Consts.M_DefultAccount))
            {
            }
            else
            {
                this.lblAccount.Text = Consts.M_DefultAccount;

                // get ether:
                double dBalance = (double)ClsNethereum.GetMyBalance();
                this.lblBalanceEther.Text = dBalance.ToString("N");// Math.Round(dBalance, 5).ToString();

                // get MITFC:
                var mitfc = ClsNethereum.GetMITFCBalance(Consts.M_DefultAccount);
                if (mitfc.IsSuccess)
                {
                    double dBalanceMitfc = (double)mitfc.Data;
                    this.lblBalanceMITFC.Text = dBalanceMitfc.ToString("N");// Math.Round(dBalanceMitfc, 5).ToString("N");
                }

                // get MITFC Locked status:
                var lockStatus = ClsNethereum.CheckMITFCLocked(Consts.M_DefultAccount);
                if (lockStatus.IsSuccess)
                {
                    this.lblLocked.Text = (!lockStatus.Data).ToString();
                }

            }

        }

        #endregion
    }
}
