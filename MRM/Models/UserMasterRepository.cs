using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS_Sender.Models
{
    public class UserMasterRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        mrmdbEntities context = new mrmdbEntities();
        //This method is used to check and validate the user credentials
        public Mem_Contacts ValidateUser(string username, string password)
        {
            return context.Mem_Contacts.FirstOrDefault(user =>
            user.PrimaryNo.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.EmailAdd == password);
        }
        public void Dispose()
        {
            context.Dispose();
        }

    }
}