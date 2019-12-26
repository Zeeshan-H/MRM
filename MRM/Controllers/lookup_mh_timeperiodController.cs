using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SMS_Sender.Controllers
{
    public class lookup_mh_timeperiodController : ApiController
    {

        [HttpPost]
        [ResponseType(typeof(LookupTimePeriodModel))]
        public IHttpActionResult Post(MH_TimePeriod time)
        {

            mrmdbEntities db = new mrmdbEntities();

            LookupTimePeriodModel look = new LookupTimePeriodModel();

            db.MH_TimePeriod.Add(time);
            db.SaveChanges();

            look.TPId = time.TPId;

            return CreatedAtRoute("DefaultApi", new
            {

                id = look.TPId
            }, look);
        
        }
    }
}
