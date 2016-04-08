using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Inbetween.Models;

namespace Inbetween
{
    public class Startup
    {
        // This is a test Kostas!
        // This is another test Mikael!
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var connString = @"Data Source=kickass.database.windows.net;Initial Catalog=KickAssDataBase;Integrated Security=False;User ID=kickass;Password=P@ssword;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connString = @"Server=tcp:kickass.database.windows.net,1433;Database=MikaelsDB;User ID=kickass@kickass;Password=P@ssword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<KickAssDataBaseContext>(o =>
                o.UseSqlServer(connString));

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IdentityDbContext>(o => o.UseSqlServer(connString));

            services.AddMvc();
            services.AddCaching();
            services.AddSession();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<INewsRepository, DBNewsRepository>();
            services.AddTransient<IAlbumsRepository, DBAlbumsRepository>();
            services.AddTransient<IIndexRepository, IndexRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseIdentity().UseCookieAuthentication(o =>
            {
                o.AutomaticChallenge = true;
                o.LoginPath = new PathString("/Admin/Login");
                //o.LogoutPath = new PathString("/Home/Index");
            }); ;
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
