using System;
using System.Collections.Generic;
using System.Text;

namespace ShuYunSDK.Models
{
    /// <summary>
    /// 会员注册信息
    /// </summary>
    public class MemberrRegister
    {
        /// <summary>
        /// 生日
        /// 格式:2018-12-25
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 平台编码，如果是微信，则传：WEIXIN
        /// 必填
        /// </summary>
        public string PlatCode { get; set; }
        /// <summary>
        /// 性别 F:女 M:男
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 开卡时间
        /// 格式:2018-12-25 09:30:00
        /// </summary>
        public string Created { get; set; }
        /// <summary>
        /// 名称
        /// 必填
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 手机号
        /// 必填
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 导购ID
        /// </summary>
        public string GuideId { get; set; }
        /// <summary>
        /// 平台会员ID 如果是微信账号，需要按格式：appid_openid
        /// 示例:1
        /// 必填
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 开卡店铺ID，如果是微信平台，则为小程序和公众号的appID
        /// 示例:123456
        /// 必填
        /// </summary>
        public string ShopId { get; set; }
    }
}
