namespace GetterApiServices.Models
{
    using System;

    public class EndPoint
    {
        public string Name { get; set; }

        public Uri Uri { get; set; }

        public bool Default { get; set; } = false;
    }
}
