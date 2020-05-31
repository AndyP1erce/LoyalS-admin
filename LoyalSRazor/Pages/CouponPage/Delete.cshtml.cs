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

namespace LoyalSRazor.Pages.CouponPage
{
    public class DeleteModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public DeleteModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coupon Coupon { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coupon = await _context.Coupons
                .Include(c => c.place).FirstOrDefaultAsync(m => m.Id == id);

            if (Coupon == null)
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

            Coupon = await _context.Coupons.FindAsync(id);

            if (Coupon != null)
            {
                _context.Coupons.Remove(Coupon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
