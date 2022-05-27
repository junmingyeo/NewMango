using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{

    public class Coupon_Controller
    {
        Coupon C = new Coupon();

        //On Page Load Generate Money Report for today
        public DataTable getAllCoupons()
        {
            return C.getAllCoupons();
        }
        public int createCoupon(string couponCode, int discountPercentage)
        {
            return C.createCoupon(couponCode, discountPercentage);
        }

        public int deleteCoupon(string couponCode)
        {
            return C.deleteCoupon(couponCode);
        }
        public int updateCoupon(string couponCode, int discountPercentage)
        {
            return C.updateCoupon(couponCode, discountPercentage);
        }
    }
}