CREATE PROCEDURE [dbo].[sp_SelectWeightsByPerson]
	@PersonId int
AS
	SELECT w.Id, w.Weight, w.DateWhenAdd FROM Weights as w WHERE w.PersonId = @PersonId;

