using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class BranchDAL : InterfaceDataLayers.BrancheInterface
    {
        #region Ibranch Members
        private BranchInfo Convert(DataRow Row)
        {
            BranchInfo info = new BranchInfo(Row["branchPin"].ToString(), Row["branchName"].ToString(), Row["branchAddress"].ToString(), Row["branchPhone"].ToString());
            return info;
        }
        public IList<DataModelLayers.BranchInfo> getListBranches()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from BRANCH");
            List<BranchInfo> List = new List<BranchInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }
        public DataModelLayers.BranchInfo getBrancheInfo(string _branchPin)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchPin",_branchPin)
            };

            DataTable Result = Conn.CreateDataTable("select * from  BRANCH where branchPin=@branchPin", Params);
            if (Result.Rows.Count != 1)
            {
                return new BranchInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }
        public IList<DataModelLayers.BranchInfo> getBranchesDetail(string _branchPin)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchPin",_branchPin)
            };

            DataTable Result = Conn.CreateDataTable("select * from  BRANCH where branchPin=@branchPin", Params);
            List<BranchInfo> List = new List<BranchInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }
        public IList<DataModelLayers.BranchInfo> searchBranches(string _branchName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from BRANCH WHERE branchName like '%" + _branchName.Trim().ToString() + "%'");
            List<BranchInfo> List = new List<BranchInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }
        public bool InsertBranche(DataModelLayers.BranchInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("branchPin", "branch", "BR", "00000000");
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchPin", id),
                new SqlParameter("branchName", info.BranchName),
                new SqlParameter("branchAddress", info.BranchAddress),
                new SqlParameter("branchPhone", info.BranchPhone)
            };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO BRANCH VALUES(@branchPin, @branchName,@branchAddress,@branchPhone)", Params);
            return (result == 1 ? true : false);
        }
        public bool UpdateBranche(DataModelLayers.BranchInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
               new SqlParameter("branchPin", info.BranchPin),
                new SqlParameter("branchName", info.BranchName),
                new SqlParameter("branchAddress", info.BranchAddress),
                new SqlParameter("branchPhone", info.BranchPhone)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("UPDATE BRANCH SET branchName = @branchName, branchAddress = @branchAddress, branchPhone = @branchPhone where branchPin=@branchPin", Params);
            return (result == 1 ? true : false);
        }
        public bool DeleteBranche(string _branchPin)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchPin", _branchPin)
            };
            BranchInfo tmp = this.getBrancheInfo(_branchPin);
            if (!tmp.BranchPin.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE BRANCH where branchPin=@branchPin", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }
        #endregion

    }
}
