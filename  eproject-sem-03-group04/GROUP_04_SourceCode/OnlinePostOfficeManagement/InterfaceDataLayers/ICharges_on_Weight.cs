using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface ICharges_on_Weight
    {
        IList<Charges_on_WeightInfo> getListWeight();
        IList<Charges_on_WeightInfo> getWeightDetail(string _Id);
        IList<Charges_on_WeightInfo> searchWeight(string _Decriptons);
        bool InsertWeight(Charges_on_WeightInfo info);
        bool UpdateWeight(Charges_on_WeightInfo info);
        bool DeleteWeight(string _id);
        Charges_on_WeightInfo getCharges_on_WeightInfo(string _id);
    }
}
