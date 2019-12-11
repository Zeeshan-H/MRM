using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Mem_ContactsModel
    {

        public int ContactID { get; set; }
        public int MemId { get; set; }
        public string PrimaryNo { get; set; }
        public string AltContactNo { get; set; }
        public short NoType { get; set; }
        public string EmailAdd { get; set; }
        public string EmailAdd2 { get; set; }
    }
}