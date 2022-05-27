using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class ProfileController
    {
        Profile dal = new Profile();

        public int RegisterRole(string Role, String Function)
        {
            return dal.CreateRole(Role, Function);
        }

        public DataSet GetRole()
        {
            return dal.BindDDLRole();
        }
        //public int GetNewRole(string newrole, string functionaccess)
        //{
        //    //Roledal dataLayerNewroleDetails;
        //    //dataLayerNewroleDetails = new Roledal();
        //    return dal.Newrole(newrole, functionaccess);
        //}
    }
}
