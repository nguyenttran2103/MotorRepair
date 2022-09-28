using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MotorRepair.Client;
using MotorRepair.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7160/") });
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IWorkItemService, WorkItemService>();

await builder.Build().RunAsync();
