USE OnlinePostOffice
GO


DROP PROC WebLogin

CREATE PROCEDURE WebLogin
	@email			VARCHAR(250),
	@password		VARCHAR(50),
	@result			VARCHAR(3) OUTPUT
AS
BEGIN
	SET @result='HEO'
	IF EXISTS (SELECT customerEmail FROM CUSTOMER WHERE customerEmail = @email AND customerPassword = @password)
		BEGIN 
			SET @result='CUS'
		END		
	ELSE IF  EXISTS (SELECT employeeEmail FROM EMPLOYEE WHERE employeeEmail = @email AND employeePassword = @password AND roleId='ROL0000001')
		BEGIN 
			SET @result='ADM'
		END		
	ELSE IF EXISTS(SELECT employeeEmail FROM EMPLOYEE WHERE employeeEmail = @email AND employeePassword = @password AND roleId='ROL0000001')
		BEGIN 
			SET @result='EPL'
		END				
END

DECLARE @KQ VARCHAR(3)
EXEC WebLogin 'tandatgocong@gmail.com','beheo1207',@result = @KQ OUTPUT
PRINT @KQ