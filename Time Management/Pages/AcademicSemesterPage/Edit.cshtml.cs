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

namespace Time_Management.Pages.AcademicSemesterPage
{
    public class EditModel : PageModel
    {
        private readonly Time_Management.Data.ApplicationDbContext _context;

        public EditModel(Time_Management.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AcademicSemester AcademicSemester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AcademicSemesters == null)
            {
                return NotFound();
            }

            var academicsemester =  await _context.AcademicSemesters.FirstOrDefaultAsync(m => m.SemesterId == id);
            if (academicsemester == null)
            {
                return NotFound();
            }
            AcademicSemester = academicsemester;
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

            _context.Attach(AcademicSemester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicSemesterExists(AcademicSemester.SemesterId))
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

        private bool AcademicSemesterExists(int id)
        {
          return (_context.AcademicSemesters?.Any(e => e.SemesterId == id)).GetValueOrDefault();
        }
    }
}
