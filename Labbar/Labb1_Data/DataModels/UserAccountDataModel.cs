using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb1_Data
{
    public class UserAccountDataModel
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<AlbumDatamodel> Albums { get; set; }
        public bool Admin { get; set; }

        public void  Update(UserAccountDataModel newUserData)
        {
            this.Name = newUserData.Name;
            this.Email = newUserData.Email;
            this.Password = newUserData.Password;
        }
    }
}