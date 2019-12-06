using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mem_info2Controller : ApiController
    {

        ModelFactory modelfactory;

        get_mem_info2Controller() {

            modelfactory = new ModelFactory();
        }


        public IEnumerable<Mem_InfoModel2> Get(int memid)
        {

            Mem_Info_repo2 mem_info_repo = new Mem_Info_repo2();

            return mem_info_repo.GetAllMemInfo_Byid(memid).ToList().Select(c => modelfactory.CreateMH(c));


        }
    }
}
