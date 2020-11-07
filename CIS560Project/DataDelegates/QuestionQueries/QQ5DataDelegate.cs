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
    internal class QQ5DataDelegate : DataReaderDelegate<IReadOnlyList<Train>>
    {
        private readonly string company;

        public QQ5DataDelegate(string company)
            : base("Trains.QQ5GetTrainsByCompany")
        {
            this.company = company;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("Company", SqlDbType.NVarChar);
            p.Value = company;
        }

        public override IReadOnlyList<Train> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(company);

            var rows = new List<Train>();

            while (reader.Read())
            {
                rows.Add(new Train(
                    reader.GetInt32("TrainID"),
                    reader.GetString("Name"),
                    reader.GetString("Driver"),
                    company,
                    reader.GetInt32("BaseSpeed"),
                    reader.GetInt32("CarCapacity")));
            }

            return rows;
        }
    }
}