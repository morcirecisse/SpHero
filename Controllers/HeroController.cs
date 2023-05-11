using Microsoft.AspNetCore.Mvc;
using SpHero.Models;
using SpHero.Service;

namespace SpHero.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        public IActionResult GetAllHeroes()
        {
            var heroes = _heroService.GetAllHeroes();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public IActionResult GetHeroById(int id)
        {
            var hero = _heroService.GetHeroById(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult AddHero([FromBody] Hero hero)
        {
            _heroService.AddHero(hero);
            return CreatedAtAction(nameof(GetHeroById), new { id = hero.Id }, hero);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHero(int id, [FromBody] Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }
            _heroService.UpdateHero(hero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHero(int id)
        {
            _heroService.DeleteHero(id);
            return NoContent();
        }
    }

}
