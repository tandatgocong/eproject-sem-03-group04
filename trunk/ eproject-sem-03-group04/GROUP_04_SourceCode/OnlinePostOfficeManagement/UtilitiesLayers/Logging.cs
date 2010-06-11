using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using System.Configuration; 
using System.Web;
using System.Web.UI.WebControls;

namespace UtilitiesLayers
{
    public static class Logging
    {
        public class log
        {
            DateTime dateTime;

            public DateTime DateTime
            {
                get { return dateTime; }
                set { dateTime = value; }
            }
            string userName;

            public string UserName
            {
                get { return userName; }
                set { userName = value; }
            }

            string message;

            public string Message
            {
                get { return message; }
                set { message = value; }
            }

            public log()
            {
                this.DateTime = DateTime.Now;
                this.UserName = "";
                this.Message = "";
            }
            public log(DateTime _date,string _user,string _mess)
            {
                this.DateTime = _date;
                this.UserName = _user;
                this.Message = _mess;
            }
        };
       
        private static string filename = string.Empty; 
        private static string appName = string.Empty;
        private static void Reset()
        {

            filename = HttpContext.Current.Server.MapPath("") + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
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

        public static IList<UtilitiesLayers.Logging.log > ReadFileLog() 
        {
            Reset();
            string adminfileLog = HttpContext.Current.Server.MapPath("").ToString() + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string EmployeefileLog = HttpContext.Current.Server.MapPath("").ToString().Replace("WebAdmin", "WebEmployee") + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string customerfileLog = HttpContext.Current.Server.MapPath("").ToString().Replace("WebAdmin", "WebCustomer") + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string str="";
            char[] delim = { '$' };
            List<UtilitiesLayers.Logging.log> List = new List<UtilitiesLayers.Logging.log>();
           // Admin
            StreamReader sr = new StreamReader(adminfileLog);
            while ((str = sr.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;                        
                    }
                    i++;
                }
               
                List.Add(obj);
            }
            sr.Close();
            // Employee
            StreamReader sr1 = new StreamReader(EmployeefileLog);
            while ((str = sr1.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;
                    }
                    i++;
                }

                List.Add(obj);
            }
            sr1.Close();
            // Customer
            StreamReader sr2 = new StreamReader(customerfileLog);
            while ((str = sr2.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;
                    }
                    i++;
                }

                List.Add(obj);
            }
            sr2.Close();
            /////////////////////////
            
            return List;
        }
        public static IList<UtilitiesLayers.Logging.log> ReadFileLog(string username)
        {
            Reset();
            string adminfileLog = HttpContext.Current.Server.MapPath("").ToString() + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string EmployeefileLog = HttpContext.Current.Server.MapPath("").ToString().Replace("WebAdmin", "WebEmployee") + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string customerfileLog = HttpContext.Current.Server.MapPath("").ToString().Replace("WebAdmin", "WebCustomer") + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string str = "";
            char[] delim = { '$' };
            List<UtilitiesLayers.Logging.log> List = new List<UtilitiesLayers.Logging.log>();
            // Admin
            StreamReader sr = new StreamReader(adminfileLog);
            while ((str = sr.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;
                    }
                    i++;
                }
                if (obj.UserName.Equals(username) == true)
                {
                    List.Add(obj);
                }
            }
            sr.Close();
            // Employee
            StreamReader sr1 = new StreamReader(EmployeefileLog);
            while ((str = sr1.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;
                    }
                    i++;
                }

                if (obj.UserName.Equals(username) == true)
                {
                    List.Add(obj);
                }
            }
            sr1.Close();
            // Customer
            StreamReader sr2 = new StreamReader(customerfileLog);
            while ((str = sr2.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;
                    }
                    i++;
                }

                if (obj.UserName.Equals(username) == true)
                {
                    List.Add(obj);
                }
            }
            sr2.Close();
            /////////////////////////

            return List;
        }

        public static IList<UtilitiesLayers.Logging.log> ReadFileLog(DateTime date)
        {
            Reset();
            string adminfileLog = HttpContext.Current.Server.MapPath("").ToString() + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string EmployeefileLog = HttpContext.Current.Server.MapPath("").ToString().Replace("WebAdmin", "WebEmployee") + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string customerfileLog = HttpContext.Current.Server.MapPath("").ToString().Replace("WebAdmin", "WebCustomer") + "/" + ConfigurationManager.AppSettings["FileLog"].ToString();
            string str = "";
            char[] delim = { '$' };
            List<UtilitiesLayers.Logging.log> List = new List<UtilitiesLayers.Logging.log>();
            // Admin
            StreamReader sr = new StreamReader(adminfileLog);
            while ((str = sr.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;
                    }
                    i++;
                }
                if (obj.DateTime.Date == date.Date)
                {
                    List.Add(obj);
                }
            }
            sr.Close();
            // Employee
            StreamReader sr1 = new StreamReader(EmployeefileLog);
            while ((str = sr1.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;
                    }
                    i++;
                }

                if (obj.DateTime.Date == date.Date)
                {
                    List.Add(obj);
                }
            }
            sr1.Close();
            // Customer
            StreamReader sr2 = new StreamReader(customerfileLog);
            while ((str = sr2.ReadLine()) != null)
            {
                int i = 1;
                string[] split = str.Split(delim);
                log obj = new log();
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 1)
                            obj.DateTime = DateTime.Parse(s.ToString());
                        else if (i == 2)
                            obj.UserName = s;
                        else if (i == 3)
                            obj.Message = s;
                    }
                    i++;
                }

                if (obj.DateTime.Date == date.Date)
                {
                    List.Add(obj);
                }
            }
            sr2.Close();
            /////////////////////////

            return List;
        }
    }
}
