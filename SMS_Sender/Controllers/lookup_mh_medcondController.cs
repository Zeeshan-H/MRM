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
    public class lookup_mh_medcondController : ApiController
    {

        [HttpPost]
        [ResponseType(typeof(LookupMedCondModel))]

        public IHttpActionResult Post(MH_MedConditionModel model)
        {

            mrmdbEntities db = new mrmdbEntities();

            MH_MedCondition cond = new MH_MedCondition();

            LookupMedCondModel look = new LookupMedCondModel();

            if (!ModelState.IsValid)
                return Ok(ModelState);
            cond.MedCond = model.MedCond;
            cond.AddedBy = model.UserId;
            cond.AddedOn = DateTime.Now;
            cond.UpdateBy = model.UserId;
            cond.UpdateOn = DateTime.Now;
            cond.IsDel = false;

            db.MH_MedCondition.Add(cond);
            db.SaveChanges();

            look.MedCondId = cond.MedCondId;

            return CreatedAtRoute("DefaultApi", new 
            { 
            
                id = look.MedCondId
            }, look);
        
        }


    }
}
