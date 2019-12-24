using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class vis_saveimagesController : ApiController
    {
        [HttpPost]

        public IHttpActionResult Post(VIS_FileAttachmentModel model)
        {
            int flag = 1;
            mrmdbEntities db = new mrmdbEntities();
            VIS_FileAttachment file = new VIS_FileAttachment();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            file.MemId = model.MemId;
            file.VisitId = model.VisitId;
            file.AttName = model.AttName;
            file.AttStatusId = 1;
            file.AddedBy = model.AddedBy;
            file.AddedOn = DateTime.Now;
            file.UpdateBy = file.AddedBy;
            file.UpdateOn = DateTime.Now;
            file.IsDel = false;

            db.VIS_FileAttachment.Add(file);
            db.SaveChanges();

            return Ok(flag);
        
        }
    }
}
