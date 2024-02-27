namespace PlaneSeatsCalculator.BL;

public class Plane : PlaneSeats
{
    public int DemandY { get; set; }
    public int DemandJ { get; set; }
    public int DemandF { get; set; }

    public float RatioOnDemandY
    {
        get
        {
            return (float)SeatsY / (float)DemandY;
        }
    }
    public float RatioOnDemandJ
    {
        get
        {
            return (float)SeatsJ / (float)DemandJ;
        }
    }
    public float RatioOnDemandF
    {
        get
        {
            return (float)SeatsF / (float)DemandF;
        }
    }
}
