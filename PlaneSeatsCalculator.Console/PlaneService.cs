namespace PlaneSeatsCalculator.ConsoleApp;

public class PlaneService
{
    public static PlaneSeats CalcSeats(int capacity, PlaneSeats demands)
    {
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
    public static List<PlaneSeats> GetAllSeatConfigurations(int capacity)
    {
        List<PlaneSeats> configurations = new List<PlaneSeats>();

        for (int seatsF = 0; seatsF <= capacity / 3; seatsF++)
        {
            for (int seatsJ = 0; seatsJ <= (capacity - seatsF * 3)/2; seatsJ++)
            {
                int seatsY = capacity - seatsJ * 2 - seatsF * 3;
                configurations.Add(new PlaneSeats { SeatsY = seatsY, SeatsJ = seatsJ, SeatsF = seatsF });
            }
        }

        return configurations;
    }
}
