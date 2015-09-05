using System.Data.Entity;
using DAL.Entities;
using Web.Service.Interface;

namespace Web.Service
{
    public class CommentService:BaseService<Comment>,ICommentService
    {
        public CommentService(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
