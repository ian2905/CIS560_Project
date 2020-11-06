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
    internal class CreateTrainDataDelegate : NonQueryDataDelegate<Train>
    {
        private readonly string name;
        private readonly string company;
        private readonly string driver;
        private readonly int baseSpeed;
        private readonly int carCapacity;

        public CreateTrainDataDelegate(string name, string company, string driver, int baseSpeed, int carCapacity)
         : base("Trains.CreateTrain")
        {
            this.name = name;
            this.company = company;
            this.driver = driver;
            this.baseSpeed = baseSpeed;
            this.carCapacity = carCapacity;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
            p.Value = name;

            p = command.Parameters.Add("Company", SqlDbType.NVarChar);
            p.Value = company;

            p = command.Parameters.Add("Driver", SqlDbType.NVarChar);
            p.Value = driver;

            p = command.Parameters.Add("BaseSpeed", SqlDbType.Int);
            p.Value = baseSpeed;

            p = command.Parameters.Add("CarCapacity", SqlDbType.Int);
            p.Value = carCapacity;

            p = command.Parameters.Add("TrainID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Train Translate(SqlCommand command)
        {
            return new Train((int)command.Parameters["TrainID"].Value, name, company, driver, baseSpeed, carCapacity);
        }
    }
}
