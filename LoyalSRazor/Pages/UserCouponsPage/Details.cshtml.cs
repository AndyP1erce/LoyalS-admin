using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoyalSRazor.Data;
using LoyalSRazor.Models;

namespace LoyalSRazor.Pages.UserCouponsPage
{
    public class DetailsModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public DetailsModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public UserCoupons UserCoupons { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserCoupons = await _context.UserCoupons
                .Include(u => u.Coupon)
                .Include(u => u.MobileAppUser).FirstOrDefaultAsync(m => m.UserId == id);

            if (UserCoupons == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
