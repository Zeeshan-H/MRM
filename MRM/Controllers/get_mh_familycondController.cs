﻿using SMS_Sender.Models;
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
            short tabid = 4;
            mrmdbEntities db = new mrmdbEntities();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.usp_MH__Mem_UpdateSelections(model.MemID, model.UserID, model.FamilyCond + ",", "", tabid);
            return Ok(flag);
        }
//   //         List<int> famcondIds = model.FamilyCond.Split(',').Select(int.Parse).ToList();

//            //db.MH_Mem_FamilyCondition.RemoveRange(db.MH_Mem_FamilyCondition.Where(c => c.MemId == model.MemID));
//            //db.SaveChanges();


//            for (int i = 0; i < famcondIds.Count; i++)
//            {
//                if(list[0])
//                //MH_Mem_FamilyCondition fam = new MH_Mem_FamilyCondition();

//                //fam.MemId = model.MemID;
//                //fam.FamilyCondId = famcondIds[i];
//                //fam.AddedBy = model.UserID;
//                //fam.AddedOn = DateTime.Now;
//                //fam.UpdateBy = model.UserID;
//                //fam.UpdateOn = DateTime.Now;
//                //fam.IsDel = false;

//                //db.MH_Mem_FamilyCondition.Add(fam);
            
//            }

////            db.SaveChanges();

//            return Ok(flag);
        
//        }

        public IHttpActionResult Put(int famcondid, int userid, MH_FamilyCondition model)
        {

            int flag = 0;

            try
            {
                using (mrmdbEntities db = new mrmdbEntities())
                {

                    var famcond = db.MH_FamilyCondition.FirstOrDefault(x => x.FamilyCondId == famcondid);

                    if (famcond == null)
                        return Ok(flag);

                    else {


                        famcond.FamilyCond = model.FamilyCond;
                        famcond.UpdateBy = userid;
                        famcond.UpdateOn = DateTime.Now;

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
