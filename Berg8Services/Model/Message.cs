using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Messages
    {
        private Messages()
        {

        }

        [DefaultValue(value: "Success")]
        public string Code { get; set; }
        [DefaultValue(value: "")]
        public string Message { get; set; }

        public static Messages CreateInstance()
        {
            return new Messages();
        }
        public static Messages CreateFailInstance()
        {
            return new Messages() { Code = MessageCode.Error.ToString()};
        }
    }
    public enum MessageCode
    {
        Success,
        Error,
        Warning,
    }
}
