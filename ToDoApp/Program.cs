using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;


var builder = WebApplication.CreateBuilder(args);
{
    string connection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
    builder.Services.AddTransient<IToDoRepository, EFToDoRepository>();
    builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
    builder.Services.AddMvc();
}

var app = builder.Build();
{
    app.UseStatusCodePages();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: null,
            template: "{category}/Page{productPage:int}",
            defaults: new { controller = "Home", action = "Index" });

        routes.MapRoute(
            name: null,
            template: "Page{productPage:int}",
            defaults: new { controller = "Home", action = "Index", productPage = 1 });

        routes.MapRoute(
            name: null,
            template: "{category}",
            defaults: new { controller = "Home", action = "Index", productPage = 1 });

        routes.MapRoute(
            name: null,
            template: "",
            defaults: new { controller = "Home", action = "Index", productPage = 1 });

        routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
    });
}

app.Run();
