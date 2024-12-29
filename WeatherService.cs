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

        // My api : https://api.openweathermap.org/data/2.5/weather?lat=55.9533&lon=3.1883&appid=bb75568c5e374c82f79e0d47bb800756


        private const string basicURL = "https://api.openweathermap.org/data/2.5/weather"; // this is the URL which is the base for everything i do with this api and weatherapp. Now i will add stuff to it.

        // helper method which adds all the values supplied to it and makes it complete. This enables portability
        public string mainUrlBuilder(double latitude, double longitude, string apiKey) // public string because i am returning a string, if not, it wouldve been int
        {
            // replace the placeholders with actual values when called(in main)
            return $"{basicURL}?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";


        }

        // async method (check documentation) to make the API call
        public async Task<string> ApiCallerAsync(double latitude, double longitude, string apiKey)
        {
            // validate API key. makes sure that api key always is of the right format
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("Invalid API key!");
            }

            // build the url
            // calls the method to construct the full API Url
            string apiUrl = mainUrlBuilder(latitude, longitude, apiKey);
            Console.WriteLine($"Generated API URL: {apiUrl}"); // Print the constructed URL

            // use httpclient 

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // send the GET request using the built URL
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // if response is succeful, read the json data, or else handle the exception
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    
                    else
                    {
                        string errorDetails = await response.Content.ReadAsStringAsync();
                        throw new Exception($"API call failed with status code: {response.StatusCode}, Response: {errorDetails}");
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured: {ex.Message}");
                    throw;
                }
            }

        }
    }
    
   
    
}
