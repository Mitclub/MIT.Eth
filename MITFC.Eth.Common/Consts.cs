using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MITFC.Eth.Common
{
    public class Consts
    {
        #region Configs.xml
        public static class Paths
        {
            public static readonly string M_Configs = Application.StartupPath + "\\Configs.xml";
        }

        public struct ConfigFields
        {
            public const string M_IsPro = "IsPro";
            public const string M_InfuraApiKey = "InfuraApiKey";
            public const string M_Account = "Account";
            public const string M_ContractAddress = "ContractAddress";
            public const string M_ABI = "ABI";
        }

        private static DataTable _dtConfigs = null;
        public static DataTable m_dtConfigs
        {
            get
            {
                try
                {
                    if (_dtConfigs == null)
                    {
                        #region Get init config file(Configs.xml)
                        DataSet dsConfigs = new DataSet();
                        if (System.IO.File.Exists(Consts.Paths.M_Configs))
                        {
                            dsConfigs.ReadXml(Consts.Paths.M_Configs);
                        }

                        if (dsConfigs.Tables.Count > 0)
                        {
                            _dtConfigs = dsConfigs.Tables[0];
                        }

                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    ClsCommon.WriteLog(ex.ToString(), Consts.LogType.M_Error);
                }
                return _dtConfigs;
            }
            set
            {
                _dtConfigs = value;
            }
        }
        private static bool? _isPro = null;
        public static bool? M_IsPro
        {
            get
            {
                if (_isPro == null)
                {
                    _isPro = bool.Parse(m_dtConfigs.Rows[0][Consts.ConfigFields.M_IsPro].ToString());
                }
                return _isPro;
            }
        }

        private static string _defultAccount = "";
        public static string M_DefultAccount
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_defultAccount))
                {
                    _defultAccount = m_dtConfigs.Rows[0][Consts.ConfigFields.M_Account].ToString();
                }
                return _defultAccount;
            }
            set
            {
                _defultAccount = value;

                m_dtConfigs.Rows[0][Consts.ConfigFields.M_Account] = _defultAccount;
                m_dtConfigs.WriteXml(Consts.Paths.M_Configs, XmlWriteMode.WriteSchema);
            }
        }


        private static string _Infura_ApiKey = "";
        public static string M_Infura_ApiKey
        {
            get
            {
                if (_Infura_ApiKey == "")
                {
                    _Infura_ApiKey = m_dtConfigs.Rows[0][Consts.ConfigFields.M_InfuraApiKey].ToString();
                }
                return _Infura_ApiKey;
            }
        }

        private static string _ContractAddress = "";
        public static string M_ContractAddress
        {
            get
            {
                if (_ContractAddress == "")
                {
                    _ContractAddress = m_dtConfigs.Rows[0][Consts.ConfigFields.M_ContractAddress].ToString();
                }
                return _ContractAddress;
            }
        }

        private static string _ABI = "";
        public static string M_ABI
        {
            get
            {
                if (_ABI == "")
                {
                    _ABI = m_dtConfigs.Rows[0][Consts.ConfigFields.M_ABI].ToString();
                }
                return _ABI;
            }
        }

        #endregion

        public struct ContractFunctions
        {
            public const string M_BalanceOf = "balanceOf";
            public const string M_ValidHolder = "validHolder";

        }

        public static string M_RPCServerUrl
        {
            get
            {
                if (M_IsPro.Value)
                {
                    return "https://mainnet.infura.io/";
                }
                else
                {
                    return "https://ropsten.infura.io/";
                }

            }
        }

        public const string M_Support_EMailAddress = "Support@Mit.club";

        /// <summary>
        /// Log type
        /// </summary>
        public struct LogType
        {
            public const string M_Error = "Error";
            public const string M_Warning = "Warning";
            public const string M_Information = "Information";
        }
    }
}
