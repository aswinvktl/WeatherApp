using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static async Task Main(string[] args)
        {
            WeatherService service = new WeatherService(); // what is this

            // example co-ordinates and api key

            double latitude = 55.9533;
            double longitude = -3.1883;
            string apiKey = "14d84b3ddd14786e18cad5844741f728";

            try
            {
                // call the API and get the result
                weatherData weatherData = await service.ApiCallerAsync(latitude, longitude, apiKey);
                // Print formatted weather details
                Console.WriteLine($"City: {weatherData.Name}");
                Console.WriteLine($"Temperature: {weatherData.main.Temp}°C");
                Console.WriteLine($"Feels Like: {weatherData.main.feels_like}°C");
                Console.WriteLine($"Weather: {weatherData.weather[0].Description}");
                Console.WriteLine($"Wind Speed: {weatherData.Wind.Speed} m/s");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
