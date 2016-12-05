using System;
using System.ComponentModel.DataAnnotations;

namespace Labb1_Data
{
    public class CommentDataModel
    {
        [Key]
        public Guid CommentId { get; set; }
        public Guid PhotoId { get; set; }      
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentedById { get; set; }

        public void Update(CommentDataModel comment)
        {
            Comment = comment.Comment;
        }
    }
}