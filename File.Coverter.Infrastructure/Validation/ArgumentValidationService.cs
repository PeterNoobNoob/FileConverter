using System;
using System.Globalization;
using FileConverter.Infrastructure.Interfaces;
using FileConverter.Infrastructure.Interfaces.Validation;

namespace File.Coverter.Infrastructure.Validation
{
    public class ArgumentValidationService : IArgumentValidationService
    {
        public bool Validate(string[] arguments)
        {
            if (arguments.Length < 5)
            {
                PrintUsageInstructions();
                return false;
            }

            if (string.Compare(arguments[0], "help", true, CultureInfo.CurrentCulture) == 0)
            {
                PrintUsageInstructions();
                return false;
            }

            if (string.Compare(arguments[0], "cloud", true, CultureInfo.CurrentCulture) != 0 &&
                string.Compare(arguments[0], "filesystem", true, CultureInfo.CurrentCulture) != 0)
            {
                PrintUsageInstructions();
                return false;
            }

            if (string.Compare(arguments[2], "xml", true, CultureInfo.CurrentCulture) != 0 &&
                string.Compare(arguments[2], "json", true, CultureInfo.CurrentCulture) != 0)
            {
                PrintAvailableSourceTypes();
                return false;
            }

            if (string.Compare(arguments[4], "xml", true, CultureInfo.CurrentCulture) != 0 &&
                string.Compare(arguments[4], "json", true, CultureInfo.CurrentCulture) != 0 &&
                string.Compare(arguments[4], "jsoncamelcase", true, CultureInfo.CurrentCulture) != 0)
            {
                PrintAvailableTargetTypes();
                return false;
            }

            return true;
        }

        private void PrintUsageInstructions()
        {
            Console.WriteLine("FileConverter usage:");
            Console.WriteLine("FileConverter cloud <source_url> <source_type> <target_file_path> <target_type>");
            Console.WriteLine("FileConverter filesystem <source_file_path> <source_type> <target_file_path> <target_type>");
        }

        private void PrintAvailableSourceTypes()
        {
            Console.WriteLine("Unsupported source type. Available source types:");
            Console.WriteLine("XML");
            Console.WriteLine("JSON");
        }

        private void PrintAvailableTargetTypes()
        {
            Console.WriteLine("Unsupported target type. Available target types:");
            Console.WriteLine("XML");
            Console.WriteLine("JSON");
            Console.WriteLine("JSONCamelCase");
        }
    }
}
