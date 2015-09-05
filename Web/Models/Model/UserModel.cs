using System;
using System.Collections.Generic;

namespace Web.Models.Model
{
    public class UserModel:BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<PostModel> Posts { get; set; }

        public UserModel()
        {
            Posts=new List<PostModel>();
        }
    }
}
