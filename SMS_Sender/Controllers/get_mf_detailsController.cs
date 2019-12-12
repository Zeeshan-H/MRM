using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mf_detailsController : ApiController
    {
        ModelFactory modelfactory;

        get_mf_detailsController() {

            modelfactory = new ModelFactory();
        }
        public IEnumerable<MF_DetailsModel> Get()
        {

            MF_Detailsrepo mem_info_repo = new MF_Detailsrepo();

            return mem_info_repo.GetAllMF_Details().ToList().Select(c => modelfactory.Create5(c));



        }

    }
}
