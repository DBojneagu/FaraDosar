using FaraDosar.Data;
using FaraDosar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FaraDosar.Controllers
{
    // [Authorize]
    public class CardsController : Controller
    {

        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public CardsController(
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
            var cards = db.Cards;
            ViewBag.Cards = cards;


            return View();
        }
        [Authorize]
        public IActionResult Show(int id)
        {
            Card card = db.Cards
                    .Where(crd => crd.Id == id)
                    .First();

            ViewBag.Id = id;

            return View(card);
        }

    }
}