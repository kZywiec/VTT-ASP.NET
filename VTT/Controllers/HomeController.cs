using VTT.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VTT.Data;
using VTT.Models;
using VTT.Models.Entities;

namespace VTT.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (_userService.LoggedUser == null)
                return Login();
            
            ViewData["isAdmin"] = _userService.LoggedUser.isAdmin;
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            _userService.Logout();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                bool loginResoult = await _userService.LoginAsync(user);

                if(loginResoult)
                    return RedirectToAction("Index");
                else
                    return View(user);
            }
            catch(Exception e)
            {
                ViewData["errorMessage"] = $"{e.Message}";
                return View(user);
            }
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                await _userService.RegisterAsync(user.login, user.password);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewData["errorMessage"] = $"{e.Message}";
                return View(user);
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}