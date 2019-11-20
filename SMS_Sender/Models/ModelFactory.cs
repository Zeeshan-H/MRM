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
                UpdateBy = mem_info.UpdateBy

            };
        
        }
    }
}