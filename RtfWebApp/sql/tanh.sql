CREATE FUNCTION GetTanH(@x float) 
RETURNS float
AS
BEGIN
	return (EXP(@x) - EXP(-@x)) / (EXP(@x) + EXP(-@x))
END


