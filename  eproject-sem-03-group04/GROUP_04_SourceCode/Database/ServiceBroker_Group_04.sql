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
		<xsd:element name="offficeId" type="xsd:string"/>
		<xsd:element name="roleId" type="xsd:string"/>
      </xsd:sequence>
    </xsd:complexType>
  </xsd:element>
</xsd:schema>'
GO

CREATE TABLE  AcceptRequest 
(
	EmployeeID VARCHAR(10) PRIMARY KEY,
	EmployeeInfo XML(CONTENT EmployeeInfoSchema) NULL
)
GO
