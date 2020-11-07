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
    public class SqlQuestionQueryRepository : IQuestionQueryRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlQuestionQueryRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public IReadOnlyList<Passenger> QQ1GetFirstClassPassengers()
        {
            var d = new QQ1DataDelegate();
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<PassengerRoute> QQ2GetPassengerRoutes(int passengerID)
        {
            var d = new QQ2DataDelegate(passengerID);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Route> QQ3GetRoutesByDL(string departureLocation)
        {
            var d = new QQ3DataDelegate(departureLocation);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Route> QQ4GetRoutesByTrain(int trainID)
        {
            var d = new QQ4DataDelegate(trainID);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Train> QQ5GetTrainsByCompany(string company)
        {
            var d = new QQ5DataDelegate(company);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<QQ6Struct> QQ6PassengerRouteByDate(DateTimeOffset departureTime)
        {
            var d = new QQ6DataDelegate(departureTime);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Passenger> QQ7PassengersForCompany(string company)
        {
            var d = new QQ7DataDelegate(company);
            return executor.ExecuteReader(d);
        }

        public QQ8Struct QQ8SpentByPassenger(int passengerID)
        {
            var d = new QQ8DataDelegate(passengerID);
            return executor.ExecuteReader(d);
        }
    }
}
