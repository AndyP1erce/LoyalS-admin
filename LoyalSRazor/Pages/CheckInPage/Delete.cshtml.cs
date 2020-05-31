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

namespace LoyalSRazor.Pages.CheckInPage
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CheckIn = await _context.CheckIns.FindAsync(id);

            if (CheckIn != null)
            {
                _context.CheckIns.Remove(CheckIn);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
