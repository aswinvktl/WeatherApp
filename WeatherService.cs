using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WeatherApp1
{
    public class WeatherService
    {
        
        private const string basicURL = "https://api.openweathermap.org/data/2.5/weather"; // this is the URL which is the base for everything i do with this api and weatherapp. Now i will add stuff to it.

        // helper method which adds all the values supplied to it and makes it complete. This enables portability
        public string mainUrlBuilder(double latitude, double longitude, string apiKey) // public string because i am returning a string
            // replace the placeholders with actual values when called(in main)
            return $"{basicURL}?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";


        }

        // async method (check documentation) to make the API call
        public async Task<weatherData> ApiCallerAsync(double latitude, double longitude, string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("Invalid API key!");
            }

            string apiUrl = mainUrlBuilder(latitude, longitude, apiKey);
            Console.WriteLine($"Generated API URL: {apiUrl}");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Raw JSON Data: {jsonData}");

                        // Parse JSON into WeatherData object
                        weatherData weatherData = JsonConvert.DeserializeObject<weatherData>(jsonData);

                        return weatherData;
                    }
                    else
                    {
                        throw new Exception($"API call failed with status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred: {ex.Message}");
                    throw;
                }

            }
        }




    }
}
