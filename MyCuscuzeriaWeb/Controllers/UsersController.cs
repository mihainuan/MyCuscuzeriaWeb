using Microsoft.AspNetCore.Mvc;
using MyCuscuzeriaWeb.Models;
using System;
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

        [HttpGet]
        public IActionResult Register(int? id)
        {
            if (id != null)
            {
                ViewBag.Verb = "Atualizar";
                ViewBag.ListOneUser = new UserViewModel().LoadUser(id);
            }
            else
            {
                ViewBag.Verb = "Registrar";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel dados)
        {
            dados.CreatedAt = DateTime.Now;
            dados.LastOrder = DateTime.Now.AddYears(-1);

            dados.CreateOrUpdateUser();
            //TODO: Return to index after Add/Edit
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
