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

namespace MITFC.Eth.CommandTool
{
    public static class ClsNethereum
    {
        private static string defultAccount = "0x021847be495f99c6DEc42D76c24d167f7Bfb1992";
        public static string m_DefultAccount
        {
            get
            {
                return defultAccount;
            }
        }

        public static Nethereum.Web3.Web3 M_Web3 = new Nethereum.Web3.Web3($"{Consts.M_RPCServerUrl+Consts.M_Infura_ApiKey}");
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
                var unLockResult = ClsNethereum.M_Web3.Personal.UnlockAccount.SendRequestAsync(m_DefultAccount, strPassword, 1000 * 60 * 10).Result;
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
                resultM.Message = "The password is incorrect. Please try again.";
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
        public static ResponseModel<BigDecimal> EstimateGas(string strFun, string contractAddress, string abi, Int32 simespan, int option, int voteNote)
        {
            var resultM = new ResponseModel<BigDecimal>() { IsSuccess = false };
            try
            {
                // get contract
                var c = ClsNethereum.M_Web3.Eth.GetContract(abi, contractAddress);

                List<Object> lstPars = new List<object>();
                lstPars.Add(option);
                lstPars.Add(simespan);
                lstPars.Add(voteNote);
                var voteForCandidate = c.GetFunction(strFun);
                var gasTMp = voteForCandidate.EstimateGasAsync(m_DefultAccount, new HexBigInteger(1000000), new HexBigInteger(Web3.Convert.ToWei(voteNote * 2, Nethereum.Util.UnitConversion.EthUnit.Ether)), lstPars.ToArray()).Result;

                // get gasprise
                var gasPrise = M_Web3.Eth.GasPrice.SendRequestAsync().Result;

                BigDecimal gasResult = 0;
                gasResult = Web3.Convert.FromWeiToBigDecimal(gasTMp.Value * gasPrise.Value);

                resultM.Data = gasResult;
                resultM.IsSuccess = true;

            }
            catch (Exception ex)
            {
                resultM.Message = "Estimating gas is failed, please try again later.";
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
        public static ResponseModel<string> Voting(string strFun, string contractAddress, string abi, Int32 simespan, int option, int voteNote)
        {
            var result = new ResponseModel<string>() { IsSuccess = false };
            try
            {
                // new contract
                var contract = ClsNethereum.M_Web3.Eth.GetContract(abi, contractAddress);

                List<Object> lstPars = new List<object>();
                lstPars.Add(option);
                lstPars.Add(simespan);
                lstPars.Add(voteNote);
                var voteForCandidate = contract.GetFunction(strFun);
                var tranCode = voteForCandidate.SendTransactionAsync(m_DefultAccount, new HexBigInteger(1000000), new HexBigInteger(Web3.Convert.ToWei(voteNote * 2, Nethereum.Util.UnitConversion.EthUnit.Ether)), lstPars.ToArray()).Result;


                result.IsSuccess = true;
                result.Data = tranCode;

            }
            catch (Exception ex)
            {
                //string strMsg = "Estimating gas is failed, please try again later."; //TODO:update wording 
                //result.Message =strMsg;
                ClsCommon.WriteLog(ex.ToString(), Consts.LogType.M_Error);
            }
            return result;
        }

        /// <summary>
        /// Get my balance
        /// </summary>
        /// <returns></returns>
        public static BigDecimal GetMyBalance()
        {
            BigDecimal result = 0;
            var balance = ClsNethereum.M_Web3.Eth.GetBalance.SendRequestAsync(m_DefultAccount).Result;
            result = Web3.Convert.FromWeiToBigDecimal(balance.Value);
            return result;
        }
    }
}
