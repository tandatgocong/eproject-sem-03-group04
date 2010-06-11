using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class SystemsDAL : InterfaceDataLayers.ISystems
    {
        #region ISystems Members
        private SystemsInfo Convert(DataRow Row)
        {
            SystemsInfo info = new SystemsInfo(Row["roleId"].ToString(), Row["roleName"].ToString(),
                Row["roleDecriptions"].ToString());
            return info;
        }
        public List<DataModelLayers.SystemsInfo> getListRole()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from ROLE");
            List<SystemsInfo> List = new List<SystemsInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.SystemsInfo> getRoleDetail(string _roleId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("roleId",_roleId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  ROLE where roleId=@roleId", Params);
            List<SystemsInfo> List = new List<SystemsInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.SystemsInfo> searchRole(string _roleName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from ROLE WHERE roleName  like '%" + _roleName.Trim().ToString() + "%'");
            List<SystemsInfo> List = new List<SystemsInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertRole(DataModelLayers.SystemsInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("roleId", "ROLE", "ROL", "0000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("roleId", id),
                    new SqlParameter("roleName", info.RoleName),
                    new SqlParameter("roleDecriptions", info.RoleDecriptions)
                };
            string sql = "INSERT INTO ROLE VALUES(@roleId, @roleName,@roleDecriptions)";            
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateRole(DataModelLayers.SystemsInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("roleId", info.RoleId),
                    new SqlParameter("roleName", info.RoleName),
                    new SqlParameter("roleDecriptions", info.RoleDecriptions)
                };
            string sql = "UPDATE ROLE SET roleName=@roleName,roleDecriptions=@roleDecriptions WHERE roleId=@roleId";
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteRole(string _roleId)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("roleId", _roleId)
            };
            SystemsInfo tmp = this.getRoleInfo(_roleId);
            if (!tmp.RoleId.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE ROLE where roleId=@roleId", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public DataModelLayers.SystemsInfo getRoleInfo(string _roleId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("roleId",_roleId)
            };
            DataTable Result = Conn.CreateDataTable("select * from  ROLE where roleId=@roleId", Params);
            if (Result.Rows.Count != 1)
            {
                return new SystemsInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        public void CountNumberVisits()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            Conn.ExcuteNonQuery("UPDATE COUNT_VISIT SET count = count + 1"); 
        }

        #endregion

        #region ISystems Members


        public string WebLogin(string username, string password)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            return Conn.WebLogin(username, password);
        }

        #endregion

        #region ISystems Members


        public bool CheckAvailabilityEmail(string email)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            return Conn.IsExisted(email);
        }

        #endregion
    }
}
