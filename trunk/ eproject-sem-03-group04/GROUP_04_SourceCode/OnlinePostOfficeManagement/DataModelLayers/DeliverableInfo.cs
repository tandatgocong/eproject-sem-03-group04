using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class DeliverableInfo
    {
        private string deliverablePin;

        public string DeliverablePin
        {
            get { return deliverablePin; }
            set { deliverablePin = value; }
        }
        private string customerSent;

        public string CustomerSent
        {
            get { return customerSent; }
            set { customerSent = value; }
        }
        private string deliverableSubject;

        public string DeliverableSubject
        {
            get { return deliverableSubject; }
            set { deliverableSubject = value; }
        }
        private string deliverableDecriptions;

        public string DeliverableDecriptions
        {
            get { return deliverableDecriptions; }
            set { deliverableDecriptions = value; }
        }
        private DateTime dateSent;

        public DateTime DateSent
        {
            get { return dateSent; }
            set { dateSent = value; }
        }
        private DateTime dateReceived;

        public DateTime DateReceived
        {
            get { return dateReceived; }
            set { dateReceived = value; }
        }
        private string personNameReceived;

        public string PersonNameReceived
        {
            get { return personNameReceived; }
            set { personNameReceived = value; }
        }
        private string personAddressReceived;

        public string PersonAddressReceived
        {
            get { return personAddressReceived; }
            set { personAddressReceived = value; }
        }
        private string personPhoneReceived;

        public string PersonPhoneReceived
        {
            get { return personPhoneReceived; }
            set { personPhoneReceived = value; }
        }
        private string personEmailReceived;

        public string PersonEmailReceived
        {
            get { return personEmailReceived; }
            set { personEmailReceived = value; }
        }
        private double totalWeight;

        public double TotalWeight
        {
            get { return totalWeight; }
            set { totalWeight = value; }
        }
        private double totalDistance;

        public double TotalDistance
        {
            get { return totalDistance; }
            set { totalDistance = value; }
        }
        private double totalCharges;

        public double TotalCharges
        {
            get { return totalCharges; }
            set { totalCharges = value; }
        }
        private bool deliverableStatus;

        public bool DeliverableStatus
        {
            get { return deliverableStatus; }
            set { deliverableStatus = value; }
        }
        private string deliverableNote;

        public string DeliverableNote
        {
            get { return deliverableNote; }
            set { deliverableNote = value; }
        }
        private string servicesType;

        public string ServicesType
        {
            get { return servicesType; }
            set { servicesType = value; }
        }
        private string employeeId;

        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public DeliverableInfo()
        {
            this.DeliverablePin=null;
            this.CustomerSent= null;
            this.DeliverableSubject = null; ;
            this.DeliverableDecriptions = null; ;
            this.DateSent = DateTime.Now.Date;
            this.DateReceived = DateTime.Now.Date; ; ;
            this.PersonNameReceived = null; ;
            this.PersonAddressReceived = null;
            this.PersonPhoneReceived = null; ;
            this.PersonEmailReceived = null; ;
            this.TotalWeight = 0.0;
            this.TotalDistance = 0.0;
            this.TotalCharges = 0.0;
            this.DeliverableStatus = false;
            this.DeliverableNote = null; ;
            this.ServicesType = null; ;
            this.EmployeeId = null; ;
         
        }
        public DeliverableInfo(string _deliverablePin,string _customerSent,string _deliverableSubject,string _deliverableDecriptions,DateTime _dateSent,
                DateTime _dateReceived,string _personNameReceived,string _personAddressReceived,string _personPhoneReceived,string _personEmailReceived,
                double _totalWeight, double _totalDistance, double _totalCharges, bool _deliverableStatus, string _deliverableNote, string _servicesType, string _employeeId)
        {
            this.DeliverablePin = _deliverablePin;
            this.CustomerSent = _customerSent;
            this.DeliverableSubject = _deliverableSubject; 
            this.DeliverableDecriptions = _deliverableDecriptions; ;
            this.DateSent = _dateSent;
            this.DateReceived = _dateReceived;
            this.PersonNameReceived = _personNameReceived; ;
            this.PersonAddressReceived = _personAddressReceived;
            this.PersonPhoneReceived = _personPhoneReceived; ;
            this.PersonEmailReceived = _personEmailReceived ;
            this.TotalWeight = _totalWeight;
            this.TotalDistance = _totalDistance;
            this.TotalCharges = _totalCharges;
            this.DeliverableStatus = _deliverableStatus;
            this.DeliverableNote = _deliverableNote;
            this.ServicesType = _servicesType;
            this.EmployeeId = _employeeId;

        }
    }
}
