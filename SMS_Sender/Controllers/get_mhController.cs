using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mhController : ApiController
    {
        [HttpGet]

        public IHttpActionResult Get(int memid)
        {

            int flag = 0;
            mrmdbEntities entities = new mrmdbEntities();

            List<usp_MH_GetAllHistorySecs_Result> list = new List<usp_MH_GetAllHistorySecs_Result>();

            list = entities.usp_MH_GetAllHistorySecs(memid).ToList();

            if (list.ElementAt(0).BloodGroup == null)
            {
                return Ok(flag);
            }
            else
                return Ok(list);
        
        }
    }
}
