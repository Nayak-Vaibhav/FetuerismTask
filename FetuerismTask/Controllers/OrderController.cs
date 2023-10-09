using FetuerismTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace FetuerismTask.Controllers
{
    public class OrderController : Controller
    {
        private readonly TaskDbContext _db;
        public OrderController(TaskDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var order = _db.Orders.ToList();

            return View(order);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var item = _db.Products.SingleOrDefault(u => u.ProductId == id);
            ViewBag.Product = item;

            return View("newCreate");
        }
        [HttpPost]
        public IActionResult Create(OrderCountModel value)
        {

            Orders order = new Orders() { };
            order.CustomerName = value.CustomerName;
            order.OrderDate = value.OrderDate;
            var count = value.Count;
            var product = _db.Products.FirstOrDefault(u => u.ProductName == value.ProductName);
            if (product != null)
            {
                Products prod = new Products()
                {
                    ProductName = product.ProductName,
                   
                    Price = product.Price,
                    QuantityInStock = product.QuantityInStock - count
                };
                return RedirectToAction("Edit", "Product", new { prod = prod } );
            }
            if (order != null)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult ListProd()
        {
            var list = _db.Products.ToList();
            return View(list);
        }
    }
}
