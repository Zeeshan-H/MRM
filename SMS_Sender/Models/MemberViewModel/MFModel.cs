using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models.MemberViewModel
{
    public class MFModel
    {

        //MF_Info
        public int MemId { get; set; }
        public short MemTypeId { get; set; }
        public short MemStatusId { get; set; }
        public string ParentMemId { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public int UpdateBy { get; set; }


        //MF_Details
        public int MFDtlsId { get; set; }
        public string MFStatus { get; set; }
        public string MFName { get; set; }
        public string MFShortName { get; set; }
        public string MFAddress { get; set; }
        public string MFWeblink { get; set; }
        public short MFStatusId { get; set; }

        //Mem_Contacts

        public int ContactID { get; set; }
        public string PrimaryNo { get; set; }
        public string AltContactNo { get; set; }
        public short NoType { get; set; }
        public string EmailAdd { get; set; }
        public string EmailAdd2 { get; set; }


        //Mem_toGroup

        public int MemGrpId { get; set; }
        //        public int MemId { get; set; }
        public short GrpId { get; set; }
        public int MFId { get; set; }
        public short UserStatusId { get; set; }

        //Gen_UserAccs

        public int UserId { get; set; }
        public string PassKey { get; set; }

        public string Username { get; set; }


    }
}