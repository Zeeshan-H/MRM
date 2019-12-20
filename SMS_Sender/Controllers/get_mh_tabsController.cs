using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mh_tabsController : ApiController
    {
        [HttpGet]

        public IHttpActionResult Get(int memid, short tabtype, int userid)
        {

            int flag = 0;
            mrmdbEntities db = new mrmdbEntities();

            List<usp_MH_PopulateMedHistoryTabs_Result> list = new List<usp_MH_PopulateMedHistoryTabs_Result>();

            list = db.usp_MH_PopulateMedHistoryTabs(memid, tabtype, userid).ToList();

            if (list.Count() == 0)

                return Ok(flag);
            else
                return Ok(list);
        
        }
    }
}
