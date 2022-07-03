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
            //var l = _db.Rehbers.ToList();
            IEnumerable<Rehber> l = _db.Rehbers.ToList();
            return View(l);
        }

        [HttpGet]
        public IActionResult Add(User users,int id)
        {
            users.Id = Convert.ToInt32(HttpContext.Session.GetString("ID"));

            if (id != 0)
            {
                Rehber re = _db.Rehbers.FirstOrDefault(f => f.Id == id);
                return View(re);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(User users,Rehber r, int id = 0)
        {
            users.Id = Convert.ToInt32(HttpContext.Session.GetString("ID"));

            if (id == 0)
            {
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
