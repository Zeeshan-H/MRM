using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class UserKey
    {

        public int MemId { get; set; }

        public short MemTypeId { get; set; }

        public short TitleId { get; set; }
        public string TitleDesc { get; set; }

        public string ParentMemID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string PrimaryNo { get; set; }

        public string EmailAdd { get; set; }

        public int MemGrpId { get; set; }

        public string UserGrp { get; set; }

        public int MFId { get; set; }


    }
}