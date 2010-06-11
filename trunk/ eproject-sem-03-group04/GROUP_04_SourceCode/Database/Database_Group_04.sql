USE master
GO

DROP DATABASE OnlinePostOffice
GO


CREATE DATABASE OnlinePostOffice
GO
 
USE OnlinePostOffice
GO

--- TABLE BRANCHES
CREATE TABLE BRANCH
(
	branchPin		VARCHAR(10) NOT NULL,
	branchName		VARCHAR(50) NOT NULL,
	branchAddress	VARCHAR(250) NOT NULL,
	branchPhone	VARCHAR(20) NOT NULL,
	CONSTRAINT PK_BRANCHES PRIMARY KEY(branchPin)
)
GO

--- TABLE OFFICES
CREATE TABLE OFFICE
(
	offficeId		VARCHAR(10) NOT NULL,
	officeName		VARCHAR(50) NOT NULL,
	officeAddress	VARCHAR(250) NOT NULL,
	officePhone		VARCHAR(15) NOT NULL,
	officeMail		VARCHAR(50) NOT NULL,
	branchPin		VARCHAR(10) NOT NULL,
	CONSTRAINT PK_OFFICES PRIMARY KEY(offficeId)
)
GO

ALTER TABLE OFFICE
ADD CONSTRAINT FK_OFFICE_BRANCHE FOREIGN KEY(branchPin) REFERENCES  BRANCH(branchPin)
GO

--- TABLE ROLE
CREATE TABLE [ROLE]
(
	roleId			VARCHAR(10) NOT NULL,
	roleName	 	VARCHAR(50) NOT NULL,
	roleDecriptions	VARCHAR(250) NULL,
	CONSTRAINT PK_ROLES PRIMARY KEY(roleId)
)
GO

---- TABLE EMPLOYEE
CREATE TABLE EMPLOYEE
(
	employeeId			VARCHAR(10) NOT NULL,
	employeeEmail		VARCHAR(50) NOT NULL,
	employeePassword	VARCHAR(50) NOT NULL,
	employeeFirstName	VARCHAR(50) NOT NULL,
	employeeLastName	VARCHAR(50) NOT NULL,
	employeeBirthday	DATETIME NOT NULL,
	employeeSex			BIT NOT NULL,
	employeeAddress		VARCHAR(250) NOT NULL,
	employeePhone		VARCHAR(20) NULL,
	employeeImage		VARCHAR(150) NULL,
	offficeId			VARCHAR(10) NOT NULL,
	roleId				VARCHAR(10) NOT NULL,
	CONSTRAINT PK_EMPLOYEE PRIMARY KEY(employeeId)
)
GO

ALTER TABLE EMPLOYEE
ADD CONSTRAINT FK_EMPLOYEE_OFFICE FOREIGN KEY(offficeId) REFERENCES  OFFICE(offficeId)
GO

ALTER TABLE EMPLOYEE
ADD CONSTRAINT FK_EMPLOYEE_ROLE FOREIGN KEY(roleId) REFERENCES  [ROLE](roleId)
GO

--- TABLE CUSTOMER
CREATE TABLE CUSTOMER
(
	customerId			VARCHAR(10) NOT NULL,
	customerEmail		VARCHAR(50) NOT NULL,
	customerPassword	VARCHAR(50) NOT NULL,
	customerFistName	VARCHAR(50) NOT NULL,
	customerLastName	VARCHAR(50) NOT NULL,
	customerBirthday	DATETIME NULL,
	customerSex			BIT NULL,
	customerAddress		VARCHAR(250) NOT NULL,
	customerPhone		VARCHAR(25) NULL,
	CONSTRAINT PK_CUSTOMER PRIMARY KEY(customerId)
)
GO

------- TABLE SERVICESTYPE
CREATE TABLE SERVICESTYPE
(
	servicesId			VARCHAR(10) NOT NULL,
	servicesName		VARCHAR(50) NOT NULL,
	servicesDecriptions	VARCHAR(250) NULL,
	servicesCharges		FLOAT  NOT NULL,
	CONSTRAINT PK_SERVICESTYPE PRIMARY KEY(servicesId)
)
GO

