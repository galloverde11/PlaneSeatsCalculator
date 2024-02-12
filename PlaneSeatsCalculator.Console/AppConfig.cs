namespace PlaneSeatsCalculator.ConsoleApp;

public class AppConfig
{
    public List<PlaneConfig> PlaneConfigs { get; set; }
}

public class PlaneConfig
{
    public string Name { get; set; }
    public int Capacity { get; set; }
}