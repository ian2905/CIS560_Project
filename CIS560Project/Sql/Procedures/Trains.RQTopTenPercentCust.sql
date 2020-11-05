--Report Query 4
CREATE OR ALTER PROCEDURE Trains.RQTopTenPercentCust
AS

SELECT P.PassengerID, P.FirstName, P.LastName,
	SUM(R.Distance) AS DistanceTraveled,
	NTILE(10) OVER(ORDER BY SUM(R.Distance) DESC) AS TravelRank,
	(
		SELECT 
		FROM Trains.Train T
			INNER JOIN Trains.[Route] SR ON SR.TrainID = T.TrainID
		WHERE SR.RouteID = PR.RouteID
	),
	SUM(PR.TricketPrice) AS AmountSpent
		
FROM Trains.Passenger P
	INNER JOIN Trains.PassengerRoute PR ON PR.PassengerID = P.PassengerID
	INNER JOIN Trains.[Route] R ON R.RouteID = PR.RouteID
GROUP BY P.PassengerID, P.FirstName, P.LastName
ORDER BY DistanceTraveled DESC
GO
