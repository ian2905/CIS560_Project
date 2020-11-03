CREATE OR ALTER PROCEDURE Trains.FetchPassengerRoute
   @PassengerRouteID INT
AS

SELECT PR.PassengerID, PR.RouteID, PR.CarID, PR.TicketPrice
FROM Trains.PassengerRoute PR
WHERE P.PassengerRouteID = @PassengerRouteID;
GO
