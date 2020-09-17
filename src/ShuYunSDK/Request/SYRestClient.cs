using RestSharp;
using ShuYunSDK.Common;
using ShuYunSDK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ShuYunSDK.Request
{
    public class SYRestClient : IClient
    {
        public SYConfig  Config { get; set; }

        public SYRestClient(SYConfig sYConfig)
        {
            Config = sYConfig;
        }


        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="actionMethod">接口</param>
        /// <param name="keyValues">请求头数据</param>
        /// <returns></returns>
        public string GetRequestSnd(string actionMethod, Dictionary<string, string> keyValues)
        {
            var result = RequestSnd(actionMethod, keyValues, Method.GET);
            return result;
        }


        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="actionMethod">接口</param>
        /// <param name="json">请求json数据</param>
        /// <param name="IsPlatform">是否包含特定头(platform=offline) 默认false</param>
        /// <returns></returns>
        public string PostRequestSnd(string actionMethod, string json, bool IsPlatform = false)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            var result = RequestSnd(actionMethod, keyValues, Method.POST, json, IsPlatform);
            return result;
        }

        /// <summary>
        /// PUT请求
        /// </summary>
        /// <param name="actionMethod">接口</param>
        /// <param name="json">请求json数据</param>
        /// <param name="IsPlatform">是否包含特定头(platform=offline) 默认false</param>
        public string PutRequestSnd(string actionMethod, string json, bool IsPlatform = false)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            var result = RequestSnd(actionMethod, keyValues, Method.PUT, json, IsPlatform);
            return result;
        }


        /// <summary>
        /// 接口:actionMethod/
        /// 查询参数:keyValues/
        /// 请求方式:Method 默认GET/
        /// 请求数据:Method为POST时,json必填/
        /// 是否特定的HTTP头(platform=offline): isplatform 默认false;
        /// </summary>
        private string RequestSnd(string actionMethod, Dictionary<string, string> keyValues, Method method = Method.GET, string json = null, bool isplatform = false)
        {
            var time = UnixTimeUtil.DtToUnix(DateTime.Now, 2).ToString();
            var sSign = GetSign(keyValues, time);
            var client = new RestClient(Config.Host);
            var request = new RestRequest(method);
            foreach (var item in keyValues)
            {
                request.AddQueryParameter(item.Key, item.Value);
            }
            if (isplatform) request.AddHeader("platform", "offline");
            request.AddHeader("Gateway-Authid", Config.AppId);
            request.AddHeader("Gateway-Request-Time", time);
            request.AddHeader("Gateway-Sign", sSign);
            request.AddHeader("Gateway-Action-Method", actionMethod);
            request.AddHeader("Gateway-Access-Token", Config.AccessToken);
            if (Method.POST == method || method == Method.PUT)
            {
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }
            IRestResponse response = client.Execute(request);
            return response.Content;
        }


        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        private string GetSign(Dictionary<string, string> keyValuePairs, string ts)
        {
            keyValuePairs.Add("Gateway-Request-Time", ts);
            keyValuePairs = AsciiDictionary(keyValuePairs);
            StringBuilder builder = new StringBuilder();
            builder.Append(Config.Secret);
            foreach (var item in keyValuePairs)
            {
                builder.Append(item.Key).Append(item.Value);
            }
            builder.Append(Config.Secret);
            return MD5Hash.GetMd5(builder.ToString());
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sArray"></param>
        /// <returns></returns>
        private Dictionary<string, string> AsciiDictionary(Dictionary<string, string> sArray)
        {
            Dictionary<string, string> asciiDic = new Dictionary<string, string>();
            string[] arrKeys = sArray.Keys.ToArray();
            Array.Sort(arrKeys, string.CompareOrdinal);
            foreach (var key in arrKeys)
            {
                string value = sArray[key];
                asciiDic.Add(key, value);
            }
            return asciiDic;
        }

    }
}
