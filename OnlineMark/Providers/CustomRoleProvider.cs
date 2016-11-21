using OnlineMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace OnlineMark.Providers
{
    public class CustomRoleProvider : RoleProvider
    {

        public override string[] GetRolesForUser(string login)
        {
            string[] roles = new string[] { };
            using (UserContext db = new UserContext())
            {
                try
                {
                    User user = db.Users.Where(i => i.Login == login).FirstOrDefault();
                    if (user != null)
                    {
                        Role userRole = db.Roles.Find(user.RoleId);
                        if (userRole != null)
                        {
                            roles = new string[] { userRole.Name };
                        }
                    }
                }
                catch 
                {
                    roles = new string[] { };
                }
            }
            return roles;
        }

        public override void CreateRole(string roleName)
        {
            Role role = new Role() { Name = roleName };
            using (UserContext db = new UserContext())
            {
                db.Roles.Add(role);
                db.SaveChanges();
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;

            using (UserContext db = new UserContext())
            {
                try
                {
                    User user = db.Users.Where(i => i.Login == username).FirstOrDefault();
                    if (user != null)
                    {
                        Role role = db.Roles.Find(user.RoleId);
                        if (role != null && role.Name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch 
                {

                    outputResult = false;
                }
            }
            return outputResult;
        }


        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

       
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}