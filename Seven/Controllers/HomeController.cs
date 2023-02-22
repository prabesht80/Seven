using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seven.Data;
using Seven.Models;
using Seven.Services;

namespace Seven.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppService _appService;
        public HomeController(ILogger<HomeController> logger, AppService appService )
        {
            _logger = logger;
            _appService = appService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View(new LoginData());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginData loginData)
        {
            if (ModelState.IsValid)
            {
                int userId;
                if (new AppService().Login(loginData))
                {
                    //FormsAuthentication.RedirectFromLoginPage(userId.ToString(), loginData.RememberMe);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.LoginError = "Username Or Password Is Incorrect";
                }
            }
            return View();
        }


    }
}