CREATE OR ALTER PROCEDURE Trains.QQGetPassengerRoutes
	@PassengerID INT
AS
SELECT PR.PassengerRouteID, PR.RouteID, PR.CarID, PR.TicketPrice
FROM Trains.PassengerRoute PR
WHERE PR.PassengerID = @PassengerID;
GO