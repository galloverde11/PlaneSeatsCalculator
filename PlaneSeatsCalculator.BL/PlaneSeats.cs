namespace PlaneSeatsCalculator.BL;

public class PlaneSeats
{
    public int SeatsY { get; set; }
    public int SeatsJ { get; set; }
    public int SeatsF { get; set; }
    public float RatioY
    {
        get
        {
            return (float)SeatsY / (float)new[] { SeatsY, SeatsJ, SeatsF }.Where(x => x != 0).Min();
        }
    }
    public float RatioJ
    {
        get
        {
            return (float)SeatsJ / (float)new[] { SeatsY, SeatsJ, SeatsF }.Where(x => x != 0).Min();
        }
    }
    public float RatioF
    {
        get
        {
            return (float)SeatsF / (float)new[] { SeatsY, SeatsJ, SeatsF }.Where(x => x != 0).Min();
        }
    }
    public override string ToString()
    {
        return SeatsY + " " + SeatsJ + " " + SeatsF;
    }
}
