using System.Text;
using System.Threading.Tasks;
using DataAccess;
using CIS560Project.Models;
using System.Data;
using System.Data.SqlClient;

namespace CIS560Project.DataDelegates
{
    internal class CreatePassengerDataDelegate : NonQueryDataDelegate<Passenger>
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly string email;

        public CreatePassengerDataDelegate(string firstName, string lastName, string email)
         : base("Trains.CreatePassenger")
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("FirstName", SqlDbType.NVarChar);
            p.Value = firstName;

            p = command.Parameters.Add("LastName", SqlDbType.NVarChar);
            p.Value = lastName;

            p = command.Parameters.Add("Email", SqlDbType.NVarChar);
            p.Value = email;

            p = command.Parameters.Add("PassengerID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Passenger Translate(SqlCommand command)
        {
            return new Passenger((int)command.Parameters["PassengerID"].Value, firstName, lastName, email);
        }
    }
}