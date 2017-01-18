using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webb4_DAL.Models
{
    class UserDataModel
    {
        public UserDataModel()
        {
            this.WatchList = new HashSet<AppartmentDataModel>();
        }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public AdressDataModel UserAdress { get; set; }
        public virtual ICollection<AppartmentDataModel> WatchList { get; set; }
    }
}
