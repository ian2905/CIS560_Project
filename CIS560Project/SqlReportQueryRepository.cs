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
    public class SqlReportQueryRepository : IReportQueryRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlReportQueryRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public IReadOnlyList<RQ1Struct> RQ1RankDrivers()
        {
            var d = new RQ1DataDelegate();
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<RQ2Struct> RQ2CarCapacityStats()
        {
            var d = new RQ2DataDelegate();
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<RQ3Struct> RQ3RankCompanies()
        {
            var d = new RQ3DataDelegate();
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<RQ4Struct> RQ4TopTenPercentCust()
        {
            var d = new RQ4DataDelegate();
            return executor.ExecuteReader(d);
        }

    }
}
