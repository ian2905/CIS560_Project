--8: Get all trains for a particualr company
CREATE OR ALTER PROCEDURE Trains.QQ5GetTrainsByCompany
	@Company NVARCHAR(64)
AS
SELECT T.TrainID, T.[Name], T.Company, T.Driver, T.BaseSpeed, T.CarCapacity
FROM Trains.Train T
WHERE T.Company = @Company
GO