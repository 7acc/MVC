using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Labb1_Data;

namespace Labb_1.Models
{
    public class Photo
    {
        public Photo()
        {
            this.Comments = new List<Comment>();
            this.Albums = new List<Album>();
        }
        public Guid PhotoID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid uploader{ get; set; }
        public DateTime UploadedDate { get; set; }
        public  List<Comment> Comments { get; set; }
        public  List<Album> Albums { get; set; }

      
      

        public Photo(PhotoDataModel dataModel)
        {
            Comments = new List<Comment>();
            Albums = new List<Album>();


            PhotoID = dataModel.PhotoID;
            Name = dataModel.Name;
            Url = dataModel.Url;
            uploader = dataModel.uploader;
            UploadedDate = dataModel.UploadedDate;
        //    Comments = dataModel.Comments.Select(x => new Comment(x)).ToList();
        //    Albums = dataModel.Albums.Select(x => new Album(x)).ToList();
        }

        public PhotoDataModel Transform()
        {
            var photodata = new PhotoDataModel
            {
                PhotoID = this.PhotoID,
                Name = this.Name,
                Url = this.Url,
                uploader = this.uploader,
                UploadedDate = this.UploadedDate,
                Comments = this.Comments.Select(x => x.Transform()).ToList(),
                Albums = this.Albums.Select(x => x.Transform()).ToList()
            };
            return photodata;
        }
    }
}

   