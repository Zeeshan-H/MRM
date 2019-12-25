using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mh_routinemedsController : ApiController
    {
        [HttpPost]

        public IHttpActionResult Post(MedicalHistoryModel6 model)
        {

            int flag = 1;


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            mrmdbEntities db = new mrmdbEntities();
            MH_Mem_RoutineMeds routine = new MH_Mem_RoutineMeds();

            var routinemeds = db.MH_Mem_RoutineMeds.FirstOrDefault(x => x.MemMedsId == model.MemMedsId);

            if (model.MemMedsId == 0)
            {

                routine.MemId = model.MemID;
                routine.MemMeds = model.StrItems;
                routine.AddedBy = model.UserID;
                routine.AddedOn = DateTime.Now;
                routine.UpdateBy = routine.AddedBy;
                routine.UpdateOn = DateTime.Now;

                db.MH_Mem_RoutineMeds.Add(routine);
                db.SaveChanges();
            }
            else {

                routinemeds.MemId = model.MemID;
                routinemeds.MemMeds = model.StrItems;
                routinemeds.UpdateBy = model.UserID;
                routinemeds.UpdateOn = DateTime.Now;

                db.SaveChanges();
            }

            return Ok(flag);

        }

        [HttpGet]

        public IHttpActionResult Get(int memid)
        {

            mrmdbEntities db = new mrmdbEntities();
            int flag = 0;
            var routines = (from r in db.MH_Mem_RoutineMeds.Where(x => x.MemId==memid)
                            select new
                            {

                                MemMedsId = r.MemMedsId,
                                MemMeds = r.MemMeds

                            });

            if (routines.Count() == 0)
                return Ok(flag);
            else
            
                return Ok(routines);

            
        }
    }
}
