using ITI_ASP.NET.Data;
using ITI_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_ASP.NET.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult ShowAllProducts()
        {
            var products = context.Products.ToList();

            return View(products);
        }
        public IActionResult Details(int id)
        {
            Product product = context.Products.FirstOrDefault(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();

                return RedirectToAction("ShowAllProducts");
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = context.Products.FirstOrDefault(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(product);
                context.SaveChanges();

                return RedirectToAction("ShowAllProducts");
            }

            return View(product);
        }
        public IActionResult Delete(int id)
        {
            Product product = context.Products.FirstOrDefault(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("ShowAllProducts");
        }
    }
}