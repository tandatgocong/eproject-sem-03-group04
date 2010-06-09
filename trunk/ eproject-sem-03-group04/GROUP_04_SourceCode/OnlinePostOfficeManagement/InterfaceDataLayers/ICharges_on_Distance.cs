using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface ICharges_on_Distance
    {
        IList<Charges_on_DistanceInfo> getListDistance();
        IList<Charges_on_DistanceInfo> getDistanceDetail(string _Id);
        IList<Charges_on_DistanceInfo> searchDistance(string _Decriptons);
        bool InsertDistance(Charges_on_DistanceInfo info);
        bool UpdateDistance(Charges_on_DistanceInfo info);
        bool DeleteDistance(string _id);
        Charges_on_DistanceInfo getCharges_on_DistanceInfo(string _id);
    }
}
