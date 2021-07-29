using System;
using System.Collections.Generic;

namespace GetterApi.Models
{
    public class Weather
    {
        public static string Name => "Weather";
        public static Uri BaseUri => new Uri("https://api.weather.gov");
        public static IEnumerable<EndPoint> EndPoints => new List<EndPoint>()
        {
            new EndPoint()
            {
                Name = "alerts",
                Uri = new Uri(BaseUri, "alerts"),
            },
            new EndPoint()
            {
                Name = "activeAlerts",
                Uri = new Uri(BaseUri, "alerts/active"),
            },
            new EndPoint()
            {
                Name = "alertTypes",
                Uri = new Uri(BaseUri, "alerts/types"),
            }
        };
    }
}