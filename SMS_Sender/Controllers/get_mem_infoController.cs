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

        public IEnumerable<Gen_UserAccs> Check2(string username)
        {


            List<Gen_UserAccs> list = new List<Gen_UserAccs>();
            using (mrmdbEntities entities = new mrmdbEntities())
            {


                list = entities.Gen_UserAccs.Where(x => x.Username.Contains(username)).ToList();

                return list;
            }
        
        }

        public IEnumerable<Gen_UserGroup> Check3(int grpId)
        {

            List<Gen_UserGroup> list = new List<Gen_UserGroup>();

            using (mrmdbEntities entities = new mrmdbEntities())
            {

                list = entities.Gen_UserGroup.Where(x => x.GrpId == grpId).ToList(); //entities.Msgs.ToList();
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
            MF_Details mf = new MF_Details();
            Mem_MemberToGroup group = new Mem_MemberToGroup();
            Gen_UserAccs acc = new Gen_UserAccs();
            UserKey key = new UserKey();


            //DateTime dateTime = Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //if ((Check2(model.PrimaryNo).Count() != 0) && (model.isMF == 0))
            //{

            //    return Ok("Username already exists!");
            //}

            //if ((Check2(model.PrimaryNo).Count() != 0) && (model.isMF == 1))
            //{

            //    return Ok("Username already exists!");
            //}

                mem.MemId = model.MemId;
              
                
                mem.MemTypeId = 2;  // Creating individual
            
               
                mem.MemStatusId = 1;
                mem.ParentMemId = "0";
                mem.AddedOn = DateTime.Now;
                mem.AddedBy = 1;
                mem.UpdateOn = DateTime.Now;
                mem.UpdateBy = 1;

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
                model.UpdateBy = mem.UpdateBy;

                //To update UserKey Model

                key.MemId = mem.MemId;
                key.MemTypeId = mem.MemTypeId;
     //           key.ParentMemID = mem.ParentMemId;





                short title_id = model.TitleId;
                int info_id = mem.MemId;

                if (model.isMF == 0)
                {
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
                }

                if (model.isMF == 1)
                {

                    mf.MFDtlsId = model.MFDtlsId;
                    mf.MFStatus = "0";
                    mf.MemId = info_id;
                    mf.MFName = model.MFName;
                    mf.MFShortName = model.MFShortName;
                    mf.MFAddress = model.MFAddress;
                    mf.MFWeblink = model.MFWeblink;
                    mf.MFStatusId = 1;

                    db.MF_Details.Add(mf);
                    db.SaveChanges();

                
                }

                

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
                key.Altcontactno = model.AltContactNo;
                key.EmailAdd = model.EmailAdd;
                key.EmailAdd2 = model.EmailAdd2;

                group.MemGrpId = model.MemGrpId;
                group.MemId = info_id;
                if (model.MFId == 1)
                {
                    group.GrpId = model.GrpId;
                }


                group.GrpId = model.GrpId;
 
                int mf_dtlsid = mf.MFDtlsId;
                if (model.isMF == 1)
                {
                    group.MFId = mf_dtlsid;

                }

                if (model.isMF == 0)
                { 
                group.MFId = 0;
                }    
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

                List<Gen_UserGroup> grplist = new List<Gen_UserGroup>();
                grplist = Check3(group.GrpId).ToList();
                if (grplist.Count() != 0)
                {
              //      key.TitleDesc = list.ElementAt(0).TitleDesc;
                    key.UserGrp = grplist.ElementAt(0).UserGrp;
                }
                
                key.MFId = group.MFId;

                int mem_groupid = group.MemGrpId;



                acc.UserId = model.UserId;
                acc.MemGrpId = mem_groupid;



                if (model.isMF == 0)
                    acc.Username = model.PrimaryNo + "/" + model.FName;

                if (model.isMF == 1)
                    acc.Username = model.MFShortName + "/" + model.PrimaryNo + "/" + model.MFName;
                //else if(model.MemTypeId == 2)
                //acc.Username = model


                acc.PassKey = model.PassKey;
                acc.AddedBy = mem.AddedBy;
                acc.AddedOn = DateTime.Now;
                acc.UpdateBy = mem.UpdateBy;
                acc.UpdateOn = DateTime.Now;

                db.Gen_UserAccs.Add(acc);
                db.SaveChanges();

                key.Username = acc.Username;
                key.UserId = acc.UserId;

                //db.usp_Gen_UserLogin(acc.Username, acc.PassKey);
                model.MemGrpId = acc.MemGrpId;
                model.UserId = acc.UserId;
               

                return CreatedAtRoute("DefaultApi", new
                {
                    id = mem.MemId
                }, key);
            }
        

        

        

    }

    //For Power User
    public class getmf_detailsController : ApiController
        {

        [HttpGet]
        public IEnumerable<MF_Details> Get()
        {
            using (mrmdbEntities entities = new mrmdbEntities())
            {

                return entities.MF_Details.ToList();

            }


        }

        [HttpPost]
        [ResponseType(typeof(UserKey))]
        public IHttpActionResult Post(MFModel mf)
        {

            mrmdbEntities db = new mrmdbEntities();
            Mem_Info info = new Mem_Info();
            MF_Details details = new MF_Details();
            UserKey model = new UserKey();
            Mem_Contacts cont = new Mem_Contacts();
            Mem_MemberToGroup group = new Mem_MemberToGroup();
            Gen_UserAccs acc = new Gen_UserAccs();
     
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (Check2(mf.PrimaryNo).Count() != 0)
            //{

            //    return Ok("Username already exists!");
            //}

            info.MemId = model.MemId;
            info.MemTypeId = 3;
            info.MemStatusId = 1;
            info.ParentMemId = "0";
            info.AddedOn = DateTime.Now;
            info.AddedBy = 1;
            info.UpdateOn = DateTime.Now;
            info.UpdateBy = 1;

            db.Mem_Info.Add(info);
            db.SaveChanges();



//Update model
            model.MemId = info.MemId;
            model.MemTypeId = info.MemTypeId;
            //model.MemStatusId = info.MemStatusId;
            //model.ParentMemId = info.ParentMemId;
            //model.AddedOn = info.AddedOn;
            //model.UpdateOn = info.UpdateOn;
            //model.AddedBy = info.AddedBy;
            //model.UpdateBy = info.UpdateBy;

            int mem_id = info.MemId;

            details.MFDtlsId = mf.MFDtlsId;
            details.MFStatus = "0";
            details.MemId = mem_id;
            details.MFName = mf.MFName;
            details.MFShortName = mf.MFShortName;
            details.MFAddress = mf.MFAddress;
            details.MFWeblink = mf.MFWeblink;
            details.MFStatusId = 1;

            db.MF_Details.Add(details);
            db.SaveChanges();

            //Update Model
            model.FName = details.MFName;
            model.LName = details.MFShortName;


            cont.ContactID = mf.ContactID;
            cont.MemId = mem_id;
            cont.PrimaryNo = mf.PrimaryNo;
            cont.AltContactNo = mf.AltContactNo;
            cont.NoType = 1;
            cont.EmailAdd = mf.EmailAdd;
            cont.EmailAdd2 = mf.EmailAdd2;

            db.Mem_Contacts.Add(cont);
            db.SaveChanges();
            //Update Model

            model.PrimaryNo = cont.PrimaryNo;
            model.EmailAdd = cont.EmailAdd;


            //Mem_MemberToGroup

            group.MemGrpId = mf.MemGrpId;
            group.MemId = mem_id;
            group.GrpId = 13;   //For Power User
            group.MFId = details.MFDtlsId;
            group.UserStatusId = 1;
            group.AddedBy = info.AddedBy;
            group.AddedOn = DateTime.Now;
            group.UpdateBy = info.UpdateBy;
            group.UpdateOn = DateTime.Now;

            db.Mem_MemberToGroup.Add(group);
            db.SaveChanges();

            int mem_grpid = group.MemGrpId;

            //Update Model
            model.MemGrpId = group.MemGrpId;
            model.MFId = group.MFId;


            //Gen_Useraccs

            acc.UserId = 2;
            acc.MemGrpId = mem_grpid;

          
            
            
                if (mf.GrpId == 13)  //For Power User
                    acc.Username = cont.PrimaryNo + "/" + details.MFShortName;
                //else if(model.MemTypeId == 2)
                //acc.Username = model
           
            acc.PassKey = mf.PassKey;
            acc.AddedBy = info.AddedBy;
            acc.AddedOn = DateTime.Now;
            acc.UpdateBy = info.UpdateBy;
            acc.UpdateOn = DateTime.Now;
            acc.Username = mf.PrimaryNo + "/" + mf.MFShortName;

            db.Gen_UserAccs.Add(acc);
            db.SaveChanges();

            //Update Model
            model.Username = acc.Username;
            model.UserGrp = "Power User";


            return CreatedAtRoute("DefaultApi", new
            {
                id = model.MemId
            }, model);    
        
        }

        public IEnumerable<Mem_Contacts> Check2(string primaryno)
        {


            List<Mem_Contacts> list = new List<Mem_Contacts>();
            using (mrmdbEntities entities = new mrmdbEntities())
            {


                list = entities.Mem_Contacts.Where(x => x.PrimaryNo.Contains(primaryno)).ToList();

                return list;
            }

        }
        


       }
}
