using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoyalSRazor.Data;
using LoyalSRazor.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoyalSRazor.Pages.UserCouponsPage
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public EditModel(LoyalSRazor.Data.ApplicationDbContext context)
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
           ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Id");
           ViewData["UserId"] = new SelectList(_context.MobileAppUsers, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserCoupons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCouponsExists(UserCoupons.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserCouponsExists(string id)
        {
            return _context.UserCoupons.Any(e => e.UserId == id);
        }
    }
}
