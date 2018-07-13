using MITFC.Eth.Common;
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

namespace MITFC.Eth.Wallet
{
    public partial class FrmCommand : Form
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process();

        public FrmCommand()
        {
            InitializeComponent();
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            process.StandardInput.WriteLine(txtCommand.Text.Trim());

        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnCommand_Click(sender, e);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (process != null)
                process.Close();
        }

        private void FrmCommand_Load(object sender, EventArgs e)
        {
            ClsNethereum.GetGasprise();
            ClsNethereum.GetMyBalance();
        }
    }
}
