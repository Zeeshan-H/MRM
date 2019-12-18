using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MH_MedConditionModel
    {
        public int MedCondId { get; set; }
        public string MedCond { get; set; }
        public int UserId { get; set; }
        public System.DateTime AddedOn { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }
    }
}