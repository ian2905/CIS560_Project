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
    internal class QQ7DataDelegate : DataReaderDelegate<IReadOnlyList<Passenger>>
    {
        private readonly string company;

        public QQ7DataDelegate(string company)
            : base("Trains.QQ7PassengersForCompany")
        {
            this.company = company;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("Company", SqlDbType.NVarChar);
            p.Value = company;
        }

        public override IReadOnlyList<Passenger> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(company);

            var rows = new List<Passenger>();

            while (reader.Read())
            {
                rows.Add(new Passenger(
                    reader.GetInt32("PassengerID"),
                    reader.GetString("FirstName"),
                    reader.GetString("LastName"),
                    reader.GetString("Email")));
            }

            return rows;
        }
    }
}