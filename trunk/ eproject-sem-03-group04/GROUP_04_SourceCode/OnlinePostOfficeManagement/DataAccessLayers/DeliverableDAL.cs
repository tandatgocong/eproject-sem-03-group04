using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class DeliverableDAL : InterfaceDataLayers.IDeliverable
    {
        #region IDeliverable Members
        private DeliverableInfo Convert(DataRow Row)
        {
            DeliverableInfo info = new DeliverableInfo(
                        Row["deliverablePin"].ToString(), Row["customerSent"].ToString(),
                        Row["deliverableSubject"].ToString(), Row["deliverableDecriptions"].ToString(),
                        DateTime.Parse(Row["dateSent"].ToString()), DateTime.Parse(Row["dateReceived"].ToString()),
                        Row["personNameReceived"].ToString(), Row["personAddressReceived"].ToString(),
                        Row["personPhoneReceived"].ToString(), Row["personEmailReceived"].ToString(),
                        float.Parse(Row["totalWeight"].ToString()), float.Parse(Row["totalDistance"].ToString()),
                        float.Parse(Row["totalCharges"].ToString()), bool.Parse(Row["deliverableStatus"].ToString()),
                        Row["deliverableNote"].ToString(), Row["servicesType"].ToString(), Row["employeeId"].ToString()
                        );
            return info;
        }
        public List<DataModelLayers.DeliverableInfo> getListDeliverable()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from DELIVERABLE");
            List<DeliverableInfo> List = new List<DeliverableInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.DeliverableInfo> getDeliverableDetail(string _deliverablePin)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("deliverablePin",_deliverablePin)
            };

            DataTable Result = Conn.CreateDataTable("select * from  DELIVERABLE where deliverablePin=@deliverablePin", Params);
            List<DeliverableInfo> List = new List<DeliverableInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.DeliverableInfo> searchDeliverable(string _deliverableSubject)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from DELIVERABLE WHERE deliverableSubject like '%" + _deliverableSubject.Trim().ToString() + "%'");
            List<DeliverableInfo> List = new List<DeliverableInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertDeliverable(DataModelLayers.DeliverableInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("deliverablePin", "DELIVERABLE", "DEL", "0000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("deliverablePin", id),
                    new SqlParameter("customerSent", info.CustomerSent),
                    new SqlParameter("deliverableSubject", info.DeliverableSubject),
                    new SqlParameter("deliverableDecriptions", info.DeliverableDecriptions),
                    new SqlParameter("dateSent", info.DateSent),
                    new SqlParameter("dateReceived", info.DateReceived),
                    new SqlParameter("personNameReceived", info.PersonNameReceived),
                    new SqlParameter("personAddressReceived", info.PersonAddressReceived),
                    new SqlParameter("personPhoneReceived", info.PersonPhoneReceived),
                    new SqlParameter("personEmailReceived", info.PersonEmailReceived),
                    new SqlParameter("totalWeight", info.TotalWeight),
                    new SqlParameter("totalDistance", info.TotalDistance),
                    new SqlParameter("totalCharges", info.TotalCharges),
                    new SqlParameter("deliverableStatus", info.DeliverableStatus),
                    new SqlParameter("deliverableNote", info.DeliverableNote),
                    new SqlParameter("servicesType", info.ServicesType),
                    new SqlParameter("employeeId", info.EmployeeId)
            };
            string sql = "INSERT INTO DELIVERABLE VALUES(@deliverablePin, @customerSent,";
            sql = sql + " @deliverableSubject,@deliverableDecriptions,@dateSent,@dateReceived,";
            sql = sql + " @personNameReceived,@personAddressReceived,@personPhoneReceived,@personEmailReceived,";
            sql = sql + " @totalWeight,@totalDistance,@totalCharges,@deliverableStatus,";
            sql = sql + " @deliverableNote,@servicesType,@employeeId)";
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateDeliverable(DataModelLayers.DeliverableInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("deliverablePin", info.DeliverablePin),
                    new SqlParameter("customerSent", info.CustomerSent),
                    new SqlParameter("deliverableSubject", info.DeliverableSubject),
                    new SqlParameter("deliverableDecriptions", info.DeliverableDecriptions),
                    new SqlParameter("dateSent", info.DateSent),
                    new SqlParameter("dateReceived", info.DateReceived),
                    new SqlParameter("personNameReceived", info.PersonNameReceived),
                    new SqlParameter("personAddressReceived", info.PersonAddressReceived),
                    new SqlParameter("personPhoneReceived", info.PersonPhoneReceived),
                    new SqlParameter("personEmailReceived", info.PersonEmailReceived),
                    new SqlParameter("totalWeight", info.TotalWeight),
                    new SqlParameter("totalDistance", info.TotalDistance),
                    new SqlParameter("totalCharges", info.TotalCharges),
                    new SqlParameter("deliverableStatus", info.DeliverableStatus),
                    new SqlParameter("deliverableNote", info.DeliverableNote),
                    new SqlParameter("servicesType", info.ServicesType),
                    new SqlParameter("employeeId", info.EmployeeId)
            };
            string sql = "UPDATE DELIVERABLE SET customerSent=@customerSent, customerSent=@customerSent,";
            sql = sql + " deliverableSubject=@deliverableSubject,deliverableDecriptions=@deliverableDecriptions,dateSent=@dateSent,dateReceived=@dateReceived,";
            sql = sql + " personNameReceived=@personNameReceived,personAddressReceived=@personAddressReceived,personPhoneReceived=@personPhoneReceived,personEmailReceived=@personEmailReceived,";
            sql = sql + " totalWeight=@totalWeight,totalDistance=@totalDistance,totalCharges=@totalCharges,deliverableStatus=@deliverableStatus,";
            sql = sql + " deliverableNote=@deliverableNote,servicesType=@servicesType,employeeId=@employeeId WHERE deliverablePin=@deliverablePin";
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery(sql, Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteDeliverable(string _deliverablePin)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("deliverablePin", _deliverablePin)
            };
            DeliverableInfo tmp = this.getDeliverableInfo(_deliverablePin);
            if (!tmp.DeliverablePin.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE DELIVERABLE where deliverablePin=@deliverablePin", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public DataModelLayers.DeliverableInfo getDeliverableInfo(string _deliverablePin)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("deliverablePin",_deliverablePin)
            };
            DataTable Result = Conn.CreateDataTable("select * from  DELIVERABLE where deliverablePin=@deliverablePin", Params);
            if (Result.Rows.Count != 1)
            {
                return new DeliverableInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        #endregion
    }
}
