using LongestIncreasingSubsequenceApp.Services.Interfaces;
using LongestIncreasingSubsequenceApp.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
internal class Program
{
    static void Main(string[] args)
    {

        // Setup Dependancy Injection
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IIncreasingSubsequenceService, IncreasingSubsequenceService>()
            .BuildServiceProvider();

        // Setup Logging
        var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
        
        // Check we actually have parameters
        if (args.Length == 0)
        {
            logger.LogCritical("No arguments passed to the application.");
            return;
        }

        // Try and pass the string array to an int array.
        var sequence = string.Join(" ", args).Split(' ').Select(int.Parse).ToArray();

        // Only proceed if we actually have a sequence, otherwise just log a error
        if (sequence.Length > 0)
        {
            var service = serviceProvider.GetService<IIncreasingSubsequenceService>();
            var result = service?.GetIncreasingSubsequence(sequence);
            Console.WriteLine(result);
        }
        else
        {
            logger.LogCritical("Unable to pass inputs to int(s)");
        }
    }
}
    