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
    
    public partial class MH_TimePeriod
    {
        public MH_TimePeriod()
        {
            this.MH_Mem_MedCondition = new HashSet<MH_Mem_MedCondition>();
            this.MH_Mem_MedProcedure = new HashSet<MH_Mem_MedProcedure>();
        }
    
        public string TimePeriod { get; set; }
        public short TPId { get; set; }
    
        public virtual ICollection<MH_Mem_MedCondition> MH_Mem_MedCondition { get; set; }
        public virtual ICollection<MH_Mem_MedProcedure> MH_Mem_MedProcedure { get; set; }
    }
}
