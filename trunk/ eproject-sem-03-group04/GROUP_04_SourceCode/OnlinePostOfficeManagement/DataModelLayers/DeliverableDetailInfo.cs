using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class DeliverableDetailInfo
    {
        private string detailId;

        public string DetailId
        {
            get { return detailId; }
            set { detailId = value; }
        }
        private string deliverablePin;

        public string DeliverablePin
        {
            get { return deliverablePin; }
            set { deliverablePin = value; }
        }
        private string deliverableName;

        public string DeliverableName
        {
            get { return deliverableName; }
            set { deliverableName = value; }
        }
        private float deivrableWeight;

        public float DeivrableWeight
        {
            get { return deivrableWeight; }
            set { deivrableWeight = value; }
        }
        private string decriptions;

        public string Decriptions
        {
            get { return decriptions; }
            set { decriptions = value; }
        }
        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public DeliverableDetailInfo()
        {
            this.DetailId= null;
            this.DeliverablePin = null;
            this.DeliverableName = null;
            this.DeivrableWeight = 0;
            this.Decriptions = null;
            this.Note = null;	  
        }
        public DeliverableDetailInfo(string _detailId, string _deliverablePin, string _deliverableName, float _deivrableWeight, string _Decriptions, string _Note)
        {
            this.DetailId = _detailId;
            this.DeliverablePin = _deliverablePin;
            this.DeliverableName = _deliverableName;
            this.DeivrableWeight = _deivrableWeight;
            this.Decriptions = _Decriptions;
            this.Note = _Note;	  
        }
     }
}
