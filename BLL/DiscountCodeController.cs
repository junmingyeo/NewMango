using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RestaurantOwner.DAL;

namespace RestaurantOwner.BLL
{
    public class DiscountCodeController
    {
        DiscountCode dc = new DiscountCode();
        Order o = new Order();
        string couponCode;
        public void validateDiscountCode(string discountID)
        {
            dc.getDiscountCode(discountID);
            o.applyDiscountCode(couponCode);
        }
    }
}