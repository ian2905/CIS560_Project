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
    internal class FetchCarDataDelegate : DataReaderDelegate<Car>
    {
        private readonly int carID;

        public FetchCarDataDelegate(int carID)
            : base("Trains.FetchCar")
        {
            this.carID = carID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("CarID", SqlDbType.Int);
            p.Value = carID;
        }

        public override Car Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(carID.ToString());

            return new Car(carID,
                reader.GetInt32("TrainID"),
                reader.GetInt32("CarTypeID"),
                reader.GetInt32("TicketPrice"),
                reader.GetInt32("PassengerCapacity"));
        }
    }
}