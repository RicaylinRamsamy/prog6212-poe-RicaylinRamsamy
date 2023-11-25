using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Time_Management.Models;

[Table("self_study_sessions")]
public partial class SelfStudySession
{
    [Key]
    [Column("session_id")]
    public int SessionId { get; set; }

    [Column("module_code")]
    [StringLength(10)]
    [Unicode(false)]
    public string ModuleCode { get; set; } = null!;

    [Column("module_credits")]
    public int ModuleCredits { get; set; }

    [Column("module_class_hours")]
    public int ModuleClassHours { get; set; }

    [Column("semester_num_weeks")]
    public int SemesterNumWeeks { get; set; }

    [Column("self_study_hours")]
    public int SelfStudyHours { get; set; }

    [Column("date_studied", TypeName = "date")]
    public DateTime DateStudied { get; set; }
    Library l = new Library();
    public double Studyhours
    {
        get
        {
            return l.CalcSelfStudyHours(ModuleCredits, ModuleClassHours, SemesterNumWeeks);
        }
    }

    public double HoursRem
    {
        get
        {
            return l.SelfStudyHoursRemaining(Studyhours, SelfStudyHours);
        }
    }
}
