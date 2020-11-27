using Business.Shared.AddressValidationRules;
using Business.Shared.CarExample;
using Business.Shared.SiteCounterExample;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customer.Blazor.Server.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Add Singleton for SiteCounter
            services.AddSingleton<ISiteCounter, SiteCounter>();

            //Add CarDataAccess & CarRepository
            var CountryCode = Configuration["CountryCode"];
            services.AddTransient<ICarDataAccess>(c => new CarDataAccess(CountryCode));

            //Add CarDataAccess & CarRepository
            services.AddTransient<ICarRepository, CarRepository>();

            // Add Validators for Client Information
            services.AddTransient<ITaskValidation, NameValidation>();
            services.AddTransient<ITaskValidation, ZipCodeValidation>();
            services.AddTransient<ITaskValidation, AddressValidation>();
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
