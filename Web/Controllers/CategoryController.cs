using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
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
        private readonly IPagingHandler<Post> _pagingHandler;
        public CategoryController(DbContext dbContext, ICategoryService categoryService, IPagingHandler<Post> pagingHandler) : base(dbContext)
        {
            this._categoryService = categoryService;
            _pagingHandler = pagingHandler;
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

        public ActionResult GetPostByCategory(int id,int ?page)
        {
            _pagingHandler.PageIndex = page ?? 1;
            var postList = _pagingHandler.GetPagingList(c=>c.CategoryId==id,c => new PostModel()
            {
                Title = c.Title,
                DateTime = c.DateTime,
                ShortDescription = c.ShortDescription,
                FullName = c.User.FirstName + " " + c.User.LastName,
                Id = c.Id
            }, c => c.DateTime, ListSortDirection.Descending).ToList();

            var pagingModel = new PagingModel()
            {
                HasNextPage = _pagingHandler.HasNextPage,
                HasPreviousPage = _pagingHandler.HasPreviousPage,
                PageIndex = _pagingHandler.PageIndex,
                IsFirstPage = _pagingHandler.IsFirstPage,
                IsLastPage = _pagingHandler.IsLastPage,
                PageCount = _pagingHandler.PageCount,
                PageNumber = _pagingHandler.PageNumber,
                PageSize = _pagingHandler.PageSize
            };

            var model = new Tuple<List<PostModel>, PagingModel>(postList, pagingModel);
            return View("_ListPost", model);
        }
    }
}