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
    }
}