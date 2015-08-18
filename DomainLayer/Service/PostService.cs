using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DomainLayer.Service.Interface;

namespace DomainLayer.Service
{
    public class PostService:BaseService<Post>,IPostService
    {

        public PostService(DbContext dbContext) : base(dbContext)
        {

        }

    }
}
