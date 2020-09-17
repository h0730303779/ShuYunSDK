using System;
using System.Collections.Generic;
using System.Text;

namespace ShuYunSDK.Models
{
    public class SYConfig
    {
        public string Host { get; set; }
        public string AccessToken { get; set; }
        public string AppId { get; set; }
        public string Secret { get; set; }
        /// <summary>
        /// 测试默认qiushi6
        /// </summary>
        public string TenantName { get; set; }
    }
}
