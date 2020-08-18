using RTAFMailManagement.Class;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Web;
using System.DirectoryServices.AccountManagement;
using System.ServiceModel.Configuration;

namespace RTAFMailManagement.Global_Class
{
    public class ConnectRTAFService
    {
        public static List<RTAF_DATA> getRTAFPersonData(string unit_code)
        {
            string user = ConfigurationManager.AppSettings["UServicePerson"];
            string pass = ConfigurationManager.AppSettings["PServicePerson"];
            string unitID = ConvertUnitId2String(unit_code); //ค่าid แต่ละกรม

            RTAFService.RTAFMail data = new RTAFService.RTAFMail
            {
                UseDefaultCredentials = true
            };

            // ค่าที่ web service ส่งมา ให้ 
            RTAFService.RTAFMailData[] resault = data.GetData(user, pass, unitID);

            List<RTAF_DATA> list_data = new List<RTAF_DATA>();

            for (int i = 0; i < resault.Length; i++)
            {
                RTAF_DATA person = new RTAF_DATA
                {
                    RTAF_person_IdGvm = resault[i].ID,
                    RTAF_person_IdCard = resault[i].PeopleID,

                    RTAF_person_Rank = new Ranks
                    {
                        Rank_Name = resault[i].RANK,
                        Rank_Code = int.Parse(resault[i].RANKCODE)
                    },

                    RTAF_person_FirstName = resault[i].FIRSTNAME,
                    RTAF_person_LastName = resault[i].LASTNAME,

                    RTAF_person_Unit = new Units
                    {
                        Unit_Code = int.Parse(resault[i].UNITCODE),
                        Unit_Name = resault[i].UNITNAME
                    },

                    RTAF_person_BirthDate = resault[i].BIRTHDAY.ToString(),

                    RTAF_person_Position = resault[i].POSITION,

                    RTAF_person_Status = new RTAF_Status
                    {
                        RTAF_status_Name = resault[i].STATUS,
                    }
                };

                list_data.Add(person);
            }

            return list_data;
        }

        public static List<RTAF_DATA> getNewRTAFPerson(string unit_code)
        {
            string user = ConfigurationManager.AppSettings["nUServicePerson"];
            string pass = ConfigurationManager.AppSettings["nPServicePerson"];
            string unitID = ConvertUnitId2String(unit_code); //ค่าid แต่ละกรม

            newRTAFMail.RTAFMail data = new newRTAFMail.RTAFMail
            {
                UseDefaultCredentials = true
            };

            // ค่าที่ web service ส่งมา ให้ 
            newRTAFMail.RTAFMailData[] resault = data.GetData(user, pass, unitID);

            List<RTAF_DATA> list_data = new List<RTAF_DATA>();

            for (int i = 0; i < resault.Length; i++)
            {
                RTAF_DATA person = new RTAF_DATA
                {
                    RTAF_person_IdGvm = resault[i].ID,
                    RTAF_person_IdCard = resault[i].PeopleID,

                    RTAF_person_Rank = new Ranks
                    {
                        Rank_Name = resault[i].RANK,
                        Rank_Code = int.Parse(resault[i].RANKCODE)
                    },

                    RTAF_person_FirstName = resault[i].FIRSTNAME,
                    RTAF_person_LastName = resault[i].LASTNAME,
                    RTAF_person_FirstName_Eng = resault[i].EFIRSTNAME,
                    RTAF_person_LastName_Eng = resault[i].ELASTNAME,

                    RTAF_person_Unit = new Units
                    {
                        Unit_Code = int.Parse(resault[i].UNITCODE),
                        Unit_Name = resault[i].UNITNAME
                    },

                    RTAF_person_BirthDate = resault[i].BIRTHDAY.ToString(),

                    RTAF_person_Position = resault[i].POSITION,
                    
                    RTAF_person_Status = new RTAF_Status
                    {
                        RTAF_status_Code = int.Parse(resault[i].CODE),
                        RTAF_status_Name = resault[i].STATUS,
                    }
                };

                list_data.Add(person);
            }

            return list_data;
        }

        public static string ConvertUnitId2String(string unit_code)
        {
            if (unit_code.Length == 1)
            {
                unit_code = "00" + unit_code;
            }
            else if (unit_code.Length == 2)
            {
                unit_code = "0" + unit_code;
            }

            return unit_code;
        }

        public static bool AuthenUserWithLDAPs(string userName, string password)
        {
            string error;
            bool found_user = false;

            string ADPAth = ConfigurationManager.AppSettings["AD_Path"];
            
            DirectoryEntry de = null;
            DirectorySearcher ds = null;

            try
            {
                de = new DirectoryEntry(ADPAth, userName, password);
                ds = new DirectorySearcher(de);
                SearchResult res = ds.FindOne();

                if(res != null)
                {
                    found_user = true;
                }
                else
                {
                    found_user = false;
                }

                return found_user;
            }
            catch(WebException ex)
            {
                error = "WebException ==> Global_Class --> ConnectRTAFService --> AuthenUserWithLDAPs()";
                Log_Error._writeErrorFile(error, ex);
                return found_user;
                
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> AuthenUserWithLDAPs()";
                Log_Error._writeErrorFile(error, ex);
                return found_user;

            }
            finally
            {
                ds.Dispose();
                de.Close();
            }
        }

        public static bool AuthenUserWithADDS(string userName, string passWord)
        {
            string domainController = ConfigurationManager.AppSettings["AD_SIP"];
            string container = ConfigurationManager.AppSettings["AD_Container"];

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController, container);

            string error;

            try
            {
                if (pc.ValidateCredentials(userName, passWord))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> AuthenUserWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> AuthenUserWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            finally
            {
                pc.Dispose();
            }
        }

