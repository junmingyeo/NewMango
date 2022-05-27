using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class LoginController
    {
        Users dal = new Users();

        public DataSet loginUser(string userID, string password)
        {
            return dal.getUserDetails(userID, password);
        }

        public DataSet GetProfile(int UserID)
        {
            return dal.profileDetails(UserID);
        }

        public DataSet GetAllUser()
        {
            return dal.profileAcc();
        }

        public int AddAccount(string Email, string FirstName, string LastName, string Password, string Role)
        {
            return dal.CreateUser(Email, FirstName, LastName, Password, Role);
        }

        public int UpdateUserDetails(int UserID, string Email, string FirstName, string LastName, string Password, string Role)
        {
            return dal.updateUser(UserID, Email, FirstName, LastName, Password, Role);
        }

        public DataSet SearchUserAcc(string FirstName)
        {
            return dal.searchUser(FirstName);
        }

        public int SuspendUserAcc(string UserID)
        {
            return dal.suspendUser(UserID);
        }



    }
}