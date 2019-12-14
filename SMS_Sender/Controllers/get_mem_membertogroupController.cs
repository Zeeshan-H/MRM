using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mem_membertogroupController : ApiController
    {

        ModelFactory modelfactory;

        get_mem_membertogroupController()
        {

            modelfactory = new ModelFactory();
        }

        public IEnumerable<Mem_MemberToGroupModel> Get()
        {

            Mem_MemtoGrouprepo mem_info_repo = new Mem_MemtoGrouprepo();

            return mem_info_repo.GetAllMem_MemtoGroup().ToList().Select(c => modelfactory.Create2(c));

        }



    }
}
