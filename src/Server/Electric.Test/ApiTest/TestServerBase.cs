using Electric.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Electric.Test.ApiTest
{
    public class TestServerBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(TestServerBase))
             .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                }).UseStartup<Startup>();

            return new TestServer(hostBuilder);
        }

        public static class Get
        {
            public static string apiUrl = "api/v1/device";

            public static string DeviceBy(string id)
            {
                return $"{apiUrl}/{id}";
            }
        }

        public static class Post
        {
            public static string apiUrl = "api/v1/device";
        }
    }
}
