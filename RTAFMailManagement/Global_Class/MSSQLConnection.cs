﻿using System;
using System.Data.SqlClient;
using System.Configuration;

namespace RTAFMailManagement.Global_Class
{
    public class MSSQLConnection
    {
        public static SqlConnection connectionMSSQL()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MSSQLConnectDBRTAFPerson"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                return con;
            }
            catch (SqlException ex)
            {
                string error = "ไม่สามารถเชื่อมต่อไปยังฐานข้อมูล Microsoft SQL Server ได้ ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                string error = "ไม่สามารถติดต่อฐานข้อมูล Microsoft SQL Server ได้ ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
        }
    }
}