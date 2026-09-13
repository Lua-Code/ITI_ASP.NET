using ITI_ASP.NET.Data;
using ITI_ASP.NET.Models;
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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Instructors = context.Instructors.ToList();
            ViewBag.Trainees = context.Trainees.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentCreateViewModel model)
        {
            var managerExists = context.Instructors
                .Any(i => i.Name == model.Manager);

            if (!managerExists)
            {
                ModelState.AddModelError("Manager", "The selected manager does not exist.");
            }

            var traineeIds = context.Trainees
                .Where(t => model.TraineeIds.Contains(t.Id))
                .Select(t => t.Id)
                .ToList();

            if (traineeIds.Count != model.TraineeIds.Count)
            {
                ModelState.AddModelError("TraineeIds", "One or more selected trainees do not exist.");
            }

            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Name = model.Name,
                    Manager = model.Manager
                };

                context.Departments.Add(department);
                context.SaveChanges();

                var trainees = context.Trainees
                    .Where(t => model.TraineeIds.Contains(t.Id))
                    .ToList();

                foreach (var trainee in trainees)
                {
                    trainee.DepartmentId = department.Id;
                }

                context.SaveChanges();

                return RedirectToAction("ShowAll");
            }

            ViewBag.Instructors = context.Instructors.ToList();
            ViewBag.Trainees = context.Trainees.ToList();

            return View(model);
        }

    }
}