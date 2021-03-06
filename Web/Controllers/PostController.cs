﻿using System;
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
using Web.Utility;

namespace Web.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IPagingHandler<Post> _pagingHandler;
        public PostController(DbContext dbContext, IPostService postService, ICommentService commentService, IPagingHandler<Post> pagingHandler) : base(dbContext)
        {
            this._postService = postService;
            _commentService = commentService;
            _pagingHandler = pagingHandler;
        }


        public ActionResult List(int? page)
        {
            _pagingHandler.PageIndex = page ?? 1 ;
           var postList=_pagingHandler.GetPagingList(c => new PostModel()
            {
                Title = c.Title,
                DateTime = c.DateTime,
                ShortDescription = c.ShortDescription,
                FullName = c.User.FirstName + " " + c.User.LastName,
                Id = c.Id
            },c=>c.DateTime,ListSortDirection.Descending).ToList();

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
            
            var model=new Tuple<List<PostModel>,PagingModel>(postList, pagingModel);
            return View("_ListPost",model);
        }


        public ActionResult Detail(int id)
        {
            return View(_postService.Retrieve(id));
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateComment(CommentModel model)
        {
            model.UserId = User.Identity.GetId();
            var comment = Mapper.Map(model, new Comment());
            if (ModelState.IsValid)
            {
                _commentService.Create(comment);
            }
            return RedirectToAction("Detail", new { id = comment.PostId });
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