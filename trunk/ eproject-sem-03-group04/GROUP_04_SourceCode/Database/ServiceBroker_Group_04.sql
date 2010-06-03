USE OnlinePostOffice
GO

ALTER DATABASE OnlinePostOffice
SET enable_broker

CREATE XML SCHEMA COLLECTION EmployeeInfoSchema as
N'<?xml version="1.0" encoding="utf-16"?>
<xsd:schema xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <xsd:element name="EmployeeInfo">
    <xsd:complexType>
      <xsd:sequence>
        <xsd:element name="employeeId" type="xsd:string"/>
        <xsd:element name="employeeEmail" type="xsd:string"/>
        <xsd:element name="employeePassword" type="xsd:string"/>
        <xsd:element name="employeeFirstName" type="xsd:string"/>
        <xsd:element name="employeeLastName" type="xsd:string"/>
        <xsd:element name="employeeBirthday" type="xsd:date"/>
        <xsd:element name="employeeSex" type="xsd:string"/>
		<xsd:element name="employeeAddress" type="xsd:string"/>
		<xsd:element name="employeePhone" type="xsd:string"/>
		<xsd:element name="employeeImage" type="xsd:string"/>
      </xsd:sequence>
    </xsd:complexType>
  </xsd:element>
</xsd:schema>'
GO
--------------*************
CREATE TABLE  AcceptRequestS 
(
	id  INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeInfo XML(CONTENT EmployeeInfoSchema) 
)
GO
-------------********************
CREATE MESSAGE TYPE AddEmployeeType 
VALIDATION = VALID_XML WITH SCHEMA COLLECTION EmployeeInfoSchema
GO
----------********************-------------------
CREATE CONTRACT AddEmployeeContract
(
	AddEmployeeType SENT BY INITIATOR
)
GO
----------********************-------------------
CREATE QUEUE RequestQueue 
WITH STATUS = ON
GO
----------********************-------------------
CREATE SERVICE AddEmployeeClientService  
ON QUEUE RequestQueue(AddEmployeeContract)
GO
----------********************-------------------
CREATE SERVICE AddEmployeeServerService 
ON QUEUE RequestQueue(AddEmployeeContract)
GO
----------********************-------------------
CREATE PROCEDURE EditProfileEmployeeProcedure 
	@employeeId			VARCHAR(10),
	@employeeEmail		VARCHAR(50),
	@employeePassword	VARCHAR(50),
	@employeeFirstName	VARCHAR(50),
	@employeeLastName	VARCHAR(50),
	@employeeBirthday	DATETIME,
	@employeeSex		BIT,
	@employeeAddress	VARCHAR(250),
	@employeePhone		VARCHAR(20),
	@employeeImage		VARCHAR(150)
AS 
BEGIN 
	DECLARE @AddEmployeeHandle UNIQUEIDENTIFIER, 
			@TempMessage varchar(1000),
			@AddEmployeeMessage xml 
	SET @TempMessage = N'<?xml version="1.0"?> 
	<EmployeeInfo>
		<employeeId>'+ @employeeId +'</employeeId>
		<employeeEmail>'+ @employeeEmail +'</employeeEmail>
		<employeePassword>'+ @employeePassword +'</employeePassword>
		<employeeFirstName>'+ @employeeFirstName +'</employeeFirstName>
		<employeeLastName>'+ @employeeLastName +'</employeeLastName>
		<employeeBirthday>'+ @employeeBirthday +'</employeeBirthday>
		<employeeSex>'+ CAST(@employeeSex AS varchar) +'</employeeSex>
		<employeeAddress>'+ @employeeAddress +'</employeeAddress>
		<employeePhone>'+ @employeePhone +'</employeePhone>
		<employeeImage>'+ @employeeImage +'</employeeImage>
	</EmployeeInfo>' 
	SET @AddEmployeeMessage = @TempMessage

	BEGIN DIALOG CONVERSATION @AddEmployeeHandle 
	  FROM SERVICE AddEmployeeClientService 
	  TO SERVICE 'AddEmployeeServerService' 
	  ON CONTRACT AddEmployeeContract 
	  WITH ENCRYPTION = OFF;

	  SEND ON CONVERSATION @AddEmployeeHandle  
	  MESSAGE TYPE AddEmployeeType (@AddEmployeeMessage)
END
GO
----------********************-------------------
CREATE PROCEDURE AcceptChangeEmployeeProcedure 
AS 
BEGIN 
	DECLARE	@employeeId			VARCHAR(10);
	DECLARE	@employeeEmail		VARCHAR(50);
	DECLARE	@employeePassword	VARCHAR(50);
	DECLARE	@employeeFirstName	VARCHAR(50);
	DECLARE	@employeeLastName	VARCHAR(50);
	DECLARE	@employeeBirthday	DATETIME;
	DECLARE	@employeeSex		BIT;
	DECLARE	@employeeAddress	VARCHAR(250);
	DECLARE	@employeePhone		VARCHAR(20);
	DECLARE	@employeeImage		VARCHAR(150),
	@message xml(CONTENT EmployeeInfoSchema)
	DECLARE @RequestTable TABLE
	(
		message_body varbinary(max)
	);

	RECEIVE message_body FROM RequestQueue INTO @RequestTable 
	SET @message			= (SELECT CAST(message_body AS XML) FROM @RequestTable); 
	SET @employeeId			= @message.value('(/EmployeeInfo/employeeId)[1]', 'varchar(10)');
	SET	@employeeEmail		= @message.value('(/EmployeeInfo/employeeEmail)[1]', 'varchar(50)');
	SET	@employeePassword	= @message.value('(/EmployeeInfo/employeePassword)[1]', 'varchar(50)');
	SET	@employeeFirstName	= @message.value('(/EmployeeInfo/employeeFirstName)[1]', 'varchar(50)');
	SET	@employeeLastName	= @message.value('(/EmployeeInfo/employeeLastName)[1]', 'varchar(50)');
	SET	@employeeBirthday	= @message.value('(/EmployeeInfo/employeeBirthday)[1]', 'DATETIME');
	SET	@employeeSex		= @message.value('(/EmployeeInfo/employeeSex)[1]', 'BIT');
	SET	@employeeAddress	= @message.value('(/EmployeeInfo/employeeAddress)[1]', 'varchar(250)');
	SET	@employeePhone		= @message.value('(/EmployeeInfo/employeePhone)[1]', 'varchar(15)');
	SET	@employeeImage		= @message.value('(/EmployeeInfo/employeeImage)[1]', 'varchar(250)');
	---
	UPDATE EMPLOYEE
	SET
		employeeEmail=@employeeEmail,
		employeePassword=@employeePassword,
		employeeFirstName=@employeeFirstName,
		employeeLastName=@employeeLastName,
		employeeBirthday=@employeeBirthday,
		employeeSex=@employeeSex,
		employeeAddress=@employeeAddress,
		employeePhone=@employeePhone,
		employeeImage=@employeeImage
	WHERE employeeId=@employeeId
	
	---
END
