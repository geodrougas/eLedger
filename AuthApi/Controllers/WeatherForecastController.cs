using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DbContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task Get()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}