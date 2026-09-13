namespace ITI_ASP.NET.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public List<Trainee> Trainees { get; set; } = new();
        public List<Instructor> Instructors { get; set; } = new();
        public List<Course> Courses { get; set; } = new();
    }
}