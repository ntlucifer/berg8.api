using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Data
    {
        private Data()
        {

        }

        [DefaultValue(value: "")]
        public string DocumentNo { get; set; }
        public Plan Plan { get; set; }
        [DefaultValue(value: "")]
        public string Description { get; set; }
        [DefaultValue(value: "")]
        public string Version { get; set; }
        [DefaultValue(value: "")]
        public string Revision { get; set; }
        [DefaultValue(value: "")]
        public string ActivityName { get; set; }
        [DefaultValue(value: null)]
        public Employee Requestor { get; set; }
        [DefaultValue(value: null)]
        public Employee Creator { get; set; }
        [DefaultValue(value: null)]
        public Employee Approver { get; set; }
        [DefaultValue(value: null)]
        public List<DocumentAction> Actions { get; set; }

        public static Data CreateInstance()
        {
            return new Data();
        }
    }
}
