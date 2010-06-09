using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class EmployeeDAL : InterfaceDataLayers.IEmployee
    {
        #region IEmployee Members
        private EmployeeInfo Convert(DataRow Row)
        {
            EmployeeInfo info = new EmployeeInfo(Row["employeeId"].ToString(), Row["employeeEmail"].ToString(),
                Row["employeePassword"].ToString(), Row["employeeFirstName"].ToString(),
                Row["employeeLastName"].ToString(), DateTime.Parse(Row["employeeBirthday"].ToString()),
                bool.Parse(Row["employeeSex"].ToString()), Row["employeeAddress"].ToString(), Row["employeePhone"].ToString(), Row["employeeImage"].ToString(), Row["offficeId"].ToString(), Row["roleId"].ToString());
            return info;
        }
        public List<DataModelLayers.EmployeeInfo> getListEmployee()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from EMPLOYEE");
            List<EmployeeInfo> List = new List<EmployeeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.EmployeeInfo> getCustomerDetail(string _EmployeeId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("employeeId",_EmployeeId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  EMPLOYEE where employeeId=@employeeId", Params);
            List<EmployeeInfo> List = new List<EmployeeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.EmployeeInfo> searchEmployee(string _EmployeeName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from EMPLOYEE WHERE (employeeFirstName + employeeLastName)  like '%" + _EmployeeName.Trim().ToString() + "%'");
            List<EmployeeInfo> List = new List<EmployeeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertEmployee(DataModelLayers.EmployeeInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("employeeId", "EMPLOYEE", "EMP", "0000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("employeeId", id),
                    new SqlParameter("employeeEmail", info.EmployeeEmail),
                    new SqlParameter("employeePassword", info.EmployeePassword),
                    new SqlParameter("employeeFirstName", info.EmployeeFirstName),
                    new SqlParameter("employeeLastName", info.EmployeeLastName),
                    new SqlParameter("employeeBirthday", info.EmployeeBirthday),
                    new SqlParameter("employeeSex", info.EmployeeSex),
                    new SqlParameter("employeeAddress", info.EmployeeAddress),
                    new SqlParameter("employeePhone", info.EmployeePhone),
                    new SqlParameter("employeeImage", info.EmployeeImage),
                    new SqlParameter("offficeId", info.OffficeId),
                    new SqlParameter("roleId", info.RoleId)
                };
            string sql = "INSERT INTO EMPLOYEE VALUES(@employeeId, @employeeEmail,";
            sql = sql + " @employeePassword,@employeeFirstName,@employeeLastName,@employeeBirthday,";
            sql = sql + " @employeeSex,@employeeAddress,@employeePhone,@employeeImage,";
            sql = sql + " @offficeId,@roleId)";
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateEmployee(DataModelLayers.EmployeeInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("employeeId", info.EmployeeId),
                    new SqlParameter("employeeEmail", info.EmployeeEmail),
                    new SqlParameter("employeePassword", info.EmployeePassword),
                    new SqlParameter("employeeFirstName", info.EmployeeFirstName),
                    new SqlParameter("employeeLastName", info.EmployeeLastName),
                    new SqlParameter("employeeBirthday", info.EmployeeBirthday),
                    new SqlParameter("employeeSex", info.EmployeeSex),
                    new SqlParameter("employeeAddress", info.EmployeeAddress),
                    new SqlParameter("employeePhone", info.EmployeePhone),
                    new SqlParameter("employeeImage", info.EmployeeImage),
                    new SqlParameter("offficeId", info.OffficeId),
                    new SqlParameter("roleId", info.RoleId)
                };
            string sql = "UPDATE EMPLOYEE SET employeeEmail=@employeeEmail, employeePassword=@employeePassword,";
            sql = sql + " employeeFirstName=@employeeFirstName,employeeLastName=@employeeLastName,employeeBirthday=@employeeBirthday,";
            sql = sql + " employeeSex=@employeeSex,employeeAddress=@employeeAddress,employeePhone=@employeePhone,employeeImage=@employeeImage,";
            sql = sql + " offficeId=@offficeId,roleId=@roleId WHERE employeeId=@employeeId";
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteEmployee(string _EmployeeId)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("employeeId", _EmployeeId)
            };
            EmployeeInfo tmp = this.getEmployeeInfo(_EmployeeId);
            if (!tmp.EmployeeId.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE EMPLOYEE where employeeId=@employeeId", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public DataModelLayers.EmployeeInfo getEmployeeInfo(string _EmployeeId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("employeeId",_EmployeeId)
            };
            DataTable Result = Conn.CreateDataTable("select * from  EMPLOYEE where employeeId=@employeeId", Params);
            if (Result.Rows.Count != 1)
            {
                return new EmployeeInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        #endregion
    }
}
