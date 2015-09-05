using System.Data.Entity;
using System.Web.Mvc;
using AutoMapper;
using DAL.Entities;
using Web.Models.Entity;
using Web.Models.Model;
using Web.Service.Interface;

namespace Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(DbContext dbContext, ICategoryService categoryService) : base(dbContext)
        {
            this._categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            var newCategory= Mapper.Map(model, new Category());
            _categoryService.Create(newCategory);
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetCategoies()
        {
            var categoies = _categoryService.GetAll(c=>new CategoryModel() {Name = c.Name,Id = c.Id,CountPost = c.Posts.Count});
            return PartialView("GetCategoies",categoies);
        }

        public ActionResult GetPostByCategory(int id)
        {
            return View(_categoryService.GetPostByCategory(id));
        }
    }
}