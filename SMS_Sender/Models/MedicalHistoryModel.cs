using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MedicalHistoryModel
    {
        public int MemID { get; set; }

        public int UserID { get; set; }

        public string MedCond { get; set; }

        public string  TimePeriod { get; set; }

        
    }
}