using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssemblyPrometheus.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RandomNumberController : ControllerBase
	{
		[HttpGet]
		public ActionResult<int> Get()
		{
			if (Random.Shared.Next(1, 10) > 5)
			{
				return Unauthorized();
			}

			return Random.Shared.Next();
		}
	}
}