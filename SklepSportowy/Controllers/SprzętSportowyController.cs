using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SklepSportowy.Models;
using SklepSportowy.Services;

namespace SklepSportowy.Controllers
{
    public class SprzętSportowyController : Controller
    {
        private readonly ISprzętSportowyService _sprzętSportowyService;
        public SprzętSportowyController(AppDbContext context, ISprzętSportowyService postService)
        {
            _sprzętSportowyService = postService;
        }


        public IActionResult Index()
        {
            return View(_sprzętSportowyService.FindAll());
        }


        //Dodawanie 

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] SprzętSportowy sprzętSportowy)
        {
            if (ModelState.IsValid)
            {
                _sprzętSportowyService.Save(sprzętSportowy);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
