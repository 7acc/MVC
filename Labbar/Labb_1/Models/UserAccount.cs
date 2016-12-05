using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services.Description;
using Labb1_Data;

namespace Labb_1.Models
{
    public class UserAccount
    {
     

      

        [Key]
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Please Confirm Your Password")]
        [DataType(DataType.Password)]       
        public string ConfirmPassword { get; set; }
        public ICollection<Album> Albums { get; set; } 

        public bool Admin { get; set; }
  

        public UserAccount()
        {
            Albums = new HashSet<Album>();
        }

        public UserAccountDataModel Transform()
        {
            var userDataModel = new UserAccountDataModel
            {
                UserId = this.UserID,
                Name = this.Name,
                Email = this.Email,
                Password = this.Password,              
                Albums = this.Albums.Select(a => a.Transform()).ToList(),
                Admin = this.Admin

            };
            return userDataModel;
        }
        public UserAccount(UserAccountDataModel dataModel)
        {
            Albums = new List<Album>();
            UserID = dataModel.UserId;
            Name = dataModel.Name;
            Email = dataModel.Email;
            Password = dataModel.Password;
            Admin = dataModel.Admin;
            //Albums = dataModel.Albums.Select(a => new Album(a)).ToList();
        }
    }
}