using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    using api.Model;
    using api.Model.Request;

    [EnableCors(Setting.policyOriginName)]
    public class WorkflowController : Controller
    {
        public IList<Document> Add(IFilter filter)
        {
            throw new NotImplementedException();
        }

        public IList<Document> Delete(IFilter filter)
        {
            throw new NotImplementedException();
        }

        #region [ GetDocuments ]
        //[DisableCors]
        [HttpPost]
        public IActionResult GetDocuments([FromBody] REQ_DOCUMENT request)
        {
            IList<Document> document = new List<Document>();
            List<Messages> message = new List<Messages>();
            RES_DOCUMENT result = new RES_DOCUMENT();
            //ACTIVITY_REQUEST request = null;
            try
            {
                //if (request == null)
                //{
                //    request = new ACTIVITY_REQUEST() { ACTION = ACTIONS.INIT };
                //    request.FILTER = new FILTER_ACTIVITY();
                //}
                //if (request.ACTION == ACTIONS.INIT)
                //    data = this.REQ_INTI(request);
                //else if (request.ACTION == ACTIONS.AMEND)
                //    data = this.REQ_INTI(request);
                //else if (request.ACTION == ACTIONS.APPROVE)
                //    data = this.REQ_INTI(request);
                //else if (request.ACTION == ACTIONS.ADD)
                //    data = this.REQ_INTI(request);
                //else if (request.ACTION == ACTIONS.REJECT)
                //    data = this.REQ_INTI(request);
                //else if (request.ACTION == ACTIONS.SNDBACK)
                //    data = this.REQ_INTI(request);
                //else if (request.ACTION == ACTIONS.XLS)
                //    data = this.REQ_INTI(request);
                //else if (request.ACTION == ACTIONS.PDF)
                //    data = this.REQ_INTI(request);
                document = REQ_INTI(request);
                message.Add(Messages.CreateInstance());
            }
            catch (Exception ex)
            {
                message.Add(Messages.CreateFailInstance(ex));
            }
            finally
            {
                result.DOCUMENTS = document;
                result.MESSAGES = message;
            }
            return Ok(result);
        }
        public IList<Document> Initialized(IFilter filter)
        {
            throw new NotImplementedException();
        }
        public IList<Document> Update(IFilter filter)
        {
            throw new NotImplementedException();
        }
        private IList<Document> REQ_INTI(REQ_DOCUMENT request)
        {
            IList<Document> oDocuments = new List<Document>();
            try
            {
                Document oDocument = null;
                int ilength = new Random().Next(10, 100);
                for (int i = 0; i < ilength; i++)
                {
                    oDocument = Document.CreateInstance();
                    //oDocument.ActivityName = request.FILTER.ACTIVITY_NAME;
                    oDocument.CODE = string.Format("DocumentNo {0}", i);
                    oDocument.TYPE = request.FILTER.REQUESTOR == null || request.FILTER.REQUEST_TYPE.Count() <= 1 ? "Plan" : request.FILTER.REQUEST_TYPE[i % 2];
                    oDocument.PLAN_BEGIN = request.FILTER.PERIOD_EXPENSE.BEGIN == null || request.FILTER.PERIOD_EXPENSE.BEGIN == "" ? DateTime.Now.ToString("yyyy-MM-dd") : request.FILTER.PERIOD_EXPENSE.BEGIN;
                    oDocument.PLAN_END = request.FILTER.PERIOD_EXPENSE.END == null || request.FILTER.PERIOD_EXPENSE.END == "" ? new DateTime(9999, 12, 31).ToString("yyyy-MM-dd") : request.FILTER.PERIOD_EXPENSE.END;
                    //oDocument.Description = string.Format("Request {0}", i);
                    //oDocument.Version = i.ToString();
                    //oDocument.Revision = "1";
                    //oDocument.Creator = Employee.CreateInstance();
                    //oDocument.Creator.NAME = request.FILTER == null || request.FILTER.REQUESTOR == null || request.FILTER.REQUESTOR == "" ? "xercise" : request.FILTER.REQUESTOR;
                    //oDocument.Creator.MOBILE = "0839990001";
                    //oDocument.Creator.ACTIONON = DateTime.Now.ToString("yyyy-MM-dd");
                    oDocument.RREQUESTOR = Employee.CreateInstance();
                    oDocument.RREQUESTOR.NAME = request.FILTER == null || request.FILTER.REQUESTOR == null || request.FILTER.REQUESTOR == "" ? "Ton" : request.FILTER.REQUESTOR;
                    oDocument.RREQUESTOR.MOBILE = "0839990002";
                    oDocument.RREQUESTOR.ACTIONON = DateTime.Now.ToString("yyyy-MM-dd");
                    //oDocument.Approver = Employee.CreateInstance();
                    //oDocument.Approver.NAME = request.FILTER == null || request.FILTER.REQUESTOR == null || request.FILTER.REQUESTOR == "" ? "Lucifer" : request.FILTER.REQUESTOR;
                    //oDocument.Approver.MOBILE = "0839990003";
                    //oDocument.Approver.ACTIONON = DateTime.Now.ToString("yyyy-MM-dd");
                    //oDocument.Actions = this.REQ_COMMAND();
                    oDocument.STATUS = "";
                    oDocument.TRANS_DATE = oDocument.PLAN_BEGIN;
                    oDocuments.Add(oDocument);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oDocuments;
        }
        #endregion [ GetDocuments ]
        #region [ GetCommandButton ]
        [HttpPost]
        public IActionResult GetCommandActions([FromBody] REQ_COMMAND pRequest)
        {
            IList<ACTION> oActions = new List<ACTION>();
            List<Messages> oMessage = new List<Messages>();
            RES_COMMAND oResult = new RES_COMMAND();

            try
            {
                //if (pRequest.OPERATOR.Code == "")
                //{
                oActions = this.REQ_COMMAND();
                oMessage.Add(Messages.CreateInstance());
                //}
            }
            catch (Exception ex)
            {
                oMessage.Add(Messages.CreateFailInstance(ex));
            }
            finally
            {
                oResult.ACTIONS = oActions;
                oResult.MESSAGES = oMessage;
            }
            return Ok(oResult);
        }
        private IList<ACTION> REQ_COMMAND()
        {
            IList<ACTION> oDocumentActions = new List<ACTION>();
            ACTION oAction = null;
            oAction = ACTION.CreateInstance();
            oAction.CODE = "ADD";
            oAction.TEXT = "เพิ่ม";
            oAction.ENABLED = true;
            oAction.VISIBLED = true;
            oDocumentActions.Add(oAction);

            oAction = ACTION.CreateInstance();
            oAction.CODE = "AMEND";
            oAction.TEXT = "แก้ไข";
            oAction.ENABLED = true;
            oAction.VISIBLED = true;
            oDocumentActions.Add(oAction);

            oAction = ACTION.CreateInstance();
            oAction.CODE = "APPROVE";
            oAction.TEXT = "อนุมัติ";
            oAction.ENABLED = true;
            oAction.VISIBLED = true;
            oDocumentActions.Add(oAction);

            oAction = ACTION.CreateInstance();
            oAction.CODE = "REJECT";
            oAction.TEXT = "ไม่อนุมัติ";
            oAction.ENABLED = true;
            oAction.VISIBLED = true;
            oDocumentActions.Add(oAction);

            oAction = ACTION.CreateInstance();
            oAction.CODE = "SNDBACK";
            oAction.TEXT = "ส่งกลับ";
            oAction.ENABLED = true;
            oAction.VISIBLED = true;
            oDocumentActions.Add(oAction);

            oAction = ACTION.CreateInstance();
            oAction.CODE = "XLS";
            oAction.TEXT = "นำออกเป็น Excel";
            oAction.ENABLED = true;
            oAction.VISIBLED = true;
            oDocumentActions.Add(oAction);

            oAction = ACTION.CreateInstance();
            oAction.CODE = "PDF";
            oAction.TEXT = "นำออกเป็น PDF";
            oAction.ENABLED = true;
            oAction.VISIBLED = true;
            oDocumentActions.Add(oAction);
            return oDocumentActions;
        }
        #endregion
        #region [ GetTasks ]
        [HttpPost]
        public IActionResult GetTasks([FromBody] REQ_TASK pRequest)
        {
            IList<TASK> oActions = new List<TASK>();
            List<Messages> oMessage = new List<Messages>();
            RES_TASK oResult = new RES_TASK();
            try
            {
                oActions = this.REQ_TASK();
                oMessage.Add(Messages.CreateInstance());
            }
            catch (Exception ex)
            {
                oMessage.Add(Messages.CreateFailInstance(ex));
            }
            finally
            {
                oResult.TASKS = oActions;
                oResult.MESSAGES = oMessage;
            }
            return Ok(oResult);

        }
        private IList<TASK> REQ_TASK()
        {
            IList<TASK> oTASK_List = new List<TASK>();
            TASK oTASK = null;
            int ilength = new Random().Next(10, 100);
            int iEmpGroup = 0;
            string EmployeeCode = string.Empty;
            for (int i = 0; i < ilength; i++)
            {
                iEmpGroup = new Random().Next(1000, 10000);
                oTASK = TASK.CreateInstance();
                oTASK.REQUESTOR = Employee.CreateInstance();
                oTASK.REQUESTOR.CODE = string.Format("{0}{1}",iEmpGroup.ToString("000000"),i);
                oTASK.REQUESTOR.EMAIL = string.Format("{0}@Berg8.com",oTASK.REQUESTOR.CODE);
                oTASK.REQUESTOR.MOBILE = new Random().Next(800000000, 999999999).ToString();
                oTASK.REQUESTOR.NAME = string.Format("{0}", oTASK.REQUESTOR.CODE);
                oTASK.REQUESTOR.CONTACT_NO = oTASK.REQUESTOR.CODE;
                oTASK_List.Add(oTASK);
            }
            return oTASK_List;
        }
        #endregion
    }
}