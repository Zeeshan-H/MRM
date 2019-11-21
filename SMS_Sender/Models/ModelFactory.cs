using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class ModelFactory
    {

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
                Mem_Contacts = mem_info.Mem_Contacts.Select(h => Create(h))
                

            };
        
        }

        public Mem_DetailsModel Create(Mem_Details mem_details)
        {

            return new Mem_DetailsModel() { 
            
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
    }
}