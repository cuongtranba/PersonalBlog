using System.Data.Entity;
using System.Web.Mvc;
using DomainLayer.Service.Interface;

namespace Web.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentService _commentService;
        public CommentController(DbContext dbContext, ICommentService commentService) : base(dbContext)
        {
            _commentService = commentService;
        }

        public ActionResult GetRecentComments()
        {
            return PartialView("_GetRecentComments");
        }
    }
}