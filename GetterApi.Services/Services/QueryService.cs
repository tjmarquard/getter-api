using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetterApi.Services.Services
{
    public interface IQueryService
    {
        string GetWeatherApiEndpoints(string[] services);
    }

    public class QueryService : IQueryService
    {
        public string GetWeatherApiEndPoints(string[] services)
        {
            return "this is a thing";
        }
    }
}
