using ShuYunSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShuYunDemo.Models
{
    public class TestMode
    {

        public string ApiName { get; set; }

        public string Method { get; set; }

        public SYConfig Config { get; set; }

        public string Json { get; set; }

        public bool IsPlatform { get; set; }
    }
}
