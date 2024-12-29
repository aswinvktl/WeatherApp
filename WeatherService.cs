using System;
using System.Collections.Generic;
using System.Linq;
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
            return $"{basicURL}?lat={latitude}&lon{longitude}&appid{apiKey}&units=metric";
        }


        public string ApiCaller(double latitude, double longitude, string apiKey)
        {
            mainUrlBuilder(latitude, longitude, apiKey);
            if (apiKey != null) 
            {
                Console.WriteLine("Invalid Key");
            }
        }
    }

   
    
}
