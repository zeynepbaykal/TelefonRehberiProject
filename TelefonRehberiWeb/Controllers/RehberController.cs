using Microsoft.AspNetCore.Mvc;
using TelefonRehberiWeb.Data;
using TelefonRehberiWeb.Models;

namespace TelefonRehberiWeb.Controllers
{
    public class RehberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RehberController(ApplicationDbContext db)
        {
           
            _db = db;
        }

        public IActionResult Index()
        {
            string UserId = ((HttpContext.Session.GetString("userId")));
            bool a = String.IsNullOrEmpty(UserId);

            if (UserId != "0")
            {
                if (!String.IsNullOrEmpty(UserId))
                {
                    IEnumerable<Rehber> l = _db.Rehbers.Where(w => w.UserId == Convert.ToInt32(UserId)).ToList();
                    return View(l);
                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }
               
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            //var l = _db.Rehbers.ToList();
           
          
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            string UserId = ((HttpContext.Session.GetString("userId")));
            bool a = String.IsNullOrEmpty(UserId);

            if (UserId != "0")
            {
                if (!String.IsNullOrEmpty(UserId))
                {
                    if (id != 0)
                    {
                        Rehber re = _db.Rehbers.FirstOrDefault(f => f.Id == id);
                        return View(re);
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }

            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

           
        }

        [HttpPost]
        public IActionResult Add(Rehber r, int id = 0)
        {
        


            if (id == 0)
            {
                r.UserId =Convert.ToInt32(HttpContext.Session.GetString("userId"));
                _db.Rehbers.Add(r);
            }
            else
            {
                Rehber re = _db.Rehbers.FirstOrDefault(f => f.Id == r.Id);
               
                re.Adress = r.Adress;
                re.Email = r.Email;
                re.PhoneNumber = r.PhoneNumber;
                re.Surname = r.Surname;
                re.Notes = r.Notes;
                re.Id = r.Id;
                re.Name = r.Name;
                _db.Rehbers.Update(re);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Rehber r = _db.Rehbers.FirstOrDefault(f => f.Id == id);
            if (r != null)
            {
                _db.Rehbers.Remove(r);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(string search)
        {
            IEnumerable<Rehber> r;
            if (String.IsNullOrEmpty(search))
            {
                r = _db.Rehbers.ToList();
            }
            else
            {
                r = _db.Rehbers.Where(w => w.Name.Contains(search)).ToList();
            }
            //Rehber r = _db.Rehbers.FirstOrDefault(f => f.Name == id);
            return View("Index", r);
        }
    }
}
