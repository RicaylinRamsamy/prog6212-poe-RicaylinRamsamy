using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Time_Management.Models;

namespace Time_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicModule> AcademicModules { get; set; }

        public virtual DbSet<AcademicSemester> AcademicSemesters { get; set; }

        public virtual DbSet<SelfStudySession> SelfStudySessions { get; set; }
    }
}