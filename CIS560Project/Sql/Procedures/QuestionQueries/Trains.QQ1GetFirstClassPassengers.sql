--5: Find each first class passengers
CREATE OR ALTER PROCEDURE Trains.QQ1GetFirstClassPassengers
AS

SELECT DISTINCT P.PassengerID, P.FirstName, P.LastName, P.Email
FROM Trains.Car C
	INNER JOIN Trains.CarType CR ON CR.CarID = C.CarID
	INNER JOIN Trains.PassengerRoute PR ON PR.CarID = C.CarID
	INNER JOIN Trains.Passenger P ON P.PassengerID = PR.PassengerID
WHERE CR.[Name] = N'FirstClass';
GO