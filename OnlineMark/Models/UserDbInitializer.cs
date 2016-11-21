using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineMark.Models
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            Role frst = new Role()
            { 
                Name = "Student"
            };
            Role scnd = new Role()
            {
                Name = "Lecturer"
            };
            User us = new User()
            {
                Login = "user1",
                Password = "user1pass",
                RoleId = 1,
                CreationDate = DateTime.Today
            };
            context.Roles.Add(frst);
            context.Roles.Add(scnd);
            context.Users.Add(us);

            base.Seed(context);
        }
    }
}