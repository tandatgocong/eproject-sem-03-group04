using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface IDeliverableDetail
    {
        IList<DeliverableDetailInfo> getListDeliverableDetail();
        IList<DeliverableDetailInfo> getDeliverableDetail(string _detailId);
        IList<DeliverableDetailInfo> searchDeliverableDetail(string _deliverableName);
        bool InsertDeliverableDetail(DeliverableDetailInfo info);
        bool UpdateDeliverableDetail(DeliverableDetailInfo info);
        bool DeleteDeliverableDetail(string _detailId);
        DeliverableDetailInfo getDeliverableDetailInfo(string _detailId);
    }
}
