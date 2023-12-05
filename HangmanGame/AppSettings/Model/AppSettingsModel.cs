using System.ComponentModel.DataAnnotations;
using CSharpConsoleHangmanGame.AppSettings.Model.Sections;

namespace CSharpConsoleHangmanGame.AppSettings.Model
{
    internal class AppSettingsModel
    {
        [Required]
        public GameConfigsModel GameConfigs { get; set; }
    }
}
