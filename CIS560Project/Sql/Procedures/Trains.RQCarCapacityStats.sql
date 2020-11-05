--Report Query 2
--Find out, on a monthly basis, how close each train car is meeting capacity for each of the
--three car types(first class, business, economy).
CREATE OR ALTER PROCEDURE Trains.RQCarCapacityStats
AS

SELECT T.TrainID, MONTH(R.DepartureTime),
	(
		SELECT SUM(COUNT(DISTINCT PR.PassengerRouteID) / C.PassengerCapacity) / COUNT(DISTINCT R.RouteID)
		FROM Trains.[Route] SR
			INNER JOIN Trains.PassengerRoute PR ON PR.RouteID = SR.RouteID
		WHERE PR.CarID = C.CarID AND
				CT.[Name] = N'FirstClass' AND
				MONTH(SR.DepartureTime) = MONTH(R.DepartureTime)
	) AS FirstClassCapacity,
	(
		SELECT SUM(COUNT(DISTINCT PR.PassengerRouteID) / C.PassengerCapacity) / COUNT(DISTINCT R.RouteID)
		FROM Trains.[Route] SR
			INNER JOIN Trains.PassengerRoute PR ON PR.RouteID = SR.RouteID
		WHERE PR.CarID = C.CarID AND
				CT.[Name] = N'Business' AND
				MONTH(SR.DepartureTime) = MONTH(R.DepartureTime)
	) AS BusinessCapacity,
	(
		SELECT SUM(COUNT(DISTINCT PR.PassengerRouteID) / C.PassengerCapacity) / COUNT(DISTINCT R.RouteID)
		FROM Trains.[Route] SR
			INNER JOIN Trains.PassengerRoute PR ON PR.RouteID = SR.RouteID
		WHERE PR.CarID = C.CarID AND
				CT.[Name] = N'Economy' AND
				MONTH(SR.DepartureTime) = MONTH(R.DepartureTime)
	) AS EconomyCapacity
FROM Trains.Train T
	INNER JOIN Trains.Car C ON C.TrainID = T.TrainID
	INNER JOIN Trains.CarType CT ON CT.CarTypeID = C.CarTypeID
	INNER JOIN Trains.[Route] R ON R.TrainID = T.TrainID
GROUP BY T.TrainID, MONTH(R.DepartureTime)
ORDER BY T.TrainID
GO