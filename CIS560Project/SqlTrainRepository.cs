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
    public class SqlTrainRepository : ITrainRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlTrainRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public Train CreateTrain(string name, string company, string driver, int baseSpeed, int carCapacity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(name));

            if (string.IsNullOrWhiteSpace(company))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(company));

            if (string.IsNullOrWhiteSpace(driver))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(driver));

            var d = new CreateTrainDataDelegate(name, company, driver, baseSpeed, carCapacity);
            return executor.ExecuteNonQuery(d);
        }

    }
}
