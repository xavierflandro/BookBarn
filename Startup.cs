using BookBarn.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBarn
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public object SessionCart { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookDBContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookBarnConnection"]);
           });

            services.AddScoped<IBooksRepository, EFBooksRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Cart>(Span => Models.SessionCart.GetCart(Span));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            //  Sets up session 
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage",                //  endpoint for when category and page provided
                    "{category}/{page:int}",
                    new { Controller = "Home", Action = "Index" });

                endpoints.MapControllerRoute("page",                        //  endpoint for when page provided
                    "{page:int}",
                    new { Controller = "Home", Action = "Index" });

                endpoints.MapControllerRoute("category",                    //  endpoint for when category provided
                    "{category}",
                    new { Controller = "Home", Action = "Index", page = 1 });

                endpoints.MapControllerRoute("pagination",                  //  endpoint for when page provided after /Books/
                    "Books/P{page}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();                                  //  lets routes be named after razor pages
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
