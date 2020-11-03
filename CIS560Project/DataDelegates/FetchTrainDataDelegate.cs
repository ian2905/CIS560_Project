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
    internal class FetchTrainDataDelegate : DataReaderDelegate<Train>
    {
        private readonly int trainID;

        public FetchTrainDataDelegate(int trainID)
            : base("Trains.FetchTrain")
        {
            this.trainID = trainID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("TrainID", SqlDbType.Int);
            p.Value = trainID;
        }

        public override Train Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(trainID.ToString());

            return new Train(trainID,
                reader.GetString("Name"),
                reader.GetString("Company"),
                reader.GetString("Driver"),
                reader.GetInt32("BaseSpeed"),
                reader.GetInt32("CarCapacity"));
        }
    }
}