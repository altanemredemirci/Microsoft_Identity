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
** Views -> Shared klas�r� views klas�r�ndeki her dosyan�n kullan�m�na sunul ortak payla��lm�� dosyalar� tutar.
 
** Layout.cshtml dosyas� projedeki birden fazla tasar�m sayfas�nda tekrar eden ortak kodlar�n tan�mland��� ve bu ortak kodlar�n d���nda kalan k�s�mlar�n RenderBody() metodu ile �ekildi�i bir tasar�m dosyas�d�r.
Her tasar�m sayfas� Layout almak zorunda de�ildir ama ortak alanlar�n tekrar tekrar yaz�lmamas� i�in Layout.cshtml alt�nda tan�mlan�r ve Layout'u alan her cshtml sayfa kendine �zg� kodlar� Layout -> RenderBody() g�ndererek b�t�n� sa�lar.

** _ViewStart.cshtml: Bir view d�nd�ren action view eklenirken Layout se�ene�i se�ilir ama belirli bir layotu yolu verilmezse _ViewStart.cshtml alt�nda tan�mlanm�� Layout dosyas�n� default olarak al�r.

** _ViewImports.cshtml: Views klas�r� alt�nda tan�mlanan RazorPages(cshtml uzant�l�) sayfalarda kullan�lacak model,entity,vb class lar�n using olarak eklendi�i dosyad�r. Bu sayede her viewden using ile tekrar tekrar tan�mlamaya gerek kalmaz.

** wwwroot: bu alanda proje tasar�m�na ait statik dosyalar yer al�r(css,js,..).
 */