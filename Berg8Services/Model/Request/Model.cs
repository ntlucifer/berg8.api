using System;
using System.Collections.Generic;
using api.Controllers;

namespace api.Model.Request
{

    public class PROFILE
    {
        public string USER_CODE { get; set; }
        public string POSITION_CODE { get; set; }

    }

    public class PERMITTION
    {
        public string BUTTON { get; set; }
    }
    public class FILTER_ACTIVITY : IFilter
    {
        public string ACTIVITY_NAME { get; set; }
        public string[] REQUEST_TYPE { get; set; }
        public string DESCTIPTION { get; set; }
        public string REQUESTOR { get; set; }
        public PERIOD PERIOD_EXPENSE { get; set; }
        public FILTER_ACTIVITY()
        {
            this.PERIOD_EXPENSE = PERIOD.CreateInstance();
        }
    }

    public class PERIOD
    {
        public string BEGIN { get; set; }
        public string END { get; set; }

        private PERIOD()
        {
            this.BEGIN = string.Empty;
            this.END = string.Empty;
        }
        public static PERIOD CreateInstance()
        {
            PERIOD instance = new PERIOD();
            return instance;
        }
    }

    public enum ACTIONS
    {
        INIT,
        ADD,
        AMEND,
        APPROVE,
        REJECT,
        SNDBACK,
        XLS,
        PDF
    }

    public class REQ_DOCUMENT
    {
        public string REFRESH_TOKEN { get; set; }
        public FILTER_ACTIVITY FILTER { get; set; }
        public Employee OPERATOR { get; set; }
    }

    public class REQ_COMMAND
    {
        public string REFRESH_TOKEN { get; set; }
        public Employee OPERATOR { get; set; }
    }

    public class REQ_TASK
    {
        public string REFRESH_TOKEN { get; set; }
        public Employee OPERATOR { get; set; }
    }
}