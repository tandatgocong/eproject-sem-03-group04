using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModelLayers;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class OfficeDAL : InterfaceDataLayers.IOffices
    {
        #region IOffices Members
        private OfficeInfo Convert(DataRow Row)
        {
            OfficeInfo info = new OfficeInfo(Row["offficeId"].ToString(), Row["officeName"].ToString(), Row["officeAddress"].ToString(), Row["officePhone"].ToString(), Row["officeMail"].ToString(), Row["branchPin"].ToString());
            return info;
        }
        public IList<DataModelLayers.OfficeInfo> getListOffice()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from OFFICE");
            List<OfficeInfo> List = new List<OfficeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }
        public IList<DataModelLayers.OfficeInfo> getOfficeDetail(string _officeId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("offficeId",_officeId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  OFFICE where offficeId=@offficeId", Params);
            List<OfficeInfo> List = new List<OfficeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }
        public IList<DataModelLayers.OfficeInfo> searchOffice(string _officeName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from OFFICE WHERE offficeId like '%" + _officeName.Trim().ToString() + "%'");
            List<OfficeInfo> List = new List<OfficeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }
        public bool InsertOffice(OfficeInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("offficeId", "OFFICE", "OF", "00000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("offficeId", id),
                    new SqlParameter("officeName", info.OfficeName),
                    new SqlParameter("officeAddress", info.OfficeAddress),
                    new SqlParameter("officePhone", info.OfficePhone),
                    new SqlParameter("officeMail", info.OfficeMail),
                    new SqlParameter("branchPin", info.BranchPin)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO OFFICE VALUES(@offficeId, @officeName,@officeAddress,@officePhone,@officeMail,@branchPin)", Params);
            return (result == 1 ? true : false);
        }
        public bool UpdateOffice(OfficeInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("offficeId", info.OffficeId),
                    new SqlParameter("officeName", info.OfficeName),
                    new SqlParameter("officeAddress", info.OfficeAddress),
                    new SqlParameter("officePhone", info.OfficePhone),
                    new SqlParameter("officeMail", info.OfficeMail),
                    new SqlParameter("branchPin", info.BranchPin)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("UPDATE OFFICE SET officeName = @officeName, officeAddress = @officeAddress, officePhone = @officePhone, officeMail=@officeMail, branchPin=@branchPin where offficeId=@offficeId", Params);
            return (result == 1 ? true : false);
        }
        public bool DeleteOffice(string _OfficePin)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("offficeId", _OfficePin)
            };
            OfficeInfo tmp = this.getOfficeInfo(_OfficePin);
            if (!tmp.BranchPin.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE OFFICE where offficeId=@offficeId", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }
        public OfficeInfo getOfficeInfo(string _OfficeId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("offficeId",_OfficeId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  OFFICE where offficeId=@offficeId", Params);
            if (Result.Rows.Count != 1)
            {
                return new OfficeInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }
        #endregion

        #region IOffices Members


        public IList<OfficeInfo> getOfficebyBranch(string _branchId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchPin",_branchId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  OFFICE where branchPin=@branchPin", Params);
            List<OfficeInfo> List = new List<OfficeInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        #endregion

        #region IOffices Members


        public int BranchExist(string _branchId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("branchPin",_branchId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  OFFICE where branchPin=@branchPin", Params);
            return Result.Rows.Count;

        }

        #endregion
    }
}
