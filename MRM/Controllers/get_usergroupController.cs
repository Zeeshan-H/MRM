using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_usergroupController : ApiController
    {
        [HttpGet]

        public IHttpActionResult Get(int memtypeid)
        {

            int flag = 0;
            mrmdbEntities db = new mrmdbEntities();

            var group = (from g in db.Gen_UserGroup.Where(x => x.MemTypeId == memtypeid && x.GrpId != 13 && x.GrpId != 1) 
                         select new
                         {

                             GrpId = g.GrpId,
                             MemTypeId = g.MemTypeId,
                             Usergrp = g.UserGrp
                         });

            if (group.Count() == 0)
                return Ok(flag);
            else
                return Ok(group);
        
        
        }
    }
}
