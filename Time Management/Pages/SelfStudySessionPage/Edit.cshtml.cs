using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Time_Management.Data;
using Time_Management.Models;

namespace Time_Management.Pages.SelfStudySessionPage
{
    public class EditModel : PageModel
    {
        private readonly Time_Management.Data.ApplicationDbContext _context;

        public EditModel(Time_Management.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SelfStudySession SelfStudySession { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SelfStudySessions == null)
            {
                return NotFound();
            }

            var selfstudysession =  await _context.SelfStudySessions.FirstOrDefaultAsync(m => m.SessionId == id);
            if (selfstudysession == null)
            {
                return NotFound();
            }
            SelfStudySession = selfstudysession;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SelfStudySession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelfStudySessionExists(SelfStudySession.SessionId))
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

        private bool SelfStudySessionExists(int id)
        {
          return (_context.SelfStudySessions?.Any(e => e.SessionId == id)).GetValueOrDefault();
        }
    }
}
