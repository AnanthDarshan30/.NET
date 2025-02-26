using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string Instructor { get; set; }
    }
}
