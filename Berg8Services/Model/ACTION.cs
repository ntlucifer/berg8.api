using System.ComponentModel;
using System.Xml.Serialization;

namespace api.Model
{
    public class ACTION
    {
        private ACTION()
        {

        }

        [DefaultValue(value: "")]
        public string CODE { get; set; }
        [DefaultValue(value :false)]
        public string TEXT { get; set; }
        [DefaultValue(value: false)]
        public bool ENABLED { get; set; }
        [DefaultValue(value: false)]
        public bool VISIBLED { get; set; }

        public static ACTION CreateInstance()
        {
            return new ACTION();
        }
    }
}