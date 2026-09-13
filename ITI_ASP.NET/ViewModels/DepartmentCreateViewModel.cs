namespace ITI_ASP.NET.ViewModels
{
    public class DepartmentCreateViewModel
    {
        public string Name { get; set; }
        public string Manager { get; set; }
        public List<int> TraineeIds { get; set; } = new();
    }
}