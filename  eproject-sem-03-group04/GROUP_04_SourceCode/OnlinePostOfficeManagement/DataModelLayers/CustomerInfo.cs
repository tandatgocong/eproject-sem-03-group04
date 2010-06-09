using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class CustomerInfo
    {
        private string customerId;

        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        private string customerEmail;

        public string CustomerEmail
        {
            get { return customerEmail; }
            set { customerEmail = value; }
        }
        private string customerPassword;

        public string CustomerPassword
        {
            get { return customerPassword; }
            set { customerPassword = value; }
        }
        private string customerFistName;

        public string CustomerFistName
        {
            get { return customerFistName; }
            set { customerFistName = value; }
        }
        private string customerLastName;

        public string CustomerLastName
        {
            get { return customerLastName; }
            set { customerLastName = value; }
        }
        private DateTime customerBirthday;

        public DateTime CustomerBirthday
        {
            get { return customerBirthday; }
            set { customerBirthday = value; }
        }
        private bool customerSex;

        public bool CustomerSex
        {
            get { return customerSex; }
            set { customerSex = value; }
        }
        private string customerAddress;

        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }
        private string customerPhone;

        public string CustomerPhone
        {
            get { return customerPhone; }
            set { customerPhone = value; }
        }

        public CustomerInfo()
        {
            this.CustomerId = null;
            this.CustomerEmail = null;
            this.CustomerPassword = null;
            this.CustomerLastName = null;
            this.CustomerFistName = null;
            this.CustomerBirthday = DateTime.Now.Date;
            this.CustomerSex = false;
            this.CustomerAddress = null;
            this.CustomerPhone = null;
            
        }

        public CustomerInfo(string _customerId, string _customerEmail,string _customerPassword, string _customerFistName, string _customerLastName, DateTime _customerBirthday, bool _customerSex, string _customerAddress, string _customerPhone)
        {
            this.CustomerId = _customerId;
            this.CustomerEmail = _customerEmail;
            this.CustomerPassword = _customerPassword;
            this.CustomerFistName = _customerFistName;
            this.CustomerLastName = _customerLastName;
            this.CustomerBirthday = _customerBirthday;
            this.CustomerSex = _customerSex;
            this.CustomerAddress = _customerAddress;
            this.CustomerPhone = _customerPhone;

        }
    }
}
