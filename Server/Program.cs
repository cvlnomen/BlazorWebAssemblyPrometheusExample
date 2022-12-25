using Prometheus;

namespace BlazorWebAssemblyPrometheus.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();

			WebApplication app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseHttpMetrics(options =>
			{
				// This will preserve only the first digit of the status code.
				// For example: 200, 201, 203 -> 2xx
				options.ReduceStatusCodeCardinality();
			});
			//TODO mogelijk moet ik dit in de app.UseEndpoints() zetten
			app.MapMetrics();


			app.MapRazorPages();
			app.MapControllers();
			app.MapFallbackToFile("index.html");

			app.Run();


			//var builder = WebApplication.CreateBuilder(args);

			//// Add services to the container.

			//builder.Services.AddControllersWithViews();
			//builder.Services.AddRazorPages();

			//var app = builder.Build();

			//// Configure the HTTP request pipeline.
			//if (app.Environment.IsDevelopment())
			//{
			//    app.UseWebAssemblyDebugging();
			//}
			//else
			//{
			//    app.UseExceptionHandler("/Error");
			//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			//    app.UseHsts();
			//}

			//app.UseHttpsRedirection();
			//app.UseRouting();
			//app.UseHttpMetrics(options =>
			//{
			//    // This will preserve only the first digit of the status code.
			//    // For example: 200, 201, 203 -> 2xx
			//    options.ReduceStatusCodeCardinality();
			//});
			//app.MapMetrics();
			////app.UseMetricServer();

			//app.UseBlazorFrameworkFiles();
			//app.UseStaticFiles();

			//app.MapRazorPages();
			//app.MapControllers();
			//app.MapFallbackToFile("index.html");

			//app.Run();
		}
	}
}