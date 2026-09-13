using ITI_ASP.NET.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_ASP.NET.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext context;

        public InstructorController(AppDbContext context)
        {
            this.context = context;
        }

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
    }
}