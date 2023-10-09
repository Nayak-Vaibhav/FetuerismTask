using FetuerismTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace FetuerismTask.Controllers
{
    public class UserController : Controller
    {
        List<UserModel> users;
        public UserController()
        {
            users = new List<UserModel>()
            {
                new UserModel(){Username="Admin@add.com",Password="12345",Role="Admin"},
                new UserModel(){Username="user1@123",Password="12345",Role="user"}
            };
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(UserModel user)
        {
            if (user != null)
            {
                var U = users.FirstOrDefault(e=>e.Username==user.Username && e.Password==user.Password);
                if (U.Role=="Admin")
                {
                    return RedirectToAction("Index","Product");
                }
                if (U.Role=="user")
                {
                    return RedirectToAction("ListProd","Order");
                }
                return View();
            }
          
            return View();
        }
    }
}
