using Microsoft.AspNetCore.Mvc;
using TelefonRehberiWeb.Data;
using TelefonRehberiWeb.ExtraClasses;
using TelefonRehberiWeb.Models;
using TelefonRehberiWeb.Services;

namespace TelefonRehberiWeb.Controllers
{
    [Route ("account")]
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _db;

      
        private AccountService accountService;

        public AccountController(AccountService _accountService , ApplicationDbContext db)
        {
            accountService = _accountService;
            _db = db;
        }

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            var account= accountService.Login(username,password);
            if (account != null)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("welcome");
            }
            else
            {
                ViewBag.msg = "Invalid";
                return View("Index");
            }
        }

       
        [Route("register")]
        public IActionResult Register(User users, int id)
        {

            if (id != 0)
            {
                users.Password = Sha256Converter.ComputeSha256Hash(users.Password);
                User re = _db.Users.FirstOrDefault(f => f.Id == id);
                return View(re);
            }
            return View();
        }


        [Route("welcome")]
        public IActionResult Welcome()
        {
            ViewBag.username= HttpContext.Session.GetString("username" );
            return View("Welcome");
        }

        [Route("logout")]
        public IActionResult LogOut()
        {
             HttpContext.Session.Remove("username");
            return View("index");
        }

    }
}
