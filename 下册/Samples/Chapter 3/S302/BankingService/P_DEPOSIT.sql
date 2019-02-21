IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'P_DEPOSIT')
	BEGIN
		DROP  Procedure  P_DEPOSIT
	END

GO

CREATE Procedure P_DEPOSIT
	(
		@id		VARCHAR(50),
		@amount FLOAT
	)
AS

IF NOT EXISTS(SELECT * FROM [dbo].[T_ACCOUNT] WHERE Id = @id)
	BEGIN
		RAISERROR ('AccountNotExists',16,1)
	END
UPDATE 	[dbo].[T_ACCOUNT] SET Balance = Balance + @amount WHERE Id = @id

GO