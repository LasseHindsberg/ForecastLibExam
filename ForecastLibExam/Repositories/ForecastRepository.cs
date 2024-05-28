using ForecastLibExam.Models;
using Newtonsoft.Json; 
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ForecastLibExam.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        private int _nextId = 1;
        private List<Forecast> _forecasts = new List<Forecast>();
        private UdpClient udpClient;

        public ForecastRepository()
        {
            Task.Run(() => ListenForUdpBroadcasts());
        }

        public Forecast Add(Forecast forecast)
        {
            forecast.Id = _nextId++;
            forecast.Validate();
            _forecasts.Add(forecast);
            ManageForecastListSize();
            return forecast;
        }

        public IEnumerable<Forecast> GetAll()
        {
            return _forecasts;
        }

        // Delete function that automatically removes the oldest entry when the list reaches 10 entries
        public Forecast DeleteOldest()
        {
            if (_forecasts.Count > 0)
            {
                var oldest = _forecasts.OrderBy(f => f.Date).First();
                _forecasts.Remove(oldest);
                return oldest;
            }
            else
            {
                throw new InvalidOperationException("No forecasts to be deleted");
            }
        }

        private void ManageForecastListSize()
        {
            if (_forecasts.Count > 10)
            {
                DeleteOldest();
            }
        }

        private async Task ListenForUdpBroadcasts()
        {
            udpClient = new UdpClient(5005);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 5005);

            while (true)
            {
                try
                {
                    var result = await udpClient.ReceiveAsync();
                    string receiveString = Encoding.ASCII.GetString(result.Buffer); // idk why, but it just works :)

                    var forecast = JsonConvert.DeserializeObject<Forecast>(receiveString);

                    if (forecast != null)
                    {
                        Add(forecast);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"Error receiving UDP broadcast: {ex.Message}");
                }
            }
        }
    }
}