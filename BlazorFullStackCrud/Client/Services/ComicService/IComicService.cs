namespace BlazorFullStackCrud.Client.Services.ComicService
{
   public interface IComicService
   {
      List<Comic> Comics { get; set; }

      Task GetComics();

      Task<Comic> GetSingleComic(int id);

      Task CreateComic(Comic comic);

      Task UpdateComic(Comic comic);

      Task DeleteComic(int id);
   }
}