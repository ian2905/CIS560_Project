IF NOT EXISTS
    (
        SELECT *
        FROM sys.schemas s
        WHERE s.[name] = N'Trains'
    )
BEGIN
    EXEC(N'CREATE SCHEMA [Trains] AUTHORIZATION [dbo]');
END;
