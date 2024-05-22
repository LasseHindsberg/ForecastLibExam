using Microsoft.EntityFrameworkCore;
using ForecastLibExam.Models;


namespace ForecastLibExam.data
{
    public class ForecastDbContext : DbContext
    {
        public ForecastDbContext(DbContextOptions<ForecastDbContext> options) : base(options)
        {
        }

        public DbSet<Forecast> Forecasts { get; set; }
    }
}
