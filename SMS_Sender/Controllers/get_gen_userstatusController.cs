using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_gen_userstatusController : ApiController
    {
            ModelFactory modelfactory;

            get_gen_userstatusController()
        {

            modelfactory = new ModelFactory();
        }
        public IEnumerable<Gen_UserStatusModel> Get()
        {

            Gen_UserStatusrepo gen_userstatusrepo = new Gen_UserStatusrepo();

            return gen_userstatusrepo.GetAllGen_UserStatus().ToList().Select(c => modelfactory.Create4(c));

        }

    }
}
