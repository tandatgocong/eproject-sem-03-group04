using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class FeedbackInfo
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private string contend;

        public string Contend
        {
            get { return contend; }
            set { contend = value; }
        }
        private DateTime datesubmit;

        public DateTime Datesubmit
        {
            get { return datesubmit; }
            set { datesubmit = value; }
        }
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public FeedbackInfo()
        {
            this.Id = null;
            this.Name= null;
            this.Email= null;
            this.Address= null;
            this.Phone= null;
            this.Subject= null;
            this.Contend= null;
            this.Datesubmit= DateTime.Now.Date;
            this.Status= false;
        }
        public FeedbackInfo(string _Id, string _Name, string _Email, string _Address, string _Phone, string _Subject, string _Contend, DateTime _Datesubmit, bool _Status)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Email = _Email;
            this.Address = _Address;
            this.Phone = _Phone;
            this.Subject = _Subject;
            this.Contend = _Contend;
            this.Datesubmit = _Datesubmit;
            this.Status = _Status;
        }

        //private string id;
        //private string name;
        //private string email;
        //private string address;
        //private string phone;
        //private string subject;
        //private string contend;
        //private DateTime datesubmit;
        //private bool status;
    }
}
