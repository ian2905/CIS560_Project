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
    internal class QQ1DataDelegate : DataReaderDelegate<IReadOnlyList<Passenger>>
    {
        public QQ1DataDelegate()
            : base("Trains.QQ1GetFirstClassPassengers")
        {
        }

        public override IReadOnlyList<Passenger> Translate(SqlCommand command, IDataRowReader reader)
        {
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