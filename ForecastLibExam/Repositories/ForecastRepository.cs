using ForecastLibExam.Models;


namespace ForecastLibExam.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        public int _nextId = 1;
        public List<Forecast> _forecasts = new List<Forecast>();

        public ForecastRepository()
        {
        }
        public Forecast Add(Forecast forecast)
        {
            forecast.Id = _nextId++;
            forecast.validate();
            _forecasts.Add(forecast);
            return forecast;
        }

        public IEnumerable<Forecast> GetAll()
        {
            return _forecasts;
        }

        //a delete function that automatically removes the oldest entry when the list reaches 10 entries
        public Forecast DeleteOldest()
        {
            if (_forecasts.Count >= 10)
            {
                var oldest = _forecasts.OrderBy(f => f.Date).First();
                _forecasts.RemoveAt(0);
                return oldest;
            }
            else
            {
                throw new InvalidOperationException("No forecasts to be deleted");
            }
        }

    }

}
