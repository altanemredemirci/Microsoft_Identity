using Mico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Mico.Controllers
{
	public class HomeController : Controller
	{		

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

        public IActionResult ContactUs()
        {
            return View();
        }

		public IActionResult Doctor()
		{
			//DataContext db = new DataContext();
			//var doctors = db.Doctors.Include(i=> i.SocialMedias).ToList();
			//return View(doctors);

			return View();
		}
    }
}
/*
** Views -> Shared klasörü views klasöründeki her dosyanýn kullanýmýna sunul ortak paylaþýlmýþ dosyalarý tutar.
 
** Layout.cshtml dosyasý projedeki birden fazla tasarým sayfasýnda tekrar eden ortak kodlarýn tanýmlandýðý ve bu ortak kodlarýn dýþýnda kalan kýsýmlarýn RenderBody() metodu ile çekildiði bir tasarým dosyasýdýr.
Her tasarým sayfasý Layout almak zorunda deðildir ama ortak alanlarýn tekrar tekrar yazýlmamasý için Layout.cshtml altýnda tanýmlanýr ve Layout'u alan her cshtml sayfa kendine özgü kodlarý Layout -> RenderBody() göndererek bütünü saðlar.

** _ViewStart.cshtml: Bir view döndüren action view eklenirken Layout seçeneði seçilir ama belirli bir layotu yolu verilmezse _ViewStart.cshtml altýnda tanýmlanmýþ Layout dosyasýný default olarak alýr.

** _ViewImports.cshtml: Views klasörü altýnda tanýmlanan RazorPages(cshtml uzantýlý) sayfalarda kullanýlacak model,entity,vb class larýn using olarak eklendiði dosyadýr. Bu sayede her viewden using ile tekrar tekrar tanýmlamaya gerek kalmaz.

** wwwroot: bu alanda proje tasarýmýna ait statik dosyalar yer alýr(css,js,..).
 */