        public static AD_Real GetInfomationsAccountWithADDS(string userName, string OUName)
        {
            string domainController = ConfigurationManager.AppSettings["AD_SIP"];
            string container = ConfigurationManager.AppSettings["AD_Container"];
            string adminName = ConfigurationManager.AppSettings["UADService"];
            string adminPassword = ConfigurationManager.AppSettings["PADService"];

            container = string.IsNullOrEmpty(OUName) ? container : "OU=" + OUName + ",OU=RTAF," + container;

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController, container, adminName, adminPassword);

            string error;

            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, userName);

                if (user != null)
                {
                    AD_Real real = new AD_Real
                    {
                        AD_EmployeeId = user.EmployeeId,
                        AD_SamAccountName = user.SamAccountName,
                        AD_GivenName = user.GivenName,
                        AD_DisplayName = user.DisplayName,
                        AD_DistinguishedName = user.DistinguishedName,
                        AD_EmailAddress = user.EmailAddress,
                        AD_HomeDirectory = user.HomeDirectory,
                        AD_HomeDrive = user.HomeDrive,
                        AD_LastBadPasswordAttempt = user.LastBadPasswordAttempt.ToString(),
                        AD_Name = user.Name,
                        AD_MiddleName = user.MiddleName,
                        AD_Surname = user.Surname,
                        AD_PasswordNeverExpires = user.PasswordNeverExpires,
                        AD_PasswordNotRequired = user.PasswordNotRequired,
                        AD_ScriptPath = user.EmployeeId,
                        AD_Enabled = (bool)user.Enabled,
                        AD_lastLogIn = user.LastLogon.ToString(),
                        AD_lastPasswordSet = user.LastPasswordSet.ToString(),
                        AD_AccountExpirationDate = user.AccountExpirationDate.ToString(),
                        AD_AccountLockoutTime = user.AccountLockoutTime.ToString(),
                        AD_BadLogonCount = user.BadLogonCount,
                        AD_UserCannotChangePassword = user.UserCannotChangePassword,
                        AD_UserPrincipalName = user.UserPrincipalName
                    };

                    return real;
                }
                else
                {
                    return null;
                }

            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> ChangeOUNameWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> ChangeOUNameWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return null;
            }
            finally
            {
                pc.Dispose();
            }
        }

        public static AD_Real CheckStatusActiveWithADDS(string userName, string OUName)
        {
            string domainController = ConfigurationManager.AppSettings["AD_SIP"];
            string container = ConfigurationManager.AppSettings["AD_Container"];
            string adminName = ConfigurationManager.AppSettings["UADService"];
            string adminPassword = ConfigurationManager.AppSettings["PADService"];

            container = string.IsNullOrEmpty(OUName) ? container : "OU=" + OUName + ",OU=RTAF," + container;

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController, container, adminName, adminPassword);

            string error;

            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, userName);

                if (user != null)
                {
                    AD_Real real = new AD_Real
                    {
                        AD_Enabled = (bool)user.Enabled,

                    };

                    return real;
                }
                else
                {
                    return null;
                }

            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> ChangeOUNameWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> ChangeOUNameWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return null;
            }
            finally
            {
                pc.Dispose();
            }
        }

        public static bool ResetPasswordWithADDS(string userName, string newPassword)
        {
            string domainController = ConfigurationManager.AppSettings["AD_SIP"];
            string container = ConfigurationManager.AppSettings["AD_Container"];
            string adminName = ConfigurationManager.AppSettings["UADService"];
            string adminPassword = ConfigurationManager.AppSettings["PADService"];

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController, container, adminName, adminPassword);

            string error;

            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, userName);

                if (user != null)
                {
                    user.SetPassword(newPassword);
                    user.Enabled = true;
                    user.Save();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (PasswordException ex)
            {
                error = "PasswordException ==> Global_Class --> ConnectRTAFService --> ChangePasswordWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> ResetPasswordWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> ResetPasswordWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            finally
            {
                pc.Dispose();
            }
        }

        public static bool ChangePasswordWithADDS(string userName, string oldPassword, string newPassword)
        {
            string domainController = ConfigurationManager.AppSettings["AD_SIP"];
            string container = ConfigurationManager.AppSettings["AD_Container"];
            string adminName = ConfigurationManager.AppSettings["UADService"];
            string adminPassword = ConfigurationManager.AppSettings["PADService"];

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController, container, adminName, adminPassword);

            string error;

            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, userName);

                if (user != null)
                {
                    user.ChangePassword(oldPassword, newPassword);
                    user.Enabled = true;
                    user.Save();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (PasswordException ex)
            {
                error = "PasswordException ==> Global_Class --> ConnectRTAFService --> ChangePasswordWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> ChangePasswordWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> ChangePasswordWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            finally
            {
                pc.Dispose();
            }
        }

        public static bool ChangeOUNameWithADDS(string userName, string OUName)
        {
            string domainController = ConfigurationManager.AppSettings["AD_SIP"];
            string container = ConfigurationManager.AppSettings["AD_Container"];
            string adminName = ConfigurationManager.AppSettings["UADService"];
            string adminPassword = ConfigurationManager.AppSettings["PADService"];

            container = string.IsNullOrEmpty(OUName) ? "OU=RTAF," + container : container;

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController, container, adminName, adminPassword);

            string error;

            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, userName);

                if (user != null)
                {
                    user.Enabled = true;
                    user.Save();

                    GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, OUName);

                    if (gp != null)
                    {
                        gp.Members.Add(user);
                        gp.Save();
                    }

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (PrincipalOperationException ex)
            {
                error = "PrincipalOperationException ==> Global_Class --> ConnectRTAFService --> ChangeOUNameWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> ChangeOUNameWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> ChangeOUNameWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            finally
            {
                pc.Dispose();
            }
        }
    }
}