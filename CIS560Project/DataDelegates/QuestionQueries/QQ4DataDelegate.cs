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
    internal class QQ4DataDelegate : DataReaderDelegate<IReadOnlyList<Route>>
    {
        private readonly int trainID;

        public QQ4DataDelegate(int trainID)
            : base("Trains.QQ4GetRoutesByTrain")
        {
            this.trainID = trainID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("TrainID", SqlDbType.Int);
            p.Value = trainID;
        }

        public override IReadOnlyList<Route> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(trainID.ToString());

            var rows = new List<Route>();

            while (reader.Read())
            {
                rows.Add(new Route(
                    reader.GetInt32("RouteID"),
                    trainID,
                    reader.GetString("DepartureLocation"),
                    reader.GetString("ArrivalLocation"),
                    reader.GetDateTimeOffset("DepartureTime"),
                    reader.GetDateTimeOffset("ArrivalTime"),
                    reader.GetInt32("Distance")));
            }

            return rows;
        }
    }
}