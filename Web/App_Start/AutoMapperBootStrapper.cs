using System.Collections.Generic;
using AutoMapper;
using DAL.Entities;
using Web.Models;

namespace Web
{
    public class AutoMapperBootStrapper
    {
        public static void BootStrap()
        {
            Mapper.CreateMap<Category, CategoryModel>().ReverseMap();
            Mapper.CreateMap<Post, PostModel>().ReverseMap();
            Mapper.CreateMap<User, UserModel>().ReverseMap();
            Mapper.CreateMap<Comment, CommentModel>().ReverseMap();
            Mapper.CreateMap<Tag, TagModel>().ReverseMap();
            Mapper.CreateMap<Image, ImageModel>().ReverseMap();
        }
    }

   
}