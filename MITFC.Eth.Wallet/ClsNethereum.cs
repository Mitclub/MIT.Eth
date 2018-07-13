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

namespace MITFC.Eth.Wallet
{
    public static class ClsNethereum
    {
        public static Nethereum.Web3.Web3 M_Web3 = new Nethereum.Web3.Web3($"{Consts.M_RPCServerUrl + Consts.M_Infura_ApiKey}");
        public static Web3Geth M_Web3Geth = new Web3Geth($"{Consts.M_RPCServerUrl + Consts.M_Infura_ApiKey}");

        public static Nethereum.Contracts.Contract _Contract = null;
        public static Nethereum.Contracts.Contract m_Contract
        {
            get
            {
                if (_Contract == null)
                {
                    _Contract = M_Web3.Eth.GetContract(Consts.M_ABI, Consts.M_ContractAddress);

                }
                return _Contract;

            }
        }

        /// <summary>
        /// unlock account
        /// </summary>
        /// <returns></returns>
        public static ResponseModel<bool> unLockAccount(string strPassword)
        {
            var resultM = new ResponseModel<bool>() { IsSuccess = false };
            try
            {
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
                var c = M_Web3.Eth.GetContract(abi, contractAddress);

                List<Object> lstPars = new List<object>();
                lstPars.Add(option);
                lstPars.Add(simespan);
                lstPars.Add(voteNote);
                var voteForCandidate = c.GetFunction(strFun);
                var gasTMp = voteForCandidate.EstimateGasAsync(Consts.M_DefultAccount, new HexBigInteger(1000000), new HexBigInteger(Web3.Convert.ToWei(voteNote * 2, Nethereum.Util.UnitConversion.EthUnit.Ether)), lstPars.ToArray()).Result;

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

        public static ResponseModel<BigDecimal> GetMITFCBalance(string strAccount)
        {
            var result = new ResponseModel<BigDecimal>() { IsSuccess = false };

            List<Object> lstPars = new List<object>();
            lstPars.Add(strAccount);

            var mitfc = GetDataFromContract(Consts.ContractFunctions.M_BalanceOf, lstPars);
            result.IsSuccess = mitfc.IsSuccess;

            if (mitfc.IsSuccess)
            {
                result.Data = Web3.Convert.FromWeiToBigDecimal((BigInteger)mitfc.Data);
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
            var balance = M_Web3.Eth.GetBalance.SendRequestAsync(Consts.M_DefultAccount).Result;
            result = Web3.Convert.FromWeiToBigDecimal(balance.Value);
            return result;
        }
    }
}
