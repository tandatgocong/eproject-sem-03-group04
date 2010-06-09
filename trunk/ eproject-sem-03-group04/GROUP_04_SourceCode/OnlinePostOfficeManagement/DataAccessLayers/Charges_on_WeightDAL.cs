using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class Charges_on_WeightDAL : InterfaceDataLayers.ICharges_on_Weight
    {

        #region ICharges_on_Weight Members
        private Charges_on_WeightInfo Convert(DataRow Row)
        {
            Charges_on_WeightInfo info = new Charges_on_WeightInfo(Row["Id"].ToString(), Row["Decriptons"].ToString(), float.Parse(Row["weightMin"].ToString()), float.Parse(Row["weightMax"].ToString()), float.Parse(Row["Charges"].ToString()), Row["Note"].ToString(), Row["servicesType"].ToString());
            return info;
        }
        public IList<Charges_on_WeightInfo> getListWeight()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from CHARGES_ON_WEIGHT");
            List<Charges_on_WeightInfo> List = new List<Charges_on_WeightInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<Charges_on_WeightInfo> getWeightDetail(string _Id)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id",_Id)
            };

            DataTable Result = Conn.CreateDataTable("select * from CHARGES_ON_WEIGHT where Id=@Id", Params);
            List<Charges_on_WeightInfo> List = new List<Charges_on_WeightInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<Charges_on_WeightInfo> searchWeight(string _Decriptons)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from CHARGES_ON_WEIGHT WHERE Decriptons like '%" + _Decriptons.Trim().ToString() + "%'");
            List<Charges_on_WeightInfo> List = new List<Charges_on_WeightInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertWeight(Charges_on_WeightInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("Id", "CHARGES_ON_WEIGHT", "COW", "0000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("Id", id),
                    new SqlParameter("Decriptons", info.Decriptons),
                    new SqlParameter("weightMin", info.WeightMin),
                    new SqlParameter("weightMax", info.WeightMax),
                    new SqlParameter("Charges", info.Charges),
                    new SqlParameter("Note", info.Note),
                    new SqlParameter("servicesType", info.ServicesType)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO CHARGES_ON_WEIGHT VALUES(@Id, @Decriptons,@weightMin,@weightMax,@Charges,@Note,@servicesType)", Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateWeight(Charges_on_WeightInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("Id", info.Id),
                    new SqlParameter("Decriptons", info.Decriptons),
                    new SqlParameter("weightMin", info.WeightMin),
                    new SqlParameter("weightMax", info.WeightMax),
                    new SqlParameter("Charges", info.Charges),
                    new SqlParameter("Note", info.Note),
                    new SqlParameter("servicesType", info.ServicesType)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            string sql = "UPDATE CHARGES_ON_WEIGHT SET Decriptons = @Decriptons, weightMin = @weightMin, weightMax=@weightMax, Charges=@Charges, Note = @Note, servicesType=@servicesType where Id=@Id";
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteWeight(string _id)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id", _id)
            };
            Charges_on_WeightInfo tmp = this.getCharges_on_WeightInfo(_id);
            if (!tmp.Id.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE CHARGES_ON_WEIGHT where Id=@Id", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public Charges_on_WeightInfo getCharges_on_WeightInfo(string _id)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id",_id)
            };

            DataTable Result = Conn.CreateDataTable("select * from  CHARGES_ON_WEIGHT where Id=@Id", Params);
            if (Result.Rows.Count != 1)
            {
                return new Charges_on_WeightInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        #endregion
    }
}
