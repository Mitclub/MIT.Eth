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
