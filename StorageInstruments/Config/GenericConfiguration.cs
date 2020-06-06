using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;


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
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddMvc();
            services.AddRazorPages();

            #region react
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            // Make sure a JS engine is registered, or you will get an error!
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
              .AddV8();
            #endregion
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

            #region react
            
            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config =>
            {
               
            });
            app.UseStaticFiles();
            #endregion

            return app;
        }
    }
}
