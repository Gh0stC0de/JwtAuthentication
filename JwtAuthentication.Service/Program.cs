using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace JwtAuthentication.Service
{
    /// <summary>
    ///     Represents the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Main function of the program.
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        ///     Creates a host builder.
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Host builder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}