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

        [Authorize(Roles = "admin")]
        public IActionResult Delete([FromRoute] int? id)
        {
            _sprzetSportowyService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit([FromRoute] int? id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public IActionResult Edit([FromForm] SprzetSportowy sprzet)
        {
            if (ModelState.IsValid)
            {
                _sprzetSportowyService.Update(sprzet);
                return RedirectToAction(nameof(Index));
            }
            return View(sprzet);
        }

        [HttpGet]
        [Authorize]
        public IActionResult DodanieFirmy([FromRoute] int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult DodanieFirmy([FromForm] Firma firma)
        {
            if (ModelState.IsValid)
            {
                firma.DzienDodania = DateTime.Now;
                _sprzetSportowyService.DodanieFirmy(firma, firma.SprzetId);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(firma);
            }
        }

        public IActionResult Firma([FromRoute] int id)
        {
            return View(_sprzetSportowyService.FindByFirmy(id));
        }










        /////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Authorize]
        public IActionResult DodaniePromocji([FromRoute] int id)
        {
            ViewBag.Id = id;
            return View();
        }

        
        [HttpPost]
        public IActionResult DodaniePromocji([FromForm] Promocja promocja)
        {
            if (ModelState.IsValid)
            {
               
                _sprzetSportowyService.DodaniePromocji(promocja, promocja.SprzetId);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(promocja);
            }
        }

        public IActionResult Promocja([FromRoute] int id)
        {
            return View(_sprzetSportowyService.FindByPromocja(id));
        }




    }
}
