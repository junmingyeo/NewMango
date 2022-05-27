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

        public int AddProfile(string Role, String Function)
        {
            return dal.createProfile(Role, Function);
        }

        public DataSet ViewRoles()
        {
            return dal.viewProfiles();
        }

        public int UpdateRole(int RoleID, string Role)
        {
            return dal.updateProfile(RoleID, Role);
        }

        public DataSet SearchRole(string Role)
        {
            return dal.searchProfile(Role);
        }

        public int SuspendRole(int RoleID)
        {
            return dal.suspendProfile(RoleID);
        }

    }
}
