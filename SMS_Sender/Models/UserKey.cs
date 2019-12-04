using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(100)]
        public string FName { get; set; }

        [StringLength(100)]
        public string LName { get; set; }

        public string PrimaryNo { get; set; }

        public string Altcontactno { get; set; }

        public string EmailAdd { get; set; }

        public string EmailAdd2 { get; set; }

        public int MemGrpId { get; set; }

        public string UserGrp { get; set; }

        public int MFId { get; set; }

        public string Username { get; set; }

        public int UserId { get; set; }

    }
}