------- TABLE DELIVERABLE
CREATE TABLE DELIVERABLE
(
	deliverablePin			VARCHAR(10) NOT NULL,
	customerSent			VARCHAR(10) NOT NULL,
	deliverableSubject		VARCHAR(50) NOT NULL,
	deliverableDecriptions	VARCHAR(250) NULL,
	dateSent				DATETIME NOT NULL,
	dateReceived			DATETIME NULL,
	personNameReceived		VARCHAR(50) NOT NULL,
	personAddressReceived	VARCHAR(250) NOT NULL,
	personPhoneReceived		VARCHAR(20) NULL,
	personEmailReceived		VARCHAR(50) NULL,
	totalWeight				FLOAT  NOT NULL,
	totalDistance			FLOAT  NOT NULL,
	totalCharges			FLOAT NOT NULL,
	deliverableStatus		BIT NOT NULL,
	deliverableNote			VARCHAR(250) NULL,
	servicesType			VARCHAR(10)  NOT NULL,
	employeeId				VARCHAR(10)  NULL,
	CONSTRAINT PK_DELIVERABLE PRIMARY KEY(deliverablePin)
)
GO

ALTER TABLE DELIVERABLE
ADD CONSTRAINT FK_DELIVERABLE_CUSTOMER FOREIGN KEY(customerSent) REFERENCES  CUSTOMER(customerId)
GO

ALTER TABLE DELIVERABLE
ADD CONSTRAINT FK_DELIVERABLE_SERVICESTYPE FOREIGN KEY(servicesType) REFERENCES  SERVICESTYPE(servicesId)
GO

ALTER TABLE DELIVERABLE
ADD CONSTRAINT FK_DELIVERABLE_EMPLOYEE FOREIGN KEY(employeeId) REFERENCES  EMPLOYEE(employeeId)
GO

----------- TABLE DELIVERABLE_DETAIL
CREATE TABLE DELIVERABLE_DETAIL
(
	detailId		VARCHAR(10) NOT NULL,
	deliverablePin	VARCHAR(10) NOT NULL,
	deliverableName	VARCHAR(50) NOT NULL,
	deivrableWeight	FLOAT NOT NULL,
	Decriptions		VARCHAR(250) NULL,
	Note			VARCHAR(250) NULL,
	CONSTRAINT PK_DELIVERABLE_DETAIL PRIMARY KEY(detailId,deliverablePin)
)
GO

ALTER TABLE DELIVERABLE_DETAIL
ADD CONSTRAINT FK_DELIVERABLE_DETAIL_DELIVERABLE FOREIGN KEY(deliverablePin) REFERENCES  DELIVERABLE(deliverablePin)
GO

----------- TABLE CHARGES_ON_WEIGHT
CREATE TABLE CHARGES_ON_WEIGHT
(
	Id				VARCHAR(10) NOT NULL,
	Decriptons		VARCHAR(250) NOT NULL,
	weightMin		FLOAT NOT NULL,
	weightMax		FLOAT NOT NULL,
	Charges			FLOAT NOT NULL,
	Note			VARCHAR(250) NULL,
	servicesType	VARCHAR(10)  NOT NULL,
	CONSTRAINT PK_DCHARGES_ON_WEIGHT PRIMARY KEY(Id)
)
GO

ALTER TABLE CHARGES_ON_WEIGHT
ADD CONSTRAINT FK_CHARGES_ON_WEIGHT FOREIGN KEY(servicesType) REFERENCES  SERVICESTYPE(servicesId)
GO

----------- TABLE CHARGES_ON_WEIGHT
CREATE TABLE CHARGES_ON_DISTANCE
(
	Id				VARCHAR(10) NOT NULL,
	Decriptons		VARCHAR(250) NOT NULL,
	distanceFrom	FLOAT NOT NULL,
	distanceTo		FLOAT NOT NULL,
	Charges			FLOAT NOT NULL,
	Note			VARCHAR(250) NOT NULL,
	servicesType	VARCHAR(10) NOT NULL,
	CONSTRAINT PK_CHARGES_ON_DISTANCE PRIMARY KEY(Id)
)
GO

ALTER TABLE CHARGES_ON_DISTANCE
ADD CONSTRAINT FK_CHARGES_ON_DISTANCE FOREIGN KEY(servicesType) REFERENCES  SERVICESTYPE(servicesId)
GO

