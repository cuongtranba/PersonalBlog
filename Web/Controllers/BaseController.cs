using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        private readonly DbContext _dbContext;
        public BaseController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _dbContext.SaveChanges();
        }

    }
}