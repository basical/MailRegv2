using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RTAFMailManagement.Managers
{
    public class RTAFData_Managers
    {
        string error = string.Empty;
        readonly int defaultNum = 0;
        readonly string defaultString = "";
        string id_error = string.Empty;

        public RTAF_DATA CheckPersonalData(RTAF_DATA sv_data)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_chkRTAF_Person]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_IdCard", sv_data.RTAF_person_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", sv_data.RTAF_person_IdGvm);
                cmd.Parameters.AddWithValue("@i_Rank_Code", sv_data.RTAF_person_Rank.Rank_Code);
                cmd.Parameters.AddWithValue("@i_FName", sv_data.RTAF_person_FirstName);
                cmd.Parameters.AddWithValue("@i_LName", sv_data.RTAF_person_LastName);
                cmd.Parameters.AddWithValue("@i_FName_Eng", sv_data.RTAF_person_FirstName_Eng);
                cmd.Parameters.AddWithValue("@i_LName_Eng", sv_data.RTAF_person_LastName_Eng);
                cmd.Parameters.AddWithValue("@i_BirthDate", DateTimeUtility.CDateTime4Service2MSSQL(sv_data.RTAF_person_BirthDate));
                cmd.Parameters.AddWithValue("@i_Unit_Code", sv_data.RTAF_person_Unit.Unit_Code);
                cmd.Parameters.AddWithValue("@i_Position", sv_data.RTAF_person_Position);
                cmd.Parameters.AddWithValue("@i_status", sv_data.RTAF_person_Status.RTAF_status_Name);
                cmd.Parameters.AddWithValue("@i_status_code", sv_data.RTAF_person_Status.RTAF_status_Code);

                SqlDataReader reader = cmd.ExecuteReader();

                RTAF_DATA data = new RTAF_DATA();

                if (reader.Read())
                {
                    data.RTAF_person_Uid = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    data.RTAF_person_IdCard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    data.RTAF_person_IdGvm = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    data.RTAF_person_FirstName = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    data.RTAF_person_LastName = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    data.RTAF_person_FirstName_Eng = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    data.RTAF_person_LastName_Eng = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    data.RTAF_person_BirthDate = reader.IsDBNull(7) ? defaultString : reader.GetDateTime(7).ToString();
                    data.RTAF_person_Position = reader.IsDBNull(8) ? defaultString : reader.GetString(8);

                    data.RTAF_person_Rank = new Ranks
                    {
                        Rank_Code = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9),
                        Rank_Name = reader.IsDBNull(10) ? defaultString : reader.GetString(10),
                        Rank_FullName = reader.IsDBNull(11) ? defaultString : reader.GetString(11)
                    };

                    data.RTAF_person_Unit = new Units
                    {
                        Unit_Code = reader.IsDBNull(12) ? defaultNum : (int)reader.GetInt64(12),
                        Unit_Name = reader.IsDBNull(13) ? defaultString : reader.GetString(13),
                        Unit_FullName = reader.IsDBNull(14) ? defaultString : reader.GetString(14)
                    };

                    data.RTAF_person_UpdateDate = reader.IsDBNull(15) ? defaultString : reader.GetDateTime(15).ToString();
                    data.RTAF_person_CreateDate = reader.IsDBNull(16) ? defaultString : reader.GetDateTime(16).ToString();

                    data.RTAF_person_Status = new RTAF_Status()
                    {
                        RTAF_status_Code = reader.IsDBNull(17) ? defaultNum : reader.GetInt32(17),
                        RTAF_status_Name = reader.IsDBNull(18) ? defaultString : reader.GetString(18)
                    };

                    data.RTAF_person_type = new RTAF_DATA_Person_Type()
                    {
                        Person_Type_Id = reader.IsDBNull(19) ? defaultNum : reader.GetInt32(19),
                        Person_Type_Name = reader.IsDBNull(20) ? defaultString : reader.GetString(20)
                    };

                    data.RTAF_user_status = new RTAF_DATA_User_Status()
                    {
                        User_Status_id = reader.IsDBNull(21) ? defaultNum : reader.GetInt32(21),
                        User_Status_Name = reader.IsDBNull(22) ? defaultString : reader.GetString(22)
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
                error = "SqlException ==> Managers --> RTAFData_Managers --> CheckPersonalData()";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> CheckPersonalData()";
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
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_RTAF_Persons]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_IdCard", i_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", i_IdGvm);

                SqlDataReader reader = cmd.ExecuteReader();

                RTAF_DATA data = new RTAF_DATA();

                if (reader.Read())
                {
                    data.RTAF_person_Uid = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    data.RTAF_person_IdCard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    data.RTAF_person_IdGvm = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    data.RTAF_person_FirstName = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    data.RTAF_person_LastName = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    data.RTAF_person_FirstName_Eng = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    data.RTAF_person_LastName_Eng = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    data.RTAF_person_BirthDate = reader.IsDBNull(7) ? defaultString : reader.GetDateTime(7).ToString();
                    data.RTAF_person_Position = reader.IsDBNull(8) ? defaultString : reader.GetString(8);

                    data.RTAF_person_Rank = new Ranks
                    {
                        Rank_Code = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9),
                        Rank_Name = reader.IsDBNull(10) ? defaultString : reader.GetString(10),
                        Rank_FullName = reader.IsDBNull(11) ? defaultString : reader.GetString(11),
                        Rank_NameEng = reader.IsDBNull(23) ? defaultString : reader.GetString(23),
                        Rank_FullNameEng = reader.IsDBNull(24) ? defaultString : reader.GetString(24)
                    };

                    data.RTAF_person_Unit = new Units
                    {
                        Unit_Code = reader.IsDBNull(12) ? defaultNum : (int)reader.GetInt64(12),
                        Unit_Name = reader.IsDBNull(13) ? defaultString : reader.GetString(13),
                        Unit_FullName = reader.IsDBNull(14) ? defaultString : reader.GetString(14)
                    };

                    data.RTAF_person_UpdateDate = reader.IsDBNull(15) ? defaultString : reader.GetDateTime(15).ToString();
                    data.RTAF_person_CreateDate = reader.IsDBNull(16) ? defaultString : reader.GetDateTime(16).ToString();

                    data.RTAF_person_Status = new RTAF_Status()
                    {
                        RTAF_status_Code = reader.IsDBNull(17) ? defaultNum : reader.GetInt32(17),
                        RTAF_status_Name = reader.IsDBNull(18) ? defaultString : reader.GetString(18)
                    };

                    data.RTAF_person_type = new RTAF_DATA_Person_Type()
                    {
                        Person_Type_Id = reader.IsDBNull(19) ? defaultNum : reader.GetInt32(19),
                        Person_Type_Name = reader.IsDBNull(20) ? defaultString : reader.GetString(20)
                    };

                    data.RTAF_user_status = new RTAF_DATA_User_Status()
                    {
                        User_Status_id = reader.IsDBNull(21) ? defaultNum : reader.GetInt32(21),
                        User_Status_Name = reader.IsDBNull(22) ? defaultString : reader.GetString(22)
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
                error = "SqlException ==> Managers --> RTAFData_Managers --> GetRTAFData() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> GetRTAFData() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<RTAF_DATA> GetRTAFDataByUnit(RTAF_DATA i_data, int row_str, int row_end)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_list_RTAF_Person]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_IdCard", "");
                cmd.Parameters.AddWithValue("@i_IdGvm", "");
                cmd.Parameters.AddWithValue("@i_Rank_Code", 0);
                cmd.Parameters.AddWithValue("@i_FName", "");
                cmd.Parameters.AddWithValue("@i_LName", "");
                cmd.Parameters.AddWithValue("@i_FName_Eng", "");
                cmd.Parameters.AddWithValue("@i_LName_Eng", "");
                cmd.Parameters.AddWithValue("@i_Unit_Code", i_data.RTAF_person_Unit.Unit_Code);
                cmd.Parameters.AddWithValue("@i_Position", "");
                cmd.Parameters.AddWithValue("@i_status", "");
                cmd.Parameters.AddWithValue("@i_status_code", 0);
                cmd.Parameters.AddWithValue("@i_row_str", row_str);
                cmd.Parameters.AddWithValue("@i_row_end", row_end);

                SqlDataReader reader = cmd.ExecuteReader();

                List<RTAF_DATA> list_data = new List<RTAF_DATA>();

                while (reader.Read())
                {
                    RTAF_DATA data = new RTAF_DATA
                    {
                        RTAF_person_Uid = reader.IsDBNull(0) ? defaultString : reader.GetString(0),
                        RTAF_person_IdCard = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        RTAF_person_IdGvm = reader.IsDBNull(2) ? defaultString : reader.GetString(2),
                        RTAF_person_FirstName = reader.IsDBNull(3) ? defaultString : reader.GetString(3),
                        RTAF_person_LastName = reader.IsDBNull(4) ? defaultString : reader.GetString(4),
                        RTAF_person_FirstName_Eng = reader.IsDBNull(5) ? defaultString : reader.GetString(5),
                        RTAF_person_LastName_Eng = reader.IsDBNull(6) ? defaultString : reader.GetString(6),
                        RTAF_person_BirthDate = reader.IsDBNull(7) ? defaultString : reader.GetDateTime(7).ToString(),
                        RTAF_person_Position = reader.IsDBNull(8) ? defaultString : reader.GetString(8),

                        RTAF_person_Rank = new Ranks
                        {
                            Rank_Code = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9),
                            Rank_Name = reader.IsDBNull(10) ? defaultString : reader.GetString(10),
                            Rank_FullName = reader.IsDBNull(11) ? defaultString : reader.GetString(11)
                        },

                        RTAF_person_Unit = new Units
                        {
                            Unit_Code = reader.IsDBNull(12) ? defaultNum : (int)reader.GetInt64(12),
                            Unit_Name = reader.IsDBNull(13) ? defaultString : reader.GetString(13),
                            Unit_FullName = reader.IsDBNull(14) ? defaultString : reader.GetString(14)
                        },

                        RTAF_person_UpdateDate = reader.IsDBNull(15) ? defaultString : reader.GetDateTime(15).ToString(),
                        RTAF_person_CreateDate = reader.IsDBNull(16) ? defaultString : reader.GetDateTime(16).ToString(),

                        RTAF_person_Status = new RTAF_Status()
                        {
                            RTAF_status_Code = reader.IsDBNull(17) ? defaultNum : reader.GetInt32(17),
                            RTAF_status_Name = reader.IsDBNull(18) ? defaultString : reader.GetString(18)
                        },

                        RTAF_person_type = new RTAF_DATA_Person_Type()
                        {
                            Person_Type_Id = reader.IsDBNull(19) ? defaultNum : reader.GetInt32(19),
                            Person_Type_Name = reader.IsDBNull(20) ? defaultString : reader.GetString(20)
                        },

                        RTAF_user_status = new RTAF_DATA_User_Status()
                        {
                            User_Status_id = reader.IsDBNull(21) ? defaultNum : reader.GetInt32(21),
                            User_Status_Name = reader.IsDBNull(22) ? defaultString : reader.GetString(22)
                        }
                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> GetRTAFDataByUnit() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> GetRTAFDataByUnit() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<RTAF_DATA> GetRTAFDataALL(RTAF_DATA i_data, int row_str, int row_end)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_list_RTAF_Person]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_IdCard", i_data.RTAF_person_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", i_data.RTAF_person_IdGvm);
                cmd.Parameters.AddWithValue("@i_Rank_Code", i_data.RTAF_person_Rank.Rank_Code);
                cmd.Parameters.AddWithValue("@i_FName", i_data.RTAF_person_FirstName);
                cmd.Parameters.AddWithValue("@i_LName", i_data.RTAF_person_LastName);
                cmd.Parameters.AddWithValue("@i_FName_Eng", i_data.RTAF_person_FirstName_Eng);
                cmd.Parameters.AddWithValue("@i_LName_Eng", i_data.RTAF_person_LastName_Eng);
                cmd.Parameters.AddWithValue("@i_Unit_Code", i_data.RTAF_person_Unit.Unit_Code);
                cmd.Parameters.AddWithValue("@i_Position", i_data.RTAF_person_Position);
                cmd.Parameters.AddWithValue("@i_status", i_data.RTAF_person_Status.RTAF_status_Name);
                cmd.Parameters.AddWithValue("@i_status_code", i_data.RTAF_person_Status.RTAF_status_Code);
                cmd.Parameters.AddWithValue("@i_row_str", row_str);
                cmd.Parameters.AddWithValue("@i_row_end", row_end);

                SqlDataReader reader = cmd.ExecuteReader();

                List<RTAF_DATA> list_data = new List<RTAF_DATA>();

                while (reader.Read())
                {
                    RTAF_DATA data = new RTAF_DATA
                    {
                        RTAF_person_Uid = reader.IsDBNull(0) ? defaultString : reader.GetString(0),
                        RTAF_person_IdCard = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        RTAF_person_IdGvm = reader.IsDBNull(2) ? defaultString : reader.GetString(2),
                        RTAF_person_FirstName = reader.IsDBNull(3) ? defaultString : reader.GetString(3),
                        RTAF_person_LastName = reader.IsDBNull(4) ? defaultString : reader.GetString(4),
                        RTAF_person_FirstName_Eng = reader.IsDBNull(5) ? defaultString : reader.GetString(5),
                        RTAF_person_LastName_Eng = reader.IsDBNull(6) ? defaultString : reader.GetString(6),
                        RTAF_person_BirthDate = reader.IsDBNull(7) ? defaultString : reader.GetDateTime(7).ToString(),
                        RTAF_person_Position = reader.IsDBNull(8) ? defaultString : reader.GetString(8),

                        RTAF_person_Rank = new Ranks
                        {
                            Rank_Code = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9),
                            Rank_Name = reader.IsDBNull(10) ? defaultString : reader.GetString(10),
                            Rank_FullName = reader.IsDBNull(11) ? defaultString : reader.GetString(11)
                        },

                        RTAF_person_Unit = new Units
                        {
                            Unit_Code = reader.IsDBNull(12) ? defaultNum : (int)reader.GetInt64(12),
                            Unit_Name = reader.IsDBNull(13) ? defaultString : reader.GetString(13),
                            Unit_FullName = reader.IsDBNull(14) ? defaultString : reader.GetString(14)
                        },

                        RTAF_person_UpdateDate = reader.IsDBNull(15) ? defaultString : reader.GetDateTime(15).ToString(),
                        RTAF_person_CreateDate = reader.IsDBNull(16) ? defaultString : reader.GetDateTime(16).ToString(),

                        RTAF_person_Status = new RTAF_Status()
                        {
                            RTAF_status_Code = reader.IsDBNull(17) ? defaultNum : reader.GetInt32(17),
                            RTAF_status_Name = reader.IsDBNull(18) ? defaultString : reader.GetString(18)
                        },

                        RTAF_person_type = new RTAF_DATA_Person_Type()
                        {
                            Person_Type_Id = reader.IsDBNull(19) ? defaultNum : reader.GetInt32(19),
                            Person_Type_Name = reader.IsDBNull(20) ? defaultString : reader.GetString(20)
                        },

                        RTAF_user_status = new RTAF_DATA_User_Status()
                        {
                            User_Status_id = reader.IsDBNull(21) ? defaultNum : reader.GetInt32(21),
                            User_Status_Name = reader.IsDBNull(22) ? defaultString : reader.GetString(22)
                        }
                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> GetRTAFDataALL() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> GetRTAFDataALL() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AddPersonalData(RTAF_DATA sv_data)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_i_RTAF_Person]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_IdCard", sv_data.RTAF_person_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", sv_data.RTAF_person_IdGvm);
                cmd.Parameters.AddWithValue("@i_Rank_Code", sv_data.RTAF_person_Rank.Rank_Code);
                cmd.Parameters.AddWithValue("@i_FName", sv_data.RTAF_person_FirstName);
                cmd.Parameters.AddWithValue("@i_LName", sv_data.RTAF_person_LastName);
                cmd.Parameters.AddWithValue("@i_FName_Eng", sv_data.RTAF_person_FirstName_Eng);
                cmd.Parameters.AddWithValue("@i_LName_Eng", sv_data.RTAF_person_LastName_Eng);
                cmd.Parameters.AddWithValue("@i_BirthDate", DateTimeUtility.CDateTime4Service2MSSQL(sv_data.RTAF_person_BirthDate));
                cmd.Parameters.AddWithValue("@i_Unit_Code", sv_data.RTAF_person_Unit.Unit_Code);
                cmd.Parameters.AddWithValue("@i_Position", sv_data.RTAF_person_Position);
                cmd.Parameters.AddWithValue("@i_status", sv_data.RTAF_person_Status.RTAF_status_Name);
                cmd.Parameters.AddWithValue("@i_status_code", sv_data.RTAF_person_Status.RTAF_status_Code);
                cmd.Parameters.AddWithValue("@i_type_id", sv_data.RTAF_person_type.Person_Type_Id);

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
                error = "Exception ==> Managers --> RTAFData_Managers --> addPersonalData() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool EditPersonalData(RTAF_DATA sv_data)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_u_RTAF_Person]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_IdCard", sv_data.RTAF_person_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", sv_data.RTAF_person_IdGvm);
                cmd.Parameters.AddWithValue("@i_Rank_Code", sv_data.RTAF_person_Rank.Rank_Code);
                cmd.Parameters.AddWithValue("@i_FName", sv_data.RTAF_person_FirstName);
                cmd.Parameters.AddWithValue("@i_LName", sv_data.RTAF_person_LastName);
                cmd.Parameters.AddWithValue("@i_FName_Eng", sv_data.RTAF_person_FirstName_Eng);
                cmd.Parameters.AddWithValue("@i_LName_Eng", sv_data.RTAF_person_LastName_Eng);
                cmd.Parameters.AddWithValue("@i_BirthDate", DateTimeUtility.CDateTime4Service2MSSQL(sv_data.RTAF_person_BirthDate));
                cmd.Parameters.AddWithValue("@i_Unit_Code", sv_data.RTAF_person_Unit.Unit_Code);
                cmd.Parameters.AddWithValue("@i_Position", sv_data.RTAF_person_Position);
                cmd.Parameters.AddWithValue("@i_status", sv_data.RTAF_person_Status.RTAF_status_Name);
                cmd.Parameters.AddWithValue("@i_status_code", sv_data.RTAF_person_Status.RTAF_status_Code);
                cmd.Parameters.AddWithValue("@i_type_id", sv_data.RTAF_person_type.Person_Type_Id);

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

        public bool ClearPersonalData()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                string sql = "TRUNCATE TABLE [dbo].[idg_RTAF_Persons] ";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> ClearPersonalData() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> ClearPersonalData() ";
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