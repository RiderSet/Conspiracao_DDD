using AutoMapper;
using Domain.Interfaces.Repositories;
using GBastos.Conspiracao.AutoMapper;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using GBastos.Conspiracao.Data;

namespace GBastos.Conspiracao
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CTX>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Conn")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<CTX>();
            //services.AddRazorPages();

            services.AddControllersWithViews();
            //services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<CTX>();
            services.AddScoped<IProdutoRep, ProdutoRep>();
            services.AddScoped<IClienteRep, ClienteRep>();

            services.AddDbContext<Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Context")));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
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
