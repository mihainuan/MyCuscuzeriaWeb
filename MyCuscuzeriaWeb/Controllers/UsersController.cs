using Microsoft.AspNetCore.Mvc;
using MyCuscuzeriaWeb.Models;
using System;

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

            return RedirectToAction("Index");
        }


        public IActionResult Remove(int id)
        {
            new UserViewModel().RemoveUser(id);

            return RedirectToAction("Index");
        }
    }
}
