using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class vis_savevisitsController : ApiController
    {
        [HttpPost]

        public IHttpActionResult Post(VIS_VisitModel model)
        {

            int flag = 1;
            string symptoms, diagnosis, visittags;
            mrmdbEntities db = new mrmdbEntities();

            VIS_Visit visit = new VIS_Visit();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<string> symps = model.Symptoms.Split(',').ToList();
            List<string> diags = model.Diagnoses.Split(',').ToList();

            visittags = "#" + model.MedFacility.Trim().Replace(" ", "_") + " " + "#" + model.MedConsultant.Trim().Replace(" ", "_") + " " +
                    "#" + model.MedFacility.Trim().Replace(" ", "_") + "_" + model.MedConsultant.Trim().Replace(" ", "_") + "$";




            for(int i=0; i<symps.Count; i++)
            {

                symptoms = " " + "#" + symps[i].Trim();
                visittags = visittags + symptoms;
            }

            visittags = visittags + "$";

            for(int j=0; j<diags.Count; j++)
            {

                diagnosis = " " + "#" + diags[j].Trim();
                visittags = visittags + diagnosis;
            }

            visit.MemId = model.MemId;
            visit.VisitDate = model.VisitDate;
            visit.Symptoms = model.Symptoms;
            visit.Diagnoses = model.Diagnoses;
            visit.MedFacility = model.MedFacility;
            visit.MedConsultant = model.MedConsultant;
            visit.VisitTags = visittags;
            visit.VisitStatusId = 1;
            visit.ReviewStatusId = 1;
            visit.AddedBy = model.AddedBy;
            visit.AddedOn = DateTime.Now;
            visit.UpdateBy = visit.AddedBy;
            visit.UpdateOn = DateTime.Now;
            visit.IsDel = false;

            db.VIS_Visit.Add(visit);
            db.SaveChanges();

            return Ok(flag);
            }
        
    }
}
