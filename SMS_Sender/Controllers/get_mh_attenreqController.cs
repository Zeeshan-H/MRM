using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mh_attenreqController : ApiController
    {

        [HttpPost]

        public IHttpActionResult Post(MedicalHistoryModel5 model)
        {

            int flag = 1;
            mrmdbEntities db = new mrmdbEntities();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<int> attenIds = model.FamilyCond.Split(',').Select(int.Parse).ToList();

            for (int i = 0; i < attenIds.Count; i++)
            {

                MH_Mem_AttentionReq req = new MH_Mem_AttentionReq();

                req.MemId = model.MemID;
                req.AttItemId = attenIds[i];
                req.AddedBy = model.UserID;
                req.AddedOn = DateTime.Now;
                req.UpdateBy = model.UserID;
                req.UpdateOn = DateTime.Now;

                db.MH_Mem_AttentionReq.Add(req);



            }

            db.SaveChanges();

            return Ok(flag);
        }
    }
}
