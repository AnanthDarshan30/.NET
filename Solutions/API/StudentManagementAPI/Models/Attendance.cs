using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int StudentId { get; set; }  // Foreign key

        public int CourseId { get; set; }  // Foreign key

        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }
    }
}
