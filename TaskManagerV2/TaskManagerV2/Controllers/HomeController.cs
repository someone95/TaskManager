using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerV2.Models;
using TaskManagerV2.ViewModels.Home;
using TaskManagerV2.ViewModels.Users;

namespace TaskManagerV2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LoginVM model)
        {
            AuthenticationManager.Authenticate(model.Username, model.Password);
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("LogIn", "Home");

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }

            AuthenticationManager.Logout();
            return RedirectToAction("LogIn", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            SaveUserVM model = new SaveUserVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(SaveUserVM model)
        {
            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password,
                IsAdmin = false
            };
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            UsersRepository usersRepo = new UsersRepository();
            usersRepo.Save(user);
            return RedirectToAction("LogIn", "Home");
        }

    }
}