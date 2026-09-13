using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ITI_ASP.NET.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Grade { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public List<CourseResult> CourseResults { get; set; } = new();
    }
}