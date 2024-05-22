using Microsoft.AspNetCore.Mvc;
using ForecastLibExam.Models;
using ForecastLibExam.Repositories;
using System.Collections.Generic;

namespace ForecastLibExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastsController : ControllerBase
    {
        private readonly IForecastRepository _forecastRepository;

        public ForecastsController(IForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }

        // GET: api/Forecasts
        [HttpGet]
        public ActionResult<IEnumerable<Forecast>> GetForecasts()
        {
            return Ok(_forecastRepository.GetAll());
        }

        // POST: api/Forecasts
        [HttpPost]
        public ActionResult<Forecast> PostForecast(Forecast forecast)
        {
            var createdForecast = _forecastRepository.Add(forecast);
            return CreatedAtAction(nameof(GetForecasts), new { id = createdForecast.Id }, createdForecast);
        }

        // DELETE: api/Forecasts/oldest
        [HttpDelete("oldest")]
        public ActionResult<Forecast> DeleteOldestForecast()
        {
            var oldestForecast = _forecastRepository.DeleteOldest();
            return Ok(oldestForecast);
        }
    }
}
