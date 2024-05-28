namespace ForecastLibExam.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public string? SensorName { get; set; }
        public float? Temperature { get; set; }
        public float? Humidity { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

public void validate()
        {
            if (Temperature == null)
            {
                throw new Exception("temp is required");
            }
            if (Humidity == null)
            {
                throw new Exception("humidity is required");
            }
        }
    }
}
