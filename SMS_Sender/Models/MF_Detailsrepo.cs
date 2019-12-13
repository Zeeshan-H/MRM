using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class MF_Detailsrepo
    {
        public IQueryable<MF_Details> GetAllMF_Details()
        {
            mrmdbEntities entities = new mrmdbEntities();
            return entities.MF_Details;

        }

        public IQueryable<MF_Details> GetAllMFInfo_Byid(int id)
        {

            mrmdbEntities entities = new mrmdbEntities();
            return entities.MF_Details.Where(c => c.MemId == id).Select(e => e);
        }
    }
}