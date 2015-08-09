using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAL.Entities;
using Web.Models;
using DomainLayer;
using DomainLayer.Service;
using DomainLayer.Service.Interface;
using Microsoft.Ajax.Utilities;

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
            var categoies = _categoryService.GetAll(false);
            return PartialView("GetCategoies",categoies);
        }

        public ActionResult GetPostByCategory(int id)
        {
            var category = _categoryService.Create();
            category.Id = id;
            
            return View();
        }
    }
}