using GeekShopping.Web.Interfaces;
using GeekShopping.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region HttpClient
builder.Services.AddHttpClient<IProductService, ProductService>(x =>
    x.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"]));

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
