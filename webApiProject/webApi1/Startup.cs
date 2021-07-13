using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lesson1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace webApi1
{
    public class Startup
    {
        ILogger<Startup> _logger;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
      
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

           // services.AddScoped<IUserDL, UserDL>();
  
            services.AddAutoMapper(typeof(Startup));



            services.AddControllers();

            //services.AddDbContext<TakeAwayContext>(options => options.UseSqlServer(
            //    Configuration.GetSection("ConnectionStrings:TakeAway").Value), ServiceLifetime.Scoped);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            
         
            _logger = logger;
            _logger.LogInformation("האפלקציה עולה");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

           app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });

            app.Map("/api", app2 =>
            {
                app2.UseRouting();
                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });

        }
    }
}
