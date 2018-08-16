using MIT.Eth.Common;
using MIT.Eth.Model;
using Newtonsoft.Json;
using System;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MIT.Eth.ETHNethereum
{
    public partial class ClsNethereum
    {
        private static string m_RpcUrl_Infura = $"{Consts.M_RPCServerUrl + Consts.M_Infura_ApiKey}";
        public static Web3 M_Web3_Infura = new Web3(m_RpcUrl_Infura);

        private static string m_RpcUrl = "http://localhost:8545";
        public static Web3 M_Web3_Geth = new Web3(m_RpcUrl);
        //public static Web3Geth M_Web3Geth = new Web3Geth(m_RpcUrl);

        private static string defultAccount = "";
        public static string M_DefultAccount
        {
            get
            {
                if (string.IsNullOrWhiteSpace(defultAccount))
                {
                    var accounts = M_Web3_Geth.Eth.Accounts.SendRequestAsync().Result;
                    defultAccount = accounts.FirstOrDefault();

                }

                return defultAccount;
            }
            set { defultAccount = value; }
        }

        public static Nethereum.Contracts.Contract _Contract_Infura = null;
        public static Nethereum.Contracts.Contract m_Contract_Infura
        {
            get
            {
                if (_Contract_Infura == null)
                {
                    _Contract_Infura = M_Web3_Infura.Eth.GetContract(Consts.M_ABI, Consts.M_ContractAddress);

                }
                return _Contract_Infura;

            }
        }

        public static Nethereum.Contracts.Contract _Contract_Geth = null;
        public static Nethereum.Contracts.Contract m_Contract_Geth
        {
            get
            {
                if (_Contract_Geth == null)
                {
                    _Contract_Geth = M_Web3_Geth.Eth.GetContract(Consts.M_ABI, Consts.M_ContractAddress);

                }
                return _Contract_Geth;

            }
        }


        /// <summary>
        /// need start geth first
        /// </summary>
        /// <param name="strPassword"></param>
        public static bool createNewAccount(string strPassword)
        {
            bool result = false;
            try
            {
                var newAccount = M_Web3_Geth.Personal.NewAccount.SendRequestAsync(strPassword).Result;
                //process.StandardInput.WriteLine($"personal.newAccount('{strPassword}')");

                if (!string.IsNullOrWhiteSpace(newAccount) && newAccount.Length > 4)
                {
                    ClsNethereum.M_DefultAccount = newAccount;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }

            return result;
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
                var accounts = M_Web3_Geth.Eth.Accounts.SendRequestAsync().Result;
                var unLockResult = M_Web3_Geth.Personal.UnlockAccount.SendRequestAsync(ClsNethereum.M_DefultAccount, strPassword, 1000 * 60 * 10).Result;
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
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
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
                var gasPrise = M_Web3_Infura.Eth.GasPrice.SendRequestAsync().Result;

                resultM.Data = gasPrise.Value;
                resultM.IsSuccess = true;

            }
            catch (Exception ex)
            {
                resultM.Message = "Get gasprise is failed, please try again later.";
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
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
        public static ResponseModel<Object> GetContractFun_Infura(string strFun, List<Object> lstPars)
        {
            var result = new ResponseModel<Object>() { IsSuccess = false };
            try
            {
                var func = m_Contract_Infura.GetFunction(strFun);
                result.Data = func.CallAsync<Object>(lstPars.ToArray()).Result;

                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
            return result;
        }

        /// <summary>
        /// voting
        /// </summary>
        /// <param name="contractAddress"></param>
        /// <param name="abi"></param>
        /// <param name="password"></param>
        /// <param name="simespan"></param>
        /// <returns></returns>
        public static ResponseModel<Object> GetContractFun_Geth(string strFun, List<Object> lstPars)
        {
            var result = new ResponseModel<Object>() { IsSuccess = false };
            try
            {
                var func = m_Contract_Geth.GetFunction(strFun);
                result.Data = func.CallAsync<Object>(lstPars.ToArray()).Result;

                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
            return result;
        }
    }
}
