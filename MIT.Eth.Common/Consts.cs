using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIT.Eth.Common
{
    public class Consts
    {
        #region Configs.xml
        public static class Paths
        {
            public static readonly string M_Configs = Application.StartupPath + "\\Configs.xml";
            public static readonly string M_Geth = Application.StartupPath + "\\Geth";
            public static readonly string M_MIT = Application.StartupPath + "\\Geth\\MIT";
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

        //private static string _defultAccount = "";
        //public static string M_TestAccount
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(_defultAccount))
        //        {
        //            _defultAccount = m_dtConfigs.Rows[0][Consts.ConfigFields.M_Account].ToString();
        //        }
        //        return _defultAccount;
        //    }
        //    set
        //    {
        //        _defultAccount = value;

        //        m_dtConfigs.Rows[0][Consts.ConfigFields.M_Account] = _defultAccount;
        //        m_dtConfigs.WriteXml(Consts.Paths.M_Configs, XmlWriteMode.WriteSchema);
        //    }
        //}

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
            public const string M_TransferFrom = "transferFrom";

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

        public enum M_MessageType
        {
            Error,
            Success,
            Information,
            Abort
        }

        public static class Enodes
        {
            private static string[] M_Test = {"enode://0892c4cd5d110406f77bcfe95e5afebe83e24d59a4dcc01bc89e5068eaf1d28b8dd68d11ad47e03d036e2dd883f21e93de26aa9c607d78dc1e07a21cf496e8a1@5.189.148.135:48293"
                                                ,"enode://0937aa1794d22e01e56f64b90bfa0efc93b5b4aee305d4788bca2b6b4d090393b70b9a6d2fa43d4ea29ed1b420ad748954702ae3f8327d57c400c4a84346e424@46.51.202.218:33434"
                                                ,"enode://14e22f64f50c9e91fb3cf9374f1bca36a84591d777d3814d89803aa98f500b5d21c6868c8a0f64fdc6e932a47afebb99d900084fd73b76b2f2e31b79170445b5@36.152.8.188:42556"
                                                ,"enode://4239237689393f39ca3d06a00a92d0a582be3f9f761b7b9c6794be3c04af7b5435bd3bbb6ab0a87d6c3cb70018c0461500ed0db4ed7830fb613aaf0b2b3a5850@18.182.18.240:42754"
                                                ,"enode://5635d8ac61d59932413d932689572e0e230b21f3ccb2ca2ef11906c621a61ee1aa817f02b548aeb8fadbbe09ee41d56784333a8c7158f8ba35c8aa19899a94e4@187.167.193.98:55736"
                                                ,"enode://5b5bbe70fa96b0adc60606fd7c094e7588d2547bf7c727e3d07f5d080827b7b4c7d7a9449981bd14de704aa735b955d2e80df50ea93ccef201bdf2a915004a59@34.226.248.216:30303"
                                                ,"enode://625fcf7a56499c754e3f3107622683b8fdb14f5ce67734071607cec0dfe20a9c9a6a1a80719bf691653a6fa53896b0a76ce0173bd1c3ff837231588c1089ee62@195.201.110.218:49024"
                                                ,"enode://77393de9564e3601d9c4f803d5496a9d4e2b3b8585ad6b346fb4003076c95ca8e2a5d0f3d721cd44ece08f360b4baeed4f2affeb578657bb13ac9452d87ccdf7@13.125.133.123:54286"
                                                ,"enode://7da8e6869f1a17e71f0a2980ee387f7a60363e113bf5ad3515be26ada46b161595c22142fb95062ff30e6c33ffaea86231797b71f7d20850315abe40a0e27ed1@52.83.90.9:38545"
                                                ,"enode://809e6382d111e4975303fe64be024c6cbfc19fe2e7cfdfbb4743afc759b43b04a299e44b0c847fe8cedb7e5c88bfc179b4414871f12f1ef224b18ce7a70f3666@35.171.161.82:56738"
                                                ,"enode://865a63255b3bb68023b6bffd5095118fcc13e79dcf014fe4e47e065c350c7cc72af2e53eff895f11ba1bbb6a2b33271c1116ee870f266618eadfc2e78aa7349c@52.176.100.77:30303"
                                                ,"enode://a297aa484ee9cfd73b0ac6584aecdce34bf483a01ef21df9e23f29179b5d129081e3d32cd33a2d51aae3b0d3052cb4c67fb48f219136c74f43358fc54d8f7382@52.50.36.119:53782"
                                                ,"enode://a591f59fb1c08412a2ef6abee1b01e13c765b320f4eae945da970a4f12f56397e614d2b3ada823ed88bf9af989c2c02dc4ae41f78a8367831eede4e2622f2f03@47.75.181.154:46939"
                                                ,"enode://af34d7c451ffd99a5ff81bc4bac72ef4b033590875959b046aaa23e4d35195695dabaa46731d8bbe857f7202e6517d164e340c0df14ea0f04fe065f0e3e48d72@52.208.46.161:30311"
                                                ,"enode://afbbe0a058c01b57a34e9e7cb0e9c0480a08046a7f434e73bb06dbd5bd8e6bd366c1442fd5afdc164bc4e9f83528d02c6c11715de2c9f5f7fc5977ece5fa9f1d@18.191.238.141:30304"
                                                ,"enode://bc58b4351f2e2849d36112d878d404a622e67711ad2c3775cf8fcd43e4b72e09a475a7f8bb7ad14629138ae34e18afb630023a15129320e67b2e477e66e8c870@18.216.116.118:40324"
                                                ,"enode://c03db733448a6c0918d6101c6641c9d9b6e85a454199001b443f93cd0afa0bd0378c20604493ce2c8daf86e2b21016360bcb8508f96b4457967ec029d193d9f4@54.162.168.183:30303"
                                                ,"enode://cc92c3aff13bb5c81f8c4a172a3847d5c6c6874a0acd607cf37f0e8bbd643d851fe727ce35245bbe22e5fc246e1efe957dd66161924692898d231541307f6d4e@47.104.183.34:60092"
                                                ,"enode://d1bcdc2578fc6f7416e380aab134630a5ea0ca50cb359064d3d957f285474ae019281aa7fb534e25874c5ff054415b37fe9e83cf333fc812d932ec0106ae6b48@104.225.218.72:45450"
                                                ,"enode://e21a761c5f6a6edd8b3d333fab562745cf3d9548baa391ab70d57e2b1eae757221c2c2b3d7438da0605ca1572a08ef0beb2a71f519c5d7c084fea7e54c82e58b@54.36.139.113:62125"
                                                ,"enode://e8ae01a09cf2c372dbb0dd2aba06bce4a9ad1e9acf4526c8667e63b05a7dd9b8386680e23d338559f1fd6e42d7fb41a8ab0fd507503d1a57674036f51ecd4516@116.247.86.250:38482"
                                                ,"enode://ecdc411b27853a75b2b4a60c1c9c73e2d35bd3cb6bf989d721776cb9ed7cca4f1ef285b703c85964a74b9ccae81d7aaa2802e66c18ac4e77bb8ffc9403116f7a@159.65.165.191:56968"
                                                ,"enode://f153a428aabab692be0e5091523d80117d47ac831b08b58d6c0129d0cf6dc470f422d985e9c0dbf33713d50d8570e52e0d7fc675ed5e21e86093a977de9fbf4f@35.192.105.45:30303"
                                                ,"enode://f20969a03e20fc57252da75640fbbbeed5135068dca54104442149a70823c607fb845f6c6a3d144b11f14c0ce115758343a1c3414f01c56eaaaadf2ee7074b1f@35.199.163.44:34422"};

            public static string[] M_Production = {"enode://1088893383e5c0d0cd110ed5b29e39407ccc1091d0c2ecad1494d342f0410439294922d3d8a2f7cbd0728001dc0588e960d15003706c07366ff5cb086c097600@35.237.143.74:30303"
                                                ,"enode://217ef992007eacdb5e690e992a138a576fbda5d42eb87f6e2e7c06ccbfc1520bf26011bf4596efd6e277fc12f7770697692a232a7765887e2209cb36841ed688@18.184.25.143:30303"
                                                ,"enode://2fbac23ad2664a7e8a4ce41b2ee92e6a4924e846934f5afc31051f8c3f5f2f81f4533e4d88e217021736c04aeab634002c3880f6fd162ea792d8f42ba3c67235@195.201.196.98:30303"
                                                ,"enode://3488a9892b349d8cd2631f837c4e22e688b681959b2bba3b4290dc37dd970e12db41bc3809f473889ac77e1bab60e90e368bb1314b0527cfd6759d95464aae58@52.29.201.111:30303"
                                                ,"enode://3616e2d0bcacf32f3153630b9fb9e93945846f915975acf7cb9de46ac8d06f52b2a3195a2e7f50c118d3e58a7b032dde18fd4a133628ee5ab5f71a787f18afcc@167.114.232.147:30303"
                                                ,"enode://3dd49dbbba3501393a3629364f0daa27ca3d17c66ceeb7e8862fe92198d4ffd36dfa10f32c911df43f8f73c4340124d0bf0e37644e4e5c42659114ce5d746c0c@54.146.1.91:30303"
                                                ,"enode://45a8a36e755912da6f9cec9fbed8a8577748116a2a8f747fd11a3d819acf87f65604b53c49a8b38891faab3b088a2154355a2be54cb9c9a5715649efd91e0b96@40.125.162.0:30303"
                                                ,"enode://76d2d369b9dc1710a584068ab2245193b1b06671ceb8ede6c5d1500d254058c6bff1c6024c83257ccc840cbf06e28f540d05c2b28b08b9a2f0c6c7211f62dfc5@142.44.143.71:30303"
                                                ,"enode://8f2ec779f9497962799648a0639cadcd7441887bbd8286e7a6da96ba7c419c466c85e70ae68015fa9fbf2946c11bc1888894be0d3e6a764d26947be2760b9158@18.207.216.213:30303"
                                                ,"enode://93b1ca4439562ea9f6bd466c41e1e1c928a182b66a7ff4ff33dd326c2ce8cd991ba1ca59c05f40635be530f500100c6f650a793b909ad0282e48fb2f5bf75500@35.171.188.74:30303"
                                                ,"enode://a39effff87733fd593539a005f9ea50886a9c8cc139a170e32eb43679827c86ccae54d44235baf54c3ebb20d37235b4c5972ede5090ce923649f6bbdc0a67a67@54.207.23.19:30303"
                                                ,"enode://a81bbebbe4f0ced6f963012e00fc1cc6c2d14c460eb2af2b1372b4456aca05eade185052c0d0aefc54fbbcb86bb435a7f3e5cfb2254b3d84f8af99fa0833896f@178.128.202.18:30303"
                                                ,"enode://b4013b63c97397a6fe6cd4d6bff890f02b0214c57ba8ac42452060b04f808af836f2558c14198f3c16140a0eeb373e81631fed0f3d4d5d274305903878024971@18.233.224.142:30303"
                                                ,"enode://bcdce0388737748e94758373b3f1316b320d7846c663ac8cc413aca0e2b3072db8b4cc91543261f29e9f6be479df2caf4d01e2c528aa4615d79caaddd256cffe@39.105.84.64:30303"
                                                ,"enode://cee5512aaa97a405e789d8ff053ac067914868ce752a25edf149f4b02e0929a88ae8b29da8eacc2efcbe6171af9fa4cbb1870650df322204533a93a7f58a4764@35.174.114.244:30303"
                                                ,"enode://d76ee9ac0c99dc320bbb9c085419e3e0d4ef69bd3f1acfb88ac30fedd0c7daf52dbee205946fb2dbd11d3a11a42dc460abd32016346065859e13d4f3069f2df2@34.233.120.39:30303"
                                                ,"enode://e5d6b02939d473b0a49a9a8f925349c516a4eaa678531bdbfa9dd48c0d1e6004ba91699efe38274910cfd8d1b3fee88a79bae9fdfa3ef20462f5c8f7ef80e809@47.75.114.49:30303"};

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
