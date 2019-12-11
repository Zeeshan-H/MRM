using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MH_MedProcedureModel
    {
        public int MedProcId { get; set; }
        public string MedProc { get; set; }
        public int UserId { get; set; }
        public System.DateTime AddedOn { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }
    }
}