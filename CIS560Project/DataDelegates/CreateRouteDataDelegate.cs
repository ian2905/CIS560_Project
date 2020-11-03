using System.Text;
using System.Threading.Tasks;
using DataAccess;
using CIS560Project.Models;
using System.Data;
using System.Data.SqlClient;
using System;

namespace CIS560Project.DataDelegates
{
    internal class CreateRouteDataDelegate : NonQueryDataDelegate<Route>
    {
        private readonly int trainID;
        private readonly string departureLocation;
        private readonly string arrivalLocation;
        private readonly DateTimeOffset departureTime;
        private readonly DateTimeOffset arrivalTime;
        private readonly int distance;

        public CreateRouteDataDelegate(int trainID, string departureLocation, string arrivalLocation, DateTimeOffset departureTime, int distance)
         : base("Trains.CreateRoute")
        {
            this.trainID = trainID;
            this.departureLocation = departureLocation;
            this.arrivalLocation = arrivalLocation;
            this.departureTime = departureTime;
            this.arrivalTime = new DateTimeOffset();
            this.distance = distance;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("TrainID", SqlDbType.Int);
            p.Value = trainID;

            p = command.Parameters.Add("DepartureLocation", SqlDbType.NVarChar);
            p.Value = departureLocation;

            p = command.Parameters.Add("ArrivalLocation", SqlDbType.NVarChar);
            p.Value = arrivalLocation;

            p = command.Parameters.Add("DepartureTime", SqlDbType.DateTimeOffset);
            p.Value = departureTime;

            p = command.Parameters.Add("ArrivalTime", SqlDbType.DateTimeOffset);
            p.Value = arrivalTime;

            p = command.Parameters.Add("Distance", SqlDbType.Int);
            p.Value = distance;

            p = command.Parameters.Add("RouteID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Route Translate(SqlCommand command)
        {
            return new Route((int)command.Parameters["RouteID"].Value, trainID, departureLocation, arrivalLocation, departureTime, arrivalTime, distance);
        }
    }
}