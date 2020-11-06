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
    internal class RQ3DataDelegate : DataReaderDelegate<IReadOnlyList<RQ3Struct>>
    {
        public RQ3DataDelegate()
            : base("Trains.RQ3RankCompanies")
        {
        }

        public override IReadOnlyList<RQ3Struct> Translate(SqlCommand command, IDataRowReader reader)
        {
            var rows = new List<RQ3Struct>();

            while (reader.Read())
            {
                rows.Add(new RQ3Struct(
                    reader.GetString("Company"),
                    reader.GetInt32("Month"),
                    reader.GetInt32("Revanue"),
                    reader.GetInt32("RevanueRank"),
                    reader.GetInt32("PassengerCount"),
                    reader.GetInt32("PassengerCountRank")));
            }

            return rows;
        }
    }

    public struct RQ3Struct
    {
        public readonly string company;
        public readonly int month;
        public readonly int revanue;
        public readonly int revanueRank;
        public readonly int passengerCount;
        public readonly int passengerCountRank;

        public RQ3Struct(string company, int month, int revanue, int revanueRank, int passengerCount, int passengerCountRank)
        {
            this.company = company;
            this.month = month;
            this.revanue = revanue;
            this.revanueRank = revanueRank;
            this.passengerCount = passengerCount;
            this.passengerCountRank = passengerCountRank;
        }
    }
}