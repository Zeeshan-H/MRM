using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MedicalHistoryModel2
    {

        public int MemID { get; set; }

        public int UserID { get; set; }

        public string MedProc { get; set; }
        public string TimePeriod { get; set; }
    }
}