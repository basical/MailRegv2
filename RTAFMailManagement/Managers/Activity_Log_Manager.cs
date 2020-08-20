using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;

using System;
using System.Data;
using System.Data.SqlClient;

namespace RTAFMailManagement.Managers
{
    public class Activity_Log_Manager
    {
        string error = string.Empty;
        readonly int defaultNum = 0;
        readonly string defaultString = "";

        public bool AddActivityLogs(Activity_Log data)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_i_Activity_Log]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_act_log_user", data.Act_log_user);
                cmd.Parameters.AddWithValue("@i_act_log_ip", data.Act_log_ip);
                cmd.Parameters.AddWithValue("@i_act_log_details", data.Act_log_details);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Activity_Log_Manager --> AddActivityLogs() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Activity_Log_Manager --> AddActivityLogs() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}