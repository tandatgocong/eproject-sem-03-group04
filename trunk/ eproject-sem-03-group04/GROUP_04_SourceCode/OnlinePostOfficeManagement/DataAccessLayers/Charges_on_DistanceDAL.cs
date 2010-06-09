using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class Charges_on_DistanceDAL : InterfaceDataLayers.ICharges_on_Distance
    {
        #region ICharges_on_Distance Members
        private Charges_on_DistanceInfo Convert(DataRow Row)
        {
            Charges_on_DistanceInfo info = new Charges_on_DistanceInfo(Row["Id"].ToString(), Row["Decriptons"].ToString(), float.Parse(Row["distanceFrom"].ToString()), float.Parse(Row["distanceTo"].ToString()), float.Parse(Row["Charges"].ToString()), Row["Note"].ToString(), Row["servicesType"].ToString());
            return info;
        }
        public IList<DataModelLayers.Charges_on_DistanceInfo> getListDistance()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from CHARGES_ON_DISTANCE");
            List<Charges_on_DistanceInfo> List = new List<Charges_on_DistanceInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.Charges_on_DistanceInfo> getDistanceDetail(string _Id)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id",_Id)
            };

            DataTable Result = Conn.CreateDataTable("select * from CHARGES_ON_DISTANCE where Id=@Id", Params);
            List<Charges_on_DistanceInfo> List = new List<Charges_on_DistanceInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.Charges_on_DistanceInfo> searchDistance(string _Decriptons)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from CHARGES_ON_DISTANCE WHERE Decriptons like '%" + _Decriptons.Trim().ToString() + "%'");
            List<Charges_on_DistanceInfo> List = new List<Charges_on_DistanceInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertDistance(DataModelLayers.Charges_on_DistanceInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("Id", "CHARGES_ON_DISTANCE", "COD", "0000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("Id", id),
                    new SqlParameter("Decriptons", info.Decriptons),
                    new SqlParameter("distanceFrom", info.DistanceFrom),
                    new SqlParameter("distanceTo", info.DistanceTo),
                    new SqlParameter("Charges", info.Charges),
                    new SqlParameter("Note", info.Note),
                    new SqlParameter("servicesType", info.ServicesType)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO CHARGES_ON_DISTANCE VALUES(@Id, @Decriptons,@distanceFrom,@distanceTo,@Charges,@Note,@servicesType)", Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateDistance(DataModelLayers.Charges_on_DistanceInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("Id", info.Id),
                    new SqlParameter("Decriptons", info.Decriptons),
                    new SqlParameter("distanceFrom", info.DistanceFrom),
                    new SqlParameter("distanceTo", info.DistanceTo),
                    new SqlParameter("Charges", info.Charges),
                    new SqlParameter("Note", info.Note),
                    new SqlParameter("servicesType", info.ServicesType)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            string sql = "UPDATE CHARGES_ON_DISTANCE SET Decriptons = @Decriptons, distanceFrom = @distanceFrom, distanceTo=@distanceTo, Charges=@Charges, Note = @Note, servicesType=@servicesType where Id=@Id";
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteDistance(string _id)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id", _id)
            };
            Charges_on_DistanceInfo tmp = this.getCharges_on_DistanceInfo(_id);
            if (!tmp.Id.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE CHARGES_ON_DISTANCE where Id=@Id", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public DataModelLayers.Charges_on_DistanceInfo getCharges_on_DistanceInfo(string _id)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id",_id)
            };

            DataTable Result = Conn.CreateDataTable("select * from  CHARGES_ON_DISTANCE where Id=@Id", Params);
            if (Result.Rows.Count != 1)
            {
                return new Charges_on_DistanceInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        #endregion
    }
}
