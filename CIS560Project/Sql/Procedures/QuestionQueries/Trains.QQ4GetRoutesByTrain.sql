--4: Get all Routes for a particular train
CREATE OR ALTER PROCEDURE Trains.QQGetRoutesByTrain
	@TrainID INT
AS

SELECT R.RouteID, R.TrainID, R.DepartureLocation, R.ArrivalLocation, R.DepartureTime, R.ArrivalTime, R.Distance
FROM Trains.Train T
	INNER JOIN Trains.[Route] R ON R.TrainID = T.TrainID
WHERE T.TrainID = @TrainID;

GO
