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
    public class IndexModel : PageModel
    {
        private readonly LoyalSRazor.Data.ApplicationDbContext _context;

        public IndexModel(LoyalSRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CheckIn> CheckIn { get;set; }

        public async Task OnGetAsync()
        {
            CheckIn = await _context.CheckIns
                .Include(c => c.MobileAppUser)
                .Include(c => c.Place).ToListAsync();
        }
    }
}
