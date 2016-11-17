using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb_1.Models
{
    public class DataAccess
    {
        public static List<UserAccount> UserAccounts { get; set; }

        public void SaveUser(UserAccount user)
        {
            if (UserAccounts == null)
            {
                UserAccounts = new List<UserAccount>();
            }
            UserAccounts.Add(user);
        }

        public UserAccount LoginUser(UserAccount user)
        {
            UserAccount usr = UserAccounts.Single(x => x.Email== user.Email && x.Password == user.Password);
            return usr;
        }
    }
}