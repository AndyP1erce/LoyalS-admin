using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoyalSRazor.Data;
using LoyalSRazor.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoyalSRazor.Pages.UserCouponsPage
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public IndexModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserCoupons> UserCoupons { get;set; }

        public async Task OnGetAsync()
        {
            UserCoupons = await _context.UserCoupons
                .Include(u => u.Coupon)
                .Include(u => u.MobileAppUser).ToListAsync();
        }
    }
}
