using DBAccess.DataAccessModels;
using DBAccess.UnitOfWork.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriversManagement.Controllers
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
        private readonly IUnitOfWork _unitOfWork;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //_unitOfWork.Drivers.Add(new Driver()
            //{
            //    dateOfBirth = DateTime.Now,
            //    aadharNumber = "12345",
            //    contactNumber = "8925887878",
            //    dateOfJoining = DateTime.Now,
            //    DepoId = 23,
            //    drivingLicenceNumber = "12345",
            //    emailId = "Ankit@ankit.com",
            //    firstName = "Ankit",
            //    lastName = "Soni",
            //    panNumber = "PAN21345"
            //});
            //var result = _unitOfWork.CompleteAsync();

            //var result = _unitOfWork.Drivers.GetAll();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
