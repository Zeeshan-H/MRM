using SMS_Sender.Models;
using SMS_Sender.Models.MemberViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class update_passController : ApiController
    {
        public IEnumerable<Mem_Title> Check(short id)
        {

            List<Mem_Title> list = new List<Mem_Title>();

            using (mrmdbEntities db = new mrmdbEntities())
            {

                list = db.Mem_Title.Where(x => x.TitleId == id).ToList();
                return list;
            }
        
        }

        public IEnumerable<Gen_UserGroup> Check2(int grpid)
        {

            List<Gen_UserGroup> list = new List<Gen_UserGroup>();

            using (mrmdbEntities db = new mrmdbEntities())
            {

                list = db.Gen_UserGroup.Where(x => x.GrpId == grpid).ToList();
                return list;
            
            }
        
        
        }


        [HttpPut]

        public IHttpActionResult Put(int userid, int memid, UpdatePass acc)
        {
            int flag = 0;

            UserKey key = new UserKey();
            List<Mem_Title> list = new List<Mem_Title>();
            List<Gen_UserGroup> list2 = new List<Gen_UserGroup>();

            try
            {
            
                using(mrmdbEntities db = new mrmdbEntities())
                {
                
                var entity = db.Gen_UserAccs.FirstOrDefault(x => x.UserId == userid);
                var entity2 = db.Mem_MemberToGroup.FirstOrDefault(k => k.MemId == memid);
                var entity3 = db.Mem_Info.FirstOrDefault(l => l.MemId == memid);
                var entity4 = db.Mem_Contacts.FirstOrDefault(m => m.MemId == memid);
                var entity5 = db.Mem_Details.FirstOrDefault(o => o.MemId == memid);
                var entity6 = db.MF_Details.FirstOrDefault(p => p.MemId == memid);


                if (entity == null)
                    return Ok(flag);


                    if(entity5 == null)
                    {

                        key.MemId = entity2.MemId;
                        key.MemTypeId = entity3.MemTypeId;
                        key.PrimaryNo = entity4.PrimaryNo;
                        key.Altcontactno = entity4.AltContactNo;
                        key.EmailAdd = entity4.EmailAdd;
                        key.EmailAdd2 = entity4.EmailAdd2;
                        key.MemGrpId = entity2.MemGrpId;

                        key.MFId = entity2.MFId;
                        key.Username = entity.Username;
                        key.UserId = entity.UserId;
                        key.GrpId = entity2.GrpId;

                        list2 = Check2(key.GrpId).ToList();

                        if (list2.Count() != 0)
                        {

                            key.UserGrp = list2.ElementAt(0).UserGrp;
                        }
                        key.MFShortName = entity6.MFShortName;
                        key.MFDtlsId = entity6.MFDtlsId;

                        return Ok(key);
                        
       
                    }

                    else
                    {

                        entity.PassKey = acc.PassKey;

                        db.SaveChanges();

                        


                            key.MemId = entity2.MemId;
                            key.MemTypeId = entity3.MemTypeId;

                            key.TitleId = entity5.TitleId;

                            list = Check(key.TitleId).ToList();
                            if (list.Count() != 0)
                            {

                                key.TitleDesc = list.ElementAt(0).TitleDesc;
                            }


                            key.FName = entity5.FName;
                            key.LName = entity5.LName;
                            key.PrimaryNo = entity4.PrimaryNo;
                            key.Altcontactno = entity4.AltContactNo;
                            key.EmailAdd = entity4.EmailAdd;
                            key.EmailAdd2 = entity4.EmailAdd2;
                            key.MemGrpId = entity2.MemGrpId;

                            key.MFId = entity2.MFId;
                            key.Username = entity.Username;
                            key.UserId = entity.UserId;
                            key.GrpId = entity2.GrpId;

                            list2 = Check2(key.GrpId).ToList();

                            if (list2.Count() != 0)
                            {

                                key.UserGrp = list2.ElementAt(0).UserGrp;
                            }



                            //             key.MFDtlsId = entity6.MFDtlsId;

                            return Ok(key);
       
                        
                    }
                
                
                }
            
            }
            catch(Exception e)
            {
            
            return Ok(e);
            }
        
        
        }
    }
}
