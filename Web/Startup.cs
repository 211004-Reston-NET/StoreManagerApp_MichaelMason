using Business;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
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
            services.AddDbContext<StoreManagerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StoreManager")));
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<IInventoryBl, InventoryBl>();
            services.AddScoped<ILineItemBL, LineItemBL>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<ISOrderBL, SOrderBL>();
            services.AddScoped<IStorefrontBL, StorefrontBL>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStorefrontRepository, StorefrontRepository>();
            services.AddScoped<ISOrderRepository, SOrderRepository>();
            //services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IRepository<Inventory>, Repository<Inventory>>();
            services.AddScoped<IRepository<LineItem>, Repository<LineItem>>();
            //services.AddScoped<IRepository<Product>, Repository<Product>>();
            //services.AddScoped<IRepository<SOrder>, Repository<SOrder>>();
            //services.AddScoped<IRepository<Storefront>, Repository<Storefront>>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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