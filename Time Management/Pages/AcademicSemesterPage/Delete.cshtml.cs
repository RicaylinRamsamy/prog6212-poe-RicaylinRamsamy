using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Time_Management.Data;
using Time_Management.Models;

namespace Time_Management.Pages.AcademicSemesterPage
{
    public class DeleteModel : PageModel
    {
        private readonly Time_Management.Data.ApplicationDbContext _context;

        public DeleteModel(Time_Management.Data.ApplicationDbContext context)
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

            var academicsemester = await _context.AcademicSemesters.FirstOrDefaultAsync(m => m.SemesterId == id);

            if (academicsemester == null)
            {
                return NotFound();
            }
            else 
            {
                AcademicSemester = academicsemester;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AcademicSemesters == null)
            {
                return NotFound();
            }
            var academicsemester = await _context.AcademicSemesters.FindAsync(id);

            if (academicsemester != null)
            {
                AcademicSemester = academicsemester;
                _context.AcademicSemesters.Remove(AcademicSemester);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
