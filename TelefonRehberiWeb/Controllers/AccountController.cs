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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password, User user)
        {
            //user.Password = Sha256Converter.ComputeSha256Hash(user.Password);
            //if (user.Password != null)
            //{
            //    HttpContext.Session.SetString("username", username);
            //    return RedirectToAction("welcome");
            //}
            //else
            //{
            //    ViewBag.msg = "Invalid";
            //    return View("Index");
            //}

            user.Password = Sha256Converter.ComputeSha256Hash(user.Password);
            var account = accountService.Login(username, password);
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

        [HttpGet]
        [Route("register")]
        public IActionResult Register(/*User users,*/ int id)
        {

            if (id != 0)
            {
                //users.Password = Sha256Converter.ComputeSha256Hash(users.Password);
                User re = _db.Users.FirstOrDefault(f => f.Id == id);
                return View(re);
            }
            return View();
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(User r, int id=0)
        {

            if (id == 0)
            {
                r.Password = Sha256Converter.ComputeSha256Hash(r.Password);
                _db.Users.Add(r);
            }
            else
            {
                Rehber re = _db.Rehbers.FirstOrDefault(f => f.Id == r.Id);
                //re.Adress = r.Adress;
                //re.Email = r.Email;
                //re.PhoneNumber = r.PhoneNumber;
                //re.Surname = r.Surname;
                //re.Notes = r.Notes;
                //re.Id = r.Id;
                //re.Name = r.Name;
                _db.Rehbers.Update(re);
            }

            _db.SaveChanges();
            return RedirectToAction("Register");
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
