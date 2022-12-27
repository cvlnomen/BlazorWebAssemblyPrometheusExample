using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace BlazorWebAssemblyPrometheus.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TrackingController : ControllerBase
	{
		private static readonly Counter RequestCountByPage = Metrics
			.CreateCounter("razor_page_requests_total", "Number of requests received, by razor page.",
				labelNames: new[] { "route" });

		[HttpPost]
		[Route("PageVisited")]
		public ActionResult Post(string uriLocalPath)
		{
			RequestCountByPage.WithLabels(uriLocalPath).Inc();
			return Ok();
		}
	}
}