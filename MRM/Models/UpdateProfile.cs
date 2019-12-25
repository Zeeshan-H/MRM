using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class UpdateProfile
    {

        public int MemId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string EmailAdd { get; set; }
        public string EmailAdd2 { get; set; }
        public string AltContactNo { get; set; }
    }
}