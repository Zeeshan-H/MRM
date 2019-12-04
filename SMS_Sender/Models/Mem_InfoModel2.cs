using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Mem_InfoModel2
    {
        public int MemId { get; set; }

        public int MemTypeId { get; set; }

        public int MemStatusId { get; set; }

        public string ParentMemId { get; set; }

        public DateTime AddedOn { get; set; }

        public int AddedBy { get; set; }

        public int UpdateBy { get; set; }



        public IEnumerable<BloodGroupModel> MH_Mem_BloodGroup { get; set; }

        public IEnumerable<MH_Mem_MedConditionModel> MH_Mem_MedCondition { get; set; }

        public IEnumerable<MH_Mem_AttentionReqModel> MH_Mem_AttentionReq { get; set; }

        public IEnumerable<MH_Mem_FamilyConditionModel> MH_Mem_FamilyCondition { get; set; }

        public IEnumerable<MH_Mem_MedAllergyModel> MH_Mem_MedAllergy { get; set; }

        public IEnumerable<MH_Mem_MedProcedureModel> MH_Mem_MedProcedure { get; set; }

 //       public IEnumerable<MH_Mem_RoutineMedsModel> MH_Mem_RoutineMeds { get; set; }



    }
}