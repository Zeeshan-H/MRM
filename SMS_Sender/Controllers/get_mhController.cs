using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_mhController : ApiController
    {
        [HttpGet]
        
        public IHttpActionResult Get(int memid)
        {

            int flag = 0;
            mrmdbEntities entities = new mrmdbEntities();

            MH_MedicalHistoryModel model = new MH_MedicalHistoryModel();

            List<usp_MH_GetAllHistorySecs_Result> list = new List<usp_MH_GetAllHistorySecs_Result>();

            list = entities.usp_MH_GetAllHistorySecs(memid).ToList();

            model.BloodGroup = list.ElementAt(0).BloodGroup;
            model.MedCondition = list.ElementAt(0).MedCondition;
            model.MedProcedure = list.ElementAt(0).MedProcedure;
            model.MedAllergy = list.ElementAt(0).MedAllergy;
            model.FamilyCond = list.ElementAt(0).FamilyCond;

            if (list.ElementAt(0).BloodGroup == null)
            {
                return Ok(flag);
            }
            else
                return Ok(model);
        
        }
    }
}
