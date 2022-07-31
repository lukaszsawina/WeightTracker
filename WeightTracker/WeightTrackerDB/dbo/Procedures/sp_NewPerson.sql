CREATE PROCEDURE [dbo].[sp_NewPerson]
	@Id int,
	@Name nvarchar(50),
	@Age int,
	@Height int
AS
	INSERT INTO Persons VALUES (@Id, @Name, @Age, @Height);
RETURN 0
