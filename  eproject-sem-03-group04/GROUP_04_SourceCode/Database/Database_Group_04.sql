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

-------------------------- INSERT RECORD -------------------------------