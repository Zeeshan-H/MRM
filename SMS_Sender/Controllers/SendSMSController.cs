using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SMS_Sender.Controllers
{

    [RoutePrefix("api/SendingSMS")]

    public class SendingSMSController : ApiController
    {

       
       
        //Console.Read(); //to keep console window open if trying in visual studio 

        [HttpGet]

        public IEnumerable<Mem_Contacts> Check(string mobile)
        {


            List<Mem_Contacts> list = new List<Mem_Contacts>();
            using (mrmdbEntities entities = new mrmdbEntities())
            {

                list = entities.Mem_Contacts.Where(x => x.PrimaryNo.Contains(mobile)).ToList(); //entities.Msgs.ToList();
                return list;

            }

        }



        [HttpPost]

        public IHttpActionResult Post(Msg msg)
        {

            string flag = "1";
          

            string MyUsername = "923228429365"; //Your Username At Sendpk.com 
            string MyPassword = "4289"; //Your Password At Sendpk.com 
            //string toNumber = "923248402416"; //Recepient cell phone number with country code 
            string Masking = "Zeeshan"; //Your Company Brand Name 
            //string MessageText = "Hello sir, this is zeeshan, testing.";

            

            mrmdbEntities entities = new mrmdbEntities();
            if (!ModelState.IsValid)
            {
                return Ok(BadRequest(ModelState));
            }

            flag = "3";
            
                if (Check(msg.mobile).Count() != 0)
                {

                    return Ok(flag);

                }

           

            //var query = from m in entities.Mem_Contacts
            //            join md in entities.Mem_Info
            //            on m.PrimaryNo equals md.ParentMemId
            //            where m.PrimaryNo == "123456789" && md.ParentMemId == "0" 
            //            select new { m.MemId };


        //    entities.Msgs.Add(msg);
        //    entities.SaveChanges();

                String URI = "http://sendpk.com" +
                "/api/sms.php?" + 
                "username=" +   MyUsername +
                "&password=" +  MyPassword+
                "&sender=" + Masking +
                "&mobile=" + msg.mobile +
                "&message=" + Uri.UnescapeDataString(msg.msg); // Visual Studio 10-15 


                flag = "1";
            try
            {
                WebRequest req = WebRequest.Create(URI);
                WebResponse resp = req.GetResponse();
                var sr = new System.IO.StreamReader(resp.GetResponseStream());
             //   return  Ok(sr.ReadToEnd().Trim());

                return Ok(flag);
            }


            catch (WebException ex)
            {
                flag = "0";

                var httpWebResponse = ex.Response as HttpWebResponse;

                

                if (httpWebResponse != null)
                {
                    switch (httpWebResponse.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            return Ok(httpWebResponse.ToString() + URI.ToString());
                        case HttpStatusCode.BadRequest:
                           
                            return Ok(flag);
                        default:
                            return Ok(httpWebResponse.StatusCode.ToString());

                    }
                }
            }


            return null;

        }

        //[HttpGet]

        //public IEnumerable<Msg> Get()
        //{
        //    using (mrmdbEntities entities = new mrmdbEntities())
        //    {

        //        return entities.Msgs.ToList();

        //    }





        //}
    }
        
}

