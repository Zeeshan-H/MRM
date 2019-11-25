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
            mrmdbEntities db = new mrmdbEntities();
            Mem_Info mem = new Mem_Info();
            Mem_Contacts cont = new Mem_Contacts();
            Mem_Details details = new Mem_Details();
            Mem_MemberToGroup group = new Mem_MemberToGroup();
            Gen_UserAccs acc = new Gen_UserAccs();
            //DateTime dateTime = Now;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


     
            mem.MemId = model.MemId;
            mem.MemTypeId = 2;
            mem.MemStatusId = 2;
            mem.ParentMemId = "0";
            mem.AddedOn = DateTime.Now;
            mem.AddedBy = 1;
            mem.UpdateOn = DateTime.Now;
            mem.UpdateBy = model.UpdateBy;

            db.Mem_Info.Add(mem);
            db.SaveChanges();
            
            model.MemId = mem.MemId;
            model.MemDtlsId = details.MemDtlsId;
            model.ContactID = cont.ContactID;
            model.AddedOn = DateTime.Now;
            model.UpdateOn = DateTime.Now;


            int info_id = mem.MemId;
            

            details.MemDtlsId = model.MemDtlsId;
            details.MemId = info_id;
            details.FName = model.FName;
            details.MName = model.MName;
            details.LName = model.LName;
            details.TitleId = 1;
            details.UpdateOn = DateTime.Now;
            details.AddedOn = DateTime.Now;
            details.AddedBy = 1;
            details.UpdateBy = 1;


            db.Mem_Details.Add(details);
            db.SaveChanges();

            model.MemDtlsId = details.MemDtlsId;

            cont.ContactID = model.ContactID;
            cont.MemId = info_id;
            cont.PrimaryNo = model.PrimaryNo;
            cont.AltContactNo = model.AltContactNo;
            cont.NoType = 1;
            cont.EmailAdd = model.EmailAdd;
            cont.EmailAdd2 = model.EmailAdd2;

            db.Mem_Contacts.Add(cont);
            db.SaveChanges();

            model.ContactID = cont.ContactID;

            group.MemGrpId = model.MemGrpId;
            group.MemId = model.MemId;
            group.GrpId = 6;
            group.MFId = 0;
            group.UserStatusId = 1;
            group.AddedBy = 1;
            group.AddedOn = DateTime.Now;
            group.UpdateBy = 1;
            group.UpdateOn = DateTime.Now;

            db.Mem_MemberToGroup.Add(group);
            db.SaveChanges();


            int mem_groupid = group.MemGrpId;


            acc.UserId = model.UserId;
            acc.MemGrpId = mem_groupid;

            acc.PassKey = model.PassKey;
            acc.AddedBy = mem.AddedBy;
            acc.AddedOn = DateTime.Now;
            acc.UpdateBy = mem.UpdateBy;
            acc.UpdateOn = DateTime.Now;

            db.Gen_UserAccs.Add(acc);
            db.SaveChanges();

            model.MemGrpId = acc.MemGrpId;

            return CreatedAtRoute("DefaultApi", new
            {
                id = mem.MemId
            }, model);
        }

    }
}
