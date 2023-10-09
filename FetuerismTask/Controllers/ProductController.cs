using FetuerismTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace FetuerismTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly TaskDbContext _db;
        public ProductController(TaskDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var list = _db.Products.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Products prod)
        {
            if (prod != null)
            {
                _db.Products.Add(prod);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _db.Products.SingleOrDefault(p => p.ProductId == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Products prod)
        {
            if (prod != null)
            {
                _db.Products.Update(prod);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _db.Products.SingleOrDefault(p => p.ProductId == id);
            return View(product);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deletep(int id)
        {
            var prod = _db.Products.SingleOrDefault(p=>p.ProductId== id);
            if(prod != null)
            {
                _db.Products.Remove(prod);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public IActionResult Details(int id)
        {
            var product = _db.Products.SingleOrDefault(p => p.ProductId == id);
            return View(product);
        }

    }
}
