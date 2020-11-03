using DataAccess;
using System;
using CIS560Project.Models;
using CIS560Project.DataDelegates;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlCarRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public Car CreateCar(int trainID, int carTypeID, int ticketPrice, int passengerCapacity)
        {
            var d = new CreateCarDataDelegate(trainID, carTypeID, ticketPrice, passengerCapacity);
            return executor.ExecuteNonQuery(d);
        }

    }
}
