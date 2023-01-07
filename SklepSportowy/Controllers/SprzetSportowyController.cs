using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SklepSportowy.Models;
using SklepSportowy.Services;

namespace SklepSportowy.Controllers
{
    public class SprzetSportowyController : Controller
    {
        private readonly ISprzetSportowyService _sprzetSportowyService;
        public SprzetSportowyController(AppDbContext context, ISprzetSportowyService sprzetService)
        {
            _sprzetSportowyService = sprzetService;
        }


        public IActionResult Index()
        {
            return View(_sprzetSportowyService.FindAll());
        }


        //Dodawanie 

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] SprzetSportowy sprzetSportowy)
        {
            if (ModelState.IsValid)
            {
                _sprzetSportowyService.Save(sprzetSportowy);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
