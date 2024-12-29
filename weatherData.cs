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
    public class weatherData
    {
        // properties to store the values
        public Coordinate coordinate { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind Wind { get; set; }
        public string Name { get; set; }
    }


    // now we explore the properties
    public class Coordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }
}
