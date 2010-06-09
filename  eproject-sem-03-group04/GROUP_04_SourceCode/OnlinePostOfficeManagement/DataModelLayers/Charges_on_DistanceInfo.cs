using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class Charges_on_DistanceInfo
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string decriptons;

        public string Decriptons
        {
            get { return decriptons; }
            set { decriptons = value; }
        }
        private float distanceFrom;

        public float DistanceFrom
        {
            get { return distanceFrom; }
            set { distanceFrom = value; }
        }
        private float distanceTo;

        public float DistanceTo
        {
            get { return distanceTo; }
            set { distanceTo = value; }
        }
        private float charges;

        public float Charges
        {
            get { return charges; }
            set { charges = value; }
        }
        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        private string servicesType;

        public string ServicesType
        {
            get { return servicesType; }
            set { servicesType = value; }
        }

        public Charges_on_DistanceInfo()
        {
            this.Id = null;
            this.Decriptons = null;
            this.DistanceFrom= 0;
            this.DistanceTo= 0;
            this.Charges= 0;
            this.Note= null;
            this.ServicesType = null;
        }
        public Charges_on_DistanceInfo(string _Id, string _Decriptons, float _DistanceFrom, float _DistanceTo, float _Charges, string _Note, string _ServicesType)
        {
            this.Id = _Id;
            this.Decriptons = _Decriptons;
            this.DistanceFrom = _DistanceFrom;
            this.DistanceTo = _DistanceTo;
            this.Charges = _Charges;
            this.Note = _Note;
            this.ServicesType = _ServicesType;
        }
    }
}
