using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class Charges_on_WeightInfo
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
        private float weightMin;

        public float WeightMin
        {
            get { return weightMin; }
            set { weightMin = value; }
        }
        private float weightMax;

        public float WeightMax
        {
            get { return weightMax; }
            set { weightMax = value; }
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

        public Charges_on_WeightInfo()
        {
            this.Id = null;
            this.Decriptons = null;
            this.WeightMin= 0;
            this.WeightMax= 0;
            this.Charges= 0;
            this.Note= null;
            this.ServicesType = null;
        }
        public Charges_on_WeightInfo(string _Id, string _Decriptons, float _weightMin, float _weightMax, float _Charges, string _Note, string _ServicesType)
        {
            this.Id = _Id;
            this.Decriptons = _Decriptons;
            this.WeightMin = _weightMin;
            this.WeightMax = _weightMax;
            this.Charges = _Charges;
            this.Note = _Note;
            this.ServicesType = _ServicesType;
        }
    }
}
