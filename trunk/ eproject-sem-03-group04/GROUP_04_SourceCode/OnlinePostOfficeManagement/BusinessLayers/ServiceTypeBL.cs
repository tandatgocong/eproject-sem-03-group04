using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class ServiceTypeBL : InterfaceDataLayers.IServiceType
    {

        #region IServiceType Members
        DataAccessLayers.ServiceTypeDAL service = new DataAccessLayers.ServiceTypeDAL();
        public List<DataModelLayers.ServiceTypeInfo> getListServiceType()
        {
            return service.getListServiceType();
        }

        public IList<DataModelLayers.ServiceTypeInfo> getServiceTypeDetail(string _servicesId)
        {
            return service.getServiceTypeDetail(_servicesId);
        }

        public IList<DataModelLayers.ServiceTypeInfo> searchServiceType(string _servicesName)
        {
            return service.searchServiceType(_servicesName);
        }

        public bool InsertServiceType(DataModelLayers.ServiceTypeInfo info)
        {
            return service.InsertServiceType(info);
        }

        public bool UpdateServiceType(DataModelLayers.ServiceTypeInfo info)
        {
            return service.UpdateServiceType(info);
        }

        public bool DeleteServiceType(string _servicesId)
        {
            return service.DeleteServiceType(_servicesId);
        }

        public DataModelLayers.ServiceTypeInfo getServiceTypeInfo(string _servicesId)
        {
            return service.getServiceTypeInfo(_servicesId);
        }

        #endregion
    }
}
