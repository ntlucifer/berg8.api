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
            try
            {
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

                message.Add(new Messages
                {
                    Code = "Success",
                    Message = ""
                });
            }
            catch (Exception ex)
            {
                message.Add(new Messages
                {
                    Code = "Error",
                    Message = ex.Message
                });
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


        private IList<Data> REQ_INTI(ACTIVITY_REQUEST request)
        {
            
            IList<Data> datas = new List<Data>();
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    datas.Add(new Data
                    {
                        
                        ActivityName = request.FILTER.ACTIVITY_NAME,
                        DocumentNo = string.Format("DocumentNo {0}", i),
                        Plan = new Plan()
                        {
                            PlanType = request.FILTER.REQUEST_TYPE.Count() <= 1? "Plan" : request.FILTER.REQUEST_TYPE[i % 2],
                            Begin = request.FILTER.PERIOD_EXPENSE.BEGIN == null? DateTime.Now.ToString("yyyy-MM-dd") : request.FILTER.PERIOD_EXPENSE.BEGIN,
                            End = request.FILTER.PERIOD_EXPENSE.END == null? new DateTime(9999, 12, 31).ToString("yyyy-MM-dd") : request.FILTER.PERIOD_EXPENSE.END
                        },
                        Description = string.Format("Request {0}", i),
                        Version = i.ToString(),
                        Revision = "1",
                        Requestor = new Requestor()
                        {
                            Name = request.FILTER.REQUESTOR == null? "xercise" : request.FILTER.REQUESTOR,
                            Mobile = "083999XXX9",
                            ActionOn = DateTime.Now.ToString("yyyy-MM-dd")
                        }
                    });
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