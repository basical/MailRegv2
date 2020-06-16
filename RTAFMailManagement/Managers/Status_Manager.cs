using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Managers
{
    public class Status_Manager
    {
        string error = string.Empty;
        int defaultNum = 0;
        string defaultString = "";
        public List<Status> getAllStatus()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM idg_Status ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Status> list_data = new List<Status>();

                while (reader.Read())
                {
                    Status data = new Status
                    {
                        status_Code = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0),
                        status_Name = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        status_Sort = reader.IsDBNull(2) ? defaultNum : reader.GetInt32(2),
                        status_Remark = reader.IsDBNull(3) ? defaultString : reader.GetString(3)
                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Status_Manager --> getAllStatus() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Status_Manager --> getAllStatus() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}