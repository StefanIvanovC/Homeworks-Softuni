USE Bank

CREATE FUNCTION ufn_CalculateFutureValue (@sum decimal(15,2), @yearly float, @numberYear int)
	RETURNS DECIMAL(15,4)
	BEGIN 
		DECLARE @Result DECIMAL(15,4)
		SET @Result = (@sum * POWER((1 + @yearly), @numberYear))
		RETURN @Result
	END

	SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)