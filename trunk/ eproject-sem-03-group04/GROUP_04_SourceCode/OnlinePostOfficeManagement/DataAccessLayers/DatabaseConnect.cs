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
            catch (Exception ex)
            {
                UtilitiesLayers.Logging.WriteString("system", ex.Message.ToString());
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
            catch (Exception ex)
            {
                UtilitiesLayers.Logging.WriteString("system", ex.Message.ToString());
                return 0;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
