namespace GetterApiServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using GetterApiServices.Models;
    using Newtonsoft.Json;

    public interface IWeatherService
    {
        public Task<string> GetEndPoints(string[] services);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient httpclient;
        private string userAgentApp = "GetterApi";
        private Guid userAgentContact = default;
        private ProductInfoHeaderValue headerValue;

        public WeatherService(HttpClient httpclient)
        {
            this.httpclient = httpclient;
            this.headerValue = new ProductInfoHeaderValue(userAgentApp, userAgentContact.ToString());
        }

        public async Task<string> GetEndPoints(string[] services)
        {
            var weather = new Weather(services);
            var responseContents = new List<dynamic>();

            var tasks = new List<Task<HttpResponseMessage>>();

            foreach (var endPoint in weather.SelectedEndPoints)
            {
                tasks.Add(GetEndPoint(endPoint.Uri));
            }

            while (tasks.Any())
            {
                var finishedTask = await Task.WhenAny(tasks);
                tasks.Remove(finishedTask);

                var contents = await (await finishedTask).Content.ReadAsStringAsync();

                dynamic obj = JsonConvert.DeserializeObject(contents);

                responseContents.Add(obj);
            }

            return JsonConvert.SerializeObject(responseContents);
        }

        private Task<HttpResponseMessage> GetEndPoint(Uri uri)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = uri,
            };

            httpRequestMessage.Headers.UserAgent.Add(headerValue);

            return httpclient.SendAsync(httpRequestMessage);
        }
    }
}
