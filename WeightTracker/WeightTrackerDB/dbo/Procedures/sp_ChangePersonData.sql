CREATE PROCEDURE [dbo].[sp_ChangePersonData]
	@id int,
	@name nvarchar(50),
	@age int,
	@height int
AS
	UPDATE Persons SET Name = @name, Age = @age, Height = @height WHERE Id = @id;
RETURN 0
