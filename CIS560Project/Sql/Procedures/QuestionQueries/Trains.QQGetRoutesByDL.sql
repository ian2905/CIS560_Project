--2: Get all routes from a particualr departure location
CREATE OR ALTER PROCEDURE Trains.QQGetRoutesByDL
   @DepartureLocation NVARCHAR(64)
AS

SELECT *
FROM Trains.[Routes] R
WHERE R.DepartureLocation = @DepartureLocation;
GO