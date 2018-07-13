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
        public static bool m_UserAgree = false;
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
        public const string M_Infura_ApiKey = "Okk2nbUcZrpNERo5bf4F";

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

        public const string M_DXCoin_EMailAddress = "DXCoin@dxc.com";

        public class Backend
        {
            public static string M_BaseUrl
            {
                get
                {
                    if (M_IsPro.Value)
                    {
                        return "http://15.140.139.236:9091/";
                    }
                    else
                    {
                        return "http://15.140.139.236:9092/";
                    }

                }
            }

            public static class M_ActionUrls
            {
                public static string M_CreateAcct = M_BaseUrl + "api/createAcct";
                public static string M_AddActivity = M_BaseUrl + "api/addActivity";
                public static string M_Voting = M_BaseUrl + "api/voting";
                public static string M_GetMatchs = M_BaseUrl + "api/getMatchList";
                public static string M_GetMatchsRes = M_BaseUrl + "api/getMatchsRes";
                public static string M_ValidateUser = M_BaseUrl + "api/validateUser";
                public static string M_GetCurrentTimeStamp = M_BaseUrl + "api/getCurrentTimeStamp";
                public static string M_GetMyUnsureTrans = M_BaseUrl + "api/getMyUnsureTrans";
            }

            public static class M_PageUrls
            {
                public static string M_WeeklyReport = M_BaseUrl + "WeeklyDigest.html";
            }

            public struct M_UrlQueryStrings
            {
                public const string M_Account = "account";
            }

            public static string M_WeeklyReportUrl
            {
                get
                {
                    if (M_IsPro.Value)
                    {
                        return "http://15.140.139.236:9091/xxx.html";
                    }
                    else
                    {
                        return "http://15.140.139.236:9092/xxx.html";
                    }

                }

            }
        }

        public static class Paths
        {
            public static readonly string M_Geth = Application.StartupPath + "\\Geth";
            public static readonly string M_DXCC = Application.StartupPath + "\\Geth\\DXCC";
            public static readonly string M_Keystore = Application.StartupPath + "\\Geth\\DXCC\\keystore";
            public static readonly string M_Configs = Application.StartupPath + "\\Configs.xml";
            public static readonly string M_ContImgs = Application.StartupPath + "\\CounImg\\";
            public static readonly string M_Resources = Application.StartupPath + "\\Resources\\";
        }

        public struct ConfigFields
        {
            public const string M_UserAgree = "UserAgree";
            public const string M_IsPro = "IsPro";
            public const string M_Identity = "Identity";
            public const string M_Networkid = "Networkid";
            public const string M_Bootnodes = "Bootnodes";
            public const string M_VotingFuncName = "VotingFuncName";
            public const string M_VotingErrorMsg = "VotingErrorMsg";
        }
        public struct VoteOption
        {
            public const int m_iVoteOption_Home = 1;
            public const int m_iVoteOption_Draw = 2;
            public const int m_iVoteOption_Away = 3;
        }

        /// <summary>
        /// Log type
        /// </summary>
        public struct LogType
        {
            public const string M_Error = "Error";
            public const string M_Warning = "Warning";
            public const string M_Information = "Information";
        }

        public enum M_MessageType
        {
            Error,
            Success,
            Information,
            Abort
        }
        public static string M_Identity
        {
            get
            {
                if (M_IsPro.Value)
                {
                    return "DXCC";
                }
                else
                {
                    return "TEST";
                }

            }

        }
        public static string M_Networkid
        {
            get
            {
                if (M_IsPro.Value)
                {
                    return "4243";
                }
                else
                {
                    return "2046";
                }

            }
        }

        public const string M_Rpcport = "9090";

        public static class Enodes
        {
            private static string[] M_Test = { "enode://c9e233f5ec24e8cf554a1b9267e7ac4a56839b65f5980d7c0464600e255a1c14392eb1a4569f52b7019ca92951e30e2a6bb4c2101db41702454d5d19f954fd65@15.107.21.50:30302" };
            public static string[] M_Production = {"enode://7eb36e886b60f772e0bd6cfceb169060e81f68a1c7b0d73ebf6fc3da682c90ba1a60389256f0fe8c5f29f2fe39a0cf3c1375a2508b48948bc680274826cdba83@15.107.29.8:30302"
                                                  ,"enode://f477c3f8c453a1a98a5a5c0a881344506556f126c79d773247005d539c4f9e59a6b13ce12548c7d6bbe5253d5051f76e350a5bd07c2a6a349012e6309f3b7961@15.107.29.5:30302"
                                                  ,"enode://53b6c78958562aa858b3e3866eb8db53990669f58ce7105abd487b6b9c44acc2349ba6a462df71e588b9d4b1d0bfecf0146b9ad1eb54b5a7fe12b6c9cc1b1403@15.140.139.236:30302"};

            public static string[] M_Enodes
            {
                get
                {
                    if (M_IsPro.Value)
                    {
                        return M_Production;
                    }
                    else
                    {
                        return M_Test;
                    }

                }
            }
        }
    }
}
