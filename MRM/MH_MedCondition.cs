//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMS_Sender
{
    using System;
    using System.Collections.Generic;
    
    public partial class MH_MedCondition
    {
        public MH_MedCondition()
        {
            this.MH_Mem_MedCondition = new HashSet<MH_Mem_MedCondition>();
        }
    
        public int MedCondId { get; set; }
        public string MedCond { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }
    
        public virtual ICollection<MH_Mem_MedCondition> MH_Mem_MedCondition { get; set; }
    }
}
