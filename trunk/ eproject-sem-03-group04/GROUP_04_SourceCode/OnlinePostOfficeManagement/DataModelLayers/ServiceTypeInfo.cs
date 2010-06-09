using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class ServiceTypeInfo
    {
        private string servicesId;

        public string ServicesId
        {
            get { return servicesId; }
            set { servicesId = value; }
        }
        private string servicesName;

        public string ServicesName
        {
            get { return servicesName; }
            set { servicesName = value; }
        }
        private string servicesDecriptions;

        public string ServicesDecriptions
        {
            get { return servicesDecriptions; }
            set { servicesDecriptions = value; }
        }
        double servicesCharges;

        public double ServicesCharges
        {
            get { return servicesCharges; }
            set { servicesCharges = value; }
        }
        public ServiceTypeInfo()
        {
            this.ServicesId = null;
            this.ServicesName = null;
            this.ServicesDecriptions = null;
            this.ServicesCharges = 0.0;
        }
        public ServiceTypeInfo(string _servicesId, string _servicesName, string _servicesDecriptions, double _servicesCharges)
        {
            this.ServicesId = servicesId;
            this.ServicesName = servicesName;
            this.ServicesDecriptions = servicesDecriptions;
            this.ServicesCharges = servicesCharges;
        }
    }
}
