using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class Gen_UserStatusrepo
    {
        public IQueryable<Gen_UserStatus> GetAllGen_UserStatus()
        {
            mrmdbEntities entities = new mrmdbEntities();
            return entities.Gen_UserStatus;

        }

        public IQueryable<Gen_UserStatus> GetAllGen_UserStatusById(int id)
        {

            mrmdbEntities entities = new mrmdbEntities();
            return entities.Gen_UserStatus.Where(c => c.UserStatusId == id).Select(e => e);
        }
    }
}