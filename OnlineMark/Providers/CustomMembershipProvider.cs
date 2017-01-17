using OnlineMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace OnlineMark.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            bool IsValid = false;

            using (UserContext udb = new UserContext())
            {
                 try
                 {
                     User user = udb.Users.Where(i => i.Login == username).FirstOrDefault();
                     if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                     {
                         IsValid = true;
                     }
                 }
                 catch 
                 {

                     IsValid = false;
                 }
             }
   
            return IsValid;
                
        }

        public MembershipUser CreateUser(string login, string password, string name, string group)
        {
            MembershipUser membershipUser = GetUser(login, false);

            if (membershipUser == null)
            {
                try
                {
                    using (UserContext udb = new UserContext())
                    {
                        using (MarksContext mdb = new MarksContext())
                        {
                            User user = new User();
                            user.Login = login;
                            user.Password = Crypto.HashPassword(password);
                            user.CreationDate = DateTime.Now;

                            if (!string.IsNullOrEmpty(group))
                            {
                                user.RoleId = 1;
                                Student student = new Student();
                                student.Name = name;
                                student.Login = login;
                                student.Group = group;
                                mdb.Students.Add(student);
                            }
                            else
                            {
                                user.RoleId = 2;
                                Lecturer lec = new Lecturer();
                                lec.Name = name;
                                lec.Login = login;
                                mdb.Lecturers.Add(lec);
                            }
                            mdb.SaveChanges();
                            udb.Users.Add(user);
                            udb.SaveChanges();
                            membershipUser = GetUser(login, false);
                        }
                    }
                }
                catch 
                {

                    return null;
                }
            }
            return membershipUser;
        }


        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    User user = db.Users.Where(i => i.Login == username).FirstOrDefault();

                    if (user != null)
                    {
                        MembershipUser memberUser = new MembershipUser("MyMembershipProvider", user.Login, null, null, null, null,
                            false, false, user.CreationDate, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                        return memberUser;
                    }
                }
            }
            catch 
            {
                return null;
            }
            return null;
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

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

       

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }
    }
}