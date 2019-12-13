using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class ModelFactory
    {

        //Member_Info Object
        public Mem_InfoModel Create(Mem_Info mem_info)
        {

            return new Mem_InfoModel()
            {
                MemId = mem_info.MemId,
                MemTypeId = mem_info.MemTypeId,
                MemStatusId = mem_info.MemStatusId,
                ParentMemId = mem_info.ParentMemId,
                AddedOn = mem_info.AddedOn,
                AddedBy = mem_info.AddedBy,
                UpdateBy = mem_info.UpdateBy,
                Mem_Details = mem_info.Mem_Details.Select(h => Create(h)),
                Mem_Contacts = mem_info.Mem_Contacts.Select(h => Create(h)),
                Mem_MemberToGroup = mem_info.Mem_MemberToGroup.Select(h => Create(h)),


            };

        }

        public Mem_DetailsModel Create(Mem_Details mem_details)
        {

            return new Mem_DetailsModel()
            {

                MemDtlsId = mem_details.MemDtlsId,
                MemId = mem_details.MemId,
                FName = mem_details.FName,
                MName = mem_details.MName,
                LName = mem_details.LName,
                TitleId = mem_details.TitleId,
                UpdateOn = mem_details.UpdateOn,
                AddedOn = mem_details.AddedOn,
                AddedBy = mem_details.AddedBy,
                UpdateBy = mem_details.UpdateBy


            };
        }

        public Mem_ContactsModel Create(Mem_Contacts mem_contacts)
        {
            return new Mem_ContactsModel()
            {
                ContactID = mem_contacts.ContactID,
                MemId = mem_contacts.MemId,
                PrimaryNo = mem_contacts.PrimaryNo,
                AltContactNo = mem_contacts.AltContactNo,
                NoType = mem_contacts.NoType,
                EmailAdd = mem_contacts.EmailAdd,
                EmailAdd2 = mem_contacts.EmailAdd2



            };

        }

        public Mem_MemberToGroupModel Create(Mem_MemberToGroup mem_memtogroup)
        {

            return new Mem_MemberToGroupModel()
            {
                MemGrpId = mem_memtogroup.MemGrpId,
                MemId = mem_memtogroup.MemId,
                GrpId = mem_memtogroup.GrpId,
                MFId = mem_memtogroup.MFId,
                UserStatusId = mem_memtogroup.UserStatusId,
                AddedBy = mem_memtogroup.AddedBy,
                AddedOn = mem_memtogroup.AddedOn,
                UpdateBy = mem_memtogroup.UpdateBy,
                UpdateOn = mem_memtogroup.UpdateOn


            };

        }

        //Mem_MemberToGroupModel Object


        public Mem_MemberToGroupModel Create2(Mem_MemberToGroup mem_memtogroup)
        {

            return new Mem_MemberToGroupModel()
            {

                MemGrpId = mem_memtogroup.MemGrpId,
                MemId = mem_memtogroup.MemId,
                GrpId = mem_memtogroup.GrpId,
                MFId = mem_memtogroup.MFId,
                UserStatusId = mem_memtogroup.UserStatusId,
                AddedBy = mem_memtogroup.AddedBy,
                AddedOn = mem_memtogroup.AddedOn,
                UpdateBy = mem_memtogroup.UpdateBy,
                UpdateOn = mem_memtogroup.UpdateOn,
                Gen_UserAccsModel = mem_memtogroup.Gen_UserAccs.Select(x => Create2(x)),


            };

        }

        public Gen_UserAccsModel Create2(Gen_UserAccs gen_useraccs)
        {

            return new Gen_UserAccsModel()
            {

                UserId = gen_useraccs.UserId,
                MemGrpId = gen_useraccs.MemGrpId,
                PassKey = gen_useraccs.PassKey,
                AddedBy = gen_useraccs.AddedBy,
                AddedOn = gen_useraccs.AddedOn,
                UpdateBy = gen_useraccs.UpdateBy,
                UpdateOn = gen_useraccs.UpdateOn



            };
        }


        //Gen_UserGroup

        public Gen_UserGroupModel Create3(Gen_UserGroup gen_usergroup)
        {


            return new Gen_UserGroupModel()
            {

                GrpId = gen_usergroup.GrpId,
                MemTypeId = gen_usergroup.MemTypeId,
                UserGrp = gen_usergroup.UserGrp,
                Mem_MemberToGroup = gen_usergroup.Mem_MemberToGroup.Select(x => Create3(x))

            };



        }


        public Mem_MemberToGroupModel Create3(Mem_MemberToGroup mem_memtogrp)
        {


            return new Mem_MemberToGroupModel()
            {
                MemGrpId = mem_memtogrp.MemGrpId,
                MemId = mem_memtogrp.MemId,
                GrpId = mem_memtogrp.GrpId,
                MFId = mem_memtogrp.MFId,
                UserStatusId = mem_memtogrp.UserStatusId,
                AddedBy = mem_memtogrp.AddedBy,
                AddedOn = mem_memtogrp.AddedOn,
                UpdateBy = mem_memtogrp.UpdateBy,
                UpdateOn = mem_memtogrp.UpdateOn


            };

        }

        //Gen_UserStatus

        public Gen_UserStatusModel Create4(Gen_UserStatus gen_userstatus)
        {


            return new Gen_UserStatusModel()
            {

                UserStatusId = gen_userstatus.UserStatusId,
                UserStatus = gen_userstatus.UserStatus,
                Mem_MemberToGroup = gen_userstatus.Mem_MemberToGroup.Select(x => Create4(x))

            };


        }


        public Mem_MemberToGroupModel Create4(Mem_MemberToGroup mem_memtogrp)
        {

            return new Mem_MemberToGroupModel()
            {
                MemGrpId = mem_memtogrp.MemGrpId,
                MemId = mem_memtogrp.MemId,
                GrpId = mem_memtogrp.GrpId,
                MFId = mem_memtogrp.MFId,
                UserStatusId = mem_memtogrp.UserStatusId,
                AddedBy = mem_memtogrp.AddedBy,
                AddedOn = mem_memtogrp.AddedOn,
                UpdateBy = mem_memtogrp.UpdateBy,
                UpdateOn = mem_memtogrp.UpdateOn


            };
        
        
        }

        //MF_Details

        public MF_DetailsModel Create5(MF_Details mf_details)
        {


            return new MF_DetailsModel()
            {
                MFDtlsId = mf_details.MFDtlsId,
                MFStatus = mf_details.MFStatus,
                MemId = mf_details.MemId,
                MFName = mf_details.MFName,
                MFShortName = mf_details.MFShortName,
                MFAddress = mf_details.MFAddress,
                MFWeblink = mf_details.MFWeblink,
                MFStatusId = mf_details.MFStatusId,

            };
        
        }


        //MemInfo for Medical History Module

        public Mem_InfoModel2 CreateMH(Mem_Info mem_info)
        {
            return new Mem_InfoModel2()
            {
                MemId = mem_info.MemId,
                MemTypeId = mem_info.MemTypeId,
                MemStatusId = mem_info.MemStatusId,
                ParentMemId = mem_info.ParentMemId,
                AddedOn = mem_info.AddedOn,
                AddedBy = mem_info.AddedBy,
                UpdateBy = mem_info.UpdateBy,
                MH_Mem_BloodGroup = mem_info.MH_Mem_BloodGroup.Select(h => CreateMH(h)),
                MH_Mem_MedCondition = mem_info.MH_Mem_MedCondition.Select(h => CreateMH2(h)),
                MH_Mem_AttentionReq = mem_info.MH_Mem_AttentionReq.Select(h => CreateMH3(h)),
                MH_Mem_FamilyCondition = mem_info.MH_Mem_FamilyCondition.Select(h => CreateMH4(h)),
                MH_Mem_MedAllergy = mem_info.MH_Mem_MedAllergy.Select(h => CreateMH5(h)),
                MH_Mem_MedProcedure = mem_info.MH_Mem_MedProcedure.Select(h => CreateMH6(h))

            };


        }

        public BloodGroupModel CreateMH(MH_Mem_BloodGroup mh_bloodgroup)
        {
            return new BloodGroupModel
            {
                MemBGId = mh_bloodgroup.MemBGId,
                MemId = mh_bloodgroup.MemId,
                BGroup = mh_bloodgroup.BGroup,
                BGComments = mh_bloodgroup.BGComments,
                AddedBy = mh_bloodgroup.AddedBy,
                AddedOn = mh_bloodgroup.AddedOn,
                UpdateBy = mh_bloodgroup.UpdateBy,
                UpdateOn = mh_bloodgroup.UpdateOn
               
            };


        }

        public MH_Mem_MedConditionModel CreateMH2(MH_Mem_MedCondition mh_medcond)
        {

            return new MH_Mem_MedConditionModel
            {
                MemMedCond = mh_medcond.MemMedCond,
                MemId = mh_medcond.MemId,
                MedCondId = mh_medcond.MedCondId,
                TPId = mh_medcond.TPId,
                AddedBy = mh_medcond.AddedBy,
                AddedOn = mh_medcond.AddedOn,
                UpdateBy = mh_medcond.UpdateBy,
                UpdateOn = mh_medcond.UpdateOn
            };
        
        }

        public MH_Mem_AttentionReqModel CreateMH3(MH_Mem_AttentionReq mh_atten)
        {

            return new MH_Mem_AttentionReqModel
            {
                MemAttItemId = mh_atten.MemAttItemId,
                MemId = mh_atten.MemId,
                AttItemId = mh_atten.AttItemId,
                AddedBy = mh_atten.AddedBy,
                AddedOn = mh_atten.AddedOn,
                UpdateBy = mh_atten.UpdateBy,
                UpdateOn = mh_atten.UpdateOn

            };
        
        }

        public MH_Mem_FamilyConditionModel CreateMH4(MH_Mem_FamilyCondition mh_fam)
        {


            return new MH_Mem_FamilyConditionModel
            {
               
                MemFamilyCondId = mh_fam.MemFamilyCondId,
                MemId = mh_fam.MemId,
                FamilyCondId = mh_fam.FamilyCondId,
                AddedBy = mh_fam.AddedBy,
                AddedOn = mh_fam.AddedOn,
                UpdateBy = mh_fam.UpdateBy,
                UpdateOn = mh_fam.UpdateOn,
                IsDel = mh_fam.IsDel

            };

        }

        public MH_Mem_MedAllergyModel CreateMH5(MH_Mem_MedAllergy mh_aller)
        {


            return new MH_Mem_MedAllergyModel
            {
                MemMedAlrgId = mh_aller.MemMedAlrgId,
                MemId = mh_aller.MemId,
                MedAlrgId = mh_aller.MedAlrgId,
                AddedBy = mh_aller.AddedBy,
                AddedOn = mh_aller.AddedOn,
                UpdateBy = mh_aller.UpdateBy,
                UpdateOn = mh_aller.UpdateOn,
                IsDel = mh_aller.IsDel

            };
        }

        public MH_Mem_MedProcedureModel CreateMH6(MH_Mem_MedProcedure mh_proc)
        {

            return new MH_Mem_MedProcedureModel
            {
                MemMedProcId = mh_proc.MemMedProcId,
                MemId = mh_proc.MemId,
                MedProcId = mh_proc.MedProcId,
                TPId = mh_proc.TPId,
                AddedBy = mh_proc.AddedBy,
                AddedOn = mh_proc.AddedOn,
                UpdateBy = mh_proc.UpdateBy,
                UpdateOn = mh_proc.UpdateOn,
                IsDel = mh_proc.IsDel

            };
        
        
        }


    }
}
