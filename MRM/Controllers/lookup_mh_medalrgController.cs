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
    public class lookup_mh_medalrgController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(LookupMedAlrg))]

        public IHttpActionResult Post(MH_MedAllergyModel model)
        {

            mrmdbEntities db = new mrmdbEntities();

            MH_MedAllergy alrg = new MH_MedAllergy();

            LookupMedAlrg look = new LookupMedAlrg();

            if (!ModelState.IsValid)
                return Ok(ModelState);

            alrg.MedAlrg = model.MedAlrg;
            alrg.AddedBy = model.UserId;
            alrg.AddedOn = DateTime.Now;
            alrg.UpdateBy = model.UserId;
            alrg.UpdateOn = DateTime.Now;
            alrg.IsDel = false;

            db.MH_MedAllergy.Add(alrg);
            db.SaveChanges();

            look.MedAlrgId = alrg.MedAlrgId;

            return CreatedAtRoute("DefaultApi", new
            {

                id = look.MedAlrgId
            }, look);

        }
    }
}
