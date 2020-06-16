using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Managers
{
    public class Units_Manager
    {
        string error = string.Empty;
        int defaultNum = 0;
        string defaultString = "";
        public List<Units> getAllUnits()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM idg_Unit WHERE Code IS NOT NULL; ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Units> list_data = new List<Units>();

                while (reader.Read())
                {
                    Units data = new Units
                    {
                        unit_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt64(0),
                        unit_Code = reader.IsDBNull(1) ? defaultNum : reader.GetInt64(1),
                        unit_Name = reader.IsDBNull(2) ? defaultString : reader.GetString(2),
                        unit_FullName = reader.IsDBNull(3) ? defaultString : reader.GetString(3),
                        unit_SubCode = reader.IsDBNull(4) ? defaultNum : reader.GetInt64(4),
                        unit_Sort = reader.IsDBNull(5) ? defaultNum : reader.GetInt32(5),
                        unit_Level = reader.IsDBNull(6) ? defaultNum : reader.GetInt32(6),
                        unit_OUName = reader.IsDBNull(7) ? defaultString : reader.GetString(7),
                        unit_GroupName = reader.IsDBNull(8) ? defaultString : reader.GetString(8),
                        unit_Remark = reader.IsDBNull(9) ? defaultString : reader.GetString(9)
                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Units_Manager --> getAllUnits() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Units_Manager --> getAllUnits() ";
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