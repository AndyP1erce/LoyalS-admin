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

namespace LoyalSRazor.Pages.CheckInPage
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
           ViewData["UserId"] = new SelectList(_context.MobileAppUsers, "Id", "Id");
           ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id");
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

            _context.Attach(CheckIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckInExists(CheckIn.UserId))
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

        private bool CheckInExists(string id)
        {
            return _context.CheckIns.Any(e => e.UserId == id);
        }
    }
}
