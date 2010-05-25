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
---------------------BRANCH
insert into BRANCH (branchPin,branchName,branchAddress,branchPhone) values ('A01','Chi nhanh 1','12, Le Duan, Q1','08398837')
insert into BRANCH (branchPin,branchName,branchAddress,branchPhone) values ('A02','Chi nhanh 2','123, Nguyen Trai, THD','061398837')
insert into BRANCH (branchPin,branchName,branchAddress,branchPhone) values ('A03','Chi nhanh 3','12, LHP, Q1','078398837')
insert into BRANCH (branchPin,branchName,branchAddress,branchPhone) values ('A04','Chi nhanh 4','12, Le Lai, Q12','04398837')
insert into BRANCH (branchPin,branchName,branchAddress,branchPhone) values ('A05','Chi nhanh 5','12, Nguyen Du, Q6','022398837')

select * from branch

--------------------OFFICE
insert into OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) values ('OF001','Office 1','23 Tran Dinh Xu, Q1','0834234234','office001@xyz.com','A01')
insert into OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) values ('OF002','Office 2','23 Tran Dinh Xu, Q1','0834234234','office002@xyz.com','A01')
insert into OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) values ('OF003','Office 3','23 Tran Dinh Xu, Q1','0834234234','office003@xyz.com','A02')
insert into OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) values ('OF004','Office 4','23 Tran Dinh Xu, Q1','0834234234','office004@xyz.com','A02')
insert into OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) values ('OF005','Office 5','23 Tran Dinh Xu, Q1','0834234234','office005@xyz.com','A03')
insert into OFFICE (offficeId,officeName,officeAddress,officePhone,officeMail,branchPin) values ('OF006','Office 6','23 Tran Dinh Xu, Q1','0834234234','office006@xyz.com','A03')

select * from office

------------------ROLE
insert into [ROLE] (roleId,roleName,roleDecriptions) values ('R01','Administrator','Quan ly cap cao')
insert into [ROLE] (roleId,roleName,roleDecriptions) values ('R02','Employee','Nhan vien')

select * from [role]

---------------SERVICESTYPE
insert into SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) values ('S01','Chuyen phat nhanh','Gui nhanh',12000)
insert into SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) values ('S02','Gui thuong','Gui thuong',9000)
insert into SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) values ('S03','VPP','thanh toan sau',5000)
insert into SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) values ('S04','Buu pham','Gui gui buu pham',15000)
insert into SERVICESTYPE (servicesId,servicesName,servicesDecriptions,servicesCharges) values ('S05','Dien hoa','Tang hoa',62000)

select * from SERVICESTYPE

--------------EMPLOYEE
insert into EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId) values ('E0001','maimai@yahoo.com','123456','Vu','Tran','12/12/1988',1,'22 duong Le Lai Q3','0909093433','hinhtao.jpg','OF001','R01')
insert into EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId) values ('E0002','maimai@yahoo.com','123456','Vu','Tran','12/12/1988',1,'22 duong Le Lai Q3','0909093433','hinhtao.jpg','OF001','R02')
insert into EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId) values ('E0003','maimai@yahoo.com','123456','Vu','Tran','12/12/1988',1,'22 duong Le Lai Q3','0909093433','hinhtao.jpg','OF002','R02')
insert into EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId) values ('E0004','maimai@yahoo.com','123456','Vu','Tran','12/12/1988',1,'22 duong Le Lai Q3','0909093433','hinhtao.jpg','OF003','R02')
insert into EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId) values ('E0005','maimai@yahoo.com','123456','Vu','Tran','12/12/1988',1,'22 duong Le Lai Q3','0909093433','hinhtao.jpg','OF004','R02')
insert into EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId) values ('E0006','maimai@yahoo.com','123456','Vu','Tran','12/12/1988',1,'22 duong Le Lai Q3','0909093433','hinhtao.jpg','OF004','R02')
insert into EMPLOYEE (employeeId,employeeEmail,employeePassword,employeeFirstName,employeeLastName,employeeBirthday,employeeSex,employeeAddress,employeePhone,employeeImage,offficeId,roleId) values ('E0007','maimai@yahoo.com','123456','Vu','Tran','12/12/1988',1,'22 duong Le Lai Q3','0909093433','hinhtao.jpg','OF002','R02')

select * from EMPLOYEE

--------------CUSTOMER
insert into CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone) values ('C0001','thangkia@gmail.com','123456','Khanh','Le','11/11/1987',1,'23 Le Hong Phong p12 Q5','0912384756')
insert into CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone) values ('C0002','thangkia2@gmail.com','123456','Khanh','Vu','11/11/1987',1,'23 Le Hong Phong p12 Q5','0912384756')
insert into CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone) values ('C0003','thangkia3@gmail.com','123456','Tam','Tran','11/11/1987',1,'23 Le Hong Phong p12 Q5','0912384756')
insert into CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone) values ('C0004','thangkia4@gmail.com','123456','Khanh','Thai','11/11/1987',1,'23 Le Hong Phong p12 Q5','0912384756')
insert into CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone) values ('C0005','thangkia5@gmail.com','123456','Khanh','Nguyen','11/11/1987',1,'23 Le Hong Phong p12 Q5','0912384756')
insert into CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone) values ('C0006','thangkia6@gmail.com','123456','Khanh','Le','11/11/1987',1,'23 Le Hong Phong p12 Q5','0912384756')
insert into CUSTOMER (customerId,customerEmail,customerPassword,customerFistName,customerLastName,customerBirthday,customerSex,customerAddress,customerPhone) values ('C0007','thangkia7@gmail.com','123456','Khanh','Le','11/11/1987',1,'23 Le Hong Phong p12 Q5','0912384756')

