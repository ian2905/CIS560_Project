--3: Amount spent for a particular customer
CREATE OR ALTER PROCEDURE Trains.QQSpentByPassenger
	@PassengerID INT
AS

SELECT SUM(PR.TicketPrice)
FROM Trains.PassengerRoute PR
WHERE PR.PassengerID = @PassengerID;
GO