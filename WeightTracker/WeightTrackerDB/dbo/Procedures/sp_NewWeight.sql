CREATE PROCEDURE [dbo].[sp_NewWeight]
	@PersonId int,
	@Id int,
	@Weight float,
	@DateWhenAdd Date
AS
	INSERT INTO Weights (Weights.PersonId, Weights.Id, Weights.Weight, Weights.DateWhenAdd) VALUES (@PersonId, @Id, @Weight, @DateWhenAdd);
RETURN 0
