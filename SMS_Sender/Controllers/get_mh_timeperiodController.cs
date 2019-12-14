using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mh_timeperiodController : ApiController
    {
        [HttpGet]

        public IHttpActionResult Get() {


            mrmdbEntities db = new mrmdbEntities();

            var q = (from time in db.MH_TimePeriod
                     select new
                     {

                         TPID = time.TPId,
                         TimePeriod = time.TimePeriod
                     }).ToList();

            return Ok(q);
        }
    }
}
