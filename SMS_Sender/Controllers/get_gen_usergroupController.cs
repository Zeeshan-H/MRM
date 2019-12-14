using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_gen_usergroupController : ApiController
    {
         ModelFactory modelfactory;

        get_gen_usergroupController()
        {

            modelfactory = new ModelFactory();
        }
        public IEnumerable<Gen_UserGroupModel> Get()
        {

            Gen_UserGrouprepo gen_usergrouprepo = new Gen_UserGrouprepo();

            return gen_usergrouprepo.GetAllGen_UserGroup().ToList().Select(c => modelfactory.Create3(c));

        }
    }
}
