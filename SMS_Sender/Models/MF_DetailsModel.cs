using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MF_DetailsModel
    {

        public int MFDtlsId { get; set; }
        public string MFStatus { get; set; }
        public int MemId { get; set; }
        public string MFName { get; set; }
        public string MFShortName { get; set; }
        public string MFAddress { get; set; }
        public string MFWeblink { get; set; }
        public short MFStatusId { get; set; }

        public IEnumerable<MF_StatusModel> MF_Status { get; set; }

    }
}