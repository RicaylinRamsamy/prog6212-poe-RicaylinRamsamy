using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Time_Management.Data;
using Time_Management.Models;

namespace Time_Management.Pages.SelfStudySessionPage
{
    public class DetailsModel : PageModel
    {
        private readonly Time_Management.Data.ApplicationDbContext _context;

        public DetailsModel(Time_Management.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public SelfStudySession SelfStudySession { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SelfStudySessions == null)
            {
                return NotFound();
            }

            var selfstudysession = await _context.SelfStudySessions.FirstOrDefaultAsync(m => m.SessionId == id);
            if (selfstudysession == null)
            {
                return NotFound();
            }
            else 
            {
                SelfStudySession = selfstudysession;
            }
            return Page();
        }
    }
}
