namespace PlaneSeatsCalculator.BL;

public class AppConfig
{
    public List<PlaneConfig>? PlaneConfigs { get; set; }
}

public class PlaneConfig
{
    public string? Name { get; set; }
    public int Capacity { get; set; }
    public GameType Game{ get; set; }
}

public enum GameType
{
    Mana4 = 1,
    Tyco = 2
}