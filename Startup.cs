using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorPrueba.Entities;
using Microsoft.EntityFrameworkCore;
using BlazorPrueba.Data;
using Syncfusion.Blazor;

namespace BlazorPrueba
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            using (var Cliente = new SQlitedbContext())
            {
                try
                {
                    if (Cliente.Database.EnsureCreated())
                        Cliente.Database.Migrate();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddEntityFrameworkSqlite().AddDbContext<SQlitedbContext>();
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IAccidenteService, AccidenteService>();
            services.AddSyncfusionBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzI4OTI0QDMxMzgyZTMzMmUzMFZtcjlTdDIwT09OTDNoQWs0d3gvdWpiR3owanFHeXdDV3VQb09tYlhGTlU9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
