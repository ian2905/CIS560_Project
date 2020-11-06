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
    internal class RQ4DataDelegate : DataReaderDelegate<IReadOnlyList<RQ4Struct>>
    {
        public RQ4DataDelegate()
            : base("Trains.RQ4TopTenPercentCust")
        {
        }

        public override IReadOnlyList<RQ4Struct> Translate(SqlCommand command, IDataRowReader reader)
        {
            var rows = new List<RQ4Struct>();

            while (reader.Read())
            {
                rows.Add(new RQ4Struct(
                    reader.GetInt32("PassengerID"),
                    reader.GetString("FirstName"),
                    reader.GetString("LastName"),
                    reader.GetInt32("DistanceTraveled"),
                    reader.GetInt32("TravelRank"),
                    reader.GetInt32("AmountSpent"),
                    reader.GetInt32("AmountSpentRank")));
            }

            return rows;
        }
    }

    public struct RQ4Struct
    {
        public readonly int passengerID;
        public readonly string firstName;
        public readonly string lastName;
        public readonly int distanceTraveled;
        public readonly int travelRank;
        public readonly int amountSpent;
        public readonly int amountSpentRank;

        public RQ4Struct(int passengerID, string firstName, string lastName, int distanceTraveled, int travelRank, int amountSpent, int amountSpentRank)
        {
            this.passengerID = passengerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.distanceTraveled = distanceTraveled;
            this.travelRank = travelRank;
            this.amountSpent = amountSpent;
            this.amountSpentRank = amountSpentRank;
        }
    }
}