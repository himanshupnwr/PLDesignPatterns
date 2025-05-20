using DecoratorPatternExample.Decorators;
using DecoratorPatternExample.OpenWeatherMap;
using DecoratorPatternExample.WeatherInterface;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace DecoratorPatternExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMemoryCache();

            builder.Services.AddScoped<IWeatherService>(serviceProvider =>
            {
                String apiKey = builder.Configuration.GetValue<String>("AppSettings:OpenWeatherMapApiKey");
                var logger = serviceProvider.GetService<ILogger<WeatherServiceLoggingDecorator>>();
                var memoryCache = serviceProvider.GetService<IMemoryCache>();

                IWeatherService concreteService = new WeatherService(apiKey);
                IWeatherService withLoggingDecorator = new WeatherServiceLoggingDecorator(concreteService, logger);
                IWeatherService withCachingDecorator = new WeatherServiceCachingDecorator(withLoggingDecorator, memoryCache);
                return withCachingDecorator;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
