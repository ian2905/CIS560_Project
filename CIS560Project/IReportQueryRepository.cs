using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIS560Project.DataDelegates;
using CIS560Project.Models;

namespace CIS560Project
{
    interface IReportQueryRepository
    {
        IReadOnlyList<RQ1Struct> RQ1RankDrivers();

        IReadOnlyList<RQ2Struct> RQ2CarCapacityStats();

        IReadOnlyList<RQ3Struct> RQ3RankCompanies();

        IReadOnlyList<RQ4Struct> RQ4TopTenPercentCust();
    }
}
