--3: Amount spent for a particular customer
CREATE OR ALTER PROCEDURE Trains.QQ8SpentByPassenger
	@PassengerID INT
AS

SELECT DISTINCT PR.PassengerID, PR.FirstName, PR.LastName, SUM(PR.TicketPrice) AS AmountSpent
FROM Trains.PassengerRoute PR
WHERE PR.PassengerID = @PassengerID
GROUP BY PR.PassengerID
ORDER BY PR.PassengerID;
GO