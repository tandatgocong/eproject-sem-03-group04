using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class Charges_on_DistanceBL : InterfaceDataLayers.ICharges_on_Distance
    {

        #region ICharges_on_Distance Members
        DataAccessLayers.Charges_on_DistanceDAL charge = new DataAccessLayers.Charges_on_DistanceDAL();
        public IList<DataModelLayers.Charges_on_DistanceInfo> getListDistance()
        {
            return charge.getListDistance();
        }

        public IList<DataModelLayers.Charges_on_DistanceInfo> getDistanceDetail(string _Id)
        {
            return charge.getDistanceDetail(_Id);
        }

        public IList<DataModelLayers.Charges_on_DistanceInfo> searchDistance(string _Decriptons)
        {
            return charge.searchDistance(_Decriptons);
        }

        public bool InsertDistance(DataModelLayers.Charges_on_DistanceInfo info)
        {
            return charge.InsertDistance(info);
        }

        public bool UpdateDistance(DataModelLayers.Charges_on_DistanceInfo info)
        {
            return charge.UpdateDistance(info);
        }

        public bool DeleteDistance(string _id)
        {
            return charge.DeleteDistance(_id);
        }

        public DataModelLayers.Charges_on_DistanceInfo getCharges_on_DistanceInfo(string _id)
        {
            return charge.getCharges_on_DistanceInfo(_id);
        }

        #endregion
    }
}
