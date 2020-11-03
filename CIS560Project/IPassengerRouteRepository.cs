using CIS560Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project
{
    public interface IPassengerRouteRepository
    {
        PassengerRoute CreatePassengerRoute(int passengerID, int routeID, int carID, int ticketPrice);
    }
}
