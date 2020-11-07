--2: Get all routes from a particualr departure location
CREATE OR ALTER PROCEDURE Trains.QQ3GetRoutesByDL
   @DepartureLocation NVARCHAR(64)
AS

SELECT R.RouteID, R.TrainID, R.ArrivalLocation, R.DepartureTime, R.ArrivalTime, R.Distance
FROM Trains.[Routes] R
WHERE R.DepartureLocation = @DepartureLocation;
GO