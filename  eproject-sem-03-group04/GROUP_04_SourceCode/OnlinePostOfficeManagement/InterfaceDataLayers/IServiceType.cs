using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface IServiceType
    {
        List<ServiceTypeInfo> getListServiceType();
        IList<ServiceTypeInfo> getServiceTypeDetail(string _servicesId);
        IList<ServiceTypeInfo> searchServiceType(string _servicesName);
        bool InsertServiceType(ServiceTypeInfo info);
        bool UpdateServiceType(ServiceTypeInfo info);
        bool DeleteServiceType(string _servicesId);
        ServiceTypeInfo getServiceTypeInfo(string _servicesId);
    }
}
