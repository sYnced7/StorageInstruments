﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageInstruments.Config
{
    public class GenericConfiguration
    {
        readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static IServiceCollection Config(IServiceCollection services, IConfiguration Configuration)
        {
            services = ConfigGeneric(services);
            services = ContextConfiguration.ConfigContext(services, Configuration);
            services = ContainerConfiguration.ConfigContext(services);
            services = SwaggerConfiguration.ConfigSwagger(services);
            return services;
        }

        public static IServiceCollection ConfigGeneric(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost");
                                  });
            });

            services.AddControllers();
            services.AddMvc();
            services.AddRazorPages();

            return services;
        }

        public static IApplicationBuilder AppBuilderConfiguration(IApplicationBuilder app, bool env)
        {
            if (env)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            

            return app;
        }
    }
}
