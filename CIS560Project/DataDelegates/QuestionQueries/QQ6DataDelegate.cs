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
    internal class QQ6DataDelegate : DataReaderDelegate<IReadOnlyList<QQ6Struct>>
    {
        private readonly DateTimeOffset departureTime;

        public QQ6DataDelegate(DateTimeOffset departureTime)
            : base("Trains.QQ6PassengerRouteByDate")
        {
            this.departureTime = departureTime;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("DepartureTime", SqlDbType.DateTimeOffset);
            p.Value = departureTime;
        }

        public override IReadOnlyList<QQ6Struct> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(departureTime.ToString());

            var rows = new List<QQ6Struct>();

            while (reader.Read())
            {
                rows.Add(new QQ6Struct(
                    reader.GetDateTimeOffset("DepartureTime"),
                    reader.GetInt32("RouteCount"),
                    reader.GetInt32("PassengerCount")));
            }

            return rows;
        }
    }

    public struct QQ6Struct
    {
        public readonly DateTimeOffset departureTime;
        public readonly int routeCount;
        public readonly int passengerCount;

        public QQ6Struct(DateTimeOffset departureTime, int routeCount, int passengerCount)
        {
            this.departureTime = departureTime;
            this.routeCount = routeCount;
            this.passengerCount = passengerCount;
        }
    }
}