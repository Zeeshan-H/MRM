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
    
    public partial class MH_Mem_MedAllergy
    {
        public int MemMedAlrgId { get; set; }
        public int MemId { get; set; }
        public int MedAlrgId { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }
    
        public virtual Mem_Info Mem_Info { get; set; }
        public virtual MH_MedAllergy MH_MedAllergy { get; set; }
    }
}