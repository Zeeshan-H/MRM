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
    public class lookup_mh_famcondController : ApiController
    {

        [HttpPost]
        [ResponseType(typeof(LookupMedFamCond))]

        public IHttpActionResult Post(MH_MedFamilyCondModel model)
        {

            mrmdbEntities db = new mrmdbEntities();

            MH_FamilyCondition fam = new MH_FamilyCondition();

            LookupMedFamCond look = new LookupMedFamCond();

            if (!ModelState.IsValid)
                return Ok(ModelState);

            fam.FamilyCond = model.FamilyCond;
            fam.AddedBy = model.Userid;
            fam.AddedOn = DateTime.Now;
            fam.UpdateBy = model.Userid;
            fam.UpdateOn = DateTime.Now;
            fam.IsDel = false;

            db.MH_FamilyCondition.Add(fam);
            db.SaveChanges();

            look.FamilyCondId = fam.FamilyCondId;


            return CreatedAtRoute("DefaultApi", new
            {

                id = look.FamilyCondId
            }, look);

        }
    }
}
