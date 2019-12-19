using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class VIS_FileAttachmentModel
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
    }
}