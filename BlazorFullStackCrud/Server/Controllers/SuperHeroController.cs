using BlazorFullStackCrud.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class SuperHeroController : ControllerBase
   {
      public static List<Comic> comics = new List<Comic> {
        new Comic {Id = 1, Name = "Marvel"},
        new Comic {Id = 2, Name = "DC"},
      };

      public static List<SuperHero> heroes = new List<SuperHero>
      {
          new SuperHero {
            Id = 1,
            FirstName = "Bithy",
            LastName = "Akter",
            HeroName = "Queen",
            Comic = comics[0],
            ComicId = 1
         },
           new SuperHero {
            Id = 2,
            FirstName = "Shammi",
            LastName = "Ahmed",
            HeroName = "Spiderman",
            Comic = comics[1],
            ComicId = 2
         },
      };

      [HttpGet]
      public async Task<ActionResult<List<SuperHero>>> GetSuperHeros(int id)
      {
         return Ok(heroes);
      }

      [HttpGet("comics")]
      public async Task<ActionResult<List<Comic>>> GetComics(int id)
      {
         return Ok(comics);
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
      {
         var hero = heroes.FirstOrDefault(h => h.Id == id);
         if(hero == null)
         {
            return NotFound("Sorry, no hero here. :/");
         }
         return Ok(hero);
      }
   }
}