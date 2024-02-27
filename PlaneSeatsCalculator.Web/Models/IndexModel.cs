namespace PlaneSeatsCalculator.Web.Models
{
    public class RequestModel
    {
        public string? PlaneName{ get; set; }
        public int? PlaneCapacity { get; set; }

        public int? DemandY { get; set; }
        public int? DemandJ { get; set; }
        public int? DemandF { get; set; }

        public int? SeatsY { get; set; }
        public int? SeatsJ { get; set; }
        public int? SeatsF { get; set; }
    }
}
