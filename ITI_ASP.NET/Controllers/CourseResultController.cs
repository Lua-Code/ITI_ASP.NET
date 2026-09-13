using ITI_ASP.NET.Data;
using ITI_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_ASP.NET.Controllers
{
    public class CourseResultController : Controller
    {
        private readonly AppDbContext context;

        public CourseResultController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult ShowAll()
        {
            var courseResults = context.CourseResults
                .Include(cr => cr.Course)
                .Include(cr => cr.Trainee)
                .ToList();

            return View(courseResults);
        }

        public IActionResult Details(int id)
        {
            var courseResult = context.CourseResults
                .Include(cr => cr.Course)
                .Include(cr => cr.Trainee)
                .FirstOrDefault(cr => cr.Id == id);

            if (courseResult == null)
            {
                return NotFound();
            }

            return View(courseResult);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = context.Courses.ToList();
            ViewBag.Trainees = context.Trainees.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseResult courseResult)
        {
            if (ModelState.IsValid)
            {
                context.CourseResults.Add(courseResult);
                context.SaveChanges();

                return RedirectToAction("ShowAll");
            }

            ViewBag.Courses = context.Courses.ToList();
            ViewBag.Trainees = context.Trainees.ToList();

            return View(courseResult);
        }
    }
}