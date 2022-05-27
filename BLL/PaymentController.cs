using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class PaymentController
    {
        Checkout co = new Checkout();
        public void custEmail(string email)
        {
            co.makePayment();
        }
    }
}