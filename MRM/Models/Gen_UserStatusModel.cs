﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Gen_UserStatusModel
    {
        public short UserStatusId { get; set; }
        public string UserStatus { get; set; }

        public IEnumerable<Mem_MemberToGroupModel> Mem_MemberToGroup { get; set; }
    }
}