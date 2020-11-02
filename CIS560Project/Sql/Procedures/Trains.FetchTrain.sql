CREATE OR ALTER PROCEDURE Trains.FetchTrain
   @TrainID INT
AS

SELECT T.[Name], T.Company, T.Driver, T.BaseSpeed, T.CarCapacity
FROM Trains.Train T
WHERE T.TrainID = @TrainID;
GO