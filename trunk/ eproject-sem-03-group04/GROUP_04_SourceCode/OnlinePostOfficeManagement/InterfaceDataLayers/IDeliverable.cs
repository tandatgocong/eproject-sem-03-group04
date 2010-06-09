using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface IDeliverable
    {
        List<DeliverableInfo> getListDeliverable();
        IList<DeliverableInfo> getDeliverableDetail(string _deliverablePin);
        IList<DeliverableInfo> searchDeliverable(string _deliverableSubject);
        bool InsertDeliverable(DeliverableInfo info);
        bool UpdateDeliverable(DeliverableInfo info);
        bool DeleteDeliverable(string _deliverablePin);
        DeliverableInfo getDeliverableInfo(string _deliverablePin);
    }
}
