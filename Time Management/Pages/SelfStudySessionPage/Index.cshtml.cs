﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Time_Management.Data.ApplicationDbContext _context;

        public IndexModel(Time_Management.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SelfStudySession> SelfStudySession { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SelfStudySessions != null)
            {
                SelfStudySession = await _context.SelfStudySessions.ToListAsync();
            }
        }
    }
}
