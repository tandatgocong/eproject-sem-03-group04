using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface ICustomers
    {
        List<CustomerInfo> getListCustomers();
        IList<CustomerInfo> getCustomerDetail(string _CustomersId);
        IList<CustomerInfo> searchCustomers(string _CustomersName);
        bool InsertCustomers(CustomerInfo info);
        bool UpdateCustomers(CustomerInfo info);
        bool DeleteCustomers(string _Customersid);
        CustomerInfo getCustomerInfo(string _Customersid);
    }
}
