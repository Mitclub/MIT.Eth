using MITFC.Eth.Common;
using MITFC.Eth.Model;
using Newtonsoft.Json;
using System;
using Nethereum.Geth;
using Nethereum.Hex.HexTypes;
using Nethereum.Util;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MITFC.Eth.ETHNethereum
{
    public partial class ClsNethereum
    {
        public static Web3 M_Web3 = new Web3($"{Consts.M_RPCServerUrl + Consts.M_Infura_ApiKey}");
        public static Web3Geth M_Web3Geth = new Web3Geth($"{Consts.M_RPCServerUrl + Consts.M_Infura_ApiKey}");

        /// <summary>
        /// unlock account
        /// </summary>
        /// <returns></returns>
        public static ResponseModel<bool> unLockAccount(string strPassword)
        {
            var resultM = new ResponseModel<bool>() { IsSuccess = false };
            try
            {
                var accounts=M_Web3.Eth.Accounts.SendRequestAsync().Result;
                var unLockResult = M_Web3.Personal.UnlockAccount.SendRequestAsync(Consts.M_DefultAccount, strPassword, 1000 * 60 * 10).Result;
                if (unLockResult)
                {
                    resultM.IsSuccess = true;
                    resultM.Data = true;
                }
                else
                {
                    resultM.Message = "The password is incorrect. Please try again.";
                }

            }
            catch (Exception ex)
            {
                resultM.Message = ex.Message;
                ClsCommon.WriteLog(ex.ToString(), Consts.LogType.M_Error);
            }

            return resultM;
        }

        /// <summary>
        /// estimate gas
        /// </summary>
        /// <param name="contractAddress"></param>
        /// <param name="abi"></param>
        /// <param name="simespan"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static ResponseModel<BigInteger> GetGasprise()
        {
            var resultM = new ResponseModel<BigInteger>() { IsSuccess = false };
            try
            {
                var gasPrise = M_Web3.Eth.GasPrice.SendRequestAsync().Result;

                resultM.Data = gasPrise.Value;
                resultM.IsSuccess = true;

            }
            catch (Exception ex)
            {
                resultM.Message = "Get gasprise is failed, please try again later.";
                ClsCommon.WriteLog(ex.ToString(), Consts.LogType.M_Error);
            }

            return resultM;
        }

        /// <summary>
        /// voting
        /// </summary>
        /// <param name="contractAddress"></param>
        /// <param name="abi"></param>
        /// <param name="password"></param>
        /// <param name="simespan"></param>
        /// <returns></returns>
        public static ResponseModel<Object> GetDataFromContract(string strFun, List<Object> lstPars)
        {
            var result = new ResponseModel<Object>() { IsSuccess = false };
            try
            {
                var voteForCandidate = m_Contract.GetFunction(strFun);
                result.Data = voteForCandidate.CallAsync<Object>(lstPars.ToArray()).Result;

                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.LogType.M_Error);
            }
            return result;
        }
    }
}
