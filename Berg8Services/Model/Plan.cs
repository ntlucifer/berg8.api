using System.ComponentModel;

namespace api.Model
{
    public class Plan
    {
        private Plan()
        {

        }

        [DefaultValue(value: "")]
        public string PlanType { get; set; }
        [DefaultValue(value: "")]
        public string Begin { get; set; }
        [DefaultValue(value: "")]
        public string End { get; set; }

        public static Plan CreateInstance()
        {
            return new Plan();
        }
        private string test() => "";

    }
}