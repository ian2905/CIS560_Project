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
    internal class RQ2DataDelegate : DataReaderDelegate<IReadOnlyList<RQ2Struct>>
    {
        public RQ2DataDelegate()
            : base("Trains.RQ2CarCapacityStats")
        {
        }

        public override IReadOnlyList<RQ2Struct> Translate(SqlCommand command, IDataRowReader reader)
        {
            var rows = new List<RQ2Struct>();

            while (reader.Read())
            {
                rows.Add(new RQ2Struct(
                    reader.GetInt32("TrainID"),
                    reader.GetInt32("Month"),
                    reader.GetInt32("FistClassCapacity"),
                    reader.GetInt32("BusinessCapacity"),
                    reader.GetInt32("EconomyCapacity")));
            }

            return rows;
        }
    }

    public struct RQ2Struct
    {
        public readonly int trainID;
        public readonly int month;
        public readonly int fistClassCapacity;
        public readonly int businessCapacity;
        public readonly int economyCapacity;

        public RQ2Struct(int trainID, int month, int fistClassCapacity, int businessCapacity, int economyCapacity)
        {
            this.trainID = trainID;
            this.month = month;
            this.fistClassCapacity = fistClassCapacity;
            this.businessCapacity = businessCapacity;
            this.economyCapacity = economyCapacity;
        }
    }
}