----- TABLE FEEDBACK_AND_CONTACT
CREATE TABLE FEEDBACK_AND_CONTACT
(
	Id			VARCHAR(10) NOT NULL,
	[Name]		VARCHAR(50) NOT NULL,
	Email		VARCHAR(50) NOT NULL,
	Address		VARCHAR(250) NOT NULL,
	Phone		VARCHAR(20) NULL,
	Subject		VARCHAR(50) NOT NULL,
	Contend		VARCHAR(250) NOT NULL,
	datesubmit	DATETIME NOT NULL,
	status		BIT NOT NULL,
	CONSTRAINT PK_FEEDBACK_AND_CONTACT PRIMARY KEY(Id)
)
GO
----- TABLE COUNT_VISIT
CREATE TABLE COUNT_VISIT
(
	[count]  INT NOT NULL
)
GO

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

CREATE TABLE  AcceptRequest
(
	id  INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeInfo XML(CONTENT EmployeeInfoSchema) 
)
GO
-------------------------------------------
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
	DECLARE @Temp varchar(1000)		
	SET @Temp = N'<?xml version="1.0"?> 
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
	
	INSERT INTO AcceptRequest(EmployeeInfo)	VALUES(@Temp)
END
GO
------------------------------------
CREATE PROCEDURE AcceptChangeEmployeeProcedure 
 @id INT
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
	
	SET @message			= (SELECT CAST(EmployeeInfo AS XML) FROM AcceptRequest WHERE id=@id ); 
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
		employeePassword=@employeePassword,
		employeeFirstName=@employeeFirstName,
		employeeLastName=@employeeLastName,
		employeeBirthday=@employeeBirthday,
		employeeSex=@employeeSex,
		employeeAddress=@employeeAddress,
		employeePhone=@employeePhone,
		employeeImage=@employeeImage
	WHERE employeeId=@employeeId
	DELETE FROM AcceptRequest WHERE id=@id
	--- 
END
GO
----------------------
-- Check User Login
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
	ELSE IF EXISTS(SELECT employeeEmail FROM EMPLOYEE WHERE employeeEmail = @email AND employeePassword = @password AND roleId='ROL0000002')
		BEGIN 
			SET @result='EPL'
		END				
END
GO
------------------
-- Check Email EXISTS
CREATE PROCEDURE IsExisted
	@email			VARCHAR(250),	
	@result			BIT OUTPUT
AS
BEGIN
	SET @result= 1
	IF EXISTS (SELECT customerEmail FROM CUSTOMER WHERE customerEmail = @email)
		BEGIN 
			SET @result=0
		END		
	ELSE IF  EXISTS (SELECT employeeEmail FROM EMPLOYEE WHERE employeeEmail = @email)
		BEGIN 
			SET @result=0
		END					
