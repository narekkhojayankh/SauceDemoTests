using Microsoft.Extensions.Configuration;

namespace SauceDemoTests.UI.Config
{
    public static class TestSettings
    {
        private static readonly IConfiguration _config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        public static string BaseUrl => _config["BaseUrl"]
            ?? throw new InvalidOperationException("BaseUrl is not set in appsettings.json");
    }
}