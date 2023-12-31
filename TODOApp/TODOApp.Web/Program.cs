using Microsoft.EntityFrameworkCore;
using TODOApp.Data;
using TODOApp.Data.Repositories.Implementations;
using TODOApp.Data.Repositories.Interfaces;

namespace TODOApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //App settings
            builder.Services.AddOptions();
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Add database context
            builder.Services.AddDbContext<TODOAppDbContext>(db => db.UseSqlServer(appSettings.ConnectionStrings.TODOAppDbConnection));

            //DI registry
            builder.Services.AddScoped<IWorkItemRepository, WorkItemRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}