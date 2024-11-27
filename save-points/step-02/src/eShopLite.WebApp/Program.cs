using eShopLite.WebApp.ApiClients;
using eShopLite.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

builder.Services.AddHttpClient<ProductApiClient>(client =>
{
    // client.BaseAddress = new("http://localhost:5051");
    client.BaseAddress = new("http://productapi:8080");
});

builder.Services.AddHttpClient<WeatherApiClient>(client =>
{
    // client.BaseAddress = new("http://localhost:5050");
    client.BaseAddress = new("http://weatherapi:8080");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();