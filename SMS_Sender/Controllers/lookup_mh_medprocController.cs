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
    public class lookup_mh_medprocController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(LookupMedProcModel))]

        public IHttpActionResult Post(MH_MedProcedureModel model)
        {
            mrmdbEntities db = new mrmdbEntities();

            MH_MedProcedure proc = new MH_MedProcedure();

            LookupMedProcModel look = new LookupMedProcModel();

            if (!ModelState.IsValid)
                return Ok(ModelState);

            proc.MedProc = model.MedProc;
            proc.AddedBy = model.UserId;
            proc.AddedOn = DateTime.Now;
            proc.UpdateOn = DateTime.Now;
            proc.UpdateBy = model.UserId;
            proc.IsDel = false;

            db.MH_MedProcedure.Add(proc);
            db.SaveChanges();

            look.MedProcId = proc.MedProcId;

            return CreatedAtRoute("DefaultApi", new
            {

                id = look.MedProcId
            }, look);

        }
    }
}
