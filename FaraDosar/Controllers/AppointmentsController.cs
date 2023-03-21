using FaraDosar.Data;
using FaraDosar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
			Appointment appointment = new Appointment();
			appointment.Ore = GetAllHours();
			appointment.Locations = GetAllLocations();
            var user = _userManager.GetUserAsync(User).Result;
            ViewBag.Nume = User.Claims.FirstOrDefault(c => c.Type == "FirstName");


            if (TempData.ContainsKey("message"))
			{
				ViewBag.Message = TempData["message"];
			}
			ViewBag.RezPentru = attributeName;
			return View(appointment);
		}
		[Authorize(Roles = "User,Admin")]
		[HttpPost]
		public IActionResult New(Appointment appointment)
		{
			appointment.UserId = _userManager.GetUserId(User);

			if (ModelState.IsValid)
			{
                db.Appointments.Add(appointment);
				db.SaveChanges();
				TempData["message"] = "Appointment a fost adaugat";
				return Redirect("/Cards/Index");
			}
			else
			{
                appointment.Ore = GetAllHours();
				appointment.Locations = GetAllLocations();
				return View(appointment);
			}
		}



		/*[Authorize(Roles = "User,Admin")]
        public IActionResult New()
        {
            var test = db.Profiles.Where(p => p.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            if (test != null)
                return RedirectToAction("Index");

            Profile profile = new Profile();
			return View(profile);
		}
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public IActionResult New(Profile profile)
        {
            profile.UserId = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {

                db.Profiles.Add(profile);
                db.SaveChanges();
                TempData["message"] = "Profilul a fost creat";
                return RedirectToAction("Index");
            }
            return View(profile);
        }*/

		[NonAction]
		public IEnumerable<SelectListItem> GetAllHours()
		{
			var selectList = new List<SelectListItem>();

			var hours = from hour in db.Hours
						select hour;

			foreach (var hour in hours)
			{
				selectList.Add(new SelectListItem
				{
					Value = hour.Id.ToString(),
					Text = hour.Time.ToString()
				});
			}
			return selectList;
		}

		[NonAction]
		public IEnumerable<SelectListItem> GetAllLocations()
		{
			var selectList = new List<SelectListItem>();

			var locations = from location in db.Locations
							select location;

			foreach (var location in locations)
			{
				selectList.Add(new SelectListItem
				{
					Value = location.Id.ToString(),
					Text = location.Name.ToString()
				});
			}
			return selectList;
		}

		[Authorize(Roles = "User,Admin")]
		public IActionResult ShowApp()
		{
			var userId = _userManager.GetUserId(User);
			var appointments = db.Appointments.Include("Hour").Include("Location")
				.Where(app => app.UserId == userId)
				.ToList();
			ViewBag.Appointments = appointments;
			return View();
		}


	}
}
