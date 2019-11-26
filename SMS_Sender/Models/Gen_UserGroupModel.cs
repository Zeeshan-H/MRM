using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Gen_UserGroupModel
    {
        public short GrpId { get; set; }
        public short MemTypeId { get; set; }
        public string UserGrp { get; set; }

        public IEnumerable<Mem_MemberToGroupModel> Mem_MemberToGroupModel { get; set; }
    }
}