using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Managers
{
    public class AD_Status_Manager
    {
        string error = string.Empty;
        int defaultNum = 0;
        string defaultString = "";

        public List<AD_Status> getAllADStatus()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM idg_Status_AD WHERE Code IS NOT NULL; ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<AD_Status> list_data = new List<AD_Status>();

                while (reader.Read())
                {
                    AD_Status data = new AD_Status
                    {
                        AD_Status_Code = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0),
                        AD_Status_Name = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        AD_Status_Sort = reader.IsDBNull(2) ? defaultNum : reader.GetInt32(2),
                        AD_Status_Remark = reader.IsDBNull(3) ? defaultString : reader.GetString(3)
                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> AD_Status_Manager --> getAllADStatus() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> AD_Status_Manager --> getAllADStatus() ";
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