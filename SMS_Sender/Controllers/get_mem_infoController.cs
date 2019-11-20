using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMS_Sender.Models;
using SMS_Sender.Models.MemberViewModel;
using System.Web.Http.Description;

namespace SMS_Sender.Controllers
{

    public class get_mem_infoController : ApiController
    {
        ModelFactory modelfactory;

        get_mem_infoController() {

            modelfactory = new ModelFactory();
        }

        public IEnumerable<Mem_InfoModel> Get()
        {

            Mem_Info_repo mem_info_repo = new Mem_Info_repo();

            return mem_info_repo.GetAllMemInfo().ToList().Select(c => modelfactory.Create(c));



        }

        [HttpPost]
        [ResponseType(typeof(MemberModel))]
        public IHttpActionResult Post(MemberModel model)
        {
            messsageEntities db = new messsageEntities();
            Mem_Info mem = new Mem_Info();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mem.MemTypeId = model.MemTypeId;
            mem.MemStatusId = model.MemStatusId;
            mem.ParentMemId = model.ParentMemId;
            mem.AddedOn = model.AddedOn;
            mem.AddedBy = model.AddedBy;
            mem.UpdateOn = model.UpdateOn;
            mem.UpdateBy = model.UpdateBy;

            db.Mem_Info.Add(mem);
            db.SaveChanges();

            int info_id = mem.MemId;

            Mem_Details details = new Mem_Details();
            details.MemDtlsId = model.MemDtlsId;
            details.MemId = info_id;
            details.FName = model.FName;
            details.MName = model.MName;
            details.LName = model.LName;
            details.TitleId = model.TitleId;
            details.UpdateOn = model.UpdateOn2;
            details.AddedOn = model.AddedOn2;
            details.AddedBy = model.AddedBy2;
            details.UpdateBy = model.UpdateBy2;


            db.Mem_Details.Add(details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new
            {
                id = model.MemId
            }, model);
        }

    }
}
