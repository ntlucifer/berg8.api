using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Document
    {
        public string CODE { get; set; }
        public string TYPE { get; set; }
        public string TRANS_DATE { get; set; }
        public string PLAN_BEGIN { get; set; }
        public string PLAN_END { get; set; }
        public string SUBJECT { get; set; }
        public Employee RREQUESTOR { get; set; }
        public string STATUS { get; set; }

        public static Document CreateInstance()
        {
            return new Document();
        }
    }
}
