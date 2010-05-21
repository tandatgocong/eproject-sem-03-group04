using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class BrancheDAL : InterfaceDataLayers.BrancheInterface
    {
        #region IBranche Members
        private BrancheInfo Convert(DataRow Row)
        {
            BrancheInfo info = new BrancheInfo(Row["branchePin"].ToString(), Row["brancheName"].ToString(), Row["brancheAddress"].ToString(), Row["branchePhone"].ToString());
            return info;
        }
        public IList<DataModelLayers.BrancheInfo> getListBranches()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from BRANCHE");
            List<BrancheInfo> List = new List<BrancheInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }
        public DataModelLayers.BrancheInfo getBrancheInfo(string _branchePin)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchePin",_branchePin)
            };

            DataTable Result = Conn.CreateDataTable("select * from  BRANCHE where branchePin=@branchePin", Params);
            if (Result.Rows.Count != 1)
            {
                return new BrancheInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }


        public IList<DataModelLayers.BrancheInfo> getBranchesDetail(string _branchePin)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchePin",_branchePin)
            };

            DataTable Result = Conn.CreateDataTable("select * from  BRANCHE where branchePin=@branchePin", Params);
            List<BrancheInfo> List = new List<BrancheInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.BrancheInfo> searchBranches(string _brancheName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from BRANCHE WHERE brancheName like '%" + _brancheName.Trim().ToString() + "%'");
            List<BrancheInfo> List = new List<BrancheInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertBranche(DataModelLayers.BrancheInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("branchePin", "BRANCHE", "BR", "00000000");
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchePin", id),
                new SqlParameter("brancheName", info.BrancheName),
                new SqlParameter("brancheAddress", info.BrancheAddress),
                new SqlParameter("branchePhone", info.BranchePhone)
            };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO BRANCHE VALUES(@branchePin, @brancheName,@brancheAddress,@branchePhone)", Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateBranche(DataModelLayers.BrancheInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
               new SqlParameter("branchePin", info.BranchePin),
                new SqlParameter("brancheName", info.BrancheName),
                new SqlParameter("brancheAddress", info.BrancheAddress),
                new SqlParameter("branchePhone", info.BranchePhone)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("UPDATE BRANCHE SET brancheName = @brancheName, brancheAddress = @brancheAddress, branchePhone = @branchePhone where branchePin=@branchePin", Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteBranche(string _branchePin)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchePin", _branchePin)
            };
            BrancheInfo tmp = this.getBrancheInfo(_branchePin);
            if (!tmp.BranchePin.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE BRANCHE where branchePin=@branchePin", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

       

        #endregion
    }
}
