CREATE OR ALTER PROCEDURE Trains.FetchCarType
   @CarTypeID INT
AS

SELECT CT.[Name]
FROM Trains.CarType CT
WHERE CT.CarTypeID = @CarTypeID;
GO