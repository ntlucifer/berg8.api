using System.ComponentModel;

namespace api.Model
{
    public class Employee
    {
        private Employee()
        {

        }
        [DefaultValue(value: "")]
        public string CODE { get; set; }
        [DefaultValue(value: "")]
        public string NAME { get; set; }
        [DefaultValue(value: "")]
        public string MOBILE { get; set; }
        [DefaultValue(value: "")]
        public string EMAIL { get; set; }
        [DefaultValue(value: "")]
        public string ACTIONON { get; set; }
        public string CONTACT_NO { get; internal set; }

        public static Employee CreateInstance()
        {
            return new Employee();
        }
    }
}