using System.ComponentModel;

namespace api.Model
{
    public class Plan
    {
        private Plan()
        {

        }

        [DefaultValue(value: "")]
        public string PLANTYPE { get; set; }
        [DefaultValue(value: "")]
        public string BEGIN { get; set; }
        [DefaultValue(value: "")]
        public string END { get; set; }

        public static Plan CreateInstance()
        {
            return new Plan();
        }
        private string test() => "";

    }
}