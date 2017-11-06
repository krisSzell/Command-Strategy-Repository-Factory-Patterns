using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWashServiceBrowserFull.API.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }

        public override string ToString()
        {
            return $"{Name}, cena: {Price} zł, czas trwania: {DurationInMinutes} min";
        }
    }
}