using KumsalBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KumsalBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult YazilimMuhendisligi()
        {
            return View();
        }

		public IActionResult YazilimMuhDetay()
		{
			return View();
		}

		public IActionResult DKUG()
		{
			return View();
		}

		public IActionResult DKUGDetay()
		{
			return View();
		}

		public IActionResult Bitirme()
		{
			return View();
		}

		public IActionResult BitirmeDetay()
		{
			return View();
		}

		public IActionResult Viki()
		{
			return View();
		}

		public IActionResult VikiDetay()
		{
			return View();
		}

		public IActionResult About()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

		public IActionResult BlogAralik()
		{
			return View();
		}

		public IActionResult BlogTenis()
		{
			return View();
		}

		public IActionResult BlogTubitak()
		{
			return View();
		}

		public IActionResult BlogSeramik()
		{
			return View();
		}

		public IActionResult BlogStaj()
		{
			return View();
		}

		public IActionResult BlogKayak()
		{
			return View();
		}

		public IActionResult BlogBuzHokeyi()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}