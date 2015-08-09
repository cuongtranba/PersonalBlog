using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PostController : BaseController
    {

        public PostController(DbContext dbContext) : base(dbContext)
        {

        }

        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}