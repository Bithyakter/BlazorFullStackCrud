using BlazorFullStackCrud.Client.Pages;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.ComicService
{
   public class ComicService : IComicService
   {
      private readonly HttpClient _http;
      private readonly NavigationManager _navigationManager;

      public ComicService(HttpClient http, NavigationManager navigationManager)
      {
         _http = http;
         _navigationManager = navigationManager;
      }

      public List<Comic> Comics { get; set; } = new List<Comic>();

      //CREATE
      public async Task CreateComic(Comic comic)
      {
         var result = await _http.PostAsJsonAsync("api/comic", comic);
         await SetComics(result);
      }

      //UPDATE
      public async Task UpdateComic(Comic comic)
      {
         var result = await _http.PutAsJsonAsync($"api/comic/{comic.Id}", comic);
         await SetComics(result);
      }

      //DELETE
      public async Task DeleteComic(int id)
      {
         var result = await _http.DeleteAsync($"api/comic/{id}");
         await SetComics(result);
      }

      //GET SINGLE COMIC
      public async Task<Comic> GetSingleComic(int id)
      {
         var result = await _http.GetFromJsonAsync<Comic>($"api/comic/{id}");
         if (result != null)
            return result;
         throw new Exception("Comic not found!");
      }

      //GET ALL COMICS
      public async Task GetComics()
      {
         var result = await _http.GetFromJsonAsync<List<Comic>>("api/comic");
         if (result != null)
            Comics = result;
      }

      //SET COMIC
      private async Task SetComics(HttpResponseMessage result)
      {
         var response = await result.Content.ReadFromJsonAsync<List<Comic>>();
         Comics = response;
         _navigationManager.NavigateTo("comics");
      }
   }
}