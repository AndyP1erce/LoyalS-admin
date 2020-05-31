using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyalSRazor.Models
{
    public class CheckIn
    {
        public string UserId { get; set; }

        public string PlaceId { get; set; }

        public DateTime date_of_check { get; set; }

        public int coins { get; set; }


        public MobileAppUser MobileAppUser { get; set; }

        public Place Place { get; set; }
    }
}
