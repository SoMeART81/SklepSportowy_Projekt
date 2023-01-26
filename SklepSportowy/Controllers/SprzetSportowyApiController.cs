using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SklepSportowy.Models;
using SklepSportowy.Services;

namespace SklepSportowy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprzetSportowyApiController : ControllerBase
    {
        private readonly ISprzetSportowyService _sprzetService;

        public SprzetSportowyApiController(ISprzetSportowyService sprzetSportowy)
        {
            _sprzetService = sprzetSportowy;
        }

        public IEnumerable<SprzetSportowy> Get()
        {
            return _sprzetService.FindAll();
        }

        [Route("{id}")]
        public ActionResult<SprzetSportowy> Get(int id)
        {
            SprzetSportowy? sprzet = _sprzetService.FindByRelations(id);

            if (sprzet is null)
            {
                return NotFound();
            }

            return sprzet;
        }

        [HttpPost]
        public ActionResult<SprzetSportowy> Post([FromBody] SprzetSportowy? sprzet)
        {
            if (ModelState.IsValid)
            {
                int id = _sprzetService.Save(sprzet);
                return Created($"/api/SprzetSportowyApi/{id}", sprzet);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult<SprzetSportowy> Put([FromBody] SprzetSportowy sprzet)
        {
            if (ModelState.IsValid)
            {
                if (_sprzetService.Update(sprzet))
                {
                    return Ok(sprzet);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<SprzetSportowy> Delete(int id)
        {
            if (_sprzetService.Delete(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
