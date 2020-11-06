using System.Text;
using System.Threading.Tasks;
using DataAccess;
using CIS560Project.Models;
using System.Data;
using System.Data.SqlClient;

namespace CIS560Project.DataDelegates
{
    internal class CreateCarDataDelegate : NonQueryDataDelegate<Car>
    {
        private readonly int trainID;
        private readonly int carTypeID;
        private readonly int ticketPrice;
        private readonly int passengerCapacity;

        public CreateCarDataDelegate(int trainID, int carTypeID, int ticketPrice, int passengerCapacity)
         : base("Trains.CreateCar")
        {
            this.trainID = trainID;
            this.carTypeID = carTypeID;
            this.ticketPrice = ticketPrice;
            this.passengerCapacity = passengerCapacity;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("TrainID", SqlDbType.Int);
            p.Value = trainID;

            p = command.Parameters.Add("CarTypeID", SqlDbType.Int);
            p.Value = carTypeID;

            p = command.Parameters.Add("TicketPrice", SqlDbType.Int);
            p.Value = ticketPrice;

            p = command.Parameters.Add("PassengerCapacity", SqlDbType.Int);
            p.Value = passengerCapacity;

            p = command.Parameters.Add("CarID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Car Translate(SqlCommand command)
        {
            return new Car((int)command.Parameters["CarID"].Value, trainID, carTypeID, ticketPrice, passengerCapacity);
        }
    }
}