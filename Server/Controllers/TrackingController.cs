using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace BlazorWebAssemblyPrometheus.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TrackingController : ControllerBase
	{
		private static readonly Counter PageVisitCounter = Metrics.CreateCounter("total_page_visits", "Number of times users have visited a page.");

		private readonly ILogger<TrackingController> _logger;

		public TrackingController(ILogger<TrackingController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		[Route("PageVisited")]
		public ActionResult Post()
		{
			PageVisitCounter.Inc();
			return Ok();
		}
	}
}
