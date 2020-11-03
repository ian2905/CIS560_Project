CREATE OR ALTER PROCEDURE Trains.FetchRoute
   @RouteID INT
AS

SELECT R.TrainID, R.DepartureLocation, R.ArrivalLocation, R.DepartureTime, R.ArrivalTime, R.Distance
FROM Trains.Route R
WHERE R.RouteID = @RouteID;
GO
