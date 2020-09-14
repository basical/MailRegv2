using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Managers
{
    public class Question_Manager
    {
        string error = string.Empty;
        int defaultNum = 0;
        string defaultString = "";

        public List<Questions> getAllQuestion()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM idg_Status_AD WHERE Code IS NOT NULL; ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Questions> list_data = new List<Questions>();

                while (reader.Read())
                {
                    Questions data = new Questions
                    {
                        Questions_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0),
                        Questions_Name = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        Questions_Name_Eng = reader.IsDBNull(2) ? defaultString : reader.GetString(2),
                        Questions_Remark = reader.IsDBNull(3) ? defaultString : reader.GetString(3),
                        Questions_Sort = reader.IsDBNull(4) ? defaultNum : reader.GetInt32(4)
                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Question_Manager --> getAllQuestion() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Question_Manager --> getAllQuestion() ";
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