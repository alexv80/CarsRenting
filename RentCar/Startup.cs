using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentCar.Core.Abstraction;
using RentCar.Infrastructure.Repository;

namespace RentCar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<RentCarsDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:RentCars:ConnectionString"]));
            services.AddTransient<ICarRepository, CarRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "pagination",
                //    pattern: "Products/Page{carPage}",
                //    defaults: new { Controller = "Product", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Car}/{action=List}/{id?}");
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
