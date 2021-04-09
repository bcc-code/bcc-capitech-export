using BCC.Capitech.Services;
using BCC.Capitech.Store;
using Capitech;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(BCC.Capitech.Functions.Startup))]
namespace BCC.Capitech.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            var config = new ConfigurationBuilder()
                .SetBasePath(builder.GetContext().ApplicationRootPath)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets("13255bd9-2956-4c9e-b4fb-71ecba5f7c46")
                .AddEnvironmentVariables()
                .Build();

            var capitechOptions = config.GetSection("Capitech").Get<CapitechOptions>();
            services.AddSingleton(capitechOptions);
            services.AddScoped<ICapitechDataService, CapitechDataService>();
            services.AddSingleton<CapitechClient>();
            services.AddScoped<DataImportService>();

            var connectionString = config.GetConnectionString("DbConnectionString");

            //services.AddDbContext<CapitechDataContext>(options => options.UseSqlServer(connectionString, opt => opt.MigrationsAssembly("BCC.Capitech.Store")));
            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddDbContext<CapitechDataContext>(options => options.UseSqlServer(connectionString));
            }
            else
            {
                services.AddDbContext<CapitechDataContext>(options => options.UseInMemoryDatabase("CapitechData"));
            }


        }

        private static string GetEnvironmentVariable(string name)
        {
            return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
