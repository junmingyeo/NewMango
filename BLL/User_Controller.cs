//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using RestaurantOwner.DAL;
//using System.Data;

//namespace RestaurantOwner.BLL
//{
//    public class User_Controller
//    {
//        Users user = new Users();
//        // -- Staff authentication -- //
//        public DataSet GetLogin(string email, string password)
//        {
            
//            return user.staffLogin(email, password);
//        }

//        public DataSet GetProfile(int UserID)
//        {
//            return user.profileDetails(UserID);
//        }
//        public DataSet GetAdminResetPW()
//        {
//            return user.adminResetPW();
//        }
//        public int GetAdminResetPWPassword(int UserID, string newPassword)
//        {
//            return user.adminResetPWPassword(UserID, newPassword);
//        }
//        public int RegisterAdmin(string Email, string FirstName, string LastName, string Password, string Role)
//        {
//            return user.staffRegistration(Email, FirstName, LastName, Password, Role);
//        }
//    }
//}