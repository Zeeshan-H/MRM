using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models.MemberViewModel
{
    public class MemberModel
    {



        //Member Info Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemId { get; set; }
        public short MemTypeId { get; set; }
        public short MemStatusId { get; set; }
        public string ParentMemId { get; set; }
        public System.DateTime AddedOn { get; set; }
        public int AddedBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
        public int UpdateBy { get; set; }

        //Mem_Details

        public int MemDtlsId { get; set; }
        public int MemId2 { get; set; } 
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public short TitleId { get; set; }

        //Mem_Contacts

        public int ContactID { get; set; }
        public int MemId3 { get; set; }
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


        //Gen_UserAccess

        public int UserId { get; set; }
        public string PassKey { get; set; }

        public string Username { get; set; }
 
    }
}