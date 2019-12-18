using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_titlesController : ApiController
    {
        [HttpGet]

        public IHttpActionResult Get()
        {

            mrmdbEntities db = new mrmdbEntities();

            var titles = (from t in db.Mem_Title
                          select new
                          {
                              TitleId = t.TitleId,
                              TitleDesc = t.TitleDesc

                          }).ToList();

            return Ok(titles);
        
        }
    }
}
