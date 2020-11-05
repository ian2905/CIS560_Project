--Report Query 3
--Rank each company on revanue and customer count per each month
CREATE OR ALTER PROCEDURE Trains.RQRankCompanies
AS

SELECT T.Company, 
	MONTH(R.DepartureTime) AS [MONTH],
	SUM(PR.TicketPrice) AS Revanue,
	RANK() OVER(
		PARTITION BY MONTH(R.DepartureTime)
		ORDER BY SUM(PR.TicketPrice)) AS RevanueRank,
	COUNT(DISTINCT PR.PassengerID) AS PassengerCount, 
	RANK() Over(
		PARTITION BY MONTH(R.DepartureTime)
		ORDER BY COUNT(DISTINCT PR.PassengerID)) AS CustomerCount
FROM Trains.Train T
	INNER JOIN Trains.Car C ON C.TrainID = T.TrainID
	INNER JOIN Trains.PassengerRoute PR ON PR.CarID = C.CarID
	INNER JOIN Trains.[Route] R ON R.RouteID = PR.RouteID
GROUP BY T.Company, MONTH(R.DepartureTime)
ORDER BY T.Company, MONTH(R.DepartureTime), Revanue, PassengerCount
GO
