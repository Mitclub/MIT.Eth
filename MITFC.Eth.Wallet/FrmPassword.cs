using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MITFC.Eth.Wallet
{
    public partial class FrmPassword : Form
    {
        #region Properties
        public class GetPasswordEventArgs : EventArgs // 事件参数类
        {
            private string password = "";
            public string M_Password
            {
                get { return password; }
                set { password = value; }
            }
        }
        
        // 声明委托
        public delegate void GetPasswordEventHandler(object sender, GetPasswordEventArgs e);
        // 定义事件
        public event GetPasswordEventHandler GetPasswordEvent;

        #endregion

        #region Events
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                this.lblError.Text = "Please enter the password";
                this.lblError.Visible = true;

                this.txtPassword.Focus();
            }
            else if (txtPassword.Text == txtRepassword.Text)
            {
                GetPasswordEventArgs e1 = new GetPasswordEventArgs();
                e1.M_Password = this.txtPassword.Text;
                if (GetPasswordEvent != null)
                {
                    GetPasswordEvent(this, e1);
                    this.Close();
                }
            }
            else
            {
                this.lblError.Text = "Fatal: Passphrases do not match";
                this.lblError.Visible = true;

                this.txtRepassword.Focus();
            }
        }
        
        private void txtRepassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.btnOK_Click(sender, e); 
            }
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
