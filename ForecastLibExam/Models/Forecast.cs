namespace ForecastLibExam.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public string? SensorName { get; set; }
        public float? Temperature { get; set; }
        public float? Humidity { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

public void Validate()
        {
            
            if (Temperature < -10 || Temperature > 30)
            {
                throw new System.Exception("Temperature is not between -10 and 30");
            }
            if (Humidity < 0 || Humidity > 100)
            {
                throw new System.Exception("Humidity is not between 0 and 100");
            }
        }
    }
}
