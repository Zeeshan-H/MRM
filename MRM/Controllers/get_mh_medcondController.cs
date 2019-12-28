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
        //        [ResponseType(typeof(MedicalHistoryModel))]
        public IHttpActionResult Post(MedicalHistoryModel model)
        {

            int flag = 1;
            short tabid = 1;
            mrmdbEntities db = new mrmdbEntities();
            //    MH_Mem_MedConditionModel model2 = new MH_Mem_MedConditionModel();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            db.usp_MH__Mem_UpdateSelections(model.MemID, model.UserID, model.MedCond + ",", model.TimePeriod + ",", tabid);
            return Ok(flag);
        }
        //    List<int> condIDs = model.MedCond.Split(',').Select(int.Parse).ToList();
        //    List<short> timeIDs = model.TimePeriod.Split(',').Select(short.Parse).ToList();

        //        db.MH_Mem_MedCondition.RemoveRange(db.MH_Mem_MedCondition.Where(c => c.MemId == model.MemID));
        //        db.SaveChanges();



        //        for (int i = 0; i < condIDs.Count; i++)
        //        {
        //            MH_Mem_MedCondition cond = new MH_Mem_MedCondition();

        //            //    cond.MemMedCond = model2.MemMedCond;
        //            cond.MemId = model.MemID;
        //            cond.MedCondId = condIDs[i];
        //            cond.TPId = timeIDs[i];
        //            cond.AddedBy = model.UserID;
        //            cond.AddedOn = DateTime.Now;
        //            cond.UpdateBy = model.UserID;
        //            cond.UpdateOn = DateTime.Now;
        //            cond.IsDel = false;

        //            db.MH_Mem_MedCondition.Add(cond);
        //        }



        //        db.SaveChanges();
           

        //    return Ok(flag);
        //}

        [HttpPut]

        public IHttpActionResult Put(int medcondid, int userid, MH_MedConditionModel model)
        {

            int flag=0;

            //MH_MedCondition medcond = new MH_MedCondition();

            try
            {

                using (mrmdbEntities db = new mrmdbEntities())
                {

                    var cond = db.MH_MedCondition.FirstOrDefault(x => x.MedCondId == medcondid);

                    if (cond == null)
                        return Ok(flag);
                    else {


                        cond.MedCond = model.MedCond;
                        cond.UpdateBy = userid;
                        cond.UpdateOn = DateTime.Now;

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

