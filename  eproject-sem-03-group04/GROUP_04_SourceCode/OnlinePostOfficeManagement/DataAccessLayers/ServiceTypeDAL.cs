using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class ServiceTypeDAL : InterfaceDataLayers.IServiceType
    {
        #region IServiceType Members
        private ServiceTypeInfo Convert(DataRow Row)
        {
            ServiceTypeInfo info = new ServiceTypeInfo(Row["servicesId"].ToString(), Row["servicesName"].ToString(), Row["servicesDecriptions"].ToString(), float.Parse(Row["servicesCharges"].ToString()));
            return info;
        }
        public List<DataModelLayers.ServiceTypeInfo> getListServiceType()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from SERVICESTYPE");
            List<ServiceTypeInfo> List = new List<ServiceTypeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.ServiceTypeInfo> getServiceTypeDetail(string _servicesId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("servicesId",_servicesId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  SERVICESTYPE where servicesId=@servicesId", Params);
            List<ServiceTypeInfo> List = new List<ServiceTypeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.ServiceTypeInfo> searchServiceType(string _servicesName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from SERVICESTYPE WHERE servicesName like '%" + _servicesName.Trim().ToString() + "%'");
            List<ServiceTypeInfo> List = new List<ServiceTypeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertServiceType(DataModelLayers.ServiceTypeInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("servicesId", "SERVICESTYPE", "SEV", "00000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("servicesId", id),
                    new SqlParameter("servicesName", info.ServicesName),
                    new SqlParameter("servicesDecriptions", info.ServicesDecriptions),
                    new SqlParameter("servicesCharges", info.ServicesCharges)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO SERVICESTYPE VALUES(@servicesId, @servicesName,@servicesDecriptions,@servicesCharges)", Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateServiceType(DataModelLayers.ServiceTypeInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("servicesId", info.ServicesId),
                    new SqlParameter("servicesName", info.ServicesName),
                    new SqlParameter("servicesDecriptions", info.ServicesDecriptions),
                    new SqlParameter("servicesCharges", info.ServicesCharges)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("UPDATE SERVICESTYPE SET  servicesName = @servicesName, servicesDecriptions = @servicesDecriptions, servicesCharges = @servicesCharges where servicesId=@servicesId", Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteServiceType(string _servicesId)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("servicesId", _servicesId)
            };
            ServiceTypeInfo tmp = this.getServiceTypeInfo(_servicesId);
            if (!tmp.ServicesId.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE SERVICESTYPE where servicesId=@servicesId", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public DataModelLayers.ServiceTypeInfo getServiceTypeInfo(string _servicesId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("servicesId",_servicesId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  SERVICESTYPE where servicesId=@servicesId", Params);
            if (Result.Rows.Count != 1)
            {
                return new ServiceTypeInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        #endregion
    }
}
