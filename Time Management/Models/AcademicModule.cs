using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Time_Management.Models;

[Table("academic_modules")]
public partial class AcademicModule
{
    [Key]
    [Column("module_id")]
    public int ModuleId { get; set; }

    [Column("module_code")]
    [StringLength(10)]
    [Unicode(false)]
    public string ModuleCode { get; set; } = null!;

    [Column("module_name")]
    [StringLength(200)]
    [Unicode(false)]
    public string ModuleName { get; set; } = null!;

    [Column("module_credits")]
    public int ModuleCredits { get; set; }

    [Column("module_class_hours")]
    public int ModuleClassHours { get; set; }

    [Column("module_reminder")]
    [StringLength(300)]
    [Unicode(false)]
    public string? ModuleReminder { get; set; }
}
