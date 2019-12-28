using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class VIS_VisitModel
    {
        public int VisitId { get; set; }
        public int MemId { get; set; }
        public System.DateTime VisitDate { get; set; }
        public string Symptoms { get; set; }
        public string Diagnoses { get; set; }
        public string MedFacility { get; set; }
        public string MedConsultant { get; set; }
        public string VisitTags { get; set; }
        public short VisitStatusId { get; set; }
        public short ReviewStatusId { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }
    }
}