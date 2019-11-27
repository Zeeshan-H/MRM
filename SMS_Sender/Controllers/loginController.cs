using SMS_Sender.Models;
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

        public IHttpActionResult Post(Mem_Contacts cont)
        {

            bool isUserExist = entities.Mem_Contacts.Any(i => i.PrimaryNo == cont.PrimaryNo && i.EmailAdd == cont.EmailAdd);

            if (isUserExist)
            {

          //      Guid guid = Guid.NewGuid();
          //      return guid.ToString();
                return CreatedAtRoute("DefaultApi", new
                {
                    id = cont.ContactID
                }, cont);
            }
            else
            {

                return Ok("Login Faild");
            }
        }

    }
}
