using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Gen_UserAccsModel
    {

        public int UserId { get; set; }
        public int MemGrpId { get; set; }
        public string PassKey { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }

        

    }
}