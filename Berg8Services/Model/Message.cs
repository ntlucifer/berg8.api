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
        public string CODE { get; set; }
        [DefaultValue(value: "")]
        public string MESSAGE { get; set; }

        public static Messages CreateInstance()
        {
            return new Messages() { CODE = MessageCode.Success.ToString(),MESSAGE =""};
        }
        public static Messages CreateFailInstance(Exception ex)
        {
            return new Messages() { CODE = MessageCode.Error.ToString(),MESSAGE = ex.Message};
        }
    }
    public enum MessageCode
    {
        Success,
        Error,
        Warning,
    }
}
