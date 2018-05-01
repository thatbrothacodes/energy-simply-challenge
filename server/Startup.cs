using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using server.data;
using server.data.models;
using server.data.repositories;
using server.services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace server
{
    public class Startup
    {
        String connection = @"Server=challenge-energy-simply-db-container;Database=CRM;User=sa;Password=P@ssw0rd;";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<CRMContext>(opt => opt.UseSqlServer(connection));
            services.AddTransient<ICustomerRepository, CustomerRepository>((ctx) => {
                CRMContext svc = ctx.GetService<CRMContext>();
                return new CustomerRepository(svc);
            });
            services.AddTransient<IPlanRepository, PlanRepository>((ctx) => {
                CRMContext svc = ctx.GetService<CRMContext>();
                return new PlanRepository(svc);
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>((ctx) => {
                CRMContext svc = ctx.GetService<CRMContext>();
                return new UnitOfWork(svc);
            });
            services.AddTransient<ICustomerService, CustomerService>((ctx) => {
                IUnitOfWork svc = ctx.GetService<IUnitOfWork>();
                return new CustomerService(svc);
            });
            services.AddTransient<IPlanService, PlanService>((ctx) => {
                IUnitOfWork svc = ctx.GetService<IUnitOfWork>();
                return new PlanService(svc);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Customers}/{action=Index}/{id?}");
            });

            if(env.IsProduction()) {
                connection = @"Server=localhost;Database=CRM;User=sa;Password=P@ssw0rd;";
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
        }
    }
}
