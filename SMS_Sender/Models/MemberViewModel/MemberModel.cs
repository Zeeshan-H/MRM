using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models.MemberViewModel
{
    public class MemberModel
    {



        //Member Info Properties
        public int MemId { get; set; }
        public short MemTypeId { get; set; }
        public short MemStatusId { get; set; }
        public string ParentMemId { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public int UpdateBy { get; set; }
        //Member Details Properties

        public int MemDtlsId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public short TitleId { get; set; }
        public System.DateTime UpdateOn2 { get; set; }
        public System.DateTime AddedOn2 { get; set; }

        public int AddedBy2 { get; set; }
        public int UpdateBy2 { get; set; }


    }
}