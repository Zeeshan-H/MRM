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
    
    public partial class MF_Details
    {
        public int MFDtlsId { get; set; }
        public string MFStatus { get; set; }
        public int MemId { get; set; }
        public string MFName { get; set; }
        public string MFShortName { get; set; }
        public string MFAddress { get; set; }
        public string MFWeblink { get; set; }
        public short MFStatusId { get; set; }
    
        public virtual Mem_Info Mem_Info { get; set; }
        public virtual MF_Status MF_Status { get; set; }
    }
}
