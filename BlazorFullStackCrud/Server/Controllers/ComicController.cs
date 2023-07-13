using BlazorFullStackCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ComicController : ControllerBase
   {
      private readonly DataContext _context;

      public ComicController(DataContext context)
      {
         _context = context;
      }

      [HttpGet]
      public async Task<ActionResult<List<Comic>>> GetComics()
      {
         var comics = await _context.Comics.ToListAsync();
         return Ok(comics);
      }

      public async Task<ActionResult<Comic>> GetComic(int id)
      {
         var comic = await _context.Comics.FirstOrDefaultAsync(c => c.Id == id);

         if(comic == null) { 
            return NotFound("Sorry, no comic here. :/");
         }

         return Ok(comic);
      }

      [HttpPost]
      public async Task<ActionResult<List<Comic>>> CreateComic(Comic comic)
      {
         _context.Comics.Add(comic);
         await _context.SaveChangesAsync();

         return Ok(await GetDbComics());
      }

      [HttpPut("{id}")]
      public async Task<ActionResult<List<Comic>>> UpdateComic(Comic comic, int id)
      {
         var comics = await _context.Comics
             .FirstOrDefaultAsync(sh => sh.Id == id);
         if (comics == null)
            return NotFound("Sorry, but no comic for you. :/");

         comics.Name = comic.Name;

         await _context.SaveChangesAsync();

         return Ok(await GetDbComics());
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult<List<Comic>>> DeleteComic(int id)
      {
         var comics = await _context.Comics
             .FirstOrDefaultAsync(sh => sh.Id == id);
         if (comics == null)
            return NotFound("Sorry, but no comic for you. :/");

         _context.Comics.Remove(comics);
         await _context.SaveChangesAsync();

         return Ok(await GetDbComics());
      }

      private async Task<List<Comic>> GetDbComics()
      {
         return await _context.Comics.ToListAsync();
      }
   }
}