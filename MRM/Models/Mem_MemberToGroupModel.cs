using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Mem_MemberToGroupModel
    {
        public int MemGrpId { get; set; }
        public int MemId { get; set; }
        public short GrpId { get; set; }
        public int MFId { get; set; }
        public short UserStatusId { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }

        public IEnumerable<Gen_UserAccsModel> Gen_UserAccsModel { get; set; }

    }
}