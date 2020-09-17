using ShuYunSDK.Models;
using ShuYunSDK.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuYunSDK
{
    public class Demo
    {
        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="config"></param>
        /// <param name="memberrRegister"></param>
        /// <returns></returns>
        public ShuYunResult MemberRegister(SYConfig config, MemberrRegister memberrRegister)
        {
            string actionMethod = "shuyun.loyalty.member.register";//必须为POST方式
            //var result = PostRequestSnd(actionMethod, config, json);
            IClient client = new SYRestClient(config);
            string memberrRegisterJsonData = Newtonsoft.Json.JsonConvert.SerializeObject(memberrRegister);
            string result = client.PostRequestSnd(actionMethod, memberrRegisterJsonData);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ShuYunResult>(result);
        }
    }
}
