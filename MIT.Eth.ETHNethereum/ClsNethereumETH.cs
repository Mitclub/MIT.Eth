using MIT.Eth.Common;
using MIT.Eth.Model;
using System;
using Nethereum.Hex.HexTypes;
using Nethereum.Util;
using Nethereum.Web3;

namespace MIT.Eth.ETHNethereum
{
    public partial class ClsNethereum
    {
        /// <summary>
        /// Get my balance
        /// </summary>
        /// <returns></returns>
        public static BigDecimal GetMyBalance()
        {
            BigDecimal result = 0;
            var balance = M_Web3_Infura.Eth.GetBalance.SendRequestAsync(ClsNethereum.M_DefultAccount).Result;
            result = Web3.Convert.FromWeiToBigDecimal(balance.Value);
            return result;
        }

        /// <summary>
        /// Send transaction from 'from' to 'to'
        /// </summary>
        /// <returns></returns>
        public static ResponseModel<string> SendTransaction(string from, string to, double amount)
        {
            var result = new ResponseModel<string>() { IsSuccess = false };
            try
            {
                result.Data= M_Web3_Geth.Eth.TransactionManager.SendTransactionAsync(from, to, new HexBigInteger(Web3.Convert.ToWei(amount, UnitConversion.EthUnit.Ether))).Result;
                result.IsSuccess = true;
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
