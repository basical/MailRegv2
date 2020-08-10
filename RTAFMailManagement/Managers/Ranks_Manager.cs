using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Managers
{
    public class Ranks_Manager
    {
        string error = string.Empty;
        int defaultNum = 0;
        string defaultString = "";

        public List<Ranks> getAllRanks()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM idg_Rank ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Ranks> list_data = new List<Ranks>();

                while (reader.Read())
                {
                    Ranks data = new Ranks
                    {
                        Rank_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt64(0),
                        Rank_Code = reader.IsDBNull(1) ? defaultNum : reader.GetInt32(1),
                        Rank_Name = reader.IsDBNull(2) ? defaultString : reader.GetString(2),
                        Rank_FullName = reader.IsDBNull(3) ? defaultString : reader.GetString(3),
                        Rank_NameEng = reader.IsDBNull(4) ? defaultString : reader.GetString(4),
                        Rank_FullNameEng = reader.IsDBNull(5) ? defaultString : reader.GetString(5),
                        Rank_GroupName = reader.IsDBNull(6) ? defaultString : reader.GetString(6),
                        Rank_Remark = reader.IsDBNull(7) ? defaultString : reader.GetString(7),
                        Rank_Sort = reader.IsDBNull(8) ? defaultNum : reader.GetInt32(8),
                        Rank_Mailbox = reader.IsDBNull(9) ? defaultString : reader.GetString(9),
                        Rank_sortrank = reader.IsDBNull(10) ? defaultNum : reader.GetInt32(10),
                        Rank_rankgroup = reader.IsDBNull(11) ? defaultString : reader.GetString(11),
                        Rank_ranktype = reader.IsDBNull(12) ? defaultNum : reader.GetInt32(12)
                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Ranks_Manager --> getAllRanks() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Ranks_Manager --> getAllRanks() ";
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