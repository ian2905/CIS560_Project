CREATE OR ALTER PROCEDURE Trains.FetchPassenger
   @PassengerID INT
AS

SELECT P.FirstName, P.LastName, P.Email
FROM Trains.Passenger P
WHERE P.PassengerID = @PassengerID;
GO
