using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Mem_InfoModel
    {
        public int MemId { get; set; }

        public int MemTypeId { get; set; }

        public int MemStatusId { get; set; }

        public string ParentMemId { get; set; }

        public DateTime AddedOn { get; set; }

        public int AddedBy { get; set; }

        public int UpdateBy { get; set; }

        public IEnumerable<Mem_DetailsModel> Mem_Details { get; set; }
    }
}