--Question Queries

----------------------------------------------------------------
--1: Get all PassengerRoutes for a Passenger
CREATE OR ALTER PROCEDURE Trains.QQGetPassengerRoutes
	@PassengerID INT
AS
SELECT PR.PassengerRouteID, PR.RouteID, PR.CarID, PR.TicketPrice
FROM Trains.PassengerRoute PR
WHERE PR.PassengerID = @PassengerID;
GO
----------------------------------------------------------------
--2: Get all routes from a particualr departure location
CREATE OR ALTER PROCEDURE Trains.QQGetRoutesByDL
   @DepartureLocation NVARCHAR(64)
AS

SELECT *
FROM Trains.[Routes] R
WHERE R.DepartureLocation = @DepartureLocation;
GO

----------------------------------------------------------------
--3: Amount spent for a particular customer
CREATE OR ALTER PROCEDURE Trains.QQSpentByPassenger
	@PassengerID INT
AS

SELECT SUM(PR.TicketPrice)
FROM Trains.PassengerRoute PR
WHERE PR.PassengerID = @PassengerID;
GO

----------------------------------------------------------------
--4: Get all Routes for a particular train
CREATE OR ALTER PROCEDURE Trains.QQGetRoutesByTrain
	@TrainID INT
AS

SELECT R.RouteID, R.TrainID, R.DepartureLocation, R.ArrivalLocation, R.DepartureTime, R.ArrivalTime, R.Distance
FROM Trains.Train T
	INNER JOIN Trains.[Route] R ON R.TrainID = T.TrainID
WHERE T.TrainID = @TrainID;

GO

----------------------------------------------------------------
--5: Find each first class passengers
CREATE OR ALTER PROCEDURE Trains.QQGetFirstClassPassengers
AS

SELECT P.PassengerID, P.FirstName, P.LastName, P.Email
FROM Trains.Car C
	INNER JOIN Trains.CarType CR ON CR.CarID = C.CarID
	INNER JOIN Trains.PassengerRoute PR ON PR.CarID = C.CarID
	INNER JOIN Trains.Passenger P ON P.PassengerID = PR.PassengerID
WHERE CR.[Name] = N'FirstClass';
GO

----------------------------------------------------------------
--6: Number of routes and passengers on a particualar day
CREATE OR ALTER PROCEDURE Trains.QQPassengerRouteByDate
	@Date DateTimeOffSet
AS

SELECT COUNT(DISTINCT R.RouteID) AS RouteCount,
	COUNT(DISTINCT PR.PassengerRouteID) AS PassengerCount
FROM Trains.[Route] R
	INNER JOIN Trains.PassengerRoute PR ON PR.RouteID = R.RouteID
WHERE YEAR(R.DeprtureTime) = YEAR(@Date) AND
	MONTH(R.DeprtureTime) = MONTH(@Date) AND
	DAY(R.DeprtureTime) = DAY(@Date);
GO

----------------------------------------------------------------
--7: All customers who have riden with a particular company
CREATE OR ALTER PROCEDURE Trains.QQPassengersForCompany
	@Company NVARCHAR(64)
AS

SELECT P.PassengerID, P.FirstName, P.LastName, P.Email
FROM Trains.Train T
	INNER JOIN Trains.Car C ON C.TrainID = T.TrainID
	INNER JOIN Trains.PassengerRoute PR ON PR.CarID = C.CarID
	INNER JOIN Trains.Passenger P ON P.PassengerID = PR.PassengerID
WHERE T.Company = @Company;
GO

----------------------------------------------------------------
--8: Get all trains for a particualr company
CREATE OR ALTER PROCEDURE Trains.QQGetTrainsByCompany
	@Company NVARCHAR(64)
AS
SELECT T.TrainID, T.[Name], T.Company, T.Driver, T.BaseSpeed, T.CarCapacity
FROM Trains.Train T
WHERE T.Company = @Company
GO

