using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MH_MedFamilyCondModel
    {
        public int FamilyCondId { get; set; }
        public string FamilyCond { get; set; }
        public int Userid { get; set; }
        public System.DateTime AddedOn { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }
    }
}