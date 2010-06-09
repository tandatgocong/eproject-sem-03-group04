using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class EmployeeInfo
    {
        private string employeeId;

        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        private string employeeEmail;

        public string EmployeeEmail
        {
            get { return employeeEmail; }
            set { employeeEmail = value; }
        }
        private string employeePassword;

        public string EmployeePassword
        {
            get { return employeePassword; }
            set { employeePassword = value; }
        }
        private string employeeFirstName;

        public string EmployeeFirstName
        {
            get { return employeeFirstName; }
            set { employeeFirstName = value; }
        }
        private string employeeLastName;

        public string EmployeeLastName
        {
            get { return employeeLastName; }
            set { employeeLastName = value; }
        }
        private DateTime employeeBirthday;

        public DateTime EmployeeBirthday
        {
            get { return employeeBirthday; }
            set { employeeBirthday = value; }
        }
        private bool employeeSex;

        public bool EmployeeSex
        {
            get { return employeeSex; }
            set { employeeSex = value; }
        }
        private string employeeAddress;

        public string EmployeeAddress
        {
            get { return employeeAddress; }
            set { employeeAddress = value; }
        }
        private string employeePhone;

        public string EmployeePhone
        {
            get { return employeePhone; }
            set { employeePhone = value; }
        }
        private string employeeImage;

        public string EmployeeImage
        {
            get { return employeeImage; }
            set { employeeImage = value; }
        }
        private string offficeId;

        public string OffficeId
        {
            get { return offficeId; }
            set { offficeId = value; }
        }
        private string roleId;

        public string RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        public EmployeeInfo()
        {
            this.EmployeeId = null;
            this.EmployeeEmail = null;
            this.EmployeePassword = null;
            this.EmployeeFirstName = null;
            this.EmployeeLastName = null;
            this.EmployeeBirthday = DateTime.Now.Date ;
            this.EmployeeSex = false;
            this.EmployeeAddress = null;
            this.EmployeePhone = null;
            this.EmployeeImage = null;
            this.OffficeId = null;
            this.RoleId = null;
        }
        public EmployeeInfo(string _employeeId, string _employeeEmail, string _employeePassword, string _employeeFirstName, string _employeeLastName, DateTime _employeeBirthday, bool _employeeSex, string _employeeAddress, string _employeePhone, string _employeeImage, string _offficeId, string _roleId)
        {
            this.EmployeeId = _employeeId;
            this.EmployeeEmail = _employeeEmail;
            this.EmployeePassword = _employeePassword;
            this.EmployeeFirstName = _employeeFirstName;
            this.EmployeeLastName = _employeeLastName;
            this.EmployeeBirthday = _employeeBirthday;
            this.EmployeeSex = _employeeSex;
            this.EmployeeAddress = _employeeAddress;
            this.EmployeePhone = _employeePhone;
            this.EmployeeImage = _employeeImage;
            this.OffficeId = _offficeId;
            this.RoleId = _roleId;
        }
    }
}
