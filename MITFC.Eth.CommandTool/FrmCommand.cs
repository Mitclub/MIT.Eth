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

namespace MITFC.Eth.CommandTool
{
    public partial class FrmCommand : Form
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process();

        public FrmCommand()
        {
            InitializeComponent();
        }

        private void tlbStart_Click(object sender, EventArgs e)
        {
            string strAppPath = Application.StartupPath;
            Control.CheckForIllegalCrossThreadCalls = false;
            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = strAppPath + "\\Geth\\";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            //Process.Start("cmd.exe");
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Start();
            //process.ProcessorAffinity = (IntPtr)(0x0001 | 0x0002);    // 使用cpu1和cpu2
            process.ProcessorAffinity = (IntPtr)0x0001; // 使用cpu1

            string strIp = ClsCommon.ClintInfor.M_IP;
            process.StandardInput.WriteLine("geth.exe --identity \"DXCC\" --rpc --rpccorsdomain \" * \" --datadir \"" + strAppPath + "\\Geth\\DXCC" + "\" --rpcaddr " + strIp + " --port \"30302\" --rpcport " + Consts.M_Rpcport + " --rpcapi \"db,eth,net,web3\" --networkid 98888 --syncmode full --bootnodes \"enode://d19f3f601ef6463dc6870ef8dd0934b512f9eb69b2f643e725020b161090e37db9a7bf00c4ec0b878ca964c7586b4718e7f3af8474541d3b946b44e944da62f9@15.107.28.20:30302,enode://a3479a5c883d9de87ab01fe01339448b6cf7d905bf28e3c80fe4d6112ca7e6b2b21e0e503bb9e4ddb906b92e5184600897857d34a179c9edc60c66b28d713aa4@15.107.28.21:30302,enode://e493cc24ed719786fd3f21364fe9633c072b97dde070a767203d51909273a685a41f235be760f310bb990067a254cb41d6c2fc9bed25245c7d224145da9b3e9d@15.107.28.19:30302,enode://97594ddd96a248665c0cbdd42c45b2ee1c93f94182ab3b1fabf06063b40f5613c36d6972c02232a1c3efbbba64f2bd1607a0454ea1b2a9110700b06f0331a382@15.107.29.13:30302\" console");
            process.BeginOutputReadLine();

        }

        private void tblNewUser_Click(object sender, EventArgs e)
        {
            process.StandardInput.WriteLine("personal.newAccount('1234')");
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            process.StandardInput.WriteLine(txtCommand.Text.Trim());

        }

        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                StringBuilder sb = new StringBuilder(this.textBox1.Text);
                this.textBox1.Text = sb.AppendLine(outLine.Data).ToString();
                this.textBox1.SelectionStart = this.textBox1.Text.Length;
                this.textBox1.ScrollToCaret();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (process != null)
                process.Close();
        }

        private void tlbInit_Click(object sender, EventArgs e)
        {
            string strAppPath = Application.StartupPath;
            Control.CheckForIllegalCrossThreadCalls = false;
            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = strAppPath + "\\Geth\\";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            //Process.Start("cmd.exe");
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Start();

            process.StandardInput.WriteLine("geth.exe --datadir \"" + strAppPath + "\\Geth\\DXCC\" init " + strAppPath + "\\Geth\\DXCC.json");
            process.StandardInput.WriteLine("exit");
            process.BeginOutputReadLine();
            process.WaitForExit();//等待程序执行完退出进程
            process.Close();
        }

        private void FrmCommand_Load(object sender, EventArgs e)
        {
            ClsNethereum.GetGasprise();
            ClsNethereum.GetMyBalance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.StandardInput.WriteLine("var abi = JSON.parse('[{\"constant\":true,\"inputs\":[],\"name\":\"getPool\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[{\"name\":\"candidate\",\"type\":\"uint256\"}],\"name\":\"validCandidate\",\"outputs\":[{\"name\":\"\",\"type\":\"bool\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"expireTime\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"numNotes\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"candidate\",\"type\":\"uint256\"},{\"name\":\"timestamp\",\"type\":\"uint256\"},{\"name\":\"votes\",\"type\":\"uint256\"}],\"name\":\"voteForCandidate\",\"outputs\":[],\"payable\":true,\"stateMutability\":\"payable\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[{\"name\":\"addr\",\"type\":\"address\"}],\"name\":\"validVoter\",\"outputs\":[{\"name\":\"\",\"type\":\"bool\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"complete\",\"outputs\":[{\"name\":\"\",\"type\":\"bool\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"notes\",\"outputs\":[{\"name\":\"amount\",\"type\":\"uint256\"},{\"name\":\"eth_address\",\"type\":\"address\"},{\"name\":\"votesfor\",\"type\":\"uint256\"},{\"name\":\"votes\",\"type\":\"uint256\"},{\"name\":\"time\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"name\":\"\",\"type\":\"address\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"bouns\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"candidate\",\"type\":\"uint256\"}],\"name\":\"drawdown\",\"outputs\":[],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[{\"name\":\"candidate\",\"type\":\"uint256\"}],\"name\":\"totalVotesFor\",\"outputs\":[{\"name\":\"\",\"type\":\"uint8\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"candidateList\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"winner\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":true,\"inputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"votesReceived\",\"outputs\":[{\"name\":\"\",\"type\":\"uint8\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"name\":\"candidateNames\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"}]')");
            process.StandardInput.WriteLine("var address = \"0xfFC7863Ba856c1F1468e743f84804dc346E73eDf\";");
            process.StandardInput.WriteLine("voting = web3.eth.contract(abi).at(address);");

            for(int i = 0; i < 41; i++)
            {
                System.Threading.Thread.Sleep(100);
                process.StandardInput.WriteLine($"voting.notes({i});");
            }
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnCommand_Click(sender, e);
            }
        }
    }
}
