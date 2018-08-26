using System.ComponentModel;

namespace api.Model
{
    public class DocumentAction
    {
        private DocumentAction()
        {

        }

        [DefaultValue(value: "")]
        public string ActionCode { get; set; }
        [DefaultValue(value :false)]
        public string ActionText { get; set; }
        [DefaultValue(value: false)]
        public bool Enable { get; set; }
        [DefaultValue(value: false)]
        public bool Visible { get; set; }

        public static DocumentAction CreateInstance()
        {
            return new DocumentAction();
        }
    }
}