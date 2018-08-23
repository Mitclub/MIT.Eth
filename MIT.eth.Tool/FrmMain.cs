using MIT.Eth.Common;
using MIT.Eth.ETHNethereum;
using MIT.Eth.UI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MIT.Eth.Common.Consts;

namespace MIT.Eth.Tool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
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

        /// <summary>
        /// lock MIT token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;

                if (string.IsNullOrWhiteSpace(txtAccount.Text.Trim())){
                    lblError.Text = "[Amount] is invalid.";
                    lblError.Visible = true;
                    return;
                }

                var unLockResult = ClsNethereum.unLockAccount(this.txtPassword.Text.Trim());
                if (unLockResult.IsSuccess == false)
                {
                    lblError.Text = unLockResult.Message;
                    this.lblError.Visible = true;
                    return;
                }

                TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
                Int32 t = (Int32)cha.TotalSeconds;

                // lock Ether
                var lockResult = ClsNethereum.LockMIT(txtAccount.Text.Trim(),t);

                if (lockResult.IsSuccess)
                {
                    new FrmMessage(M_MessageType.Success, lockResult.Data, false).ShowDialog();
                }
                else
                {
                    new FrmMessage(M_MessageType.Error, lockResult.Message, false).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
        }

        /// <summary>
        /// unlock MIT token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;

                if (string.IsNullOrWhiteSpace(txtAccount.Text.Trim()))
                {
                    lblError.Text = "[Amount] is invalid.";
                    lblError.Visible = true;
                    return;
                }

                var unLockResult = ClsNethereum.unLockAccount(this.txtPassword.Text.Trim());
                if (unLockResult.IsSuccess == false)
                {
                    lblError.Text = unLockResult.Message;
                    this.lblError.Visible = true;
                    return;
                }
                
                // lock Ether
                var lockResult = ClsNethereum.UnlockMIT(txtAccount.Text.Trim());
                if (lockResult.IsSuccess)
                {
                    new FrmMessage(M_MessageType.Success, lockResult.Data, false).ShowDialog();
                }
                else
                {
                    new FrmMessage(M_MessageType.Error, lockResult.Message, false).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }

        }
    }
}
