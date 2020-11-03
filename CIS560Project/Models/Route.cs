using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project.Models
{
    public class Route
    {
        public int RouteID { get; }
        public int TrainID { get; }
        public string DepartureLocation { get; }
        public string ArrivalLocation { get; }
        public DateTimeOffset DepartureTime { get; }
        public DateTimeOffset ArrivalTime { get; set; }
        public int Distance { get;  }

        public Route(int routeID, int trainID, string departureLocation, string arrivalLocation, DateTimeOffset departureTime, DateTimeOffset arrivalTime, int distance)
        {
            RouteID = routeID;
            TrainID = trainID;
            DepartureLocation = departureLocation;
            ArrivalLocation = arrivalLocation;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Distance = distance;
        }

        public void SetArrivalTime(DateTimeOffset arrivalTime)
        {
            ArrivalTime = arrivalTime;
        }


    }
}
