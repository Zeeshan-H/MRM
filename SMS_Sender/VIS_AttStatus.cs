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
    
    public partial class VIS_AttStatus
    {
        public VIS_AttStatus()
        {
            this.VIS_FileAttachment = new HashSet<VIS_FileAttachment>();
        }
    
        public short AttStatusId { get; set; }
        public string AttStatus { get; set; }
    
        public virtual ICollection<VIS_FileAttachment> VIS_FileAttachment { get; set; }
    }
}