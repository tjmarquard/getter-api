using System;

namespace GetterApiServices
{
    public interface IQueryService
    {
        string GetWeatherApiEndPoints(string[] services);
    }

    public class QueryService : IQueryService
    {
        public string GetWeatherApiEndPoints(string[] services)
        {
            throw new NotImplementedException();
        }
    }
}