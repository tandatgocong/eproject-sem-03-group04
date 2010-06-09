using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class FeedbackDAL : InterfaceDataLayers.IFeedback
    {
        #region IFeedback Members
        private FeedbackInfo Convert(DataRow Row)
        {
            FeedbackInfo info = new FeedbackInfo(Row["Id"].ToString(), Row["Name"].ToString(),
                Row["Email"].ToString(), Row["Address"].ToString(),
                Row["Phone"].ToString(), Row["Subject"].ToString(),
                Row["Contend"].ToString(), DateTime.Parse(Row["datesubmit"].ToString()), bool.Parse(Row["status"].ToString()));
            return info;
        }
        public List<DataModelLayers.FeedbackInfo> getListFeedback()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from FEEDBACK_AND_CONTACT");
            List<FeedbackInfo> List = new List<FeedbackInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.FeedbackInfo> getFeedbackDetail(string _Id)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id",_Id)
            };

            DataTable Result = Conn.CreateDataTable("select * from  FEEDBACK_AND_CONTACT where Id=@Id", Params);
            List<FeedbackInfo> List = new List<FeedbackInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.FeedbackInfo> searchFeedback(string _Subject)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from FEEDBACK_AND_CONTACT WHERE Subject like '%" + _Subject.Trim().ToString() + "%'");
            List<FeedbackInfo> List = new List<FeedbackInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertFeedback(DataModelLayers.FeedbackInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("Id", "FEEDBACK_AND_CONTACT", "FAC", "0000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("Id", id),
                    new SqlParameter("Name", info.Name),
                    new SqlParameter("Email", info.Email),
                    new SqlParameter("Address", info.Address),
                    new SqlParameter("Phone", info.Phone),
                    new SqlParameter("Subject", info.Subject),
                    new SqlParameter("Contend", info.Contend),
                    new SqlParameter("datesubmit", info.Datesubmit),
                    new SqlParameter("status", info.Status)
                };
            string sql = "INSERT INTO FEEDBACK_AND_CONTACT VALUES(@Id, @Name,";
            sql = sql + " @Email,@Address,@Phone,@Subject,";
            sql = sql + " @Contend,@datesubmit,@status)";
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateFeedback(DataModelLayers.FeedbackInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("Id", info),
                    new SqlParameter("Name", info.Name),
                    new SqlParameter("Email", info.Email),
                    new SqlParameter("Address", info.Address),
                    new SqlParameter("Phone", info.Phone),
                    new SqlParameter("Subject", info.Subject),
                    new SqlParameter("Contend", info.Contend),
                    new SqlParameter("datesubmit", info.Datesubmit),
                    new SqlParameter("status", info.Status)
                };
            string sql = "UPDATE FEEDBACK_AND_CONTACT SET Name=@Name,";
            sql = sql + " Email=@Email,Address=@Address,Phone=@Phone,";
            sql = sql + " Subject=@Subject,Contend=@Contend,datesubmit=@datesubmit WHERE Id=@Id";
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteFeedback(string _Id)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id", _Id)
            };
            FeedbackInfo tmp = this.getFeedbackInfo(_Id);
            if (!tmp.Id.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE FEEDBACK_AND_CONTACT where Id=@Id", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public DataModelLayers.FeedbackInfo getFeedbackInfo(string _Id)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("Id",_Id)
            };
            DataTable Result = Conn.CreateDataTable("select * from  FEEDBACK_AND_CONTACT where Id=@Id", Params);
            if (Result.Rows.Count != 1)
            {
                return new FeedbackInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        #endregion
    }
}
