using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project.Models
{
    public class Car
    {
        public int CarID { get; }
        public int TrainID { get; }
        public int CarTypeID { get; }
        public int TicketPrice { get; }
        public int PassengerCapacity { get; }

        public Car(int carID, int trainID, int carTypeID, int ticketPrice, int passengerCapacity)
        {
            CarID = carID;
            TrainID = trainID;
            CarTypeID = carTypeID;
            TicketPrice = ticketPrice;
            PassengerCapacity = passengerCapacity;
        }
    }
}
