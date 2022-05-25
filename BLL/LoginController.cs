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

        public DataSet GetAdminResetPW()
        {
            return dal.adminResetPW();
        }
        public int GetAdminResetPWPassword(int UserID, string newPassword)
        {
            return dal.adminResetPWPassword(UserID, newPassword);
        }
        public int AddAccount(string Email, string FirstName, string LastName, string Password, string Role)
        {
            return dal.CreateUser(Email, FirstName, LastName, Password, Role);
        }


    }
}