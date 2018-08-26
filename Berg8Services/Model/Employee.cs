using System.ComponentModel;

namespace api.Model
{
    public class Employee
    {
        private Employee()
        {

        }

        [DefaultValue(value: "")]
        public string Name { get; set; }
        [DefaultValue(value: "")]
        public string Mobile { get; set; }
        [DefaultValue(value: "")]
        public string ActionOn { get; set; }

        public static Employee CreateInstance()
        {
            return new Employee();
        }
    }
}