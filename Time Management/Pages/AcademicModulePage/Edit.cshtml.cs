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

namespace Time_Management.Pages.AcademicModulePage
{
    public class EditModel : PageModel
    {
        private readonly Time_Management.Data.ApplicationDbContext _context;

        public EditModel(Time_Management.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AcademicModule AcademicModule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AcademicModules == null)
            {
                return NotFound();
            }

            var academicmodule =  await _context.AcademicModules.FirstOrDefaultAsync(m => m.ModuleId == id);
            if (academicmodule == null)
            {
                return NotFound();
            }
            AcademicModule = academicmodule;
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

            _context.Attach(AcademicModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicModuleExists(AcademicModule.ModuleId))
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

        private bool AcademicModuleExists(int id)
        {
          return (_context.AcademicModules?.Any(e => e.ModuleId == id)).GetValueOrDefault();
        }
    }
}
