using MITFC.Eth.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITFC.Eth.Common
{
    public class ClsUserActionTrack
    {
        public static int M_UserLoginId = 0;
        public static int M_MiningId = 0;

        static public ResponseModel<dynamic> CreateAccount(string strUserAccount)
        {
            try
            {
                // post json
                var obj = new
                {
                    chainAcct = strUserAccount,
                    ip = ClsCommon.ClintInfor.M_IP,
                    winAcct = Environment.UserDomainName + "\\\\" + Environment.UserName,
                    os = Environment.OSVersion.VersionString
                };

                return ClsRequestApi<dynamic>.RequestPost(JsonConvert.SerializeObject(obj), Consts.Backend.M_ActionUrls.M_CreateAcct);

            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
                return new ResponseModel<dynamic>() { IsSuccess = false };
            }
        }

        static public bool StartApp(string strUserAccount)
        {
            try
            {
                // post json
                var obj = new
                {
                    chainAcct = strUserAccount,
                    isAppStart = true
                };

                var result = ClsRequestApi<int>.RequestPost(JsonConvert.SerializeObject(obj), Consts.Backend.M_ActionUrls.M_AddActivity);

                if (result.IsSuccess)
                {
                    M_UserLoginId = result.Data;
                }

                return result.IsSuccess;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
                return false;
            }
        }

        static public bool EndApp(string strUserAccount)
        {
            try
            {
                if (M_UserLoginId <= 0)
                {
                    StartApp(strUserAccount);
                }

                // post json
                var obj = new
                {
                    id = M_UserLoginId,
                    isAppEnd = true
                };

                var result = ClsRequestApi<dynamic>.RequestPost(JsonConvert.SerializeObject(obj), Consts.Backend.M_ActionUrls.M_AddActivity);

                return result.IsSuccess;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
                return false;
            }
        }

        static public bool StartMining(string strUserAccount)
        {
            try
            {
                if (M_UserLoginId == 0)
                {
                    StartApp(strUserAccount);
                }

                // post json
                var obj = new
                {
                    chainAcct = strUserAccount,
                    isMiningStart = true
                };

                var result = ClsRequestApi<int>.RequestPost(JsonConvert.SerializeObject(obj), Consts.Backend.M_ActionUrls.M_AddActivity);

                if (result.IsSuccess)
                {
                    M_MiningId = result.Data;
                }

                // 及时更新online时间，防止异常掉线后，开始挖矿时间>下线时间
                EndApp(strUserAccount);

                return result.IsSuccess;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
                return false;
            }
        }

        static public bool EndMining()
        {
            try
            {
                // post json
                var obj = new
                {
                    id = M_MiningId,
                    isMiningEnd = true,
                };

                var result = ClsRequestApi<dynamic>.RequestPost(JsonConvert.SerializeObject(obj), Consts.Backend.M_ActionUrls.M_AddActivity);
                return result.IsSuccess;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteLog(ex.Message, Consts.LogType.M_Error);
                return false;
            }
        }
    }
}
