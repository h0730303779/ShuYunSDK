using System;
using System.Collections.Generic;
using System.Text;

namespace ShuYunSDK.Models
{
    public class ShuYunResult
    {
        /// <summary>
        /// 状态码 10000-成功 其他-失败
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 成功或失败
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 结果描述
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据 一般查询才有数据
        /// </summary>
        public object Data { get; set; }
    }
}
