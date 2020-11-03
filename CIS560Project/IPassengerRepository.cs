using CIS560Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project
{
    public interface IPassengerRepository
    {
        Passenger CreatePassenger(string firstName, string lastName, string email);
    }
}
