--Get all PassengerRoutes for a Passenger
CREATE OR ALTER PROCEDURE Trains.QQ2GetPassengerRoutes
	@PassengerID INT
AS
SELECT PR.PassengerRouteID, PR.RouteID, PR.CarID, PR.TicketPrice
FROM Trains.PassengerRoute PR
WHERE PR.PassengerID = @PassengerID;
GO
