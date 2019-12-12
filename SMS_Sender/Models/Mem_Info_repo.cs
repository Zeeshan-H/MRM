using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Mem_Info_repo
    {

        public IQueryable<Mem_Info> GetAllMemInfo()
        {
            mrmdbEntities entities = new mrmdbEntities();
            return entities.Mem_Info;
 
        }

        public IQueryable<Mem_Info> GetAllMemInfo_Byid(int id)
        {

            mrmdbEntities entities = new mrmdbEntities();
            return entities.Mem_Info.Where(c => c.MemId == id).Select(e => e);
        }
    }
}