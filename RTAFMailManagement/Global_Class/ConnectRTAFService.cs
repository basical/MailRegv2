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
                    RTAF_person_IdGvm = string.IsNullOrEmpty(resault[i].ID) ? "" : General_Functions.subStringIdGvm(resault[i].ID),
                    RTAF_person_IdCard = string.IsNullOrEmpty(resault[i].ID) ? "" : resault[i].PeopleID,

                    RTAF_person_Rank = new Ranks
                    {
                        Rank_Name = string.IsNullOrEmpty(resault[i].RANK) ? "" : resault[i].RANK,
                        Rank_Code = string.IsNullOrEmpty(resault[i].RANKCODE) ? 0 : int.Parse(resault[i].RANKCODE)
                    },

                    RTAF_person_FirstName = string.IsNullOrEmpty(resault[i].ID) ? "" : resault[i].FIRSTNAME,
                    RTAF_person_LastName = string.IsNullOrEmpty(resault[i].ID) ? "" : resault[i].LASTNAME,
                    RTAF_person_FirstName_Eng = string.IsNullOrEmpty(resault[i].EFIRSTNAME)? "" : resault[i].EFIRSTNAME.ToLower(),
                    RTAF_person_LastName_Eng = string.IsNullOrEmpty(resault[i].ELASTNAME)? "" : resault[i].ELASTNAME.ToLower(),

                    RTAF_person_Unit = new Units
                    {
                        Unit_Code = string.IsNullOrEmpty(resault[i].UNITCODE) ? 0 : int.Parse(resault[i].UNITCODE),
                        Unit_Name = string.IsNullOrEmpty(resault[i].UNITNAME) ? "" : resault[i].UNITNAME
                    },

                    RTAF_person_BirthDate = string.IsNullOrEmpty(resault[i].BIRTHDAY.ToString())? "1907-01-01" : DateTimeUtility.CDateTime4Service2MSSQL(resault[i].BIRTHDAY.ToString()),

                    RTAF_person_Position = string.IsNullOrEmpty(resault[i].POSITION) ? "" : resault[i].POSITION,
                    
                    RTAF_person_Status = new RTAF_Status
                    {
                        RTAF_status_Code = string.IsNullOrEmpty(resault[i].CODE) ? 0 : int.Parse(resault[i].CODE),
                        RTAF_status_Name = string.IsNullOrEmpty(resault[i].STATUS) ? "" : resault[i].STATUS,
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
                    DirectoryEntry deUser = (DirectoryEntry)user.GetUnderlyingObject();
                    ActiveDs.IADsUser nativeDeUser = (ActiveDs.IADsUser)deUser.NativeObject;

                    AD_Real real = new AD_Real
                    {
                        AD_EmployeeId = user.EmployeeId ?? user.EmployeeId,
                        AD_SamAccountName = user.SamAccountName ?? user.SamAccountName,
                        AD_GivenName = user.GivenName ?? user.GivenName,
                        AD_DisplayName = user.DisplayName ?? user.DisplayName,
                        AD_DistinguishedName = user.DistinguishedName ?? user.DistinguishedName,
                        AD_EmailAddress = user.EmailAddress ?? user.EmailAddress,
                        AD_HomeDirectory = user.HomeDirectory ?? user.HomeDirectory,
                        AD_HomeDrive = user.HomeDrive ?? user.HomeDrive,
                        AD_LastBadPasswordAttempt = user.LastBadPasswordAttempt == null ? "" : user.LastBadPasswordAttempt.ToString(),
                        AD_Name = user.Name ?? user.Name,
                        AD_MiddleName = user.MiddleName ?? user.MiddleName,
                        AD_Surname = user.Surname ?? user.Surname,
                        AD_PasswordNeverExpires = user.PasswordNeverExpires,
                        AD_PasswordNotRequired = user.PasswordNotRequired,
                        AD_ScriptPath = user.ScriptPath ?? user.ScriptPath,
                        AD_Enabled = (bool)user.Enabled,
                        AD_lastLogIn = user.LastLogon == null ? "" : user.LastLogon.ToString(),
                        AD_lastPasswordSet = user.LastPasswordSet == null ? "" : user.LastPasswordSet.ToString(),
                        AD_AccountExpirationDate = user.AccountExpirationDate == null ? "" : user.AccountExpirationDate.ToString(),
                        AD_AccountLockoutTime = user.AccountLockoutTime == null ? "" : user.AccountLockoutTime.ToString(),
                        AD_BadLogonCount = user.BadLogonCount,
                        AD_UserCannotChangePassword = user.UserCannotChangePassword,
                        AD_UserPrincipalName = user.UserPrincipalName ?? user.UserPrincipalName,

                        AD_Nv_AccountDisabled = nativeDeUser.AccountDisabled,
                        AD_Nv_AccountExpirationDate = nativeDeUser.AccountExpirationDate == null ? "" :  nativeDeUser.AccountExpirationDate.ToString(),
                        AD_Nv_ADsPath = nativeDeUser.ADsPath,
                        //AD_Nv_BadLoginAddress = nativeDeUser.BadLoginAddress,
                        AD_Nv_BadLoginCount = nativeDeUser.BadLoginCount,
                        //AD_Nv_Department = nativeDeUser.Department,
                        AD_Nv_Description = nativeDeUser.Description,
                        //AD_Nv_Division = nativeDeUser.Division,
                        AD_Nv_EmailAddress = nativeDeUser.EmailAddress,
                        //AD_Nv_EmployeeID = nativeDeUser.EmployeeID,
                        //AD_Nv_FaxNumber = nativeDeUser.FaxNumber.ToString(),
                        AD_Nv_FirstName = nativeDeUser.FirstName,
                        AD_Nv_FullName = nativeDeUser.FullName,
                        //AD_Nv_GraceLoginsAllowed = nativeDeUser.GraceLoginsAllowed,
                        //AD_Nv_GraceLoginsRemaining = nativeDeUser.GraceLoginsRemaining,
                        AD_Nv_GUID = nativeDeUser.GUID,
                        //AD_Nv_HomeDirectory = nativeDeUser.HomeDirectory,
                        //AD_Nv_HomePage = nativeDeUser.HomePage,
                        AD_Nv_IsAccountLocked = nativeDeUser.IsAccountLocked,
                        //AD_Nv_Languages = nativeDeUser.Languages,
                        AD_Nv_LastFailedLogin = nativeDeUser.LastFailedLogin.ToString(),
                        AD_Nv_LastLogin = nativeDeUser.LastLogin.ToString(),
                        //AD_Nv_LastLogoff = nativeDeUser.LastLogoff.ToString(),
                        AD_Nv_LastName = nativeDeUser.LastName,
                        //AD_Nv_LoginHours = nativeDeUser.LoginHours,
                        //AD_Nv_LoginScript = nativeDeUser.LoginScript,
                        //AD_Nv_LoginWorkstations = nativeDeUser.LoginWorkstations,
                        //AD_Nv_Manager = nativeDeUser.Manager,
                        //AD_Nv_MaxLogins = nativeDeUser.MaxLogins,
                        //AD_Nv_MaxStorage = nativeDeUser.MaxStorage,
                        AD_Nv_Name = nativeDeUser.Name,
                        //AD_Nv_NamePrefix = nativeDeUser.NamePrefix,
                        //AD_Nv_NameSuffix = nativeDeUser.NameSuffix,
                        //AD_Nv_OfficeLocations = nativeDeUser.OfficeLocations,
                        //AD_Nv_OtherName = nativeDeUser.OtherName,
                        //AD_Nv_Parent = nativeDeUser.Parent,
                        AD_Nv_PasswordExpirationDate = nativeDeUser.PasswordExpirationDate.ToString(),
                        AD_Nv_PasswordLastChanged = nativeDeUser.PasswordLastChanged.ToString(),
                        AD_Nv_PasswordMinimumLength = nativeDeUser.PasswordMinimumLength,
                        AD_Nv_PasswordRequired = nativeDeUser.PasswordRequired,
                        //AD_Nv_Picture = nativeDeUser.Picture,
                        //AD_Nv_PostalAddresses = nativeDeUser.PostalAddresses,
                        //AD_Nv_PostalCodes = nativeDeUser.PostalCodes,
                        //AD_Nv_Profile = nativeDeUser.Profile,
                        AD_Nv_RequireUniquePassword = nativeDeUser.RequireUniquePassword,
                        AD_Nv_Schema = nativeDeUser.Schema ?? nativeDeUser.Schema,
                        //AD_Nv_TelephoneHome = nativeDeUser.TelephoneHome,
                        //AD_Nv_TelephoneMobile = nativeDeUser.TelephoneMobile,
                        //AD_Nv_TelephoneNumber = nativeDeUser.TelephoneNumber,
                        //AD_Nv_TelephonePager = nativeDeUser.TelephonePager,
                        AD_Nv_Title = nativeDeUser.Title,

                        passdiff = Math.Round((DateTime.Now - nativeDeUser.PasswordLastChanged).TotalDays, 2)
                    };

                    deUser.Close();

                    return real;
                }
                else
                {
                    return null;
                }

            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> GetInfomationsAccountWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> GetInfomationsAccountWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return null;
            }
            finally
            {
                pc.Dispose();
            }
        }

        public static bool AccountDisabledWithADDS(string userName, bool disable)
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
                    user.Enabled = disable;

                    DirectoryEntry deUser = (DirectoryEntry)user.GetUnderlyingObject();
                    ActiveDs.IADsUser nativeDeUser = (ActiveDs.IADsUser)deUser.NativeObject;

                    nativeDeUser.AccountDisabled = !disable;

                    deUser.Close();

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
                error = "PasswordException ==> Global_Class --> ConnectRTAFService --> AccountDisabledWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> AccountDisabledWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> AccountDisabledWithADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
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
                    DirectoryEntry deUser = (DirectoryEntry)user.GetUnderlyingObject();
                    ActiveDs.IADsUser nativeDeUser = (ActiveDs.IADsUser)deUser.NativeObject;

                    nativeDeUser.AccountDisabled = false;
                    nativeDeUser.SetPassword(newPassword);
                    nativeDeUser.PasswordExpirationDate = DateTime.Now.AddMonths(6);

                    deUser.Close();

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
                error = "PasswordException ==> Global_Class --> ConnectRTAFService --> ResetPasswordWithADDS()";
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
                    DirectoryEntry deUser = (DirectoryEntry)user.GetUnderlyingObject();
                    ActiveDs.IADsUser nativeDeUser = (ActiveDs.IADsUser)deUser.NativeObject;

                    nativeDeUser.AccountDisabled = false;
                    nativeDeUser.ChangePassword(oldPassword, newPassword);
                    nativeDeUser.PasswordExpirationDate = DateTime.Now.AddMonths(6);

                    deUser.Close();

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
                    user.HomeDirectory = OUName;
                    user.Enabled = true;
                    user.Save();

                    /*GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, OUName);

                    if (gp != null)
                    {
                        gp.Members.Add(user);
                        gp.Save();
                    }*/

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