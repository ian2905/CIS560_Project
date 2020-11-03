using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project.Models
{
    public class Passenger
    {
        public int PassengerID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public Passenger(int passengerID, string firstName, string lastName, string email)
        {
            PassengerID = passengerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
