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
    
    public partial class Mem_Details
    {
        public int MemDtlsId { get; set; }
        public int MemId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public short TitleId { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int AddedBy { get; set; }
        public int UpdateBy { get; set; }
    
        public virtual Mem_Info Mem_Info { get; set; }
        public virtual Mem_Title Mem_Title { get; set; }
    }
}
