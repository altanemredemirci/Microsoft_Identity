using Mico.EmailServices;
using Mico.Identity;
using Mico.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mico.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();

        //Giriş yapan kişinin Role tanımı ADMİN ise bu controller a gelecek ve yönetici işlemlerini yapacak
        public IActionResult Index()
        {
            var doctors = db.Doctors.ToList();

            return View(doctors);
        }

        public IActionResult CreateDoctor()
        {
            return View(new Doctor());
        }

        [HttpPost]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = db.Doctors.Add(doctor);

            //    if (!_roleManager.Roles.Any(i => i.Name == "doctor"))
            //    {
            //        await _roleManager.CreateAsync(new IdentityRole() { Name = "doctor" });
            //    }

            //    await _userManager.AddToRoleAsync(user, "doctor");

            //    //GenerateToken ile Email Confirm Mail Gönderimi
            //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //    var callbackUrl = Url.Action("ConfirmEmail", "Account", new
            //    {
            //        userId = user.Id,
            //        token = code
            //    });

            //    string siteUrl = "http://localhost:5204";
            //    string activeUrl = siteUrl + callbackUrl;
            //    string body = $"Sayın {user.UserName} üyeliğinizin onaylanması için <a href={activeUrl}>linke</a> tıklayınız";
            //    MailHelper.SendMail(body, user.Email, "Üyelik Onayı");

            //    TempData["message"] = "Lütfen email adresinize gönderilen onay mailine tıklayınız";
            //    return RedirectToAction("Login");
            //}
            return View(doctor);
        }
    }
}


