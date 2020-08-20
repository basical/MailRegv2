using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;

using System;
using System.Data;
using System.Data.SqlClient;

namespace RTAFMailManagement.Managers
{
    public class Admin_User_Manager
    {
        string error = string.Empty;
        readonly int defaultNum = 0;
        readonly string defaultString = "";

        public Admin_Users GetCheckAdministratorLevel(string i_username)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_chkAdminUser]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_username", i_username);

                SqlDataReader reader = cmd.ExecuteReader();

                Admin_Users data = new Admin_Users();

                if (reader.Read())
                {
                    data.Admin_Users_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    data.Admin_Users_Name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);

                    data.Admin_User_Type = new Admin_Users_Type()
                    {
                        Admin_Users_Type_id = reader.IsDBNull(2) ? defaultNum : reader.GetInt32(2),
                        Admin_Users_Type_Name = reader.IsDBNull(3) ? defaultString : reader.GetString(3)
                    };

                    data.Admin_Users_Unit = new Units()
                    {
                        Unit_id = reader.IsDBNull(4) ? defaultNum : reader.GetInt64(4),
                        Unit_Code = reader.IsDBNull(5) ? defaultNum : reader.GetInt64(5),
                        Unit_Name = reader.IsDBNull(6) ? defaultString : reader.GetString(6),
                        Unit_FullName = reader.IsDBNull(7) ? defaultString : reader.GetString(7),
                        Unit_OUName = reader.IsDBNull(8) ? defaultString : reader.GetString(8)
                    };

                    data.Admin_User_detail = new Users()
                    {
                        User_FirstName = reader.IsDBNull(9) ? defaultString : reader.GetString(9),
                        User_LastName = reader.IsDBNull(10) ? defaultString : reader.GetString(10)
                    };
                }
                else
                {
                    data = null;
                }

                return data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Admin_User_Manager --> GetCheckAdministratorLevel()";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Admin_User_Manager --> GetCheckAdministratorLevel()";
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