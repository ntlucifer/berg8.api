using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class TASK
    {
        public Employee REQUESTOR { get; set; }
        public string WIDGET { get; set; }
        public string STATUS { get; set; }
        public decimal COUNT { get; set; }
        public static TASK CreateInstance()
        {
            return new TASK();
        }
    }
}
