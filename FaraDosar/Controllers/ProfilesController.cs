using FaraDosar.Data;
using FaraDosar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FaraDosar.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ProfilesController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager
        )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var profile = db.Profiles.Where(p => p.UserId == userId).FirstOrDefault();


            if (profile == null)
                ViewBag.Created = false;
            else
            {
                ViewBag.Created = true;
                ViewBag.Profile = profile;
            }

            if (TempData.ContainsKey("message"))
            {
                ViewBag.Message = TempData["message"];
            }
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult Show(int id)
        {
            var profile = db.Profiles.Where(p => p.Id == id).FirstOrDefault();
            return View(profile);
        }

        [Authorize(Roles = "User,Admin")]
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
        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult Edit(int id)
        {
            var profile = db.Profiles.Find(id);

            if (profile.UserId == _userManager.GetUserId(User))
            {
                return View(profile);
            }
            TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra altui profil";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Edit(int id, Profile requestProfile)
        {
            var profile = db.Profiles.Find(id);
            if (ModelState.IsValid)
            {
                if (profile.UserId == _userManager.GetUserId(User))
                {
                    profile.FirstName = requestProfile.FirstName;
                    profile.LastName = requestProfile.LastName;
                    profile.Adresa = requestProfile.Adresa;
                    profile.BirthDate = requestProfile.BirthDate;
                    profile.PhoneNumber = requestProfile.PhoneNumber;
                    profile.CNP = requestProfile.CNP;
                    db.SaveChanges();
                    TempData["message"] = "Profil modificat cu Succes";
                    return RedirectToAction("Index");
                }
                TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra altui profil";
                return RedirectToAction("Index");
            }
            return View(requestProfile);
        }
    }

}