END
GO
------------------------------------ INSERT RECORD -------------------------------
-- Table BRANCH
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000001','HO CHI MINH','128, CMT8 Street, Ward 5, Tan Binh District','(84)08-39906511')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000002','HA NOI','41/37 SHN, Tien Su, Mon Khoai ward, Su District','(84)04-39905678')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000003','THANH PHO VINH','5/2, Van Long street, Ward 10, HK District','(84)065-3990568')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000004','DA NANG','145, Ba Ku street, District 10','(84)08-39906511')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000005','NHA TRANG','22/11/2, Luu Tu street, Tan Thanh ward, District 2','(84)08-39907689')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000006','BINH THUAN','144/222, Van Thanh street, 7 ward, District 1','(84)07-39999911')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000007','BINH DUONG','300 KAP, Lung Tung street, Ward 4, Li Tinh District','(84)04-3000011')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000008','KIEN GIANG','123 Tolo, Nga Voi, Muong','(84)08-38888511')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000009','HAU GIANG','22, Kho Xeng, Thanh Tan ward, District 15','(84)064-39977771')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000010','TIEN GIANG','92/224, Tran Thai Binh, Gia Tan ward. District 8','(84)04-3996511')
INSERT INTO BRANCH (branchPin,branchName,branchAddress,branchPhone) VALUES('BR00000011','CAN THO','128, Au Co Street, Ward 5, Tan Binh District','(84)06-3990000511')
-- Table Office
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000001','Hong Ha Office','12/22, Tran Hung Dao, ward 10, Binh Thanh district','(84)08-39906511','officehcm01@onlinepostoffice.com','BR00000001')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000002','Phu Thanh Office','2, Luu Tu street, Tan Thanh ward, District 2','(84)08-39322321','officehcm02@onlinepostoffice.com','BR00000001')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000003','Binh Phuoc Office','12/22, Tran Hung Dao, ward 10, Binh Thanh district','(84)08-35346561','officehcm04@onlinepostoffice.com','BR00000001')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000004','Thanh Binh Office','5, Van Long street, Ward 10, HK District','(84)06-78546535','officehcm05@onlinepostoffice.com','BR00000002')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000005','Nguyen Trai Office','2, Luu Tu street, Tan Thanh ward, District 2','(84)06-65365436','officehcm06@onlinepostoffice.com','BR00000002')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000006','Binh Hung Office','5, Van Long street, Ward 10, HK District','(84)04-86587658','officehcm07@onlinepostoffice.com','BR00000003')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000007','Chi Thanh Office','12/22, Tran Hung Dao, ward 10, Binh Thanh district','(84)05-39906511','officehcm08@onlinepostoffice.com','BR00000003')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000008','Luu Tu Office','2, Luu Tu street, Tan Thanh ward, District 2','(84)06-97698696','officehcm09@onlinepostoffice.com','BR00000004')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000009','Van Long Office','5, Van Long street, Ward 10, HK District','(84)04-21343143','officehanoi@onlinepostoffice.com','BR00000004')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000010','Tran Hung Dao Office','12/22, Tran Hung Dao, ward 10, Binh Thanh district','(84)05-53432754','officehaiph@onlinepostoffice.com','BR00000005')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000011','Au Co Office','12, Au Co Street, Ward 5, Tan Binh District','(84)07-53686007','officecanth@onlinepostoffice.com','BR00000005')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000012','Van Truy Office','5, Van Long street, Ward 10, HK District','(84)07-36587656','officenhatr@onlinepostoffice.com','BR00000006')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000013','Thanh Tunng Office','12, Au Co Street, Ward 5, Tan Binh District','(84)04-21432543','nhatrang@onlinepostoffice.com','BR00000006')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000014','Che Lan Office','12/22, Tran Hung Dao, ward 10, Binh Thanh district','(84)63-87464355','tienggorg@onlinepostoffice.com','BR00000007')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000015','Go Cong Office','12, Au Co Street, Ward 5, Tan Binh District','(84)63-25457654','haugiangorg@onlinepostoffice.com','BR00000008')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000016','Thanh Binh Office','2, Luu Tu street, Tan Thanh ward, District 2','(84)62-65438453','lamdongorg@onlinepostoffice.com','BR00000009')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000017','New Work Office','12/22, Tran Hung Dao, ward 10, Binh Thanh district','(84)02-54356765','linhtuanhcm@onlinepostoffice.com','BR00000010')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000018','Dimon Office','5, Van Long street, Ward 10, HK District','(84)05-78784532','thanhtamhcm@onlinepostoffice.com','BR00000011')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000019','Thuan Kieu Office','2, Luu Tu street, Tan Thanh ward, District 2','(84)03-24544676','nguyenthanhct@onlinepostoffice.com','BR00000011')
INSERT INTO OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) VALUES('OF00000020','Partion Office','12/22, Tran Hung Dao, ward 10, Binh Thanh district','(84)09-96424254','datlthcm@onlinepostoffice.com','BR00000011')
-- Table ROLE
INSERT INTO [ROLE] (roleId,roleName,roleDecriptions) VALUES ('ROL0000001','Administrator','Manager Systems')
INSERT INTO [ROLE] (roleId,roleName,roleDecriptions) VALUES ('ROL0000002','Employee','')
-- Table SERVICESTYPE
INSERT INTO SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) VALUES ('SEV0000001','Courier','man posting mails',12000)
INSERT INTO SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) VALUES ('SEV0000002','VPP','package posting',9000)
INSERT INTO SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) VALUES ('SEV0000003','Speed Post','Fast Delivery',5000)
INSERT INTO SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) VALUES ('SEV0000004','Normal Post','Normal Posting',15000)
-- Table EMPLOYEE
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000001','tandatgocong@gmail.com','beheo1207','DAT','LE TAN','11/30/1988',0,'128, CMT8 Street, Ward 5, Tan Binh District','0909093433','employee1.jpg','OF00000001','ROL0000001')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000002','ngothao@gmail.com','123','LAN','LE THI','10/15/1986',1,'25, Tran Dinh Xu Street, Ward 1, 1 District','0906010843','employee2.jpg','OF00000001','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000003','foreverlove@yahoo.com','123','TUAN','NGUYEN VAN','3/5/1978',0,'22 ,Nguyen Trai Street, Ward 7, 5 District','0932898098','employee3.jpg','OF00000002','ROL0000001')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000004','tuongmap@yahoo.com','123','TUONG','MAP','11/5/1989',0,'195/222, Pham Van Hai, Ward 8, Tan Binh District','0958333829','employee4.jpg','OF00000003','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000005','tuandinh@yahoo.com','123','DINH','TRAN TUAN','12/19/1978',0,'48 ,Nguyen Thai Son Street, Ward 4, Tan Phu District','0911758848','employee5.jpg','OF00000004','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000006','trangnumberone@gmail.com','123','TRANG','NGUYEN THI THUY','12/12/1988',1,'84/294 ,Le Loi Street, Ward 1, 1 District','0981847365','employee6.jpg','OF00000004','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000007','tienthanh@hotmail.com','123','TIEN','TRAN THANH','3/5/1988',0,'325 ,Le Dai Hanh Street, Ward 13, 11 District','0973659234','employee7.jpg','OF00000002','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000008','vovanhai@yahoo.com','123','HAI','VO VAN','4/27/1987',0,'99/35/223 ,Tran Hung Dao Street, Ward 4, 1 District','01227748362','employee8.jpg','OF00000001','ROL0000001')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000009','nguyenson@freemail.com','123','SON','NGUYEN','1/5/1982',1,'44bis ,Su Van Hanh Street, Ward 4, 10 District','01219283745','employee9.jpg','OF00000001','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000010','thanhphuong@gmail.com','123','PHUONG','NGUYEN THANH','9/16/1985',1,'76 ,Hoa Hao Street, Ward 3, 10 District','0909183756','employee10.jpg','OF00000002','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000011','theduy@yahoo.com','dongian12','DUY','PHAM THE','4/7/1979',1,'485/242 ,Hung Vuong Street, Ward 9, 5 District','0901847563','employee11.jpg','OF00000003','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000012','thanhthao@hotmail.com','phuctap86','THAO','HONG THI PHUONG','3/5/1983',0,'44/2 ,Ba Hat Street, Ward 7, 10 District','0937366352','employee12.jpg','OF00000004','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000013','binhminh@gmail.com','datgia','MINH','NGUYEN BINH','2/5/1978',1,'544 ,An Duong Vuong Street, Ward 8, 10 District','0947264753','employee13.jpg','OF00000004','ROL0000002')
INSERT INTO EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId)
 VALUES ('EMP0000014','kimbien@yahoo.com','chandoi','BIEN','NGUYEN VAN','11/11/1986',1,'443 ,Nguyen Duy Duong Street, Ward 3, 10 District','0938262843','employee14.jpg','OF00000002','ROL0000002')

