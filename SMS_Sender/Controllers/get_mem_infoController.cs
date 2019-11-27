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


        public IEnumerable<Mem_Title> Check(short id)
        {


            List<Mem_Title> list = new List<Mem_Title>();
            using (mrmdbEntities entities = new mrmdbEntities())
            {

                list = entities.Mem_Title.Where(x => x.TitleId==id).ToList(); //entities.Msgs.ToList();
                return list;

            }

        }


        [HttpPost]
        [ResponseType(typeof(UserKey))]
        public IHttpActionResult Post(MemberModel model)
        {
            mrmdbEntities db = new mrmdbEntities();
            Mem_Info mem = new Mem_Info();
            Mem_Contacts cont = new Mem_Contacts();
            Mem_Details details = new Mem_Details();
            Mem_MemberToGroup group = new Mem_MemberToGroup();
            Gen_UserAccs acc = new Gen_UserAccs();
            Mem_Title title = new Mem_Title();
            UserKey key = new UserKey();

            
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
            model.AddedBy = mem.AddedBy;
            model.MemStatusId = mem.MemStatusId;
            model.MemTypeId = mem.MemTypeId;
            model.ParentMemId = mem.ParentMemId;
            model.AddedOn = DateTime.Now;
            model.UpdateOn = DateTime.Now;

            //To update UserKey Model

            key.MemId = mem.MemId;
            key.MemTypeId = mem.MemTypeId;
            key.ParentMemID = mem.ParentMemId;





            short title_id = model.TitleId;
            int info_id = mem.MemId;
            

            details.MemDtlsId = model.MemDtlsId;
            details.MemId = info_id;
            details.FName = model.FName;
            details.MName = model.MName;
            details.LName = model.LName;
            details.TitleId = model.TitleId;
            details.UpdateOn = DateTime.Now;
            details.AddedOn = DateTime.Now;
            details.AddedBy = 1;
            details.UpdateBy = 1;


            db.Mem_Details.Add(details);
            db.SaveChanges();


            List<Mem_Title> list = new List<Mem_Title>();
            list = Check(details.TitleId).ToList();
            if (list.Count() != 0)
            {

                //key.TitleDesc = list.Select(x => x.TitleDesc).ToString();
                key.TitleDesc = list.ElementAt(0).TitleDesc;
            }
            model.MemId2 = info_id;
            model.MemDtlsId = details.MemDtlsId;
            model.TitleId = details.TitleId;
            model.UpdateBy = details.UpdateBy;
            key.TitleId = details.TitleId;
          
            
            cont.ContactID = model.ContactID;
            cont.MemId = info_id;
            cont.PrimaryNo = model.PrimaryNo;
            cont.AltContactNo = model.AltContactNo;
            cont.NoType = 1;
            cont.EmailAdd = model.EmailAdd;
            cont.EmailAdd2 = model.EmailAdd2;

            //UserKey class updation

            key.FName = model.FName;
            key.LName = model.LName;

            db.Mem_Contacts.Add(cont);
            db.SaveChanges();


            model.MemId3 = info_id;
            model.ContactID = cont.ContactID;
            model.NoType = cont.NoType;

            //UserKey class updation

            key.PrimaryNo = model.PrimaryNo;
            key.EmailAdd = model.EmailAdd;

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


            model.GrpId = group.GrpId;
            model.MFId = group.MFId;
            model.UserStatusId = group.UserStatusId;
            //model.AddedBy = group.AddedBy;
            //model.UpdateBy = group.UpdateBy;

            //Userkey class updation
            key.MemGrpId = group.MemGrpId;
            key.UserGrp = "Owner";
            key.MFId = group.MFId;

            int mem_groupid = group.MemGrpId;

           

            acc.UserId = model.UserId;
            acc.MemGrpId = mem_groupid;
            acc.Username = model.Username;
            acc.PassKey = model.PassKey;
            acc.AddedBy = mem.AddedBy;
            acc.AddedOn = DateTime.Now;
            acc.UpdateBy = mem.UpdateBy;
            acc.UpdateOn = DateTime.Now;

            db.Gen_UserAccs.Add(acc);
            db.SaveChanges();

            key.Username = model.Username;

            //db.usp_Gen_UserLogin(acc.Username, acc.PassKey);
            model.MemGrpId = acc.MemGrpId;
            model.UserId = acc.UserId;

            return CreatedAtRoute("DefaultApi", new
            {
                id = mem.MemId
            }, key);
        }

    }
}
