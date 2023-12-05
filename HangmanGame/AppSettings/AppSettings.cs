using CSharpConsoleHangmanGame.AppSettings.Model;
using CSharpConsoleHangmanGame.AppSettings.Model.Sections;
using Microsoft.Extensions.Configuration;
using Optional;
using System.ComponentModel.DataAnnotations;

namespace CSharpConsoleHangmanGame.AppSettings
{
    internal class AppSettings
    {
        public Option<GameConfigsModel> GameConfigsOpt { get; }

        internal AppSettings(string appSettingsFilePath)
        {
            try
            {
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }

                var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(
                                appSettingsFilePath,
                                optional: false,
                                reloadOnChange: true);

                IConfiguration config = builder.Build();

                var appSettingsModel = config.Get<AppSettingsModel>();
                var context = new ValidationContext(appSettingsModel);
                var results = new List<ValidationResult>();

                if (Validator.TryValidateObject(appSettingsModel, context, results, true) == false)
                {
                    // Handle validation failure
                    var errors = results.Select(x => x.ErrorMessage).Aggregate((i, j) => i + ", " + j);
                    Console.WriteLine($"Error: Configuration is invalid: {errors}");
                    return;
                }
                if (appSettingsModel == null || results.Any())
                {
                    // Handle the case where appSettingsModel is null
                    // Or if results.Any() is true, it means there are validation errors
                    Console.WriteLine($"Error: App settings configuration is missing or incorrect.");
                    return;
                }

                GameConfigsOpt = Option.Some(appSettingsModel.GameConfigs);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: App settings configuration is missing or incorrect: {e.Message}");
            }
        }
    }
}
