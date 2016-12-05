using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Data.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<CommentDataModel> GetAll();
        void Add(CommentDataModel comment);
        void Delete(Guid id);
        CommentDataModel GetById(Guid id);
       IEnumerable<CommentDataModel> GetCommentsForPhoto(Guid imageId);
    }
}
