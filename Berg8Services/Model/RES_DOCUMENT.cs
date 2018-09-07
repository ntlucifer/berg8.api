using System.Collections.Generic;

namespace api.Model
{
    public class RES_DOCUMENT
    {
        public IList<Document> DOCUMENTS { get; set; }
        public IList<Messages> MESSAGES { get; set; }
    }
}
