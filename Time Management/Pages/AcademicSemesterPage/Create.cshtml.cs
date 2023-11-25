using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Time_Management.Data;
using Time_Management.Models;

namespace Time_Management.Pages.AcademicSemesterPage
{
    public class CreateModel : PageModel
    {
        private readonly Time_Management.Data.ApplicationDbContext _context;

        public CreateModel(Time_Management.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AcademicSemester AcademicSemester { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AcademicSemesters == null || AcademicSemester == null)
            {
                return Page();
            }

            _context.AcademicSemesters.Add(AcademicSemester);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
