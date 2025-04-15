using Mico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mico.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DataContext _db;

        public DoctorController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {          
            return View(_db.Doctors.Include(i=> i.SocialMedias).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Branchs = _db.Branches.ToList();
            return View(new Doctor());
        }


        [HttpPost]
        public IActionResult Create(Doctor model)
        {
            ModelState.Remove("SocialMedias[0].Icon");
            ModelState.Remove("SocialMedias[0].Doctor");
            ModelState.Remove("SocialMedias[1].Icon");
            ModelState.Remove("SocialMedias[1].Doctor");
            ModelState.Remove("SocialMedias[2].Icon");
            ModelState.Remove("SocialMedias[2].Doctor");
            if (ModelState.IsValid)
            {
                var doctor = _db.Doctors.Where(i => i.Branch == model.Branch && i.Name == model.Name).FirstOrDefault();

                if (doctor == null)
                {
                    model.SocialMedias[0].Icon = "fa-twitter";
                    model.SocialMedias[1].Icon = "fa-instagram";
                    model.SocialMedias[2].Icon = "fa-facebook";
                    _db.Doctors.Add(model);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }


            ViewBag.Branchs = _db.Branches.ToList();
            return View(model);
        }
    }
}
