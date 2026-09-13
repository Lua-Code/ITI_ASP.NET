namespace ITI_ASP.NET.ViewModels
{
    public class DepartmentDetailsViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<TraineeAdvertisementColorBranchesTempViewModel> Trainees { get; set; } = new();
    }
}