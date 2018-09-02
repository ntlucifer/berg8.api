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
    public class WorkflowController : Controller, IUIAction<IList<Data>>
    {
        public IList<Data> Add(IFilter filter)
        {
            throw new NotImplementedException();
        }

        public IList<Data> Delete(IFilter filter)
        {
            throw new NotImplementedException();
        }

        #region [ GetDocuments ]
        //[DisableCors]
        [HttpPost]
        public IActionResult GetDocuments([FromBody] ACTIVITY_REQUEST request)
        {
            IList<Data> data = new List<Data>();
            List<Messages> message = new List<Messages>();
            DocumentResult result = new DocumentResult();
            //ACTIVITY_REQUEST request = null;
            try
            {
                //if (request == null)
                //{
                //    request = new ACTIVITY_REQUEST() { ACTION = ACTIONS.INIT };
                //    request.FILTER = new FILTER_ACTIVITY();
                //}
                if (request.ACTION == ACTIONS.INIT)
                    data = this.REQ_INTI(request);
                else if (request.ACTION == ACTIONS.AMEND)
                    data = this.REQ_INTI(request);
                else if (request.ACTION == ACTIONS.APPROVE)
                    data = this.REQ_INTI(request);
                else if (request.ACTION == ACTIONS.ADD)
                    data = this.REQ_INTI(request);
                else if (request.ACTION == ACTIONS.REJECT)
                    data = this.REQ_INTI(request);
                else if (request.ACTION == ACTIONS.SNDBACK)
                    data = this.REQ_INTI(request);
                else if (request.ACTION == ACTIONS.XLS)
                    data = this.REQ_INTI(request);
                else if (request.ACTION == ACTIONS.PDF)
                    data = this.REQ_INTI(request);

                message.Add(Messages.CreateInstance());
            }
            catch (Exception ex)
            {
                message.Add(Messages.CreateFailInstance(ex));
            }
            finally
            {
                result.data = data;
                result.message = message;
            }
            return Ok(result);
        }
        public IList<Data> Initialized(IFilter filter)
        {
            throw new NotImplementedException();
        }
        public IList<Data> Update(IFilter filter)
        {
            throw new NotImplementedException();
        }
        #endregion [ GetDocuments ]
        #region GetCommandButton
        [HttpPost]
        public IActionResult GetCommandActions(REQ_COMMAND pRequest)
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
                oResult.MESSAGE = oMessage;
            }
            return Ok(oResult);
        }
        #endregion
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
        private IList<Data> REQ_INTI(ACTIVITY_REQUEST request)
        {
            IList<Data> datas = new List<Data>();
            try
            {
                Data oData = null;
                ACTION oAction = null; 
                for (int i = 0; i < 50; i++)
                {
                    oData = Data.CreateInstance();
                    oData.ActivityName = request.FILTER.ACTIVITY_NAME;
                    oData.DocumentNo = string.Format("DocumentNo {0}", i);
                    oData.Plan = Plan.CreateInstance();
                    oData.Plan.PlanType = request.FILTER.REQUESTOR == null || request.FILTER.REQUEST_TYPE.Count() <= 1 ? "Plan" : request.FILTER.REQUEST_TYPE[i % 2];
                    oData.Plan.Begin = request.FILTER.PERIOD_EXPENSE.BEGIN == null || request.FILTER.PERIOD_EXPENSE.BEGIN == "" ? DateTime.Now.ToString("yyyy-MM-dd") : request.FILTER.PERIOD_EXPENSE.BEGIN;
                    oData.Plan.End = request.FILTER.PERIOD_EXPENSE.END == null || request.FILTER.PERIOD_EXPENSE.END == "" ? new DateTime(9999, 12, 31).ToString("yyyy-MM-dd") : request.FILTER.PERIOD_EXPENSE.END;
                    oData.Description = string.Format("Request {0}", i);
                    oData.Version = i.ToString();
                    oData.Revision = "1";
                    oData.Creator = Employee.CreateInstance();
                    oData.Creator.Name = request.FILTER == null || request.FILTER.REQUESTOR == null || request.FILTER.REQUESTOR == "" ? "xercise" : request.FILTER.REQUESTOR;
                    oData.Creator.Mobile = "0839990001";
                    oData.Creator.ActionOn = DateTime.Now.ToString("yyyy-MM-dd");
                    oData.Requestor = Employee.CreateInstance();
                    oData.Requestor.Name = request.FILTER == null || request.FILTER.REQUESTOR == null || request.FILTER.REQUESTOR == "" ? "Ton" : request.FILTER.REQUESTOR;
                    oData.Requestor.Mobile = "0839990002";
                    oData.Requestor.ActionOn = DateTime.Now.ToString("yyyy-MM-dd");
                    oData.Approver = Employee.CreateInstance();
                    oData.Approver.Name = request.FILTER == null || request.FILTER.REQUESTOR == null || request.FILTER.REQUESTOR == "" ? "Lucifer" : request.FILTER.REQUESTOR;
                    oData.Approver.Mobile = "0839990003";
                    oData.Approver.ActionOn = DateTime.Now.ToString("yyyy-MM-dd");
                    oData.Actions = this.REQ_COMMAND();

                    datas.Add(oData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datas;
        }
    }
}