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
    public class DeleteModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public DeleteModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserCoupons = await _context.UserCoupons.FindAsync(id);

            if (UserCoupons != null)
            {
                _context.UserCoupons.Remove(UserCoupons);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
