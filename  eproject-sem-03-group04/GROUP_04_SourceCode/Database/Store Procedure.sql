USE OnlinePostOffice
GO

 
DROP PROC WebLogin

CREATE PROCEDURE WebLogin
	@email			VARCHAR(250),
	@password		VARCHAR(50),
	@result			VARCHAR(3) OUTPUT
AS
BEGIN
	IF EXISTS (SELECT customerEmail FROM CUSTOMER WHERE customerEmail = @email AND customerPassword = @password)
		BEGIN 
			SET @result='CUS'
		END		
	ELSE IF  EXISTS (SELECT employeeEmail FROM EMPLOYEE WHERE employeeEmail = @email AND employeePassword = @password AND roleId='R0000001')
		BEGIN 
			SET @result='ADM'
		END		
	ELSE IF EXISTS(SELECT employeeEmail FROM EMPLOYEE WHERE employeeEmail = @email AND employeePassword = @password AND roleId='R0000002')
		BEGIN 
			SET @result='EPL'
		END		
	ELSE 
		BEGIN 
			SET @result='NULL'
		END		
END

DECLARE @KQ VARCHAR(3)
EXEC WebLogin 'trangtrang','234',@result = @KQ OUTPUT
PRINT @KQ