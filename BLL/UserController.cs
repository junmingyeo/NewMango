using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class UserController
    {
        Users dal = new Users();

        public DataSet getUsers()
        {
            return dal.viewUsers();
        }

        public int AddAccount(string Email, string FirstName, string LastName, string Password, string Role)
        {
            return dal.createUser(Email, FirstName, LastName, Password, Role);
        }

        public int UpdateUserDetails(int UserID, string Email, string FirstName, string LastName, string Password, string Role)
        {
            return dal.updateUser(UserID, Email, FirstName, LastName, Password, Role);
        }

        public DataSet SearchUserAcc(string FirstName)
        {
            return dal.searchUser(FirstName);
        }

        public int SuspendUserAcc(int UserID)
        {
            return dal.suspendUser(UserID);
        }

        public class UserLoginRole
        {
            private string _Email = null;
            private string _Password = "";
            private string _Role = "";

            // Default constructor
            public UserLoginRole()
            {

            }

            public UserLoginRole(string Email_, string Password_, string Role_)
            {
                _Email = Email_;
                _Password = Password_;
                _Role = Role_;
            }

            public string Email_
            {
                get { return _Email; }
                set { _Email = value; }
            }

            public string Password_
            {
                get { return _Password; }
                set { _Password = value; }
            }

            public string Role_
            {
                get { return _Role; }
                set { _Role = value; }
            }
            public void ValidateLogin(string Email_, string Password_, string Role_)
            {
                if (Email_ != null && Password_ != null)
                {
                    if (Email_ == _Email && Password_ == _Password)
                    {
                        Role_ = _Role;
                        throw new Exception("Login Successful");
                    }
                    if (Email_ != _Email)
                    {
                        throw new Exception("Wrong Email");
                    }
                    if (Password_ != _Password)
                    {
                        throw new Exception("Wrong Password");
                    }
                }
                else
                {
                    throw new Exception("No Values");
                }
            }
        }
    }
}
