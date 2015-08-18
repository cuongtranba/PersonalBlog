using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAL.Entities;
using DomainLayer.Service;
using DomainLayer.Service.Interface;
using Web.Models;

namespace Web.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        public PostController(DbContext dbContext, IPostService postService, ICommentService commentService) : base(dbContext)
        {
            this._postService = postService;
            _commentService = commentService;
        }


        public ActionResult List()
        {
            return View();
        }


        public ActionResult Detail(int id)
        {
            var model = Mapper.Map(_postService.Retrieve(id), new PostModel());
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateComment(CommentModel model)
        {
            var comment = Mapper.Map(model, new Comment());
            if (ModelState.IsValid)
            {
                _commentService.Create(comment);
            }
            return RedirectToAction("Detail", new { id = comment.Post.Id });
        }
        [ChildActionOnly]
        public ActionResult Comment(int postId)
        {
            var model=new CommentModel()
            {
                PostId = postId
            };
            return PartialView("Comment", model);
        }
    }
}