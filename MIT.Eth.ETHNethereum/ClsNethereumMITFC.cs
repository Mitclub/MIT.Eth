using MIT.Eth.Common;
using MIT.Eth.Model;
using Newtonsoft.Json;
using System;
using Nethereum.Hex.HexTypes;
using Nethereum.Util;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Numerics;

namespace MIT.Eth.ETHNethereum
{
    public partial class ClsNethereum
    {
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
                var c = M_Web3_Infura.Eth.GetContract(abi, contractAddress);

                List<Object> lstPars = new List<object>();
                lstPars.Add(option);
                lstPars.Add(simespan);
                lstPars.Add(voteNote);
                var voteForCandidate = c.GetFunction(strFun);
                var gasTMp = voteForCandidate.EstimateGasAsync(ClsNethereum.M_DefultAccount, new HexBigInteger(1000000), new HexBigInteger(Web3.Convert.ToWei(voteNote * 2, Nethereum.Util.UnitConversion.EthUnit.Ether)), lstPars.ToArray()).Result;

                // get gasprise
                var gasPrise = M_Web3_Infura.Eth.GasPrice.SendRequestAsync().Result;

                BigDecimal gasResult = 0;
                gasResult = Web3.Convert.FromWeiToBigDecimal(gasTMp.Value * gasPrise.Value);

                resultM.Data = gasResult;
                resultM.IsSuccess = true;

            }
            catch (Exception ex)
            {
                resultM.Message = "Estimating gas is failed, please try again later.";
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }

            return resultM;
        }

        public static ResponseModel<BigDecimal> GetMITBalance(string strAccount)
        {
            var result = new ResponseModel<BigDecimal>() { IsSuccess = false };

            List<Object> lstPars = new List<object>();
            lstPars.Add(strAccount);

            var MIT = GetContractFun_Infura(Consts.M_ContractFunctions.M_BalanceOf, lstPars);
            result.IsSuccess = MIT.IsSuccess;

            if (MIT.IsSuccess)
            {
                result.Data = Web3.Convert.FromWeiToBigDecimal((BigInteger)MIT.Data);
            }
            return result;
        }

        public static ResponseModel<bool> CheckMITLocked(string strAccount)
        {
            var result = new ResponseModel<bool>() { IsSuccess = false };

            List<Object> lstPars = new List<object>();
            lstPars.Add(strAccount);

            var MIT = GetContractFun_Infura(Consts.M_ContractFunctions.M_ValidHolder, lstPars);
            result.IsSuccess = MIT.IsSuccess;

            if (MIT.IsSuccess)
            {
                result.Data = (bool)MIT.Data;
            }
            return result;
        }

        public static ResponseModel<string> SendMIT(string from, string to, double amount)
        {
            var result = new ResponseModel<string>() { IsSuccess = false };
            try
            {
                List<Object> lstPars = new List<object>();
                lstPars.Add(from);
                lstPars.Add(to);
                lstPars.Add(amount);
                var sendT = m_Contract_Geth.GetFunction(Consts.M_ContractFunctions.M_TransferFrom);
                var tranCode = sendT.SendTransactionAsync(ClsNethereum.M_DefultAccount, new HexBigInteger(1000000), new HexBigInteger(Web3.Convert.ToWei(0, Nethereum.Util.UnitConversion.EthUnit.Ether)), lstPars.ToArray()).Result;

                result.IsSuccess = true;
                result.Data = tranCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
            return result;
        }

        /// <summary>
        /// Lock(Testing)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="simespan"></param>
        /// <returns></returns>
        public static ResponseModel<string> LockMIT(string account, Int32 simespan)
        {
            var result = new ResponseModel<string>() { IsSuccess = false };
            try
            {
                List<Object> lstPars = new List<object>();
                lstPars.Add(account);
                lstPars.Add(simespan);
                var sendT = m_Contract_Geth.GetFunction(Consts.M_ContractFunctions.M_Lock);
                var tranCode = sendT.SendTransactionAsync(ClsNethereum.M_DefultAccount, new HexBigInteger(1000000), new HexBigInteger(Web3.Convert.ToWei(0, Nethereum.Util.UnitConversion.EthUnit.Ether)), lstPars.ToArray()).Result;

                result.IsSuccess = true;
                result.Data = tranCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
            return result;
        }

        /// <summary>
        /// Unlock(Testing)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="simespan"></param>
        /// <returns></returns>
        public static ResponseModel<string> UnlockMIT(string account)
        {
            var result = new ResponseModel<string>() { IsSuccess = false };
            try
            {
                List<Object> lstPars = new List<object>();
                lstPars.Add(account);
                var sendT = m_Contract_Geth.GetFunction(Consts.M_ContractFunctions.M_Unlock);
                var tranCode = sendT.SendTransactionAsync(ClsNethereum.M_DefultAccount, new HexBigInteger(1000000), new HexBigInteger(Web3.Convert.ToWei(0, Nethereum.Util.UnitConversion.EthUnit.Ether)), lstPars.ToArray()).Result;

                result.IsSuccess = true;
                result.Data = tranCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                ClsCommon.WriteLog(ex.ToString(), Consts.M_LogType.M_Error);
            }
            return result;
        }
    }
}
