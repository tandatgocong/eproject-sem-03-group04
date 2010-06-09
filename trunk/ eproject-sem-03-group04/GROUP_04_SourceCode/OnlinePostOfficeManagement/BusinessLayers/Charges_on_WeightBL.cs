using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class Charges_on_WeightBL : InterfaceDataLayers.ICharges_on_Weight
    {
        #region ICharges_on_Weight Members
        DataAccessLayers.Charges_on_WeightDAL weight = new DataAccessLayers.Charges_on_WeightDAL();
        public IList<DataModelLayers.Charges_on_WeightInfo> getListWeight()
        {
            return weight.getListWeight();
        }

        public IList<DataModelLayers.Charges_on_WeightInfo> getWeightDetail(string _Id)
        {
            return weight.getWeightDetail(_Id);
        }

        public IList<DataModelLayers.Charges_on_WeightInfo> searchWeight(string _Decriptons)
        {
            return weight.searchWeight(_Decriptons);
        }

        public bool InsertWeight(DataModelLayers.Charges_on_WeightInfo info)
        {
            return weight.InsertWeight(info);
        }

        public bool UpdateWeight(DataModelLayers.Charges_on_WeightInfo info)
        {
            return weight.UpdateWeight(info);
        }

        public bool DeleteWeight(string _id)
        {
            return weight.DeleteWeight(_id);
        }

        public DataModelLayers.Charges_on_WeightInfo getCharges_on_WeightInfo(string _id)
        {
            return weight.getCharges_on_WeightInfo(_id);
        }

        #endregion
    }
}
