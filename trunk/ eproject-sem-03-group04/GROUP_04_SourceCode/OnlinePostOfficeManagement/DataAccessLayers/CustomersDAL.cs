using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
    public class CustomersDAL : InterfaceDataLayers.ICustomers
    {
       #region ICustomers Members
        private CustomerInfo Convert(DataRow Row)
        {
            CustomerInfo info = new CustomerInfo(Row["customerId"].ToString(), Row["customerEmail"].ToString(), Row["customerPassword"].ToString(), Row["customerFistName"].ToString(), Row["customerLastName"].ToString(), DateTime.Parse(Row["customerBirthday"].ToString()), bool.Parse(Row["customerSex"].ToString()), Row["customerAddress"].ToString(), Row["customerPhone"].ToString());
            return info;
        }
        public List<CustomerInfo> getListCustomers()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from CUSTOMER");
            List<CustomerInfo> List = new List<CustomerInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<CustomerInfo> getCustomerDetail(string _CustomersId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("customerId",_CustomersId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  CUSTOMER where customerId=@customerId", Params);
            List<CustomerInfo> List = new List<CustomerInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<CustomerInfo> searchCustomers(string _CustomersName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from CUSTOMER WHERE (customerFistName + customerLastName)  like '%" + _CustomersName.Trim().ToString() + "%'");
            List<CustomerInfo> List = new List<CustomerInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertCustomers(CustomerInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("customerId", "CUSTOMER", "CUS", "0000000");
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("customerId", id),
                    new SqlParameter("customerEmail", info.CustomerEmail),
                    new SqlParameter("customerPassword", info.CustomerPassword),
                    new SqlParameter("customerFistName", info.CustomerFistName),
                    new SqlParameter("customerLastName", info.CustomerLastName),
                    new SqlParameter("customerBirthday", info.CustomerBirthday),
                    new SqlParameter("customerSex", info.CustomerSex),
                    new SqlParameter("customerAddress", info.CustomerAddress),
                    new SqlParameter("customerPhone", info.CustomerPhone)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO CUSTOMER VALUES(@customerId, @customerEmail,@customerPassword,@customerFistName,@customerLastName,@customerBirthday,@customerSex,@customerAddress,@customerPhone)", Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateCustomers(CustomerInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("customerId", info.CustomerId),
                    new SqlParameter("customerEmail", info.CustomerEmail),
                    new SqlParameter("customerPassword", info.CustomerPassword),
                    new SqlParameter("customerFistName", info.CustomerFistName),
                    new SqlParameter("customerLastName", info.CustomerLastName),
                    new SqlParameter("customerBirthday", info.CustomerBirthday),
                    new SqlParameter("customerSex", info.CustomerSex),
                    new SqlParameter("customerAddress", info.CustomerAddress),
                    new SqlParameter("customerPhone", info.CustomerPhone)
                };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("UPDATE CUSTOMER SET customerEmail = @customerEmail, customerPassword = @customerPassword, customerFistName = @customerFistName, customerLastName=@customerLastName, customerBirthday=@customerBirthday,customerSex=@customerSex,customerAddress=@customerAddress,customerPhone=@customerPhone where customerId=@customerId", Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteCustomers(string _CustomersId)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("customerId", _CustomersId)
            };
            CustomerInfo tmp = this.getCustomerInfo(_CustomersId);
            if (!tmp.CustomerId.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE CUSTOMER where customerId=@customerId", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        public CustomerInfo getCustomerInfo(string _CustomersId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("customerId",_CustomersId)
            };
            DataTable Result = Conn.CreateDataTable("select * from  CUSTOMER where customerId=@customerId", Params);
            if (Result.Rows.Count != 1)
            {
                return new CustomerInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }

        #endregion
    }
}