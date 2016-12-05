using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Labb1_Data;

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
        public  Guid commentedById { get; set; }

        public Comment()
        {
            
        }

        public Comment(CommentDataModel commentDataModel)
        {
            CommentId = commentDataModel.CommentId;
            photoId = commentDataModel.PhotoId;
            comment = commentDataModel.Comment;
            CommentDate = commentDataModel.CommentDate;
            commentedById = commentDataModel.CommentedById;

        }


        public CommentDataModel Transform()
        {
            var datamodel = new CommentDataModel
            {
                CommentId = this.CommentId,
                PhotoId = this.photoId,
                Comment = this.comment,
                CommentDate = this.CommentDate,
                CommentedById = this.commentedById
            };
            return datamodel;
        }
    }
}