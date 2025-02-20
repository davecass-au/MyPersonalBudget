using Application;
using Application.Services;
using Application.Services.Data.Interfaces;
using Application.Services.Data.Repository;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//7272

builder.Services.AddHttpClient<IDataServicesRepo, DataServicesRepo>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7272");
});

builder.Services.AddScoped<IBudgetService, BudgetService>();   

await builder.Build().RunAsync();
