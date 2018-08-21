using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class DocumentResult
    {
        public IEnumerable<Data> data { get; set; }
        public IEnumerable<Messages> message { get; set; }

    }

}
