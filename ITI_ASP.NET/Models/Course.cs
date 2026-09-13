using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ITI_ASP.NET.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }
        public int CourseHours { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Instructor> Instructors { get; set; } = new();
        public List<CourseResult> CourseResults { get; set; } = new();
    }
}