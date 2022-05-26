using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class Role_Controller
    {
        Role dal = new Role();

        public int RegisterRole(string Role, String Function)
        {
            return dal.CreateRole(Role, Function);
        }

        public DataSet GetRole()
        {
            //Roledal dataLayerRoleData;
            //dataLayerRoleData = new Roledal();
            return dal.BindDDLRole();
        }
        public int GetNewRole(string newrole, string functionaccess)
        {
            //Roledal dataLayerNewroleDetails;
            //dataLayerNewroleDetails = new Roledal();
            return dal.Newrole(newrole, functionaccess);
        }
    }
}
}