using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using JnjStudyCompoundChecker.Constants;
using JnjStudyCompoundChecker.DbContext;
using JnjStudyCompoundChecker.Helper;
using JnjStudyCompoundChecker.Models.AppSettingsModels;
using JnjStudyCompoundChecker.Services.Implementations;
using JnjStudyCompoundChecker.Services.Interfaces;
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
            try
            {
                ConfigureServices();
                var studyCompoundCheckerService = ServiceProvider.GetService<IStudyCompoundCheckerService>();
                var result = studyCompoundCheckerService.Execute();
                SendMail(result.Item1, result.Item2);
                Log.CloseAndFlush();
            }
            catch (Exception e)
            {
                LogHelper.PrintLog($"Error caught in Program.cs. Details: {e}");
                SendMail(-1);
                Environment.Exit(-1);
            }
            Environment.Exit(0);
        }

        private static void SendMail(int mailFlag, IEnumerable<string> protocolNames = null)
        {
            var mailService = ServiceProvider.GetService<IMailService>();
            var mailBody = Enums.MailBody.None;

            switch (mailFlag)
            {
                case -1:
                    mailBody = Enums.MailBody.ProcessingFailedBody;
                    break;
                case 0:
                    mailBody = Enums.MailBody.FileNotFoundBody;
                    break;
                default:
                    mailBody = Enums.MailBody.CompoundMismatchBody;
                    break;
            }

            var message = mailService.CreateMailMessage(mailBody, protocolNames);
            var client = mailService.GetSmtpClient();
            client.Send(message);
        }

        private static void ConfigureServices()
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

            // Create service collection and add services
            var services = new ServiceCollection().AddOptions();
            services.Configure<MailSettings>(Configuration.GetSection(nameof(MailSettings)));
            services.Configure<LookupPathSettings>(Configuration.GetSection(nameof(LookupPathSettings)));

            services.AddDbContext<SafetyRepositoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SafetyRepositoryDbContext")));

            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IFileLookupService, FileLookupService>();
            services.AddScoped<IEntityModelLoaderService, EntityModelLoaderService>();
            services.AddScoped<IProtocolCompoundService, ProtocolCompoundService>();
            services.AddScoped<IStudyCompoundCheckerService, StudyCompoundCheckerService>();

            services.AddSingleton(Log.Logger);

            // Create service provider
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
