using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MH_Mem_AttentionReqModel
    {
        public int MemAttItemId { get; set; }
        public int MemId { get; set; }
        public int AttItemId { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }

        
    }
}