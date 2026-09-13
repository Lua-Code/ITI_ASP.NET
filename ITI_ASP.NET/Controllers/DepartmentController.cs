using ITI_ASP.NET.Data;
using ITI_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_ASP.NET.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext context;

        public DepartmentController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult ShowAll()
        {
            var departments = context.Departments
                .Include(d => d.Trainees)
                .ToList();

            return View(departments);
        }

        public IActionResult Details(int id)
        {
            var department = context.Departments
                .Include(d => d.Trainees)
                .FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            var model = new DepartmentDetailsViewModel
            {
                DepartmentId = department.Id,
                DepartmentName = department.Name,
                Trainees = department.Trainees.Select(t => new TraineeAdvertisementColorBranchesTempViewModel
                {
                    TraineeId = t.Id,
                    TraineeName = t.Name,
                    TraineeImage = t.Image,
                    DepartmentName = department.Name,
                    Advertisement = "Join ITI Now!",
                    Color = "Blue",
                    Branches = "Cairo, Alexandria",
                    Temp = 25
                }).ToList()
            };

            return View(model);
        }
    }
}