using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class CustomersBL : InterfaceDataLayers.ICustomers
    {
        #region ICustomers Members
        DataAccessLayers.CustomersDAL cus = new DataAccessLayers.CustomersDAL();
        public List<DataModelLayers.CustomerInfo> getListCustomers()
        {
            return cus.getListCustomers();
        }

        public IList<DataModelLayers.CustomerInfo> getCustomerDetail(string _CustomersId)
        {
            return cus.getCustomerDetail(_CustomersId);
        }

        public IList<DataModelLayers.CustomerInfo> searchCustomers(string _CustomersName)
        {
            return cus.searchCustomers(_CustomersName);
        }

        public bool InsertCustomers(DataModelLayers.CustomerInfo info)
        {
            return cus.InsertCustomers(info);
        }

        public bool UpdateCustomers(DataModelLayers.CustomerInfo info)
        {
            return cus.UpdateCustomers(info);
        }

        public bool DeleteCustomers(string _CustomersId)
        {
            return cus.DeleteCustomers(_CustomersId);
        }

        public DataModelLayers.CustomerInfo getCustomerInfo(string _CustomersId)
        {
            return cus.getCustomerInfo(_CustomersId);
        }

        #endregion
    }
}
