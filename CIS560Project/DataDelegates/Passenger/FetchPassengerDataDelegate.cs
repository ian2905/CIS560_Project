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
    internal class FetchPassengerDataDelegate : DataReaderDelegate<Passenger>
    {
        private readonly int passengerID;

        public FetchPassengerDataDelegate(int passengerID)
            : base("Trains.FetchPassenger")
        {
            this.passengerID = passengerID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("PassengerID", SqlDbType.Int);
            p.Value = passengerID;
        }

        public override Passenger Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(passengerID.ToString());

            return new Passenger(passengerID,
                reader.GetString("FirstName"),
                reader.GetString("LastName"),
                reader.GetString("Email"));
        }
    }
}