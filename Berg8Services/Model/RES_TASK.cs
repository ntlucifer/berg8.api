using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class RES_TASK
    {
        public IList<TASK> TASKS { get; set; }
        public IList<Messages> MESSAGES { get; set; }
    }
}
