using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.StartUpHelpers
{
    public static class ServiceExtensions
    {
        public static void AddFormFactory<TForm>(this IServiceCollection services)
            where TForm : class
        {
            services.AddTransient<TForm>();
            services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
            services.AddSingleton<IAbstractFactory<TForm>, AbstractFactory<TForm>>();
        }
        public static void AddAbstractFactory<TInterface, Timplementation>(this IServiceCollection services)
            where TInterface : class
                                where Timplementation : class, TInterface
        {
            services.AddTransient<TInterface, Timplementation>();
            services.AddSingleton<Func<TInterface>>(x => () => x.GetService<TInterface>()!);
            services.AddSingleton<IAbstractFactory<TInterface>, AbstractFactory<TInterface>>();
        }

    }
}
