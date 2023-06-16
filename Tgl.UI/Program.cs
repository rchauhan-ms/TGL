using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tgl.UI;
using Tgl.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IShipmentDataService, ShipmentDataService>(client => client.BaseAddress = new Uri("https://localhost:7192/"));
builder.Services.AddHttpClient<IUserFilterDataService, UserFilterDataService>(client => client.BaseAddress = new Uri("https://localhost:7192/"));

await builder.Build().RunAsync();
