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
    public class IndexModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public IndexModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Suggestion> Suggestion { get;set; }

        public async Task OnGetAsync()
        {
            Suggestion = await _context.Suggestions.ToListAsync();
        }
    }
}
