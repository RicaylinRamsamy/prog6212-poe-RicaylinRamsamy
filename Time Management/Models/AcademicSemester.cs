using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Time_Management.Models;

[Table("academic_semesters")]
public partial class AcademicSemester
{
    [Key]
    [Column("semester_id")]
    public int SemesterId { get; set; }

    [Column("semester_name")]
    [StringLength(20)]
    [Unicode(false)]
    public string SemesterName { get; set; } = null!;

    [Column("semester_start_date", TypeName = "date")]
    public DateTime SemesterStartDate { get; set; }

    [Column("semester_num_weeks")]
    public int SemesterNumWeeks { get; set; }
}
