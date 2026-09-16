using ITI_ASP.NET.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_ASP.NET.Models;

namespace ITI_ASP.NET.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext context;

        public InstructorController(AppDbContext context)
        {
            this.context = context;
        }
        
        [Route("instructors")]
        public IActionResult ShowAll()
        {
            var instructors = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .ToList();

            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var instructor = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefault(i => i.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("ShowAll");
            }

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(i => i.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();

            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                context.Instructors.Update(instructor);
                context.SaveChanges();

                return RedirectToAction("ShowAll");
            }

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();

            return View(instructor);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(i => i.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(i => i.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            context.Instructors.Remove(instructor);
            context.SaveChanges();

            return RedirectToAction("ShowAll");
        }
    }
}