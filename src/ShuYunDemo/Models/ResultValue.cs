using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShuYunDemo.Models
{
    public class ResultValue
    {
        public static ResultValue Current = new ResultValue();
        public object Data { get; set; }
        public string Id { get; set; }
        public string Msg { get; set; }
        public int MsgCode { get; set; }
        public bool Prompt { get; set; }
        public bool Result { get; set; }
    }
}
