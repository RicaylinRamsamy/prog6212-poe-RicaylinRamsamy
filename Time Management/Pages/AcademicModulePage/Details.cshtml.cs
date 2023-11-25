﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Time_Management.Data;
using Time_Management.Models;

namespace Time_Management.Pages.AcademicModulePage
{
    public class DetailsModel : PageModel
    {
        private readonly Time_Management.Data.ApplicationDbContext _context;

        public DetailsModel(Time_Management.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AcademicModule AcademicModule { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AcademicModules == null)
            {
                return NotFound();
            }

            var academicmodule = await _context.AcademicModules.FirstOrDefaultAsync(m => m.ModuleId == id);
            if (academicmodule == null)
            {
                return NotFound();
            }
            else 
            {
                AcademicModule = academicmodule;
            }
            return Page();
        }
    }
}
