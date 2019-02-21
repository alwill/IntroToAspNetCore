using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToAspNetCore_Cooked.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IntroToAspNetCore_Cooked
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
            services.AddScoped<ICalculatorService, CalculatorService>();
            services.AddScoped<LifeStyleService>();
            services.AddScoped<Scoped>();
            services.AddSingleton<Singelton>();
            services.AddTransient<Transient>();
            services.AddSwaggerDocument();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUi3();

            app.Use(async (context, next) =>
            {
                Console.WriteLine(context.Request.Path);
                await next.Invoke();
                Console.WriteLine(context.Response.StatusCode);
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
