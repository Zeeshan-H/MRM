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

            List<usp_Gen_UserLogin_Result> list = new List<usp_Gen_UserLogin_Result>();
            //usp_Gen_UserLogin_Result obj = new usp_Gen_UserLogin_Result();

            list = entities.usp_Gen_UserLogin(uname, passkey).ToList();

            if (list.Count() == 0)
            {
                return Ok(flag);
            }
            else
                return Ok(list);



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
