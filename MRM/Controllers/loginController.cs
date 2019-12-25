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
    public class loginController : ApiController
    {
        mrmdbEntities entities = new mrmdbEntities();
        [HttpPost]

        public IHttpActionResult Post(string username, string password)
        {
         //   bool isUserExist = entities.usp_Gen_UserLogin(username, password));

            UserKey user = new UserKey();
            
            bool exist = entities.Gen_UserAccs.Any(i => i.Username == username && i.PassKey == password);

            if (exist)
            {

                return Ok(user);
            }
            else
                return Ok("Failed");
        }

        [HttpGet]

        public IHttpActionResult Get(string uname, string passkey)
        {
            int flag = 0;
            mrmdbEntities entities = new mrmdbEntities();

            UserKey key = new UserKey();

            List<usp_Gen_UserLogin_Result> list = new List<usp_Gen_UserLogin_Result>();
            //usp_Gen_UserLogin_Result obj = new usp_Gen_UserLogin_Result();

            list = entities.usp_Gen_UserLogin(uname, passkey).ToList();


            if (list.Any())
            {
                key.UserId = list.ElementAt(0).UserId;
                key.MemGrpId = list.ElementAt(0).MemGrpId;
                key.MemId = list.ElementAt(0).MemId;
                key.GrpId = list.ElementAt(0).GrpId;
                key.UserGrp = list.ElementAt(0).UserGrp;
                key.MemTypeId = list.ElementAt(0).MemTypeId;
                key.FName = list.ElementAt(0).FName;
                key.LName = list.ElementAt(0).LName;
                key.TitleDesc = list.ElementAt(0).TitleDesc;
                key.PrimaryNo = list.ElementAt(0).PrimaryNo;
                key.Altcontactno = list.ElementAt(0).AltContactNo;
                key.EmailAdd2 = list.ElementAt(0).EmailAdd2;
                key.EmailAdd = list.ElementAt(0).EmailAdd;
                key.MFShortName = list.ElementAt(0).MFShortName;
                key.MFDtlsId = list.ElementAt(0).MFDtlsId;
                key.Username = list.ElementAt(0).Username;

                return Ok(key);

            }
            else 
                    {
                        return Ok(flag);
                    }
                    
            
                

        }

       
        //public IHttpActionResult Post(Mem_Contacts cont)
        //{

        //    bool isUserExist = entities.Mem_Contacts.Any(i => i.PrimaryNo == cont.PrimaryNo && i.EmailAdd == cont.EmailAdd);

        //    if (isUserExist)
        //    {

        //  //      Guid guid = Guid.NewGuid();
        //  //      return guid.ToString();
        //        return CreatedAtRoute("DefaultApi", new
        //        {
        //            id = cont.ContactID
        //        }, cont);
        //    }
        //    else
        //    {

        //        return Ok("Login Faild");
        //    }
        //}

    }
}
