﻿using System;
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