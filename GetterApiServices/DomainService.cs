namespace GetterApiServices
{
    using System;
    using System.Collections.Generic;
    using GetterApiServices.Models;
    using Newtonsoft.Json;

    public interface IDomainService
    {
        public string GetDomains();
    }

    public class DomainService : IDomainService
    {
        public string GetDomains()
        {
            var domains = new List<object>()
            {
                new Weather(),
            };

            return JsonConvert.SerializeObject(domains);
        }
    }
}