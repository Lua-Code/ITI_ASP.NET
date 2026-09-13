using ITI_ASP.NET.Data;
using ITI_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_ASP.NET.Models;

namespace ITI_ASP.NET.Controllers
{
    public class TraineeController : Controller
    {
        private readonly AppDbContext context;

        public TraineeController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult ShowAll()
        {
            var trainees = context.Trainees
                .Include(t => t.Department)
                .Select(t => new TraineeAdvertisementColorBranchesTempViewModel
                {
                    TraineeId = t.Id,
                    TraineeName = t.Name,
                    TraineeImage = t.Image,
                    DepartmentName = t.Department.Name,
                    Advertisement = "Join ITI Now!",
                    Color = "Blue",
                    Branches = "Cairo, Alexandria",
                    Temp = 25
                })
                .ToList();

            ViewBag.Title = "Trainees";
            ViewBag.TraineeCount = trainees.Count;

            ViewData["Message"] = "ITI Trainee Management System";

            return View(trainees);
        }

        public IActionResult Details(int id)
        {
            var trainee = context.Trainees
                .Include(t => t.Department)
                .Where(t => t.Id == id)
                .Select(t => new TraineeAdvertisementColorBranchesTempViewModel
                {
                    TraineeId = t.Id,
                    TraineeName = t.Name,
                    TraineeImage = t.Image,
                    DepartmentName = t.Department.Name,
                    Advertisement = "Join ITI Now!",
                    Color = "Red",
                    Branches = "Cairo, Alexandria",
                    Temp = 25
                })
                .FirstOrDefault();

            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                context.Trainees.Add(trainee);
                context.SaveChanges();
                return RedirectToAction("ShowAll");
            }

            ViewBag.Departments = context.Departments.ToList();
            return View(trainee);
        }

    }
}