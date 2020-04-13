using System;
using System.IO;
using System.Reflection;
using JnjStudyCompoundChecker.DbContext;
using JnjStudyCompoundChecker.Models.AppSettingsModels;
using JnjStudyCompoundChecker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace JnjStudyCompoundChecker
{
    class Program
    {
        public static IServiceProvider ServiceProvider;
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            #region Set startup path
            var appBasePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
            Console.WriteLine("App Path: " + appBasePath);

            Configuration = new ConfigurationBuilder()
                .SetBasePath(appBasePath)
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();
            #endregion

            // create service collection and add services
            var services = new ServiceCollection().AddOptions();
            services.Configure<FileLookupPath>(Configuration.GetSection(nameof(FileLookupPath)));
            services.Configure<MailSettings>(Configuration.GetSection(nameof(MailSettings)));

            services.AddDbContext<SafetyRepositoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SafetyRepositoryDbContext")));
            services.AddScoped<IMailService, MailService>();
            //services.AddScoped<ISftpService, SftpService>();
            //services.AddScoped<IMappingService, MappingService>();
            services.AddScoped<IProtocolCompoundService, ProtocolCompoundService>();
            
            services.AddSingleton(Log.Logger);

            // create service provider
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
