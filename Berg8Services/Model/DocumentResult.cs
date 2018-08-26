using System.Collections.Generic;

namespace api.Model
{
    public class DocumentResult
    {
        public IEnumerable<Data> data { get; set; }
        public IEnumerable<Messages> message { get; set; }
    }
}
