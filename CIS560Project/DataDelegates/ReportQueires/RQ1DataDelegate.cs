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
    internal class RQ1DataDelegate : DataReaderDelegate<IReadOnlyList<RQ1Struct>>
    {
        public RQ1DataDelegate()
            : base("Trains.RQ1RankDrivers")
        {
        }

        public override IReadOnlyList<RQ1Struct> Translate(SqlCommand command, IDataRowReader reader)
        {
            var rows = new List<RQ1Struct>();

            while (reader.Read())
            {
                rows.Add(new RQ1Struct(
                    reader.GetString("Driver"),
                    reader.GetInt32("Month"),
                    reader.GetInt32("AverageTimeInMinutes"),
                    reader.GetInt32("DriverRank")));
            }

            return rows;
        }
    }

    public struct RQ1Struct
    {
        public readonly string driver;
        public readonly int month;
        public readonly int averageTimeInMinutes;
        public readonly int driverRank;

        public RQ1Struct(string driver, int month, int averageTimeInMinutes, int driverRank)
        {
            this.driver = driver;
            this.month = month;
            this.averageTimeInMinutes = averageTimeInMinutes;
            this.driverRank = driverRank;
        }
    }
}