using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class RES_COMMAND
    {
        public IList<ACTION> ACTIONS { get; set; }
        public IList<Messages> MESSAGE { get; set; }
    }
}
