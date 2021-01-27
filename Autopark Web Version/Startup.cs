using Autopark_Web_Version.Models;
using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models.Models;
using Autopark_Web_Version.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version
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
            string connectionString = Configuration.GetConnectionString("Default");
            services.AddScoped<IVenicleRepository<Venicles>, VenicleRepository>(provider => new VenicleRepository(connectionString));
            services.AddScoped<IVenicleTypeRepository<VenicleType>, VenicleTypeRepository>(provider => new VenicleTypeRepository(connectionString));
            services.AddScoped<IDetailsRepository<Details>, DetailsRepository>(provider => new DetailsRepository(connectionString));
            services.AddScoped<IOrdersRepository<Orders>, OrdersRepository>(provider => new OrdersRepository(connectionString));
            services.AddScoped<IOrderDetailsRepository<OrderDetails>, OrderDetailsRepository>(provider => new OrderDetailsRepository(connectionString));
            services.AddScoped<IVOrdersRepository<VOrders>, VOrdersRepository>(provider => new VOrdersRepository(connectionString));
            services.AddScoped<IVVeniclesRepository<VVEnicles>, VVeniclesRepository>(provider => new VVeniclesRepository(connectionString));
            services.AddScoped<IVOrderDetailsRepository<VOrderDetails>, VOrderDetailsRepository>(provider => new VOrderDetailsRepository(connectionString));
            services.AddControllersWithViews();  
            
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
