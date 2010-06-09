using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class DeliverableBL : InterfaceDataLayers.IDeliverable
    {
        #region IDeliverable Members
        DataAccessLayers.DeliverableDAL deliverble = new DataAccessLayers.DeliverableDAL();
        public List<DataModelLayers.DeliverableInfo> getListDeliverable()
        {
            return deliverble.getListDeliverable();
        }

        public IList<DataModelLayers.DeliverableInfo> getDeliverableDetail(string _deliverablePin)
        {
            return deliverble.getDeliverableDetail(_deliverablePin);
        }

        public IList<DataModelLayers.DeliverableInfo> searchDeliverable(string _deliverableSubject)
        {
            return deliverble.searchDeliverable(_deliverableSubject);
        }

        public bool InsertDeliverable(DataModelLayers.DeliverableInfo info)
        {
            return deliverble.InsertDeliverable(info);
        }

        public bool UpdateDeliverable(DataModelLayers.DeliverableInfo info)
        {
            return deliverble.UpdateDeliverable(info);
        }

        public bool DeleteDeliverable(string _deliverablePin)
        {
            return deliverble.DeleteDeliverable(_deliverablePin);
        }

        public DataModelLayers.DeliverableInfo getDeliverableInfo(string _deliverablePin)
        {
            return deliverble.getDeliverableInfo(_deliverablePin);
        }

        #endregion
    }
}
