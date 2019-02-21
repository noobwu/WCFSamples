IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'P_WITHDRAW')
	BEGIN
		DROP  Procedure  P_WITHDRAW
	END

GO

CREATE Procedure P_WITHDRAW
	(
		@id		VARCHAR(50),
		@amount FLOAT
	)
AS

IF NOT EXISTS(SELECT * FROM [dbo].[T_ACCOUNT] WHERE ID = @id)
	BEGIN
		RAISERROR ('AccountNotExists',16,1)
		RETURN
	END
	
IF NOT EXISTS(SELECT * FROM [dbo].[T_ACCOUNT] WHERE ID = @id AND BALANCE > @amount)
	BEGIN
		RAISERROR ('LackofBalance',16,1)
		RETURN
	END
	
UPDATE 	[dbo].[T_ACCOUNT] SET Balance = Balance - @amount WHERE Id = @id

GO