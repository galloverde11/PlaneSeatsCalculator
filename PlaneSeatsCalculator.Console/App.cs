using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.CommandLine;

namespace PlaneSeatsCalculator.ConsoleApp
{
    public class App : RootCommand
    {
        private readonly ILogger<App> _logger;
        private readonly AppConfig _appConfig;

        public App(IOptions<AppConfig> appConfig, ILogger<App> logger) :
            base("Calculate your seats.")
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appConfig = appConfig?.Value ?? throw new ArgumentNullException(nameof(appConfig));

            var namePlane = new Argument<string>("name", "The name of the plane to use between A380, MAX10 and 900ER.");
            var demandY = new Argument<int>("demandY", "The demand for class Y.");
            var demandJ = new Argument<int>("demandJ", "The demand for class J.");
            var demandF = new Argument<int>("demandF", "The demand for class F.");
            AddArgument(namePlane);
            AddArgument(demandY);
            AddArgument(demandJ);
            AddArgument(demandF);
            
            this.SetHandler(Execute, namePlane, demandY, demandJ, demandF);
            this.SetHandler(Execute, namePlane, demandY, demandJ, demandF);
            this.SetHandler(Execute, namePlane, demandY, demandJ, demandF);
            this.SetHandler(Execute, namePlane, demandY, demandJ, demandF);
        }

        private async Task Execute(string namePlane, int demandY, int demandJ, int demandF)
        {
            _logger.LogInformation("Starting...");
            var capacity = _appConfig.PlaneConfigs.FirstOrDefault(pc=>pc.Name == namePlane).Capacity;
            var demands = new PlaneSeats { SeatsY = demandY, SeatsJ = demandJ, SeatsF = demandF };
            var planeSeats = PlaneService.CalcSeats(capacity, demands);

            Console.WriteLine(planeSeats);

            _logger.LogInformation("Finished!");

            await Task.CompletedTask;
        }
    }
}
