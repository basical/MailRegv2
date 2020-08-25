using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RTAFMailManagement.Managers
{
    public class Users_Mananer
    {
        string error = string.Empty;
        readonly int defaultNum = 0;
        readonly string defaultString = "";

        public bool ChangeADStatusDB(string userName, int AD_status)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_u_ADStatus]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_UerName", userName);
                cmd.Parameters.AddWithValue("@i_ADStatus", AD_status);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Users_Mananer --> ChangeADSTatus() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Users_Mananer --> ChangeADSTatus() ";
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