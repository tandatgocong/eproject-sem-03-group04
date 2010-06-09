using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface IEmployee
    {
        List<EmployeeInfo> getListEmployee();
        IList<EmployeeInfo> getCustomerDetail(string _EmployeeId);
        IList<EmployeeInfo> searchEmployee(string _EmployeeName);
        bool InsertEmployee(EmployeeInfo info);
        bool UpdateEmployee(EmployeeInfo info);
        bool DeleteEmployee(string _Employeeid);
        EmployeeInfo getEmployeeInfo(string _Employeeid);
    }
}
