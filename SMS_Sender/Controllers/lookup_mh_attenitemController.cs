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
    public class lookup_mh_attenitemController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(LookupMedAttenitem))]

        public IHttpActionResult Post(MH_AttentionItem item)
        {

            mrmdbEntities db = new mrmdbEntities();
            LookupMedAttenitem look = new LookupMedAttenitem();
            if(!ModelState.IsValid)
                return Ok(ModelState);

            db.MH_AttentionItem.Add(item);
            db.SaveChanges();

            look.AttItemId = item.AttItemId;

            return CreatedAtRoute("DefaultApi", new
            {

                id = look.AttItemId
            }, look);
        }
    }
}
