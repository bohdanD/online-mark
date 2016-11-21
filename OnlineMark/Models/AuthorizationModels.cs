using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineMark.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
    }


    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }
        [ScaffoldColumn(false)]
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}