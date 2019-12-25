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
            short tabid = 3;
            mrmdbEntities db = new mrmdbEntities();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            db.usp_MH__Mem_UpdateSelections(model.MemID, model.UserID, model.MedAlrg + ",", "", tabid);
            return Ok(flag);
        }

        //    List<int> alrgIds = model.MedAlrg.Split(',').Select(int.Parse).ToList();

        //    db.MH_Mem_MedAllergy.RemoveRange(db.MH_Mem_MedAllergy.Where(c => c.MemId == model.MemID));
        //    db.SaveChanges();
            
        //    for (int i = 0; i < alrgIds.Count; i++)
        //    {

        //        MH_Mem_MedAllergy alrg = new MH_Mem_MedAllergy();

        //        alrg.MemId = model.MemID;
        //        alrg.MedAlrgId = alrgIds[i];
        //        alrg.AddedBy = model.UserID;
        //        alrg.AddedOn = DateTime.Now;
        //        alrg.UpdateBy = model.UserID;
        //        alrg.UpdateOn = DateTime.Now;
        //        alrg.IsDel = false;

        //        db.MH_Mem_MedAllergy.Add(alrg);
            
        //    }

        //    db.SaveChanges();

        //    return Ok(flag);
        
        //}

        [HttpPut]

        public IHttpActionResult Put(int medalrgid, int userid, MH_MedAllergyModel model)
        {

            int flag = 0;

            try
            {
                using (mrmdbEntities db = new mrmdbEntities())
                {

                    var alrg = db.MH_MedAllergy.FirstOrDefault(x => x.MedAlrgId == medalrgid);

                    if (alrg == null)
                        return Ok(flag);

                    else
                    {

                        alrg.MedAlrg = model.MedAlrg;
                        alrg.UpdateBy = userid;
                        alrg.UpdateOn = DateTime.Now;

                        db.SaveChanges();

                        flag = 1;

                        return Ok(flag);
                    }
                
                }

            }
            catch (Exception e)
            {

                return Ok(e);
            }
        
        }
    }

}
