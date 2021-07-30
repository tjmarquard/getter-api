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
            SetSelectedEndpoints(services);
        }

        [JsonProperty]
        public static string Name => "Weather";

        public static Uri BaseUri => new ("https://api.weather.gov");

        [JsonProperty]
        public static IEnumerable<Endpoint> AvailableEndpoints => new List<Endpoint>()
        {
            new Endpoint()
            {
                Name = "alerts",
                Uri = new Uri(BaseUri, "alerts"),
            },
            new Endpoint()
            {
                Name = "activeAlerts",
                Uri = new Uri(BaseUri, "alerts/active"),
                Default = true,
            },
            new Endpoint()
            {
                Name = "alertTypes",
                Uri = new Uri(BaseUri, "alerts/types"),
            },
        };

        [JsonIgnore]
        public List<Endpoint> SelectedEndpoints { get; set; }

        private void SetSelectedEndpoints(string[] services)
        {
            SelectedEndpoints = new List<Endpoint>();

            if (services != null)
            {
                foreach (var service in services)
                {
                    SelectedEndpoints.AddRange(
                        AvailableEndpoints.Where(endPoint => endPoint.Name.Equals(
                            service,
                            StringComparison.OrdinalIgnoreCase)).ToList());
                }
            }

            SetDefaultEndpoints();
        }

        private void SetDefaultEndpoints()
        {
            if (SelectedEndpoints.Count == 0)
            {
                SelectedEndpoints.AddRange(
                    AvailableEndpoints.Where(endpoint => endpoint.Default));
            }
        }
    }
}
