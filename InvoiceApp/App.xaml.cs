﻿using InvoiceApp.Domain;
using InvoiceApp.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;
using System.Windows;
using InvoiceApp.StartUpHelpers;
using InvoiceApp.Service.Services.Interfaces;
using InvoiceApp.Service.Services;
using InvoiceApp.Domain.DataAccess.Interfaces;
using InvoiceApp.Domain.DataAccess;

namespace InvoiceApp
{

    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<Dashboard>();
                    services.AddAbstractFactory<IAuthenticationService, AuthenticationService>();
                    services.AddAbstractFactory<IUserLayer, UserLayer>();

                    services.AddDbContext<UserContext>(
                    options =>
                    {
                        options.UseSqlite("Data Source=main.db");
                        options.UseLazyLoadingProxies();
                    });
                }
                )
                .Build();

            using var scope = AppHost.Services.CreateScope();
            using (var dbContext = scope.ServiceProvider.GetRequiredService<UserContext>())
            {
                dbContext.Database.Migrate();

                Task.Run(async () => await PopulateMasterCreds(dbContext)).Wait();
            }
        }

        private static async Task PopulateMasterCreds(UserContext userContext)
        {
            if (await userContext.Users.AnyAsync())
            {
                return;
            }
            using (SHA256 mySHA256 = SHA256.Create())
            {
                userContext.Users.Add(
                new Domain.Entity.UserEntity()
                {
                    FirstName = "master",
                    Email = "vimal802.11@gmail.com",
                    Password = CommonHelper.GetHash(mySHA256, "thick-thighs"),
                    UserName="master",
                    UserTypeFK=Domain.Enums.EUser.Master,
                    CreatedDate = DateTime.UtcNow
                }
                );
            }


            userContext.SaveChanges();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
            startUpForm.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }

}
