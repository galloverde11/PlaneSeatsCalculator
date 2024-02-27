using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using PlaneSeatsCalculator.BL;
using PlaneSeatsCalculator.Web.Models;

namespace PlaneSeatsCalculator.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppConfig _appConfig;
        public List<SelectListItem>? PlaneNames { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IOptions<AppConfig> appConfig)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
        }

        public IActionResult OnGet()
        {
            return LoadPage();
        }

        [BindProperty]
        public RequestModel RequestModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return LoadPage();
            }

            var plane = _appConfig.PlaneConfigs!.FirstOrDefault(pc => pc.Name == RequestModel.PlaneName)!;
            int capacity = RequestModel.PlaneCapacity.HasValue ? RequestModel.PlaneCapacity!.Value : plane.Capacity;
            var demands = new PlaneSeats { SeatsY = RequestModel.DemandY!.Value, SeatsJ = RequestModel.DemandJ!.Value, SeatsF = RequestModel.DemandF!.Value };
            var planeSeats = PlaneService.CalcSeats(capacity, demands, plane.Game);

            RequestModel.SeatsY = planeSeats.SeatsY;
            RequestModel.SeatsJ = planeSeats.SeatsJ;
            RequestModel.SeatsF = planeSeats.SeatsF;

            return LoadPage();
        }

        private IActionResult LoadPage()
        {
            PlaneNames = _appConfig.PlaneConfigs!.Select(p =>
                                  new SelectListItem
                                  {
                                      Value = p.Name,
                                      Text = p.Name
                                  }).ToList();
            return Page();
        }
    }
}
