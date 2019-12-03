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
    public class get_mh_medcondController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(MH_Mem_MedConditionModel))]
        public IHttpActionResult Post(MH_Mem_MedConditionModel model)
        {

            int flag = 1;
            mrmdbEntities db = new mrmdbEntities();
            MH_Mem_MedCondition cond = new MH_Mem_MedCondition();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            cond.MemMedCond = model.MemMedCond;
            cond.MemId = model.MemId;
            cond.MedCondId = model.MedCondId;
            cond.TPId = model.TPId;
            cond.AddedBy = model.AddedBy;
            cond.AddedOn = DateTime.Now;
            cond.UpdateBy = model.UpdateBy;
            cond.UpdateOn = DateTime.Now;
            cond.IsDel = false;

            db.MH_Mem_MedCondition.Add(cond);
            db.SaveChanges();

            return Ok(flag);
        }


    }
}

