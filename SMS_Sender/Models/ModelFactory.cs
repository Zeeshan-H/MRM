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
                Mem_MemberToGroupModel = gen_usergroup.Mem_MemberToGroup.Select(x => Create3(x))

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
                Mem_MemberToGroupModel = gen_userstatus.Mem_MemberToGroup.Select(x => Create4(x))

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

    }
}
