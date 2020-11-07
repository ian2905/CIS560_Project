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
    internal class QQ8DataDelegate : DataReaderDelegate<QQ8Struct>
    {
        private readonly int passengerID;

        public QQ8DataDelegate(int passengerID)
            : base("Trains.QQ8SpentByPassenger")
        {
            this.passengerID = passengerID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("PassengerID", SqlDbType.Int);
            p.Value = passengerID;
        }

        public override QQ8Struct Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(passengerID.ToString());

            return new QQ8Struct(
                reader.GetInt32("PassengerID"),
                reader.GetString("FirstName"),
                reader.GetString("LastName"),
                reader.GetInt32("AmountSpent"));
        }
    }
    public struct QQ8Struct
    {
        public readonly int passengerID;
        public readonly string firstName;
        public readonly string lastName;
        public readonly int amountSpent;

        public QQ8Struct(int passengerID, string firstName, string lastName,  int amountSpent)
        {
            this.passengerID = passengerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.amountSpent = amountSpent;
        }
    }
}