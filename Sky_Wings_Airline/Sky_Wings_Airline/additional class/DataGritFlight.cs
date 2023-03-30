using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky_Wings_Airline.additional_class
{
    internal class DataGritFlight
    {
        public int ID { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Plane { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string Status { get; set;}
        public string SurnameFirstPilot { get; set; }
        public string SurnameSecondPilot { get; set; }
    }
}
