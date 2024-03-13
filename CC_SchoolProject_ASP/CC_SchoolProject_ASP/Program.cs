using log4net;
using CC_SchoolProject_ASP.Services;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace CC_SchoolProject_ASP;

public class Program
{
    private static readonly ILog logger = LogManager.GetLogger("Program.main method");
    public static void Main(string[] args)
    {
        logger.Info("ASP.NET MVC App has started.");
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientApp"));
        string clientBaseUrl = builder.Configuration.GetSection("ClientApp:ClientBaseUrl").Value;

        builder.Services.AddHttpClient();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {

            endpoints.MapAreaControllerRoute(
                       name: "UserAccessArea",
                       areaName: "UserAccess",
                       pattern: "UserAccess/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapAreaControllerRoute(
                       name: "AdminArea",
                       areaName: "Admin",
                       pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapAreaControllerRoute(
                      name: "PrincipalArea",
                      areaName: "Principal",
                      pattern: "Principal/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapAreaControllerRoute(
                      name: "TeachersArea",
                      areaName: "Teachers",
                      pattern: "Teachers/{controller=Home}/{action=Index}/{id?}");


        });


        app.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}



