namespace GetterApiServices.Models
{
    using System;

    public class Endpoint
    {
        public string Name { get; set; }

        public Uri Uri { get; set; }

        public bool Default { get; set; } = false;
    }
}
