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
    public class get_mh_medprocController : ApiController
    {

        [HttpPost]
        [ResponseType(typeof(MH_Mem_MedProcedureModel))]

        public IHttpActionResult Post(MH_Mem_MedProcedureModel model)
        {

            int flag = 1;
            mrmdbEntities db = new mrmdbEntities();
            MH_Mem_MedProcedure proc = new MH_Mem_MedProcedure();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            proc.MemMedProcId = model.MemMedProcId;
            proc.MemId = model.MemId;
            proc.MedProcId = model.MedProcId;
            proc.TPId = model.TPId;
            proc.AddedBy = model.AddedBy;
            proc.AddedOn = DateTime.Now;
            proc.UpdateBy = model.UpdateBy;
            proc.UpdateOn = DateTime.Now;
            proc.IsDel = false;

            db.MH_Mem_MedProcedure.Add(proc);
            db.SaveChanges();

            return Ok(flag);
        
        }
    }
}
