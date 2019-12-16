﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MH_Mem_MedProcedureModel
    {
        public int MemMedProcId { get; set; }
        public int MemId { get; set; }
        public int MedProcId { get; set; }
        public short TPId { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public bool IsDel { get; set; }
    }
}