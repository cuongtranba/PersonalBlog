using System.Data.Entity;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CommentController : BaseController
    {
        public CommentController(DbContext dbContext) : base(dbContext)
        {

        }

        public ActionResult GetRecentComments()
        {

            return PartialView("_GetRecentComments");
        }
    }
}