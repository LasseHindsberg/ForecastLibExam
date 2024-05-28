using ForecastLibExam.Models;
using System.Collections.Generic;

namespace ForecastLibExam.Repositories
{
    public interface IForecastRepository
    {
        Forecast Add(Forecast forecast);
        IEnumerable<Forecast> GetAll();
        Forecast DeleteOldest();
    }
}