using CIS560Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project
{
    public interface ICarRepository
    {
        Car CreateCar(int trainID, int carTypeID, int ticketPrice, int passengerCapacity);
    }
}
