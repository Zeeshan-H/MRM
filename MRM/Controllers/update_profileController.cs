using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class update_profileController : ApiController
    {

        [HttpPut]

        public IHttpActionResult Put(UpdateProfile prof)
        {
            int flag = 0;
            int flag2 = 1;
            try
            {
                using (mrmdbEntities db = new mrmdbEntities())
                {

                    var details = db.Mem_Details.FirstOrDefault(x => x.MemId == prof.MemId);
                    var contacts = db.Mem_Contacts.FirstOrDefault(x => x.MemId == prof.MemId);

                    if (details == null)
                        return Ok(flag);
                    else
                    {


                        details.FName = prof.FName;
                        details.MName = prof.MName;
                        details.LName = prof.LName;
                        contacts.EmailAdd = prof.EmailAdd;
                        contacts.EmailAdd2 = prof.EmailAdd2;
                        contacts.AltContactNo = prof.AltContactNo;


                        db.SaveChanges();

                        return Ok(flag2);
                    
                    }

                
                
                }

            }
            catch (Exception e)
            {

                return Ok(e);
            
            }

        
        
        }
    }
}
