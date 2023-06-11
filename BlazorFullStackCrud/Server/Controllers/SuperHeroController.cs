using BlazorFullStackCrud.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class SuperHeroController : ControllerBase
   {
      private readonly DataContext _context;

      public SuperHeroController(DataContext context)
      {
         _context = context;
      }

      [HttpGet]
      public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
      {
         var heroes = await _context.superHeroes.ToArrayAsync();
         return Ok(heroes);
      }

      [HttpGet("comics")]
      public async Task<ActionResult<List<Comic>>> GetComics()
      {
         var comics = await _context.comics.ToArrayAsync();
         return Ok(comics);
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
      {
         var hero = await _context.superHeroes
            .Include(h => h.Comic)
            .FirstOrDefaultAsync(h => h.Id == id);

         if (hero == null)
         {
            return NotFound("Sorry, no hero here. :/");
         }
         return Ok(hero);
      }

      [HttpPost]
      public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
      {
         hero.Comic = null;

         _context.superHeroes.Add(hero);
         await _context.SaveChangesAsync();

         return Ok(await GetDbHeroes());
      }

      [HttpPost]
      public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero, int id)
      {
         var dbHero = await _context.superHeroes
            .Include(h => h.Comic)
            .FirstOrDefaultAsync(h => h.Id == id);

         if (dbHero == null)
            return NotFound("Sorry, but no hero for you. :/");

         dbHero.FirstName = hero.FirstName;
         dbHero.LastName = hero.LastName;
         dbHero.HeroName = hero.HeroName;
         dbHero.ComicId = hero.ComicId;

         await _context.SaveChangesAsync();

         return Ok(await GetDbHeroes());
      }

      [HttpPost]
      public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
      {
         var dbHero = await _context.superHeroes
            .Include(h => h.Comic)
            .FirstOrDefaultAsync(h => h.Id == id);

         if (dbHero == null)
            return NotFound("Sorry, but no hero for you. :/");

         _context.superHeroes.Remove(dbHero);
         await _context.SaveChangesAsync();

         return Ok(await GetDbHeroes());
      }

      private async Task<List<SuperHero>> GetDbHeroes()
      {
         return await _context.superHeroes.Include(h => h.Comic).ToListAsync();
      }
   }
}