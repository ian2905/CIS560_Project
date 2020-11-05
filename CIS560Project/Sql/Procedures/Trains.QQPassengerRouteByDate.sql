--6: Number of routes and passengers on a particualar day
CREATE OR ALTER PROCEDURE Trains.QQPassengerRouteByDate
	@Date DateTimeOffSet
AS

SELECT COUNT(DISTINCT R.RouteID) AS RouteCount,
	COUNT(DISTINCT PR.PassengerRouteID) AS PassengerCount
FROM Trains.[Route] R
	INNER JOIN Trains.PassengerRoute PR ON PR.RouteID = R.RouteID
WHERE YEAR(R.DeprtureTime) = YEAR(@Date) AND
	MONTH(R.DeprtureTime) = MONTH(@Date) AND
	DAY(R.DeprtureTime) = DAY(@Date);
GO