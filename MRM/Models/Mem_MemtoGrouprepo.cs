using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Mem_MemtoGrouprepo
    {

        public IQueryable<Mem_MemberToGroup> GetAllMem_MemtoGroup()
        {
            mrmdbEntities entities = new mrmdbEntities();
            return entities.Mem_MemberToGroup;

        }

        public IQueryable<Mem_MemberToGroup> GetAllMem_MemtoGroup_ById(int id)
        {

            mrmdbEntities entities = new mrmdbEntities();
            return entities.Mem_MemberToGroup.Where(c => c.MemId == id).Select(e => e);
        }
    }
}