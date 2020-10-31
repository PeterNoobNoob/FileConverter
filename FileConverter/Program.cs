using Microsoft.Extensions.DependencyInjection;
using System;
using File.Coverter.Infrastructure.Validation;
using FileConverter.Infrastructure.Interfaces.Converter;
using FileConverter.Infrastructure.Interfaces.Validation;
using FileConverter.Mappers;

namespace FileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = InitializeDependencyInjector();
            var validator = container.GetService<IArgumentValidationService>();
            if (validator.Validate(args))
            {
                var converter = container.GetService<IConverterService>();
                try
                {
                    converter.ConvertFile(args.ToModel());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static ServiceProvider InitializeDependencyInjector()
        {
            var serviceProvider = new ServiceCollection();
            //Registering service here
            serviceProvider.AddSingleton<IArgumentValidationService, ArgumentValidationService>();
            return serviceProvider.BuildServiceProvider();
        }
    }
}
