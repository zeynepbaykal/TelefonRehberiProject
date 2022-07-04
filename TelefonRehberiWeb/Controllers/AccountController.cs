using Microsoft.AspNetCore.Http;
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
        private List<User> user;
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
            IEnumerable<User> r = _db.Users.ToList();
            return View("Welcome",r);
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password,int id=0 )
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

          
            

            password = Sha256Converter.ComputeSha256Hash(password);
            //var account = accountService.Login(username, password);
            //if (id != 0)
            
              //r = _db.Users.ToList();
                User r = _db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
               
                if(r!=null) {
                HttpContext.Session.SetString("userId", r.UserId.ToString());
                return View("welcome",r);
            }
            else
            {
                HttpContext.Session.SetString("userId", "0");
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
                User re = _db.Users.FirstOrDefault(f => f.UserId == id);
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
                Rehber re = _db.Rehbers.FirstOrDefault(f => f.Id == r.UserId);
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
            ViewBag.username= HttpContext.Session.GetString("userId");
            return View("Welcome");
        }

        [Route("logout")]
        public IActionResult LogOut()
        {
             HttpContext.Session.Remove("userId");
            return View("index");
        }

    }
}
