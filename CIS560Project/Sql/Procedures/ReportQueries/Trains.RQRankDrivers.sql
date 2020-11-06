--Report Query 1
--Create a monthly(Data will span a single year) ranking of the drivers of each train on
--how well they adhered to the expected travel time for each route they made in that year.
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