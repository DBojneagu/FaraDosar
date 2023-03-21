using FaraDosar.Data;
using FaraDosar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FaraDosar.Controllers
{
    public class AppointmentsController : Controller
    {
		private readonly ApplicationDbContext db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AppointmentsController(
		ApplicationDbContext context,
		UserManager<ApplicationUser> userManager,
		RoleManager<IdentityRole> roleManager
		)
		{
			db = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}
		public IActionResult Index()
        {
            return View();
        }
        public IActionResult New(string attributeName)
        {
			// legam profilul de user pt a folosi profilul in fereastra new
			var userId = _userManager.GetUserId(User);
			var profile = db.Profiles.Where(p => p.UserId == userId).FirstOrDefault();

			if(profile == null)
			{
				ViewBag.Created = false;
			}
			else
			{
				ViewBag.Created = true;
				ViewBag.Profile = profile;
			}
			if (TempData.ContainsKey("message"))
			{
				ViewBag.Message = TempData["message"];
			}
			ViewBag.RezPentru = attributeName;
			Appointment appointment = new Appointment();
            return View(appointment);
        }
    }
}
