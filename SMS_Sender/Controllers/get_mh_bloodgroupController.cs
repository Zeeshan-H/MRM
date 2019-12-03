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
    public class get_mh_bloodgroupController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(BloodGroupModel))]
        public IHttpActionResult Post(BloodGroupModel model)
        {
            int flag = 1;
            mrmdbEntities db = new mrmdbEntities();
            MH_Mem_BloodGroup bg = new MH_Mem_BloodGroup();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bg.MemBGId = model.MemBGId;
            bg.MemId = model.MemId;
            bg.BGroup = model.BGroup;
            bg.BGComments = model.BGComments;
            bg.AddedBy = model.AddedBy;
            bg.AddedOn = DateTime.Now;
            bg.UpdateBy = model.UpdateBy;
            bg.UpdateOn = DateTime.Now;

            db.MH_Mem_BloodGroup.Add(bg);
            db.SaveChanges();

            return Ok(flag);
            //Updating Model
            //model.MemBGId = bg.MemBGId;
            //model.AddedBy = bg.AddedBy;
            //model.AddedOn = bg.AddedOn;
            //model.UpdateBy = bg.UpdateBy;
            //model.UpdateOn = bg.UpdateOn;

            //return CreatedAtRoute("DefaultApi", new
            //    {
            //        id = model.MemBGId
            //    }, model);

        }
    }
}
