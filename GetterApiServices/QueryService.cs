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
            return "empty";
        }
    }
}