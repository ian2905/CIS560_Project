CREATE OR ALTER PROCEDURE Train.AddArrivalTime
	@ArrivalTime DATETIMEOFFSET,
	@RouteID INT
AS

UPDATE Trains.[Route]
SET ArrivalTime = @ArrivalTime
WHERE RouteID = @RouteID;
GO
