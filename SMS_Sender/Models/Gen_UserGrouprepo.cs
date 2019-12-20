using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Gen_UserGrouprepo
    {
        public IQueryable<Gen_UserGroup> GetAllGen_UserGroup()
        {
            mrmdbEntities entities = new mrmdbEntities();
            return entities.Gen_UserGroup;

        }

        public IQueryable<Mem_MemberToGroup> GetAllGen_UserGroupById(int id)
        {

            mrmdbEntities entities = new mrmdbEntities();
            return entities.Mem_MemberToGroup.Where(c => c.MemId == id).Select(e => e);
        }
    }
}