using Mico.EmailServices;
using Mico.Identity;
using Mico.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mico.Controllers
{
    public class AccountController : Controller
    {
        #region Injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signManager = signInManager;
            _roleManager = roleManager;
        }
        #endregion

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if(await _userManager.IsEmailConfirmedAsync(user))
                {
                    var result = await _signManager.PasswordSignInAsync(user, model.Password, model.IsPersient, true);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Email Onaylanmamıştır");
                    return View(model);
                }
               
            }
            return View(model);
        }


        [HttpGet] //Http attribute verilmeyen her action metot HTTPGET olarak tanımlanır. GET sayfa çağırmayı sağlar.
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) //Metot imzası parametre sayısı veya parametre veri tipi farklı olmalı.
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = model.Email;
                user.FullName = model.Name + " " + model.Surname;
                user.UserName = model.Username;

                var result = await _userManager.CreateAsync(user,model.Password);

                if (result.Errors.Count() > 0)
                {
                    foreach (var i in result.Errors)
                    {
                        ModelState.AddModelError(i.Code, i.Description);
                    }
                    return View(model);
                }

                if(!_roleManager.Roles.Any(i=> i.Name == "doctor"))
                {
                    await _roleManager.CreateAsync(new IdentityRole() { Name = "doctor" });
                }

                await _userManager.AddToRoleAsync(user, "doctor");

                //GenerateToken ile Email Confirm Mail Gönderimi
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });

                string siteUrl = "http://localhost:5204";
                string activeUrl = siteUrl + callbackUrl;
                string body = $"Sayın {user.UserName} üyeliğinizin onaylanması için <a href={activeUrl}>linke</a> tıklayınız";
                MailHelper.SendMail(body, user.Email, "Üyelik Onayı");

                TempData["message"] = "Lütfen email adresinize gönderilen onay mailine tıklayınız";
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                TempData["message"] = "Email onaylanacak kullanıcı bulunamadı!";
                return View("Login");
            }
            try
            {
                await _userManager.ConfirmEmailAsync(user, token);
                TempData["message"] = "Üyeliğiniz Onaylanmıştır";
                return View("Login");
            }

            catch
            {
                TempData["message"] = "Email onay token anahtarı hatalı!";
                return View("Login");
            }           
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["message"] = "Email Adresi Girmediniz!";
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["message"] = "Kayıtlı Bir Email Adresi Girmediniz!";
                return View();
            }

            //GenerateToken ile Email Confirm Mail Gönderimi
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            string siteUrl = "http://localhost:5204";
            string activeUrl = siteUrl + callbackUrl;
            string body = $"Sayın {user.UserName} yeni şifre oluşturmak için <a href={activeUrl}>linke</a> tıklayınız";
            MailHelper.SendMail(body, user.Email, "Şifre Yenileme");

            TempData["message"] = "Lütfen email adresinize gönderilen mail ile şifrenizi yeniden oluşturunuz";
            return RedirectToAction("Login");
        }

        public IActionResult ResetPassword(string token, string userId)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel()
            {
                userId = userId,
                token = token
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.userId);
                if (user == null)
                {
                    TempData["message"] = "Kayıtlı Bir Kullanıcı Bulunamadı!";
                    return View();
                }


                await _userManager.ResetPasswordAsync(user, model.token, model.Password);
                TempData["message"] = "Şifreniz yenilendi";
                return RedirectToAction("Login");
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
