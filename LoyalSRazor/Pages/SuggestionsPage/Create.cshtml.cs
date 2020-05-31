using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoyalSRazor.Data;
using LoyalSRazor.Models;

namespace LoyalSRazor.Pages.SuggestionsPage
{
    public class CreateModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public CreateModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Suggestion Suggestion { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Suggestion.Id = Guid.NewGuid().ToString();

            _context.Suggestions.Add(Suggestion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
