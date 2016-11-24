using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Labb_1.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        
        public Guid photoId { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage ="Sorry, but our DataBase is crap. you cant post a comment that contains more than 500 chatacters(including spaces)")]
        public string comment { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual UserAccount commentedBy { get; set; }

    }
}