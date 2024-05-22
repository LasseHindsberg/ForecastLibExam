using ForecastLibExam.Models;

namespace ForecastLibExam.Repositories
{
    public interface IForecastRepository
    {
        Forecast Add(Forecast forecast);
        Forecast DeleteOldest();
        IEnumerable<Forecast> GetAll();
    }
}