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

namespace LoyalSRazor.Pages.UserPage
{
    public class DeleteModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public DeleteModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MobileAppUser MobileAppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MobileAppUser = await _context.MobileAppUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (MobileAppUser == null)
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

            MobileAppUser = await _context.MobileAppUsers.FindAsync(id);

            if (MobileAppUser != null)
            {
                _context.MobileAppUsers.Remove(MobileAppUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