select * from CUSTOMER

---------------CHARGES_ON_DISTANCE
-----For servicestype S01
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD001','duoi 51 km',0,50,13000,'','S01')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD002','tu 51 den 100 km',51,100,15000,'','S01')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD003','tu 101 den 200 km',101,200,20000,'','S01')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD004','tu 201 den 400 km',201,400,30000,'','S01')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD005','tu 401 den 1000 km',401,1000,40000,'','S01')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD006','tren 1000 km',1001,2500,50000,'','S01')
-----For servicestype S02
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD001','duoi 51 km',0,50,13000,'','S02')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD002','tu 51 den 100 km',51,100,15000,'','S02')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD003','tu 101 den 200 km',101,200,20000,'','S02')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD004','tu 201 den 400 km',201,400,30000,'','S02')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD005','tu 401 den 1000 km',401,1000,40000,'','S02')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD006','tren 1000 km',1001,2500,50000,'','S02')
-----For servicestype S03
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD007','duoi 51 km',0,50,13000,'','S03')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD008','tu 51 den 100 km',51,100,15000,'','S03')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD009','tu 101 den 200 km',101,200,20000,'','S03')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD010','tu 201 den 400 km',201,400,30000,'','S03')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD011','tu 401 den 100 km',401,1000,40000,'','S03')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD012','tren 1000 km',1001,2500,50000,'','S03')
-----For servicestype S04
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD013','duoi 51 km',0,50,13000,'','S04')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD014','tu 51 den 100 km',51,100,15000,'','S04')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD015','tu 101 den 200 km',101,200,20000,'','S04')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD016','tu 201 den 400 km',201,400,30000,'','S04')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD017','tu 401 den 100 km',401,1000,40000,'','S04')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD018','tren 1000 km',1001,2500,50000,'','S04')
-----For servicestype S05
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD019','duoi 51 km',0,50,13000,'','S05')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD020','tu 51 den 100 km',51,100,15000,'','S05')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD021','tu 101 den 200 km',101,200,20000,'','S05')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD022','tu 201 den 400 km',201,400,30000,'','S05')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD023','tu 401 den 1000 km',401,1000,40000,'','S05')
insert into CHARGES_ON_DISTANCE (Id,Decriptons,distanceFrom,distanceTo,Charges,Note,servicesType) values ('CD024','Tren 1000km',1001,2500,50000,'','S05')

select * from CHARGES_ON_DISTANCE

----------------CHARGES_ON_WEIGHT
-----For servicestype S01
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW001','duoi 0.5 kg',0,0.5,13000,'','S01')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW002','tu 0.6 den 3 kg',0.6,3,15000,'','S01')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW003','tu 3.1 den  10 kg',3.1,10,20000,'','S01')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW004','tu 9.1 den 20 kg',9.1,20,30000,'','S01')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW005','tu 20.1 den 50 kg',401,1000,40000,'','S01')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW006','tren 50 kg',1001,2500,50000,'','S01')
-----For servicestype S02
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW001','duoi 0.5 kg',0,50,13000,'','S02')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW002','tu 0.6 den 3 kg',51,100,15000,'','S02')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW003','tu 3.1 den 10 kg',101,200,20000,'','S02')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW004','tu 10.1 den 20 kg',201,400,30000,'','S02')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW005','tu 20.1 den 50 kg',401,1000,40000,'','S02')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW006','tren 50 kg',1001,2500,50000,'','S02')
-----For servicestype S03
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW007','duoi 0.5 kg',0,50,13000,'','S03')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW008','tu 0.6 den 3 kg',51,100,15000,'','S03')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW009','tu 3.1 den 10 kg',101,200,20000,'','S03')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW010','tu 10.1 den 20 kg',201,400,30000,'','S03')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW011','tu 20.1 den 50 kg',401,1000,40000,'','S03')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW012','tren 50 kg',1001,2500,50000,'','S03')
-----For servicestype S04
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW013','duoi 0.5 kg',0,50,13000,'','S04')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW014','tu 0.6 den 3 kg',51,100,15000,'','S04')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW015','tu 3.1 den 10 kg',101,200,20000,'','S04')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW016','tu 10.1 den 20 kg',201,400,30000,'','S04')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW017','tu 20.1 den 50 kg',401,1000,40000,'','S04')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW018','tren 50 kg',1001,2500,50000,'','S04')
-----For servicestype S05
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW019','duoi 0.5 kg',0,50,13000,'','S05')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW020','tu 0.6 den 3 kg',51,100,15000,'','S05')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW021','tu 3.1 den 10 kg',101,200,20000,'','S05')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW022','tu 10.1 den 20 kg',201,400,30000,'','S05')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW023','tu 20.1 den 50 kg',401,1000,40000,'','S05')
insert into CHARGES_ON_WEIGHT (Id,Decriptons,weightMin,weightMax,Charges,Note,servicesType) values ('CW024','tren 50 kg',1001,2500,50000,'','S05')

select * from CHARGES_ON_WEIGHT

-----------------------