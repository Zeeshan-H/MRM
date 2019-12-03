using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MedConditionModel
    {
        public int MemMedCond { get; set; }
        public int MemId { get; set; }
        public int MedCondId { get; set; }
        public short TPId { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }

        public IEnumerable<Mem_Info> Mem_Info { get; set; }
        public IEnumerable<MH_MedCondition> MH_MedCondition { get; set; }
        public IEnumerable<MH_TimePeriod> MH_TimePeriod { get; set; }

    }
}