using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class DeliverableDetaliBL : InterfaceDataLayers.IDeliverableDetail
    {
        #region IDeliverableDetail Members
        DataAccessLayers.DeliverableDetailDAL detail = new DataAccessLayers.DeliverableDetailDAL();
        public IList<DataModelLayers.DeliverableDetailInfo> getListDeliverableDetail()
        {
            return detail.getListDeliverableDetail();
        }

        public IList<DataModelLayers.DeliverableDetailInfo> getDeliverableDetail(string _detailId)
        {
            return detail.getDeliverableDetail(_detailId);
        }

        public IList<DataModelLayers.DeliverableDetailInfo> searchDeliverableDetail(string _deliverableName)
        {
            return detail.searchDeliverableDetail(_deliverableName);
        }

        public bool InsertDeliverableDetail(DataModelLayers.DeliverableDetailInfo info)
        {
            return detail.InsertDeliverableDetail(info);
        }

        public bool UpdateDeliverableDetail(DataModelLayers.DeliverableDetailInfo info)
        {
            return detail.UpdateDeliverableDetail(info);
        }

        public bool DeleteDeliverableDetail(string _detailId)
        {
            return detail.DeleteDeliverableDetail(_detailId);
        }

        public DataModelLayers.DeliverableDetailInfo getDeliverableDetailInfo(string _detailId)
        {
            return detail.getDeliverableDetailInfo(_detailId);
        }

        #endregion
    }
}
