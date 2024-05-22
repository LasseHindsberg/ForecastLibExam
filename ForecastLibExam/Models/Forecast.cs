namespace ForecastLibExam.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public double? Temp { get; set; }
        public double? Humidity { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"id: {Id}, temp: {Temp}, humidity: {Humidity}, date: {Date}";
        }

        public void validate()
        {
            if (Temp == null)
            {
                throw new Exception("temp is required");
            }
            if (Humidity == null)
            {
                throw new Exception("humidity is required");
            }
            if (Date == DateTime.MinValue)
            {
                throw new InvalidOperationException("Date is required.");
            }
        }
    }
}
