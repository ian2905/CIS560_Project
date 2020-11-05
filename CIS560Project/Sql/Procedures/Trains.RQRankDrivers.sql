--Report Query 1
CREATE OR ALTER PROCEDURE Trains.RQRankDrivers
AS

SELECT T.Driver, 
	MONTH(R.DepartureTime) AS [Month]
	SUM( CAST(R.Distance * T.BaseSpeed) / CAST(DATEDIFF(MI, R.ArrivalTime, R.DepartureTime) AS INT)) / COUNT(DISTINCT R.RouteID) AS AverageTime,
	RANK() OVER (
		PARTITION BY MONTH(R.DepartureTime)
		ORDER BY SUM( (R.Distance * T.BaseSpeed) / (R.ArrivalTime - R.DepartureTime)) / COUNT(DISTINCT R.RouteID) DESC
		) AS DriverRank
FROM Trains.Train T
	INNER JOIN Trains.[Route] R ON R.TrainID = T.TrainID
WHERE R.ArrivalTime IS NOT NULL
GROUP BY T.Driver, MONTH(R.DepartureTime)
ORDER BY AverageTime
GO