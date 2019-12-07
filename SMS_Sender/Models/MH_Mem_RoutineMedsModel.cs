using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MH_Mem_RoutineMedsModel
    {
        public int MemMedsId { get; set; }
        public int MemId { get; set; }
        public string MemMeds { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
    }
}