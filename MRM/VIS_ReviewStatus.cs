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
    
    public partial class VIS_ReviewStatus
    {
        public VIS_ReviewStatus()
        {
            this.VIS_Visit = new HashSet<VIS_Visit>();
        }
    
        public short ReviewStatusID { get; set; }
        public string ReviewStatus { get; set; }
    
        public virtual ICollection<VIS_Visit> VIS_Visit { get; set; }
    }
}