CREATE OR ALTER PROCEDURE Trains.CreateTrain
	@Name NVARCHAR(32),
	@Company NVARCHAR(64),
	@Driver NVARCHAR(32),
	@BaseSpeed INT,
	@CarCapacity INT,
	@TrainID INT OUTPUT
AS

INSERT Trains.Train([Name], Company, Driver, BaseSpeed, CarCapacity)
VALUES(@Name, @Company, @Driver, @BaseSpeed, @CarCapacity);

SET @TrainID = SCOPE_IDENTITY();
GO
