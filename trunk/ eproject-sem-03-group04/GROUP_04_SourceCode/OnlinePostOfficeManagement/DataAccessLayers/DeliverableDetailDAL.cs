using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class DeliverableDetailDAL : InterfaceDataLayers.IDeliverableDetail
    {
        #region IDeliverableDetail Members
        private DeliverableDetailInfo Convert(DataRow Row)
        {
            DeliverableDetailInfo info = new DeliverableDetailInfo(Row["detailId"].ToString(), Row["deliverablePin"].ToString(), Row["deliverableName"].ToString(), float.Parse(Row["deivrableWeight"].ToString()), Row["Decriptions"].ToString(), Row["Note"].ToString());
            return info;
        }
        public IList<DataModelLayers.DeliverableDetailInfo> getListDeliverableDetail()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from DELIVERABLE_DETAIL");
            List<DeliverableDetailInfo> List = new List<DeliverableDetailInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.DeliverableDetailInfo> getDeliverableDetail(string _detailId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("detailId",_detailId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  DELIVERABLE_DETAIL where detailId=@detailId", Params);
            List<DeliverableDetailInfo> List = new List<DeliverableDetailInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.DeliverableDetailInfo> searchDeliverableDetail(string _deliverableName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from DELIVERABLE_DETAIL WHERE deliverableName  like '%" + _deliverableName.Trim().ToString() + "%'");
            List<DeliverableDetailInfo> List = new List<DeliverableDetailInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertDeliverableDetail(DataModelLayers.DeliverableDetailInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("detailId", "DELIVERABLE_DETAIL", "DET", "0000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("detailId", id),
                    new SqlParameter("deliverablePin", info.DeliverablePin),
                    new SqlParameter("deliverableName", info.DeliverableName),
                    new SqlParameter("deivrableWeight", info.DeivrableWeight),
                    new SqlParameter("Decriptions", info.Decriptions),
                    new SqlParameter("Note", info.Note)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO DELIVERABLE_DETAIL VALUES(@detailId, @deliverablePin,@deliverableName,@deivrableWeight,@Decriptions,@Note)", Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateDeliverableDetail(DataModelLayers.DeliverableDetailInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("detailId", info.DetailId),
                    new SqlParameter("deliverablePin", info.DeliverablePin),
                    new SqlParameter("deliverableName", info.DeliverableName),
                    new SqlParameter("deivrableWeight", info.DeivrableWeight),
                    new SqlParameter("Decriptions", info.Decriptions),
                    new SqlParameter("Note", info.Note)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("UPDATE DELIVERABLE_DETAIL SET deliverableName = @deliverableName, deivrableWeight = @deivrableWeight, Decriptions = @Decriptions, Note=@Note where detailId=@detailId AND deliverablePin=@deliverablePin", Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteDeliverableDetail(string _detailId)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("detailId", _detailId)
            };
            DeliverableDetailInfo tmp = this.getDeliverableDetailInfo(_detailId);
            if (!tmp.DetailId.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE DELIVERABLE_DETAIL where detailId=@detailId", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public DataModelLayers.DeliverableDetailInfo getDeliverableDetailInfo(string _detailId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("detailId",_detailId)
            };
            DataTable Result = Conn.CreateDataTable("select * from  DELIVERABLE_DETAIL where detailId=@detailId", Params);
            if (Result.Rows.Count != 1)
            {
                return new DeliverableDetailInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        #endregion
    }
}
