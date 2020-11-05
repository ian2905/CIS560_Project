------------------------------------------------------------------
--1 Create a monthly(Data will span a single year) ranking of the drivers of each train on
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

------------------------------------------------------------------
--2: Find out, on a monthly basis, how close each train car is meeting capacity for each of the
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

------------------------------------------------------------------
--3 Rank each company on revanue and customer count per each month
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

------------------------------------------------------------------
--4 
--Top 10% of passenegers by distance as well as the amount of money each of those spent
--I would like this to be finding out what company they road with the most or what car type they road the most but idk how for now
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

