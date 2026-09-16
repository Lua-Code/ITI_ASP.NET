using ITI_ASP.NET.Data;
using ITI_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_ASP.NET.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext context;

        public CourseController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult ShowAll()
        {
            var courses = context.Courses
                .Include(c => c.Department)
                .ToList();

            return View(courses);
        }

        public IActionResult Details(int id)
        {
            var course = context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructors)
                .Include(c => c.CourseResults)
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = context.Departments.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Add(course);
                context.SaveChanges();

                return RedirectToAction("ShowAll");
            }

            ViewBag.Departments = context.Departments.ToList();

            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            ViewBag.Departments = context.Departments.ToList();

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Update(course);
                context.SaveChanges();

                return RedirectToAction("ShowAll");
            }

            ViewBag.Departments = context.Departments.ToList();

            return View(course);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            context.Courses.Remove(course);
            context.SaveChanges();

            return RedirectToAction("ShowAll");
        }
    }
}