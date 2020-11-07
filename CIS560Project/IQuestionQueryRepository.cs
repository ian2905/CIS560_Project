using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIS560Project.DataDelegates;
using CIS560Project.Models;

namespace CIS560Project
{
    interface IQuestionQueryRepository
    {
        IReadOnlyList<Passenger> QQ1GetFirstClassPassengers();

        IReadOnlyList<PassengerRoute> QQ2GetPassengerRoutes(int passengerID);

        IReadOnlyList<Route> QQ3GetRoutesByDL(string departureLocation);

        IReadOnlyList<Route> QQ4GetRoutesByTrain(int trainID);

        IReadOnlyList<Train> QQ5GetTrainsByCompany(string company);

        IReadOnlyList<QQ6Struct> QQ6PassengerRouteByDate(DateTimeOffset departureTime);

        IReadOnlyList<Passenger> QQ7PassengersForCompany(string company);

        QQ8Struct QQ8SpentByPassenger(int passengerID);
    }
}
