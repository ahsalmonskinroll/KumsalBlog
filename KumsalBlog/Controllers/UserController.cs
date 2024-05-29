
using KumsalBlog.Kernel.Models;
using KumsalBlog.Kernel.Service;
using KumsalBlog.Types;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KumsalBlog.Controllers
{
	public class UserController: Controller
	{

		private readonly IService<User> _service;
		private readonly AppDbContext _context;

		public UserController(IService<User> service, AppDbContext context) 
		{
			_service = service;

			_context = context;
		}

		public IActionResult Blog()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Save(User user)
		{

			if (ModelState.IsValid)
			{
				user.CreatedDate = DateTime.Now;
				await _service.AddAsync(user);
				TempData["SuccessMessage"] = "Yorum başarılı!";
				return View("~/Views/Home/Blog.cshtml", user);
			}

			TempData["ErrorMessage"] = "İşlem başarısız oldu!";
			return View("~/Views/Home/Blog.cshtml", user);

		}


	}
}