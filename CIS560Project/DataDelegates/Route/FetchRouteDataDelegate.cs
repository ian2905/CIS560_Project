using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using CIS560Project.Models;
using System.Data;
using System.Data.SqlClient;

namespace CIS560Project.DataDelegates
{
    internal class FetchRouteDataDelegate : DataReaderDelegate<Route>
    {
        private readonly int routeID;

        public FetchRouteDataDelegate(int routeID)
            : base("Trains.FetchRoute")
        {
            this.routeID = routeID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("RouteID", SqlDbType.Int);
            p.Value = routeID;
        }

        public override Route Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(routeID.ToString());

            return new Route(routeID,
                reader.GetInt32("TrainID"),
                reader.GetString("DepartureLocation"),
                reader.GetString("ArrivalLocation"),
                reader.GetDateTimeOffset("DepartureTime"),
                reader.GetDateTimeOffset("ArrivalTime"),
                reader.GetInt32("Distance"));
        }
    }
}