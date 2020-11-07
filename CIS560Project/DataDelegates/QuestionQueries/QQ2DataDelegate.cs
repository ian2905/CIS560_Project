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
    internal class QQ2DataDelegate : DataReaderDelegate<IReadOnlyList<PassengerRoute>>
    {
        private readonly int passengerID;

        public QQ2DataDelegate(int passengerID)
            : base("Trains.QQ2GetPassengerRoutes")
        {
            this.passengerID = passengerID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("PassengerID", SqlDbType.Int);
            p.Value = passengerID;
        }

        public override IReadOnlyList<PassengerRoute> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(passengerID.ToString());

            var rows = new List<PassengerRoute>();

            while (reader.Read())
            {
                rows.Add(new PassengerRoute(
                    reader.GetInt32("PassengerRouteID"),
                    passengerID,
                    reader.GetInt32("RouteID"),
                    reader.GetInt32("CarID"),
                    reader.GetInt32("TicketPrice")));
            }

            return rows;
        }
    }
}