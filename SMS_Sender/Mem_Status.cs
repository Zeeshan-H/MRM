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
    
    public partial class Mem_Status
    {
        public Mem_Status()
        {
            this.Mem_Info = new HashSet<Mem_Info>();
        }
    
        public short MemStatusId { get; set; }
        public string MemStatus { get; set; }
    
        public virtual ICollection<Mem_Info> Mem_Info { get; set; }
    }
}
