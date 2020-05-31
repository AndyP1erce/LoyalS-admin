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

namespace LoyalSRazor.Pages.UserPage
{
    public class EditModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public EditModel(LoyalSRazor.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MobileAppUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileAppUserExists(MobileAppUser.Id))
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

        private bool MobileAppUserExists(string id)
        {
            return _context.MobileAppUsers.Any(e => e.Id == id);
        }
    }
}
