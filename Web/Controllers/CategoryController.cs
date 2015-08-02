using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAL.Entities;
using Web.Models;
using DomainLayer;
using DomainLayer.Service;
using DomainLayer.Service.Interface;

namespace Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;
        public CategoryController(DbContext dbContext, ICategoryService categoryService) : base(dbContext)
        {
            this.categoryService = categoryService;
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
            var a= Mapper.Map(model, new Category());
            categoryService.Create(a);
            return View();
        }

       
    }
}