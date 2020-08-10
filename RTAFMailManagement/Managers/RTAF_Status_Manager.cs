using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Managers
{
    public class RTAF_Status_Manager
    {
        string error = string.Empty;
        int defaultNum = 0;
        string defaultString = "";
        public List<RTAF_Status> getAllStatus()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM idg_Status ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<RTAF_Status> list_data = new List<RTAF_Status>();

                while (reader.Read())
                {
                    RTAF_Status data = new RTAF_Status
                    {
                        RTAF_status_Code = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0),
                        RTAF_status_Name = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        RTAF_status_Sort = reader.IsDBNull(2) ? defaultNum : reader.GetInt32(2),
                        RTAF_status_Remark = reader.IsDBNull(3) ? defaultString : reader.GetString(3)
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