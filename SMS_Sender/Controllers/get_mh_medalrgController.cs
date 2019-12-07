using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mh_medalrgController : ApiController
    {
        [HttpPost]

        public IHttpActionResult Post(MedicalHistoryModel3 model)
        {

            int flag = 1;
            mrmdbEntities db = new mrmdbEntities();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<int> alrgIds = model.MedAlrg.Split(',').Select(int.Parse).ToList();

            for (int i = 0; i < alrgIds.Count; i++)
            {

                MH_Mem_MedAllergy alrg = new MH_Mem_MedAllergy();

                alrg.MemId = model.MemID;
                alrg.MedAlrgId = alrgIds[i];
                alrg.AddedBy = model.UserID;
                alrg.AddedOn = DateTime.Now;
                alrg.UpdateBy = model.UserID;
                alrg.UpdateOn = DateTime.Now;
                alrg.IsDel = false;

                db.MH_Mem_MedAllergy.Add(alrg);
            
            }

            db.SaveChanges();

            return Ok(flag);
        
        }
    }

}
