using GuessWeight.Web;
using GuessWeight.Web.Services;
using GuessWeight.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var baseURL = "https://localhost:7172";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseURL) });
builder.Services.AddScoped<IAuthServices,AuthServices>();
builder.Services.AddScoped<ISalaServices,SalaServices>();

await builder.Build().RunAsync();
