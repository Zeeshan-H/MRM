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


        [HttpPost]

        public IHttpActionResult Post(Msg msg)
        {

            String flag2 = "1", flag = "0";

            //string MyUsername = "923228429365"; //Your Username At Sendpk.com 
            //string MyPassword = "4289"; //Your Password At Sendpk.com 
            //string toNumber = "923248402416"; //Recepient cell phone number with country code 
            //string Masking = "Zeeshan"; //Your Company Brand Name 
            //string MessageText = "Hello sir, this is zeeshan, testing.";

            messsageEntities entities = new messsageEntities();
            if (!ModelState.IsValid)
            {
                return Ok(BadRequest(ModelState).ToString());
            }

            entities.Msgs.Add(msg);
            entities.SaveChanges();

                String URI = "http://sendpk.com" +
                "/api/sms.php?" + 
                "username=" +   msg.username +
                "&password=" + msg.pass +
                "&sender=" + msg.sender +
                "&mobile=" + msg.mobile +
                "&message=" + Uri.UnescapeDataString(msg.msg1); // Visual Studio 10-15 

            


            /*

            String URI = "http://sendpk.com" +
            "/api/sms.php?" +
            "username=" + MyUsername +
            "&password=" + MyPassword +
            "&sender=" + Masking +
            "&mobile=" + toNumber +
            "&message=" + Uri.UnescapeDataString(MessageText); // Visual Studio 10-15 

            */
            try
            {
                WebRequest req = WebRequest.Create(URI);
                WebResponse resp = req.GetResponse();
                var sr = new System.IO.StreamReader(resp.GetResponseStream());
             //   return  Ok(sr.ReadToEnd().Trim());
                return Ok(flag2.ToString());
            }


            catch (WebException ex)
            {
                var httpWebResponse = ex.Response as HttpWebResponse;

                

                if (httpWebResponse != null)
                {
                    switch (httpWebResponse.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            return Ok(httpWebResponse.ToString() + URI.ToString());
                        case HttpStatusCode.BadRequest:
                           
                            return Ok(flag.ToString());
                        default:
                            return Ok(httpWebResponse.StatusCode.ToString());

                    }
                }
            }


            return null;

        }

        [HttpGet]

        public IEnumerable<Msg> Get()
        {
            using (messsageEntities entities = new messsageEntities())
            {

                return entities.Msgs.ToList();

            }





        }
    }
        
}

