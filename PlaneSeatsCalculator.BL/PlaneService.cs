namespace PlaneSeatsCalculator.BL;

public class PlaneService
{
    private static float CoeffJ { get; set; }
    private static float CoeffF { get; set; }

    public static PlaneSeats CalcSeats(int capacity, PlaneSeats demands, GameType game)
    {
        CoeffJ = game == GameType.Mana4 ? 2 : 1.8f;
        CoeffF = game == GameType.Mana4 ? 3 : 4.2f;
        var res = new PlaneSeats();
        var possibleConfigurations = GetAllSeatConfigurations(capacity);
        float discrepancy = float.MaxValue;

        foreach (var configuration in possibleConfigurations)
        {
            float currentDiscrepancy = 0;
            // Calculate the proportional difference for each demand type
            currentDiscrepancy = currentDiscrepancy + Math.Abs(demands.RatioY - configuration.RatioY);
            currentDiscrepancy = currentDiscrepancy + Math.Abs(demands.RatioJ - configuration.RatioJ);
            currentDiscrepancy = currentDiscrepancy + Math.Abs(demands.RatioF - configuration.RatioF);

            // Check if this configuration has a smaller proportional difference
            if (currentDiscrepancy < discrepancy)
            {
                discrepancy = currentDiscrepancy;
                res = configuration;
            }
        }

        return res;
    }

    private static List<PlaneSeats> GetAllSeatConfigurations(int capacity)
    {
        List<PlaneSeats> configurations = new List<PlaneSeats>();

        for (int seatsF = 0; seatsF <= capacity / CoeffF; seatsF++)
        {
            for (int seatsJ = 0; seatsJ <= (capacity - seatsF * 3)/ CoeffJ; seatsJ++)
            {
                int seatsY = (int)(capacity - seatsJ * CoeffJ - seatsF * CoeffF);
                configurations.Add(new PlaneSeats { SeatsY = seatsY, SeatsJ = seatsJ, SeatsF = seatsF });
            }
        }

        return configurations;
    }
}
