using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyalSRazor.Models
{
    public class Coupon
    {
        public string Id { get; set; }

        public string title { get; set; }

        public int price { get; set; }

        public string photo_path { get; set; }

        public string buy_time { get; set; }

        public DateTime date_of_start { get; set; }

        public DateTime date_of_end { get; set; }


        public string PlaceId { get; set; }

        public Place place { get; set; }

        public IList<UserCoupons> UserCoupons { get; set; }
    }
}
