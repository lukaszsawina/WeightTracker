CREATE PROCEDURE [dbo].[sp_DeleteWeight]
	@id int
AS
	DELETE FROM Weights WHERE Id = @id;