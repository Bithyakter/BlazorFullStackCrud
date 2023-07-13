global using BlazorFullStackCrud.Client.Services.SuperHeroService;
global using BlazorFullStackCrud.Client.Services.ComicService;
global using  BlazorFullStackCrud.Shared;
using BlazorFullStackCrud.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<IComicService, ComicService>();

await builder.Build().RunAsync();
