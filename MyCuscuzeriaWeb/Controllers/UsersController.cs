using Microsoft.AspNetCore.Mvc;
using MyCuscuzeriaWeb.Models;
using System.Diagnostics;

namespace MyCuscuzeriaWeb.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel objUser = new UserViewModel();
            ViewBag.ListAllUsers = objUser.ListAllUsers();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
