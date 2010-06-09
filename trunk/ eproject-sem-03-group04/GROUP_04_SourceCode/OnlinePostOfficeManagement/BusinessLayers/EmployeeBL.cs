using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class EmployeeBL : InterfaceDataLayers.IEmployee
    {
        #region IEmployee Members
        DataAccessLayers.EmployeeDAL employee = new DataAccessLayers.EmployeeDAL();
        public List<DataModelLayers.EmployeeInfo> getListEmployee()
        {
            return employee.getListEmployee();
        }

        public IList<DataModelLayers.EmployeeInfo> getCustomerDetail(string _EmployeeId)
        {
            return employee.getCustomerDetail(_EmployeeId);
        }

        public IList<DataModelLayers.EmployeeInfo> searchEmployee(string _EmployeeName)
        {
            return employee.searchEmployee(_EmployeeName);
        }

        public bool InsertEmployee(DataModelLayers.EmployeeInfo info)
        {
            return employee.InsertEmployee(info);
        }

        public bool UpdateEmployee(DataModelLayers.EmployeeInfo info)
        {
            return employee.UpdateEmployee(info);
        }

        public bool DeleteEmployee(string _EmployeeId)
        {
            return employee.DeleteEmployee(_EmployeeId);
        }

        public DataModelLayers.EmployeeInfo getEmployeeInfo(string _EmployeeId)
        {
            return employee.getEmployeeInfo(_EmployeeId);
        }

        #endregion
    }
}
