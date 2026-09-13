namespace ITI_ASP.NET.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public decimal Degree { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public int TraineeId { get; set; }
        public Trainee? Trainee { get; set; }
    }
}