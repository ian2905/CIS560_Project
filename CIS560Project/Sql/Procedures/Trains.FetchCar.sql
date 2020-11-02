CREATE OR ALTER PROCEDURE Trains.FetchCar
   @CarID INT
AS

SELECT C.TrainID, C.CarTypeID, C.TicketPrice, C.PassengerCapacity
FROM Trains.Car C
WHERE C.CarID = @CarID;
GO