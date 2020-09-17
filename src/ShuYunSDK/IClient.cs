using System;
using System.Collections.Generic;
using System.Text;

namespace ShuYunSDK
{
    public interface IClient
    {


        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="actionMethod">接口</param>
        /// <param name="keyValues">请求头数据</param>
        /// <returns></returns>
        string GetRequestSnd(string actionMethod, Dictionary<string, string> keyValues);


        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="actionMethod">接口</param>
        /// <param name="json">请求json数据</param>
        /// <param name="IsPlatform">是否包含特定头(platform=offline) 默认false</param>
        /// <returns></returns>
        string PostRequestSnd(string actionMethod, string json, bool IsPlatform = false);



        /// <summary>
        /// PUT请求
        /// </summary>
        /// <param name="actionMethod">接口</param>
        /// <param name="json">请求json数据</param>
        /// <param name="IsPlatform">是否包含特定头(platform=offline) 默认false</param>
        string PutRequestSnd(string actionMethod, string json, bool IsPlatform = false);
    }
}
