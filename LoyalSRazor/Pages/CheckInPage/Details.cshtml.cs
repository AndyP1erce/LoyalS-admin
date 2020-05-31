using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoyalSRazor.Data;
using LoyalSRazor.Models;

namespace LoyalSRazor.Pages.CheckInPage
{
    public class DetailsModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public DetailsModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CheckIn CheckIn { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CheckIn = await _context.CheckIns
                .Include(c => c.MobileAppUser)
                .Include(c => c.Place).FirstOrDefaultAsync(m => m.UserId == id);

            if (CheckIn == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
