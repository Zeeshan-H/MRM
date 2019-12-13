using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mh_familycondController : ApiController
    {
        [HttpPost]

        public IHttpActionResult Post(MedicalHistoryModel4 model)
        {
            int flag = 1;
            mrmdbEntities db = new mrmdbEntities();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<int> famcondIds = model.FamilyCond.Split(',').Select(int.Parse).ToList();

            db.MH_Mem_FamilyCondition.RemoveRange(db.MH_Mem_FamilyCondition.Where(c => c.MemId == model.MemID));
            db.SaveChanges();
            for (int i = 0; i < famcondIds.Count; i++)
            {

                MH_Mem_FamilyCondition fam = new MH_Mem_FamilyCondition();

                fam.MemId = model.MemID;
                fam.FamilyCondId = famcondIds[i];
                fam.AddedBy = model.UserID;
                fam.AddedOn = DateTime.Now;
                fam.UpdateBy = model.UserID;
                fam.UpdateOn = DateTime.Now;
                fam.IsDel = false;

                db.MH_Mem_FamilyCondition.Add(fam);
            
            }

            db.SaveChanges();

            return Ok(flag);
        
        }

    }
}
