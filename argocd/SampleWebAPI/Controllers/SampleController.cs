using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Models;
using SampleWebAPI.Enums;

namespace SampleWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private IWebHostEnvironment _hostingEnvironment;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<SampleController> _logger;

    public SampleController(ILogger<SampleController> logger,IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _hostingEnvironment = httpContextAccessor.HttpContext.RequestServices.GetService<IWebHostEnvironment>();
    }

    [HttpGet(Name = "Data")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet]
    [Route("Info")]
    public ResponseMessage HealthCheck()
    {
        return new ResponseMessage()
        {
            ResultCode = ResultCode.OK,
            Payload = new
            {
                BuildNumber = Environment.GetEnvironmentVariable("BUILD_NUMBER"),
                Environment = _hostingEnvironment.EnvironmentName
            }
        };
    }
}
