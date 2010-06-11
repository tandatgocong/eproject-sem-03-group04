using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;


namespace DataAccessLayers
{
    public  class DatabaseConnect
    {
        public  SqlConnection conn;        
        public  DatabaseConnect()
        {
            try
            {
                conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["OnlinePostOfficeManagement"].ConnectionString);
            }
            catch (Exception)
            {
                return;
            }
            
        }
        public  DataTable CreateDataTable(string Query)
        {
            try
            {
                SqlDataAdapter adt = new SqlDataAdapter(Query, conn);
                DataTable Result = new DataTable();
                adt.Fill(Result);
                return Result;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            
        }
        public  DataTable CreateDataTable(string Query, SqlParameter[] Params)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddRange(Params);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable Result = new DataTable();
                adt.Fill(Result);
                return Result;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
           
        }
        public  int ExcuteNonQuery(string Query, SqlParameter[] Params)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddRange(Params);
                 return   cmd.ExecuteNonQuery();                
            }
            catch (Exception )
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
            
        }
        public int ExcuteNonQuery(string Query)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception )
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public string WebLogin(string username, string pass)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.CommandText = "WebLogin";
                cmd.Parameters.Add("@email", SqlDbType.Char, 50);
                cmd.Parameters["@email"].Value = username.ToString();
                cmd.Parameters.Add("@password", SqlDbType.Char, 50);
                cmd.Parameters["@password"].Value = pass.ToString();
                cmd.Parameters.Add("@result", SqlDbType.Char, 50);
                cmd.Parameters[2].Direction = ParameterDirection.Output;                
                cmd.ExecuteNonQuery();
                string returnValue = (string)cmd.Parameters["@result"].Value;
                return returnValue;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool IsExisted(string email)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.CommandText = "IsExisted";
                cmd.Parameters.Add("@email", SqlDbType.Char, 50);
                cmd.Parameters["@email"].Value = email.ToString();              
                cmd.Parameters.Add("@result", SqlDbType.Bit);
                cmd.Parameters[1].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                bool returnValue = (bool)cmd.Parameters["@result"].Value;
                return returnValue;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
