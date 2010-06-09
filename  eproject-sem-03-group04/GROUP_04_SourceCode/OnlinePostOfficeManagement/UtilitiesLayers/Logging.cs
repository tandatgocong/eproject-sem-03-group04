using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using System.Configuration; 
using System.Web;

namespace UtilitiesLayers
{
    public static class Logging
    {
        private static string filename = string.Empty; 
        private static string appName = string.Empty;
        private static void Reset()
        {                    
            
            filename = HttpContext.Current.Server.MapPath(".") + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            appName = ConfigurationManager.AppSettings["App"].ToString();
        }
        
        public static void WriteString(string user,string message)
        {
            Reset();             
            StreamWriter sw = new StreamWriter(filename, true, Encoding.UTF8);
            sw.WriteLine(DateTime.Now.ToString() + "$" + user + "$" +  message); 
            sw.Close();     
        }


        public static void WriteError(string user, string error)
        {
            Reset();
            StreamWriter sw = new StreamWriter(filename, true, Encoding.UTF8);
            sw.WriteLine(DateTime.Now.ToString() + "$" + user + "$" + error);
            sw.Close();
        }

      
        public static void WriteStacktrace(string error, string Stacktrace)
        {
            Reset();
            StreamWriter sw = new StreamWriter(filename, true, Encoding.UTF8);
            sw.WriteLine(DateTime.Now.ToString() + "$" + error);
            sw.WriteLine(DateTime.Now.ToString() + "$" + Stacktrace);
            sw.Close();
        }
    }
}
