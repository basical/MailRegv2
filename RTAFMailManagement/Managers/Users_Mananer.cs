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

        public List<Users_Type> getAllUserType()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM idg_Type WHERE Code IS NOT NULL; ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Users_Type> list_data = new List<Users_Type>();

                while (reader.Read())
                {
                    Users_Type data = new Users_Type
                    {
                        User_Type_Code = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0),
                        User_Type_Name = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        User_Type_Sort = reader.IsDBNull(2) ? defaultNum : reader.GetInt32(2),
                        User_Type_Remark = reader.IsDBNull(3) ? defaultString : reader.GetString(3)
                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Users_Mananer --> getAllUserType() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Users_Mananer --> getAllUserType() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

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

        public Users GetUserById(string user_id)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_listMailUser]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_userid", int.Parse(user_id));
                cmd.Parameters.AddWithValue("@i_username", "");
                cmd.Parameters.AddWithValue("@i_IdCard", "");
                cmd.Parameters.AddWithValue("@i_IdGvm", "");
                cmd.Parameters.AddWithValue("@i_FName", "");
                cmd.Parameters.AddWithValue("@i_LName", "");
                cmd.Parameters.AddWithValue("@i_Rank", 0);
                cmd.Parameters.AddWithValue("@i_Unit", 0);
                cmd.Parameters.AddWithValue("@i_status_code", 0);
                cmd.Parameters.AddWithValue("@i_row_str", 0);
                cmd.Parameters.AddWithValue("@i_row_end", 0);

                SqlDataReader reader = cmd.ExecuteReader();

                Users data = new Users();

                if (reader.Read())
                {
                    data.User_id = reader.IsDBNull(0) ? defaultNum : (int)reader.GetInt64(0);
                    data.User_Email = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    data.User_IdCard = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    data.User_IdGvm = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    data.User_BirthDate = reader.IsDBNull(4) ? defaultString : reader.GetDateTime(4).ToString();
                    data.User_FirstName = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    data.User_LastName = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    data.User_FirstNameEn = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    data.User_LastNameEn = reader.IsDBNull(8) ? defaultString : reader.GetString(8);

                    data.User_Rank = new Ranks()
                    {
                        Rank_id = reader.IsDBNull(9) ? defaultNum : reader.GetInt64(9),
                        Rank_Code = reader.IsDBNull(10) ? defaultNum : reader.GetInt32(10),
                        Rank_Name = reader.IsDBNull(11) ? defaultString : reader.GetString(11),
                        Rank_FullName = reader.IsDBNull(12) ? defaultString : reader.GetString(12),
                        Rank_NameEng = reader.IsDBNull(13) ? defaultString : reader.GetString(13),
                        Rank_FullNameEng = reader.IsDBNull(14) ? defaultString : reader.GetString(14),
                        Rank_GroupName = reader.IsDBNull(15) ? defaultString : reader.GetString(15),
                        Rank_Remark = reader.IsDBNull(16) ? defaultString : reader.GetString(16),
                        Rank_Sort = reader.IsDBNull(17) ? defaultNum : reader.GetInt32(17),
                        Rank_Mailbox = reader.IsDBNull(18) ? defaultString : reader.GetString(18),
                        Rank_sortrank = reader.IsDBNull(19) ? defaultNum : reader.GetInt32(19),
                        Rank_rankgroup = reader.IsDBNull(20) ? defaultString : reader.GetString(20),
                        Rank_ranktype = reader.IsDBNull(21) ? defaultNum : reader.GetInt32(21)
                    };

                    data.User_Unit = new Units()
                    {
                        Unit_id = reader.IsDBNull(22) ? defaultNum : reader.GetInt64(22),
                        Unit_Code = reader.IsDBNull(23) ? defaultNum : reader.GetInt64(23),
                        Unit_Name = reader.IsDBNull(24) ? defaultString : reader.GetString(24),
                        Unit_FullName = reader.IsDBNull(25) ? defaultString : reader.GetString(25),
                        Unit_SubCode = reader.IsDBNull(26) ? defaultNum : reader.GetInt64(26),
                        Unit_Sort = reader.IsDBNull(27) ? defaultNum : reader.GetInt32(27),
                        Unit_Level = reader.IsDBNull(28) ? defaultNum : reader.GetInt32(28),
                        Unit_OUName = reader.IsDBNull(29) ? defaultString : reader.GetString(29),
                        Unit_GroupName = reader.IsDBNull(30) ? defaultString : reader.GetString(30),
                        Unit_Remark = reader.IsDBNull(31) ? defaultString : reader.GetString(31)
                    };

                    data.User_Password = reader.IsDBNull(32) ? defaultString : reader.GetString(32);
                    data.User_Format = reader.IsDBNull(33) ? defaultNum : reader.GetInt32(33);

                    data.User_Question = new Questions()
                    {
                        Questions_id = reader.IsDBNull(34) ? defaultNum : reader.GetInt32(34)
                    };

                    data.User_Answer = reader.IsDBNull(35) ? defaultString : reader.GetString(35);
                    data.User_Position = reader.IsDBNull(36) ? defaultString : reader.GetString(36);
                    data.User_UserName = reader.IsDBNull(37) ? defaultString : reader.GetString(37);
                    data.User_Name = reader.IsDBNull(38) ? defaultString : reader.GetString(38);

                    data.User_ADStatus = new AD_Status()
                    {
                        AD_Status_Code = reader.IsDBNull(39) ? defaultNum : reader.GetInt32(39),
                        AD_Status_Name = reader.IsDBNull(40) ? defaultString : reader.GetString(40),
                        AD_Status_Sort = reader.IsDBNull(41) ? defaultNum : reader.GetInt32(41),
                        AD_Status_Remark = reader.IsDBNull(42) ? defaultString : reader.GetString(42)
                    };

                    data.User_MailStatus = new Mail_Status()
                    {
                        Mail_Status_Code = reader.IsDBNull(43) ? defaultNum : reader.GetInt32(43),
                        Mail_Status_Name = reader.IsDBNull(44) ? defaultString : reader.GetString(44),
                        Mail_Status_Sort = reader.IsDBNull(45) ? defaultNum : reader.GetInt32(45),
                        Mail_Status_Remark = reader.IsDBNull(46) ? defaultString : reader.GetString(46)
                    };

                    data.User_Type = new Users_Type()
                    {
                        User_Type_Code = reader.IsDBNull(47) ? defaultNum : reader.GetInt32(47),
                        User_Type_Name = reader.IsDBNull(48) ? defaultString : reader.GetString(48),
                        User_Type_Sort = reader.IsDBNull(49) ? defaultNum : reader.GetInt32(49),
                        User_Type_Remark = reader.IsDBNull(50) ? defaultString : reader.GetString(50)
                    };

                    data.User_Tel = reader.IsDBNull(51) ? defaultString : reader.GetString(51);
                    data.User_Type_Rank = reader.IsDBNull(52) ? defaultNum : reader.GetInt32(52);
                    data.User_UpdateDate = reader.IsDBNull(53) ? defaultString : reader.GetDateTime(53).ToString();
                    data.User_CreateDate = reader.IsDBNull(54) ? defaultString : reader.GetDateTime(54).ToString();
                    data.User_Remark = reader.IsDBNull(55) ? defaultString : reader.GetString(55);
                    data.User_PasswordOld = reader.IsDBNull(56) ? defaultString : reader.GetString(56);
                    data.User_Permission = reader.IsDBNull(57) ? defaultNum : reader.GetInt32(57);
                    data.User_Division = reader.IsDBNull(58) ? defaultNum : reader.GetInt32(58);
                    data.User_WorkingYear = reader.IsDBNull(59) ? defaultNum : reader.GetInt32(59);
                    data.User_WorkingRank = reader.IsDBNull(60) ? defaultNum : reader.GetInt32(60);
                    data.User_PosAction = reader.IsDBNull(61) ? defaultNum : reader.GetInt32(61);
                    data.User_SecEmail = reader.IsDBNull(62) ? defaultString : reader.GetString(62);
                    data.User_status_msg = reader.IsDBNull(63) ? defaultString : reader.GetString(63);

                    data.User_status = new RTAF_Status()
                    {
                        RTAF_status_Code = reader.IsDBNull(64) ? defaultNum : reader.GetInt32(64),
                        RTAF_status_Name = reader.IsDBNull(65) ? defaultString : reader.GetString(65),
                        RTAF_status_Sort = reader.IsDBNull(66) ? defaultNum : reader.GetInt32(66),
                        RTAF_status_Remark = reader.IsDBNull(67) ? defaultString : reader.GetString(67)
                    };
                }

                return data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> GetUserById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> GetUserById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Users> GetListUsers(Users i_data, int row_str, int row_end)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_g_listMailUser]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_userid", i_data.User_id);
                cmd.Parameters.AddWithValue("@i_username", i_data.User_UserName);
                cmd.Parameters.AddWithValue("@i_IdCard", i_data.User_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", i_data.User_IdGvm);
                cmd.Parameters.AddWithValue("@i_FName", i_data.User_FirstName);
                cmd.Parameters.AddWithValue("@i_LName", i_data.User_LastName);
                cmd.Parameters.AddWithValue("@i_Rank", i_data.User_Rank.Rank_Code);
                cmd.Parameters.AddWithValue("@i_Unit", i_data.User_Unit.Unit_Code);
                cmd.Parameters.AddWithValue("@i_status_code", i_data.User_status.RTAF_status_Code);
                cmd.Parameters.AddWithValue("@i_row_str", row_str);
                cmd.Parameters.AddWithValue("@i_row_end", row_end);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Users> list_data = new List<Users>();

                while (reader.Read())
                {
                    Users data = new Users()
                    {
                        User_id = reader.IsDBNull(0) ? defaultNum : (int)reader.GetInt64(0),
                        User_Email = reader.IsDBNull(1) ? defaultString : reader.GetString(1),
                        User_IdCard = reader.IsDBNull(2) ? defaultString : reader.GetString(2),
                        User_IdGvm = reader.IsDBNull(3) ? defaultString : reader.GetString(3),
                        User_BirthDate = reader.IsDBNull(4) ? defaultString : reader.GetDateTime(4).ToString(),
                        User_FirstName = reader.IsDBNull(5) ? defaultString : reader.GetString(5),
                        User_LastName = reader.IsDBNull(6) ? defaultString : reader.GetString(6),
                        User_FirstNameEn = reader.IsDBNull(7) ? defaultString : reader.GetString(7),
                        User_LastNameEn = reader.IsDBNull(8) ? defaultString : reader.GetString(8),

                        User_Rank = new Ranks()
                        {
                            Rank_id = reader.IsDBNull(9) ? defaultNum : reader.GetInt64(9),
                            Rank_Code = reader.IsDBNull(10) ? defaultNum : reader.GetInt32(10),
                            Rank_Name = reader.IsDBNull(11) ? defaultString : reader.GetString(11),
                            Rank_FullName = reader.IsDBNull(12) ? defaultString : reader.GetString(12),
                            Rank_NameEng = reader.IsDBNull(13) ? defaultString : reader.GetString(13),
                            Rank_FullNameEng = reader.IsDBNull(14) ? defaultString : reader.GetString(14),
                            Rank_GroupName = reader.IsDBNull(15) ? defaultString : reader.GetString(15),
                            Rank_Remark = reader.IsDBNull(16) ? defaultString : reader.GetString(16),
                            Rank_Sort = reader.IsDBNull(17) ? defaultNum : reader.GetInt32(17),
                            Rank_Mailbox = reader.IsDBNull(18) ? defaultString : reader.GetString(18),
                            Rank_sortrank = reader.IsDBNull(19) ? defaultNum : reader.GetInt32(19),
                            Rank_rankgroup = reader.IsDBNull(20) ? defaultString : reader.GetString(20),
                            Rank_ranktype = reader.IsDBNull(21) ? defaultNum : reader.GetInt32(21)
                        },

                        User_Unit = new Units()
                        {
                            Unit_id = reader.IsDBNull(22) ? defaultNum : reader.GetInt64(22),
                            Unit_Code = reader.IsDBNull(23) ? defaultNum : reader.GetInt64(23),
                            Unit_Name = reader.IsDBNull(24) ? defaultString : reader.GetString(24),
                            Unit_FullName = reader.IsDBNull(25) ? defaultString : reader.GetString(25),
                            Unit_SubCode = reader.IsDBNull(26) ? defaultNum : reader.GetInt64(26),
                            Unit_Sort = reader.IsDBNull(27) ? defaultNum : reader.GetInt32(27),
                            Unit_Level = reader.IsDBNull(28) ? defaultNum : reader.GetInt32(28),
                            Unit_OUName = reader.IsDBNull(29) ? defaultString : reader.GetString(29),
                            Unit_GroupName = reader.IsDBNull(30) ? defaultString : reader.GetString(30),
                            Unit_Remark = reader.IsDBNull(31) ? defaultString : reader.GetString(31)
                        },

                        User_Password = reader.IsDBNull(32) ? defaultString : reader.GetString(32),
                        User_Format = reader.IsDBNull(33) ? defaultNum : reader.GetInt32(33),

                        User_Question = new Questions()
                        {
                            Questions_id = reader.IsDBNull(34) ? defaultNum : reader.GetInt32(34)
                        },

                        User_Answer = reader.IsDBNull(35) ? defaultString : reader.GetString(35),
                        User_Position = reader.IsDBNull(36) ? defaultString : reader.GetString(36),
                        User_UserName = reader.IsDBNull(37) ? defaultString : reader.GetString(37),
                        User_Name = reader.IsDBNull(38) ? defaultString : reader.GetString(38),

                        User_ADStatus = new AD_Status()
                        {
                            AD_Status_Code = reader.IsDBNull(39) ? defaultNum : reader.GetInt32(39),
                            AD_Status_Name = reader.IsDBNull(40) ? defaultString : reader.GetString(40),
                            AD_Status_Sort = reader.IsDBNull(41) ? defaultNum : reader.GetInt32(41),
                            AD_Status_Remark = reader.IsDBNull(42) ? defaultString : reader.GetString(42)
                        },

                        User_MailStatus = new Mail_Status()
                        {
                            Mail_Status_Code = reader.IsDBNull(43) ? defaultNum : reader.GetInt32(43),
                            Mail_Status_Name = reader.IsDBNull(44) ? defaultString : reader.GetString(44),
                            Mail_Status_Sort = reader.IsDBNull(45) ? defaultNum : reader.GetInt32(45),
                            Mail_Status_Remark = reader.IsDBNull(46) ? defaultString : reader.GetString(46)
                        },

                        User_Type = new Users_Type()
                        {
                            User_Type_Code = reader.IsDBNull(47) ? defaultNum : reader.GetInt32(47),
                            User_Type_Name = reader.IsDBNull(48) ? defaultString : reader.GetString(48),
                            User_Type_Sort = reader.IsDBNull(49) ? defaultNum : reader.GetInt32(49),
                            User_Type_Remark = reader.IsDBNull(50) ? defaultString : reader.GetString(50)
                        },

                        User_Tel = reader.IsDBNull(51) ? defaultString : reader.GetString(51),
                        User_Type_Rank = reader.IsDBNull(52) ? defaultNum : reader.GetInt32(52),
                        User_UpdateDate = reader.IsDBNull(53) ? defaultString : reader.GetDateTime(53).ToString(),
                        User_CreateDate = reader.IsDBNull(54) ? defaultString : reader.GetDateTime(54).ToString(),
                        User_Remark = reader.IsDBNull(55) ? defaultString : reader.GetString(55),
                        User_PasswordOld = reader.IsDBNull(56) ? defaultString : reader.GetString(56),
                        User_Permission = reader.IsDBNull(57) ? defaultNum : reader.GetInt32(57),
                        User_Division = reader.IsDBNull(58) ? defaultNum : reader.GetInt32(58),
                        User_WorkingYear = reader.IsDBNull(59) ? defaultNum : reader.GetInt32(59),
                        User_WorkingRank = reader.IsDBNull(60) ? defaultNum : reader.GetInt32(60),
                        User_PosAction = reader.IsDBNull(61) ? defaultNum : reader.GetInt32(61),
                        User_SecEmail = reader.IsDBNull(62) ? defaultString : reader.GetString(62),
                        User_status_msg = reader.IsDBNull(63) ? defaultString : reader.GetString(63),

                        User_status = new RTAF_Status()
                        {
                            RTAF_status_Code = reader.IsDBNull(64) ? defaultNum : reader.GetInt32(64),
                            RTAF_status_Name = reader.IsDBNull(65) ? defaultString : reader.GetString(65),
                            RTAF_status_Sort = reader.IsDBNull(66) ? defaultNum : reader.GetInt32(66),
                            RTAF_status_Remark = reader.IsDBNull(67) ? defaultString : reader.GetString(67)
                        },

                        User_Real_AD = ConnectRTAFService.GetInfomationsAccountWithADDS(reader.IsDBNull(37) ? defaultString : reader.GetString(37), ""),

                    };

                    list_data.Add(data);
                }

                return list_data;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> RTAFData_Managers --> GetListUsers() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> RTAFData_Managers --> GetListUsers() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateUserAccountWithRTAFDATA(Users i_data)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[new_u_UserWithRTAF_Person]", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@i_IdCard", i_data.User_IdCard);
                cmd.Parameters.AddWithValue("@i_IdGvm", i_data.User_IdGvm);
                cmd.Parameters.AddWithValue("@i_BirthDate", i_data.User_BirthDate);
                cmd.Parameters.AddWithValue("@i_FName", i_data.User_FirstName);
                cmd.Parameters.AddWithValue("@i_LName", i_data.User_LastName);
                cmd.Parameters.AddWithValue("@i_FName_Eng", i_data.User_FirstNameEn);
                cmd.Parameters.AddWithValue("@i_LName_Eng", i_data.User_LastNameEn);
                cmd.Parameters.AddWithValue("@i_Rank", i_data.User_Rank.Rank_Code);
                cmd.Parameters.AddWithValue("@i_Unit", i_data.User_Unit.Unit_Code);
                cmd.Parameters.AddWithValue("@i_Position", i_data.User_Position);
                cmd.Parameters.AddWithValue("@i_status", i_data.User_status_msg);
                cmd.Parameters.AddWithValue("@i_status_code", i_data.User_status.RTAF_status_Code);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Managers --> Users_Mananer --> UpdateUserAccountWithRTAFDATA() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers --> Users_Mananer --> UpdateUserAccountWithRTAFDATA() ";
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