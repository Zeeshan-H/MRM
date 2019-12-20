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
        //[HttpGet]

        //public IEnumerable<MH_Mem_MedCondition> Check(int memid)
        //{


        //    List<MH_Mem_MedCondition> list = new List<MH_Mem_MedCondition>();
        //    using (mrmdbEntities entities = new mrmdbEntities())
        //    {

        //        list = entities.MH_Mem_MedCondition.Where(x => x.MemId == memid).ToList(); //entities.Msgs.ToList();
        //        return list;

        //    }

        //}

        [HttpPost]

        public IHttpActionResult Post(MedicalHistoryModel2 model)
        {

            int flag = 1;
            short tabid=2;
            mrmdbEntities db = new mrmdbEntities();
            //    MH_Mem_MedProcedure proc = new MH_Mem_MedProcedure();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.usp_MH__Mem_UpdateSelections(model.MemID, model.UserID, model.MedProc + ",", model.TimePeriod + ",", tabid);
            return Ok(flag);
        }
     //       List<int> procIds = model.MedProc.Split(',').Select(int.Parse).ToList();
     //       List<short> timeIDs = model.TimePeriod.Split(',').Select(short.Parse).ToList();

     //       db.MH_Mem_MedProcedure.RemoveRange(db.MH_Mem_MedProcedure.Where(c => c.MemId == model.MemID));
     //       db.SaveChanges();

     //       for (int i = 0; i < procIds.Count; i++)
     //       {
     //           MH_Mem_MedProcedure proc = new MH_Mem_MedProcedure();
     ////           proc.MemMedProcId = model.MemMedProcId;
     //           proc.MemId = model.MemID;
     //           proc.MedProcId = procIds[i];
     //           proc.TPId = timeIDs[i];
     //           proc.AddedBy = model.UserID;
     //           proc.AddedOn = DateTime.Now;
     //           proc.UpdateBy = model.UserID;
     //           proc.UpdateOn = DateTime.Now;
     //           proc.IsDel = false;

     //           db.MH_Mem_MedProcedure.Add(proc);


                
     //       }
     //       db.SaveChanges();

     //       return Ok(flag);
        
     //   }
    }
}