-- Table Customer
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000001','gocongit@gmail.com','123','LAM','NGUYEN THANH','4/6/1986',1,'332 ,Tran Binh Trong Street, Ward 6, 10 District','0938573322')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000002','lahanqua@gmail.com','123','MINH','NGUYEN DUY','4/6/1988',1,'584 ,Nguyen Dinh Chieu Street, Ward 5, 3 District','0938371653')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000003','traitao@gmail.com','123','NAM','TRAN THANH','7/2/1978',1,'252 ,Au Co Street, Ward 3, Tan Binh District','0937164524')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000004','tinhtien@yahoo.com','123','KIM','AU SUONG','5/6/1989',0,'237 ,Dinh Tien Hoang Street, Ward 6, 5 District','01229482756')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000005','vuson@yahoo.com','123','PHUONG','TRAN MY','9/6/1984',0,'954 ,Vo Thi Sau Street, Ward 8, 4 District','0938748382')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000006','tantan99@yahoo.com','123','QUAN','NGUYEN DINH','4/5/1991',1,'363 ,Hung Vuong Street, Ward 5, 8 District','0938473625')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000007','ambinh@yahoo.com','123','NHU','PHAM THAI','3/5/1986',0,'26 ,Tran Binh Trong Street, Ward 3, 4 District','0909385737')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000008','mynune@gmail.com','123','TIEN','DO THANH','5/2/1986',1,'74 ,Vinh Vien Street, Ward 6, 3 District','0933827536')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000009','trietly@yahoo.com','123','TRUNG','NGUYEN TUAN','4/1/1986',1,'633 ,Binh Long Street, Ward 1, 1 District','0948277244')
INSERT INTO CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone)
 VALUES ('CUS0000010','tinhphong@yahoo.com','123','QUANG','AU NHAN','4/4/1986',1,'73 ,Truong Trinh Street, Ward 2, 6 District','0948588573')
