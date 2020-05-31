using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyalSRazor.Models
{
    public class Place
    {
        public string Id { get; set; }

        public string title { get; set; }

        public float rating { get; set; }

        public string city { get; set; }

        public string adress { get; set; }

        public string working_hours { get; set; }

        public string phone { get; set; }

        public string average_cost { get; set; }

        public string category { get; set; }

        public string photo_path { get; set; }


        public ICollection<Coupon> Coupons { get; set; }

        public IList<CheckIn> CheckIns { get; set; }

    }
}
