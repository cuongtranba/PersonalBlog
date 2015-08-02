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
        }
    }
}