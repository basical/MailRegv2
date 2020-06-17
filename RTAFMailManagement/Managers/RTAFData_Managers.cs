using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Managers
{
    public class RTAFData_Managers
    {
        string error = string.Empty;
        readonly int defaultNum = 0;
        readonly string defaultString = "";
        string id_error = string.Empty;

        public RTAF_DATA GetCheckPersonalData(string i_IdCard, string i_IdGvm, string i_BirthDate, string i_Name, int i_Rank, int i_Unit, string i_Position, string i_status)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_chkRTAFData]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_IdCard", i_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", i_IdGvm);
                cmd.Parameters.AddWithValue("@i_BirthDate", i_BirthDate);
                cmd.Parameters.AddWithValue("@i_Name", i_Name);
                cmd.Parameters.AddWithValue("@i_Rank", i_Rank);
                cmd.Parameters.AddWithValue("@i_Unit", i_Unit);
                cmd.Parameters.AddWithValue("@i_Position", i_Position);
                cmd.Parameters.AddWithValue("@i_status", i_status);

                SqlDataReader reader = cmd.ExecuteReader();

                RTAF_DATA data = new RTAF_DATA();

                if (reader.Read())
                {
                    data.rtaf_person_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt64(0);
                    data.rtaf_person_IdCard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    data.rtaf_person_IdGvm = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    data.rtaf_person_BirthDate = reader.IsDBNull(3) ? defaultString : reader.GetDateTime(3).ToString();
                    data.rtaf_person_FirstName = reader.IsDBNull(4) ? defaultString : reader.GetString(4).IndexOf(' ') > 1 ? reader.GetString(4).Split(' ')[0] : reader.GetString(4);
                    data.rtaf_person_LastName = reader.IsDBNull(4) ? defaultString : reader.GetString(4).IndexOf(' ') > 1 ? reader.GetString(4).Split(' ')[1] : "";

                    data.Rank = new Ranks
                    {
                        rank_Name = reader.IsDBNull(5) ? defaultString : reader.GetString(5)
                    };

                    data.Unit = new Units
                    {
                        unit_Name = reader.IsDBNull(6) ? defaultString : reader.GetString(6)
                    };

                    data.rtaf_person_Type = reader.IsDBNull(7) ? defaultNum : reader.GetInt32(7);
                    data.rtaf_person_Enable = reader.IsDBNull(8) ? defaultNum : reader.GetInt32(8);
                    data.rtaf_person_UpdateDate = reader.IsDBNull(9) ? defaultString : reader.GetDateTime(9).ToString();
                    data.rtaf_person_CreateDate = reader.IsDBNull(10) ? defaultString : reader.GetDateTime(10).ToString();
                    data.rtaf_person_Position = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    data.status = reader.IsDBNull(12) ? defaultString : reader.GetString(12);

                    id_error = data.rtaf_person_id.ToString();
                }
                else
                {
                    data = null;
                }

                return data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> getCheckPersonalData() : id_error => " + id_error;
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> getCheckPersonalData() : id_error => " + id_error;
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public RTAF_DATA GetRTAFData(string i_IdCard, string i_IdGvm)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_RTAFData]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_IdCard", i_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", i_IdGvm);

                SqlDataReader reader = cmd.ExecuteReader();

                RTAF_DATA data = new RTAF_DATA();

                if (reader.Read())
                {
                    data.rtaf_person_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt64(0);
                    data.rtaf_person_IdCard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    data.rtaf_person_IdGvm = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    data.rtaf_person_BirthDate = reader.IsDBNull(3) ? defaultString : reader.GetDateTime(3).ToString();
                    data.rtaf_person_FirstName = reader.IsDBNull(4) ? defaultString : reader.GetString(4).IndexOf(' ') > 1 ? reader.GetString(4).Split(' ')[0] : reader.GetString(4);
                    data.rtaf_person_LastName = reader.IsDBNull(4) ? defaultString : reader.GetString(4).IndexOf(' ') > 1 ? reader.GetString(4).Split(' ')[1] : "";

                    data.Rank = new Ranks
                    {
                        rank_Code = reader.IsDBNull(5) ? defaultNum : reader.GetInt32(5)
                    };

                    data.Unit = new Units
                    {
                        unit_Code = reader.IsDBNull(6) ? defaultNum : reader.GetInt32(6)
                    };

                    data.rtaf_person_Type = reader.IsDBNull(7) ? defaultNum : reader.GetInt32(7);
                    data.rtaf_person_Enable = reader.IsDBNull(8) ? defaultNum : reader.GetInt32(8);
                    data.rtaf_person_UpdateDate = reader.IsDBNull(9) ? defaultString : reader.GetDateTime(9).ToString();
                    data.rtaf_person_CreateDate = reader.IsDBNull(10) ? defaultString : reader.GetDateTime(10).ToString();
                    data.rtaf_person_Position = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    data.status = reader.IsDBNull(12) ? defaultString : reader.GetString(12);

                    id_error = data.rtaf_person_id.ToString();
                }
                else
                {
                    data = null;
                }

                return data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> getRTAFData() : id_error => " + id_error;
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> getRTAFData() : id_error => " + id_error;
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<RTAF_DATA> GetRTAFDataByUnit(int i_Unit)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_listRTAFDataByUnit]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Unit", i_Unit);

                SqlDataReader reader = cmd.ExecuteReader();

                List<RTAF_DATA> list_data = new List<RTAF_DATA>();

                while (reader.Read())
                {
                    RTAF_DATA data = new RTAF_DATA
                    {
                        rtaf_person_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt64(0),
                        rtaf_person_IdCard = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        rtaf_person_IdGvm = reader.IsDBNull(2) ? defaultString : reader.GetString(2),
                        rtaf_person_BirthDate = reader.IsDBNull(3) ? defaultString : reader.GetDateTime(3).ToString(),
                        rtaf_person_FirstName = reader.IsDBNull(4) ? defaultString : reader.GetString(4).IndexOf(' ') > 1 ? reader.GetString(4).Split(' ')[0] : reader.GetString(4),
                        rtaf_person_LastName = reader.IsDBNull(4) ? defaultString : reader.GetString(4).IndexOf(' ') > 1 ? reader.GetString(4).Split(' ')[1] : "",

                        Rank = new Ranks
                        {
                            rank_Name = reader.IsDBNull(5) ? defaultString : reader.GetString(5)
                        },

                        Unit = new Units
                        {
                            unit_Name = reader.IsDBNull(6) ? defaultString : reader.GetString(6)
                        },

                        rtaf_person_Type = reader.IsDBNull(7) ? defaultNum : reader.GetInt32(7),
                        rtaf_person_Enable = reader.IsDBNull(8) ? defaultNum : reader.GetInt32(8),
                        rtaf_person_UpdateDate = reader.IsDBNull(9) ? defaultString : reader.GetDateTime(9).ToString(),
                        rtaf_person_CreateDate = reader.IsDBNull(10) ? defaultString : reader.GetDateTime(10).ToString(),
                        rtaf_person_Position = reader.IsDBNull(11) ? defaultString : reader.GetString(11),
                        status = reader.IsDBNull(12) ? defaultString : reader.GetString(12),

                    };

                    id_error = data.rtaf_person_id.ToString();

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> getAllRTAFData() : id_error => " + id_error;
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> getAllRTAFData() : id_error => " + id_error;
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AddPersonalData(RTAF_DATA data)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_i_RTAFData]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_IdCard", data.rtaf_person_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", General_Functions.subStringIdGvm(data.rtaf_person_IdGvm));
                cmd.Parameters.AddWithValue("@i_BirthDate", DateTimeUtility.CDateTime4Service2MSSQL(data.rtaf_person_BirthDate));
                cmd.Parameters.AddWithValue("@i_Name", data.rtaf_person_FirstName + " " + data.rtaf_person_LastName);
                cmd.Parameters.AddWithValue("@i_Rank", data.Rank.rank_Code);
                cmd.Parameters.AddWithValue("@i_Unit", data.Unit.unit_Code);
                cmd.Parameters.AddWithValue("@i_Position", data.rtaf_person_Position);
                cmd.Parameters.AddWithValue("@i_status", data.status);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> addPersonalData() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> addPersonalData() " ;
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool EditPersonalData(RTAF_DATA data)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_u_RTAFData]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_IdCard", data.rtaf_person_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", General_Functions.subStringIdGvm(data.rtaf_person_IdGvm));
                cmd.Parameters.AddWithValue("@i_BirthDate", DateTimeUtility.CDateTime4Service2MSSQL(data.rtaf_person_BirthDate));
                cmd.Parameters.AddWithValue("@i_Name", data.rtaf_person_FirstName + " " + data.rtaf_person_LastName);
                cmd.Parameters.AddWithValue("@i_Rank", data.Rank.rank_Code);
                cmd.Parameters.AddWithValue("@i_Unit", data.Unit.unit_Code);
                cmd.Parameters.AddWithValue("@i_Position", data.rtaf_person_Position);
                cmd.Parameters.AddWithValue("@i_status", data.status);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> editPersonalData() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> editPersonalData() ";
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