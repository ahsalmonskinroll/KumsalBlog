
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
		//private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public UserController(IService<User> service, AppDbContext context)  /*IMapper mapper,*/
		{
			_service = service;
			//_mapper = mapper;
			_context = context;
		}

		public IActionResult Blog()
		{
			return View();
		}

		//public async Task<IActionResult> Save()
		//{
		//	var students = await _services.GetAllAsync();

		//	var studentDto = _mapper.Map<List<StudentDto>>(students.ToList());

		//	ViewBag.students = new SelectList(studentDto, "Id", "TcNo");

		//	return View(studentDto);
		//}

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