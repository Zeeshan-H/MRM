using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Mem_DetailsModel
    {

        public int MemDtlsId { get; set; }
        public int MemId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public int TitleId { get; set; }
        public DateTime UpdateOn { get; set; }
        public DateTime AddedOn { get; set; }
        public int AddedBy { get; set; }
        public int UpdateBy { get; set; }

    }
}