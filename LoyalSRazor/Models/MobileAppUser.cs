using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyalSRazor.Models
{
    public class MobileAppUser
    {

            public string Id { get; set; }

            public string name { get; set; }    

            public string email { get; set; }

            public string password { get; set; }

            public string salt { get; set; }

            public string token { get; set; }

            public int current_balance { get; set; }

            public string photo_path { get; set; }

            public DateTime date_of_reg { get; set; }

            public IList<UserCoupons> UserCoupons { get; set; }

            public IList<CheckIn> CheckIns { get; set; }
    }
}
