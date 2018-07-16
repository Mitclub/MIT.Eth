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

        public static ResponseModel<bool> CheckMITFCLocked(string strAccount)
        {
            var result = new ResponseModel<bool>() { IsSuccess = false };

            List<Object> lstPars = new List<object>();
            lstPars.Add(strAccount);

            var mitfc = GetDataFromContract(Consts.ContractFunctions.M_ValidHolder, lstPars);
            result.IsSuccess = mitfc.IsSuccess;

            if (mitfc.IsSuccess)
            {
                result.Data = (bool)mitfc.Data;
            }
            return result;
        }
    }
}
