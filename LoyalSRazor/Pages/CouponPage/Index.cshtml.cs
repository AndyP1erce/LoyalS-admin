using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoyalSRazor.Data;
using LoyalSRazor.Models;

namespace LoyalSRazor.Pages.CouponPage
{
    public class IndexModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public IndexModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Coupon> Coupon { get;set; }

        public async Task OnGetAsync()
        {
            Coupon = await _context.Coupons
                .Include(c => c.place).ToListAsync();
        }
    }
}
