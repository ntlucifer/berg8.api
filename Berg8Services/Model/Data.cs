using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Data
    {
        
        public string DocumentNo { get; set; }
        public Plan Plan { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        public string ActivityName { get; set; }
        public Requestor Requestor { get; set; }
    }
}
