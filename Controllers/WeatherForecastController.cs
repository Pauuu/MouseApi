using Microsoft.AspNetCore.Mvc;

namespace MouseApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetMouses")]
    public IEnumerable<WeatherForecast> Get()
    {
       
    }
}
