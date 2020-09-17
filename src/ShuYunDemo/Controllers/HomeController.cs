using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShuYunDemo.Common;
using ShuYunDemo.Models;
using ShuYunSDK;
using ShuYunSDK.Models;
using ShuYunSDK.Request;

namespace ShuYunDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ResultValue Send(TestMode testMode)
        {
            var result = ResultValue.Current;

            var json = testMode.Json;
            var config = testMode.Config;
            var actionMethod = testMode.ApiName;
            var Method = testMode.Method;
            var isPlatform = testMode.IsPlatform;
            if (string.IsNullOrEmpty(json))
            {
                result.MsgCode = 2;
                result.Msg = "json数据不能为空";
                return result;
            }
            if (config == null || string.IsNullOrEmpty(config.Host))
            {
                result.MsgCode = 2;
                result.Msg = "Host数据不能为空";
                return result;
            }
            try
            {
                IClient client = new SYRestClient(config);
                switch (Method)
                {
                    case "GET":
                        var pairs = json.ToObject<Dictionary<string, string>>();
                        result.Data = client.GetRequestSnd(actionMethod, pairs);
                        break;
                    case "POST":
                        result.Data = client.PostRequestSnd(actionMethod, json, isPlatform);
                        break;
                    case "PUT":
                        result.Data = client.PutRequestSnd(actionMethod, json, isPlatform);
                        break;
                    default:
                        result.MsgCode = 2;
                        result.Msg = "json数据不能为空";
                        break;
                }
                result.MsgCode = 1;
                return result;
            }
            catch (Exception er)
            {
                result.MsgCode = 3;
                result.Msg = "异常:" + er.Message;
                return result;
            }
        }
    }
}
