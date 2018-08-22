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
using static MIT.Eth.Common.Consts;

namespace MIT.Eth.UI.Utils
{
    public partial class FrmMessage : Form
    {
        private bool m_needAppendEmailAddress = false;

        #region Events
        public FrmMessage(M_MessageType messageType, string message, bool needAppendEmailAddress = false)
        {
            InitializeComponent();

            if (messageType == M_MessageType.Error)
            {
                imgWarn.Image = Properties.Resources.warn;
                lblMessageType.Text = "Error";
                this.Text = "X-Pocket - Error";
            }
            else if (messageType == M_MessageType.Success)
            {
                imgWarn.Image = Properties.Resources.ok;
                lblMessageType.Text = "Sucess";
                this.Text = "X-Pocket - Sucess";
            }
            else if (messageType == M_MessageType.Abort)
            {
                imgWarn.Image = Properties.Resources.warn;
                lblMessageType.Text = "Abort";
                this.Text = "X-Pocket - Abort";
            }

            this.txtMessage.Text = message;
            m_needAppendEmailAddress = needAppendEmailAddress;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            if (m_needAppendEmailAddress)
            {
                this.txtMessage.SelectionStart = txtMessage.TextLength;
                txtMessage.SelectionLength = 0;
                txtMessage.SelectionColor = ColorTranslator.FromHtml("#f27130");
                txtMessage.AppendText(Consts.M_Support_EMailAddress);
                txtMessage.SelectionColor = txtMessage.ForeColor;

            }

            this.btnOK.Focus();
        }

        #endregion
    }
}
