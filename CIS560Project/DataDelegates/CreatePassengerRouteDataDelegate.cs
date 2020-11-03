using System.Text;
using System.Threading.Tasks;
using DataAccess;
using CIS560Project.Models;
using System.Data;
using System.Data.SqlClient;
using System;

namespace CIS560Project.DataDelegates
{
    internal class CreatePassengerRouteDataDelegate : NonQueryDataDelegate<PassengerRoute>
    {
        private readonly int passengerID;
        private readonly int routeID;
        private readonly int carID;
        private readonly int ticketPrice;

        public CreatePassengerRouteDataDelegate(int passengerID, int routeID, int carID, int ticketPrice)
         : base("Trains.CreatePassengerRoute")
        {
            this.passengerID = passengerID;
            this.routeID = routeID;
            this.carID = carID;
            this.ticketPrice = ticketPrice;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("PassengerID", SqlDbType.Int);
            p.Value = passengerID;

            p = command.Parameters.Add("RouteID", SqlDbType.Int);
            p.Value = routeID;

            p = command.Parameters.Add("CarID", SqlDbType.Int);
            p.Value = carID;

            p = command.Parameters.Add("TicketPrice", SqlDbType.Int);
            p.Value = ticketPrice;

            p = command.Parameters.Add("PassengerRouteID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override PassengerRoute Translate(SqlCommand command)
        {
            return new PassengerRoute((int)command.Parameters["PassengerRouteID"].Value, passengerID, routeID, carID, ticketPrice);
        }
    }
}