using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetterApi.Models
{
    public static class Domains
    {
        public static Weather Weather;

        static Domains()
        {
            Weather = new Weather();
        }
    }
}
