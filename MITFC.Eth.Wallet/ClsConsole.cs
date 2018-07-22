using MITFC.Eth.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITFC.Eth.Wallet
{
    public class ClsConsole
    {
        public static System.Diagnostics.Process M_Process = new System.Diagnostics.Process();
        
        /// <summary>
        /// Start Geth
        /// </summary>
        public static void startGeth()
        {
            ClsConsole.M_Process = new Process();
            ClsConsole.M_Process.StartInfo.FileName = "cmd.exe";
            ClsConsole.M_Process.StartInfo.WorkingDirectory = Consts.Paths.M_Geth;
            ClsConsole.M_Process.StartInfo.UseShellExecute = false;
            ClsConsole.M_Process.StartInfo.RedirectStandardInput = true;
            ClsConsole.M_Process.StartInfo.RedirectStandardOutput = true;
            ClsConsole.M_Process.StartInfo.Verb = "runas";

            ClsConsole.M_Process.StartInfo.CreateNoWindow = true;
            ClsConsole.M_Process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            ClsConsole.M_Process.Start();
            //process.ProcessorAffinity = (IntPtr)(0x0001 | 0x0002);    // 使用cpu1和cpu2
            //process.ProcessorAffinity = (IntPtr)0x0001; // 使用cpu1

            //string strIp = ClsCommon.ClintInfor.M_IP;

            string testNode = Consts.M_IsPro.Value ? string.Empty : " --testnet";
            ClsConsole.M_Process.StandardInput.WriteLine($"geth --rpc --rpccorsdomain \"http://localhost:8545\" --datadir \"{Consts.Paths.M_MITFC}\"{testNode} --syncmode \"light\" --rpcapi \"db,eth,net,web3,personal,admin,miner\" console");

            ClsConsole.M_Process.BeginOutputReadLine();
        }

        private static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            try
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    ClsCommon.WriteLog(outLine.Data, Consts.LogType.M_Information);
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
            }
        }
    }
}
