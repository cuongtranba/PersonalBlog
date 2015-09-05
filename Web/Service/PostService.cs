using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Entities;
using Web.Models.Entity;
using Web.Service.Interface;

namespace Web.Service
{
    public class PostService : BaseService<Post>, IPostService
    {

        public PostService(DbContext dbContext) : base(dbContext)
        {

        }

    }
}
