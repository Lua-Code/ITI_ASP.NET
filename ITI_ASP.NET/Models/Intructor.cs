namespace ITI_ASP.NET.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}