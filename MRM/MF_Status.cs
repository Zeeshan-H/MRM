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
    
    public partial class MF_Status
    {
        public MF_Status()
        {
            this.MF_Details = new HashSet<MF_Details>();
        }
    
        public short MFStatusId { get; set; }
        public string MEStatus { get; set; }
    
        public virtual ICollection<MF_Details> MF_Details { get; set; }
    }
}
