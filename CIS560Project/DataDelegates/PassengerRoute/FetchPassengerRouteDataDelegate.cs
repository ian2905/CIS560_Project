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
    internal class FetchPassengerRouteDataDelegate : DataReaderDelegate<PassengerRoute>
    {
        private readonly int passengerRouteID;

        public FetchPassengerRouteDataDelegate(int passengerRouteID)
            : base("Trains.FetchPassengerRoute")
        {
            this.passengerRouteID = passengerRouteID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("PassengerRouteID", SqlDbType.Int);
            p.Value = passengerRouteID;
        }

        public override PassengerRoute Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(passengerRouteID.ToString());

            return new PassengerRoute(passengerRouteID,
                reader.GetInt32("PassengerID"),
                reader.GetInt32("RouteID"),
                reader.GetInt32("CarID"),
                reader.GetInt32("TicketPrice"));
        }
    }
}