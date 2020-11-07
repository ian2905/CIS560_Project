--7: All customers who have riden with a particular company
CREATE OR ALTER PROCEDURE Trains.QQ7PassengersForCompany
	@Company NVARCHAR(64)
AS

SELECT DISTINCT P.PassengerID, P.FirstName, P.LastName, P.Email
FROM Trains.Train T
	INNER JOIN Trains.Car C ON C.TrainID = T.TrainID
	INNER JOIN Trains.PassengerRoute PR ON PR.CarID = C.CarID
	INNER JOIN Trains.Passenger P ON P.PassengerID = PR.PassengerID
WHERE T.Company = @Company;
GO