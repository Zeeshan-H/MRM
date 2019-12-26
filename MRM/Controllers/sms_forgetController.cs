using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class sms_forgetController : ApiController
    {
        //[HttpGet]
        //public IHttpActionResult Get(string username)
        //{
        //    mrmdbEntities db = new mrmdbEntities();
        //    var resp = (db.Mem_Info.Join(db.Mem_Contacts, prim => prim.MemId, number => number.MemId,

        //           (prim, number) => new
        //           {
        //               MemberId = prim.MemId,
        //               PrimaryNo = number.PrimaryNo
        //               //School = stdAward.School,
        //               //Class = stdAward.Class,
        //               //Grade = stdAward.Grade,
        //               // ScholarshipAmount = account.ScholarshipAmount
        //           })




        //        .Join(db.Mem_MemberToGroup, student => student.MemberId, award => award.MemId,
        //           (student, award) => new
        //           {
        //               MemberId = student.MemberId,
        //               MemGrpId = award.MemGrpId,
        //               Number = student.PrimaryNo
        //               //School = award.School,
        //               //Class = award.Class,
        //               //Grade = award.Grade,
        //               //AccountNumber = award.AccountNumber
        //           }))


        //           .Join(db.Gen_UserAccs.Where(x => x.Username == username), stdAward => stdAward.MemGrpId, account => account.MemGrpId,
        //           (stdAward, account) => new
        //           {
        //               MemberId = stdAward.MemberId,
        //               Username = account.Username,
        //               Number = stdAward.Number
        //               //School = stdAward.School,
        //               //Class = stdAward.Class,
        //               //Grade = stdAward.Grade,
        //               // ScholarshipAmount = account.ScholarshipAmount
        //           }).ToList();

        //    return Ok(resp);
        //}

        [HttpPost]

        public IHttpActionResult Post(Msg2 msg)
        {

            int flag = 1;

            int UserId = 0;
            int MemId = 0;

            string MyUsername = "923228429365"; //Your Username At Sendpk.com 
            string MyPassword = "4289"; //Your Password At Sendpk.com 
            //string toNumber = "923248402416"; //Recepient cell phone number with country code 
            string Masking = "MRM"; //Your Company Brand Name 
            //string MessageText = "Hello sir, this is zeeshan, testing.";
            string mobile = "";



            mrmdbEntities db = new mrmdbEntities();
            ForgetPass model = new ForgetPass();
            if (!ModelState.IsValid)
            {
                return Ok(BadRequest(ModelState));
            }
            var response = (db.Mem_Info.Join(db.Mem_Contacts, prim => prim.MemId, number => number.MemId,

                   (prim, number) => new
                   {
                       MemberId = prim.MemId,
                       PrimaryNo = number.PrimaryNo
                       //School = stdAward.School,
                       //Class = stdAward.Class,
                       //Grade = stdAward.Grade,
                       // ScholarshipAmount = account.ScholarshipAmount
                   })




                .Join(db.Mem_MemberToGroup, info => info.MemberId, group => group.MemId,
                   (info, group) => new
                   {
                       MemberId = info.MemberId,
                       MemGrpId = group.MemGrpId,
                       Number = info.PrimaryNo
                       //School = award.School,
                       //Class = award.Class,
                       //Grade = award.Grade,
                       //AccountNumber = award.AccountNumber
                   }))


                   .Join(db.Gen_UserAccs.Where(x => x.Username == msg.username), group => group.MemGrpId, account => account.MemGrpId,
                   (group, account) => new
                   {
                       //MemberId = stdAward.MemberId,
                       //Username = account.Username,
                       Number = group.Number,
                       UserId = account.UserId,
                       MemberId = group.MemberId
                       //School = stdAward.School,
                       //Class = stdAward.Class,
                       //Grade = stdAward.Grade,
                       // ScholarshipAmount = account.ScholarshipAmount
                   }).ToList();

            foreach (var obj in response)
            {
               
                    mobile = obj.Number;
                    UserId = obj.UserId;
                    MemId = obj.MemberId;

            }

  //          int[] arr = new int[2] {UserId, MemId};
            model.UserId = UserId;
            model.MemId = MemId;


            if (response.Count == 0)
                return Ok(0);
           
            
   //         list = Check(msg.username);


 //           flag = 1;

           
            
            //if (list != null)
            //{
               
                
            //    return Ok(flag);

            //}



            //var query = from m in entities.Mem_Contacts
            //            join md in entities.Mem_Info
            //            on m.PrimaryNo equals md.ParentMemId
            //            where m.PrimaryNo == "123456789" && md.ParentMemId == "0" 
            //            select new { m.MemId };


            //    entities.Msgs.Add(msg);
            //    entities.SaveChanges();

            String URI = "http://sendpk.com" +
            "/api/sms.php?" +
            "username=" + MyUsername +
            "&password=" + MyPassword +
            "&sender=" + Masking +
            "&mobile=" + mobile +
            "&message=" + Uri.UnescapeDataString(msg.msg); // Visual Studio 10-15 


 //           flag = 1;
            try
            {
                WebRequest req = WebRequest.Create(URI);
                WebResponse resp = req.GetResponse();
                var sr = new System.IO.StreamReader(resp.GetResponseStream());
                //   return  Ok(sr.ReadToEnd().Trim());
              
                return Ok(model);
            }


            catch (WebException ex)
            {
                flag = 3;

                var httpWebResponse = ex.Response as HttpWebResponse;



                if (httpWebResponse != null)
                {
                    switch (httpWebResponse.StatusCode)
                    {
                        case HttpStatusCode.NotFound:

                            return Ok(flag);
                        case HttpStatusCode.BadRequest:

                            return Ok(flag);
                        default:
                            return Ok(flag);

                    }
                }
            }


            return null;
        }

    }
}
