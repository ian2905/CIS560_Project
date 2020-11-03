using CIS560Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project
{
    public interface IRouteRepository
    {
        Route CreateRoute(int trainID, string departureLocation, string arrivalLocation, DateTimeOffset departureTime, DateTimeOffset arrivalTime, int distance);
    }
}
