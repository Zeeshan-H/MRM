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
    
    public partial class VIS_FileAttachment
    {
        public int AttId { get; set; }
        public int MemId { get; set; }
        public int VisitId { get; set; }
        public string AttName { get; set; }
        public short AttStatusId { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }
    
        public virtual VIS_AttStatus VIS_AttStatus { get; set; }
    }
}
