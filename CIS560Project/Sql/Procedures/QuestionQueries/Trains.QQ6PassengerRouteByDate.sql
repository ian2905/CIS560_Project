--6: Number of routes and passengers on a particualar day
CREATE OR ALTER PROCEDURE Trains.QQ6PassengerRouteByDate
	@DepartureTime DateTimeOffSet
AS

SELECT R.DepartureTime,
	COUNT(DISTINCT R.RouteID) AS RouteCount,
	COUNT(DISTINCT PR.PassengerRouteID) AS PassengerCount
FROM Trains.[Route] R
	INNER JOIN Trains.PassengerRoute PR ON PR.RouteID = R.RouteID
WHERE YEAR(R.DepartureTime) = YEAR(@Date) AND
	MONTH(R.DepartureTime) = MONTH(@Date) AND
	DAY(R.DepartureTime) = DAY(@Date);
GO