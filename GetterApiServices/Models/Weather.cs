namespace GetterApiServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    public class Weather
    {
        public Weather(string[] services = null)
        {
            SetSelectedEndPoints(services);
        }

        [JsonProperty]
        public static string Name => "Weather";

        public static Uri BaseUri => new ("https://api.weather.gov");

        [JsonProperty]
        public static IEnumerable<EndPoint> AvailableEndPoints => new List<EndPoint>()
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
                Default = true,
            },
            new EndPoint()
            {
                Name = "alertTypes",
                Uri = new Uri(BaseUri, "alerts/types"),
            },
        };

        [JsonIgnore]
        public List<EndPoint> SelectedEndPoints { get; set; }

        private void SetSelectedEndPoints(string[] services)
        {
            SelectedEndPoints = new List<EndPoint>();

            if (services != null)
            {
                foreach (var service in services)
                {
                    SelectedEndPoints.AddRange(
                        AvailableEndPoints.Where(endPoint => endPoint.Name.Equals(
                            service,
                            StringComparison.OrdinalIgnoreCase)).ToList());
                }
            }

            SetDefaultEndPoints();
        }

        private void SetDefaultEndPoints()
        {
            if (SelectedEndPoints.Count == 0)
            {
                SelectedEndPoints.AddRange(
                    AvailableEndPoints.Where(endpoint => endpoint.Default));
            }
        }
    }
}
