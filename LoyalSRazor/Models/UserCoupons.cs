using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyalSRazor.Models
{
    public class UserCoupons
    {
        public string UserId { get; set; }
        public string CouponId { get; set; }

        public DateTime date_of_buy { get; set; }


        public MobileAppUser MobileAppUser { get; set; }

        public Coupon Coupon { get; set; }
    }
}
