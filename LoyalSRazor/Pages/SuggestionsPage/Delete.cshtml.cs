using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoyalSRazor.Data;
using LoyalSRazor.Models;

namespace LoyalSRazor.Pages.SuggestionsPage
{
    public class DeleteModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public DeleteModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Suggestion Suggestion { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Suggestion = await _context.Suggestions.FirstOrDefaultAsync(m => m.Id == id);

            if (Suggestion == null)
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

            Suggestion = await _context.Suggestions.FindAsync(id);

            if (Suggestion != null)
            {
                _context.Suggestions.Remove(Suggestion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
