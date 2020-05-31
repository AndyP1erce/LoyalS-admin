using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoyalSRazor.Data;
using LoyalSRazor.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoyalSRazor.Pages.CheckInPage
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public CreateModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.MobileAppUsers, "Id", "Id");
        ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CheckIn CheckIn { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CheckIns.Add(CheckIn);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
