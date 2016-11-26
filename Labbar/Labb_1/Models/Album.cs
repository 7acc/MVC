using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Labb_1.Models
{
    public class Album
    {
        public Album()
        {
            this.Photos = new HashSet<Photo>();
        }
        [Key]
        public Guid AlbumId { get; set; }
        [Required(ErrorMessage = "Your album needs a name")]
        [MaxLength(30), MinLength(3)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public  ICollection<Photo> Photos{ get; set; }
    }
}