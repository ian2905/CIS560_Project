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
    internal class QQ3DataDelegate : DataReaderDelegate<IReadOnlyList<Route>>
    {
        private readonly string departureLocation;

        public QQ3DataDelegate(string departureLocation)
            : base("Trains.QQ3GetRoutesByDL")
        {
            this.departureLocation = departureLocation;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("DepartureLocation", SqlDbType.NVarChar);
            p.Value = departureLocation;
        }

        public override IReadOnlyList<Route> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(departureLocation);

            var rows = new List<Route>();

            while (reader.Read())
            {
                rows.Add(new Route(
                    reader.GetInt32("RouteID"),
                    reader.GetInt32("TrainID"),
                    departureLocation,
                    reader.GetString("ArrivalLocation"),
                    reader.GetDateTimeOffset("DepartureTime"),
                    reader.GetDateTimeOffset("ArrivalTime"),
                    reader.GetInt32("Distance")));
            }

            return rows;
        }
    }
}