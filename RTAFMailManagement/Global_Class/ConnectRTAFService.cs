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
            string error;

            newRTAFMails.RTAFMail data = new newRTAFMails.RTAFMail
            {
                UseDefaultCredentials = true
            };

            try
            {
                // ค่าที่ web service ส่งมา ให้ 
                newRTAFMails.RTAFMailData[] resault = data.GetData(user, pass, unitID);

                List<RTAF_DATA> list_data = new List<RTAF_DATA>();

                for (int i = 0; i < resault.Length; i++)
                {
                    RTAF_DATA person = new RTAF_DATA
                    {
                        RTAF_person_IdGvm = string.IsNullOrEmpty(resault[i].ID) ? "" : resault[i].ID,
                        RTAF_person_IdCard = string.IsNullOrEmpty(resault[i].PeopleID) ? "" : resault[i].PeopleID,
                        RTAF_person_FirstName = string.IsNullOrEmpty(resault[i].FIRSTNAME) ? "" : resault[i].FIRSTNAME,
                        RTAF_person_LastName = string.IsNullOrEmpty(resault[i].LASTNAME) ? "" : resault[i].LASTNAME,
                        RTAF_person_FirstName_Eng = string.IsNullOrEmpty(resault[i].EFIRSTNAME) ? "" : resault[i].EFIRSTNAME.ToLower(),
                        RTAF_person_LastName_Eng = string.IsNullOrEmpty(resault[i].ELASTNAME) ? "" : resault[i].ELASTNAME.ToLower(),
                        RTAF_person_BirthDate = string.IsNullOrEmpty(resault[i].BIRTHDAY.ToString()) ? "01/01/2540 0:00:00" : resault[i].BIRTHDAY.ToString(),
                        RTAF_person_Position = string.IsNullOrEmpty(resault[i].POSITION) ? "" : resault[i].POSITION,

                        RTAF_person_Status = new RTAF_Status
                        {
                            RTAF_status_Code = string.IsNullOrEmpty(resault[i].CODE) ? 0 : int.Parse(resault[i].CODE),
                            RTAF_status_Name = string.IsNullOrEmpty(resault[i].STATUS) ? "" : resault[i].STATUS
                        },

                        RTAF_person_Rank = new Ranks
                        {
                            Rank_Name = string.IsNullOrEmpty(resault[i].RANK) ? "" : resault[i].RANK,
                            Rank_Code = string.IsNullOrEmpty(resault[i].RANKCODE) ? 0 : int.Parse(resault[i].RANKCODE)
                        },

                        RTAF_person_Unit = new Units
                        {
                            Unit_Code = string.IsNullOrEmpty(resault[i].UNITCODE) ? 0 : int.Parse(resault[i].UNITCODE),
                            Unit_Name = string.IsNullOrEmpty(resault[i].UNITNAME) ? "" : resault[i].UNITNAME
                        },

                        RTAF_person_type = new RTAF_DATA_Person_Type
                        {
                            Person_Type_Id = string.IsNullOrEmpty(resault[i].PERSON_TYPE_PK) ? 0 : int.Parse(resault[i].PERSON_TYPE_PK)
                        },

                        RTAF_person_Img64Base = string.IsNullOrEmpty(resault[i].IMAGEBASE64) ? "" : resault[i].IMAGEBASE64
                    };

                    list_data.Add(person);
                }

                return list_data;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> getNewRTAFPerson()";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                data.Dispose();
            }
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

                if (res != null)
                {
                    found_user = true;
                }
                else
                {
                    found_user = false;
                }

                return found_user;
            }
            catch (WebException ex)
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
                        AD_UserPrincipalName = user.UserPrincipalName ?? user.UserPrincipalName
                    };

                    try { real.AD_Nv_AccountDisabled = nativeDeUser.AccountDisabled; } catch (Exception) { real.AD_Nv_AccountDisabled = false; }
                    try { real.AD_Nv_AccountExpirationDate = nativeDeUser.AccountExpirationDate.ToString(); } catch (Exception) { real.AD_Nv_AccountExpirationDate = ""; }
                    try { real.AD_Nv_ADsPath = nativeDeUser.ADsPath; } catch (Exception) { real.AD_Nv_ADsPath = ""; }
                    try { real.AD_Nv_BadLoginAddress = nativeDeUser.BadLoginAddress; } catch (Exception) { real.AD_Nv_BadLoginAddress = ""; }
                    try { real.AD_Nv_BadLoginCount = nativeDeUser.BadLoginCount; } catch (Exception) { real.AD_Nv_BadLoginCount = 0; }
                    try { real.AD_Nv_Department = nativeDeUser.Department; } catch (Exception) { real.AD_Nv_Department = ""; }
                    try { real.AD_Nv_Description = nativeDeUser.Description; } catch (Exception) { real.AD_Nv_Description = ""; }
                    try { real.AD_Nv_Division = nativeDeUser.Division; } catch (Exception) { real.AD_Nv_Division = ""; }
                    try { real.AD_Nv_EmailAddress = nativeDeUser.EmailAddress; } catch (Exception) { real.AD_Nv_EmailAddress = ""; }
                    try { real.AD_Nv_EmployeeID = nativeDeUser.EmployeeID; } catch (Exception) { real.AD_Nv_EmployeeID = ""; }
                    try { real.AD_Nv_FaxNumber = nativeDeUser.FaxNumber.ToString(); } catch (Exception) { real.AD_Nv_FirstName = ""; }
                    try { real.AD_Nv_FirstName = nativeDeUser.FirstName; } catch (Exception) { real.AD_Nv_FirstName = ""; }
                    try { real.AD_Nv_FullName = nativeDeUser.FullName; } catch (Exception) { real.AD_Nv_FullName = ""; }
                    try { real.AD_Nv_GraceLoginsAllowed = nativeDeUser.GraceLoginsAllowed; } catch (Exception) { real.AD_Nv_GraceLoginsAllowed = 0; }
                    try { real.AD_Nv_GraceLoginsRemaining = nativeDeUser.GraceLoginsRemaining; } catch (Exception) { real.AD_Nv_GraceLoginsRemaining = 0; }
                    try { real.AD_Nv_GUID = nativeDeUser.GUID; } catch (Exception) { real.AD_Nv_GUID = ""; }
                    try { real.AD_Nv_HomeDirectory = nativeDeUser.HomeDirectory; } catch (Exception) { real.AD_Nv_HomeDirectory = ""; }
                    try { real.AD_Nv_HomePage = nativeDeUser.HomePage; } catch (Exception) { real.AD_Nv_HomePage = ""; }
                    try { real.AD_Nv_IsAccountLocked = nativeDeUser.IsAccountLocked; } catch (Exception) { real.AD_Nv_IsAccountLocked = false; }
                    try { real.AD_Nv_Languages = nativeDeUser.Languages; } catch (Exception) { real.AD_Nv_Languages = ""; }
                    try { real.AD_Nv_LastFailedLogin = nativeDeUser.LastFailedLogin.ToString(); } catch (Exception) { real.AD_Nv_LastFailedLogin = ""; }
                    try { real.AD_Nv_LastLogin = nativeDeUser.LastLogin.ToString(); } catch (Exception) { real.AD_Nv_LastLogin = ""; }
                    try { real.AD_Nv_LastLogoff = nativeDeUser.LastLogoff.ToString(); } catch (Exception) { real.AD_Nv_LastLogoff = ""; }
                    try { real.AD_Nv_LastName = nativeDeUser.LastName; } catch (Exception) { real.AD_Nv_LastName = ""; }
                    try { real.AD_Nv_LoginHours = nativeDeUser.LoginHours; } catch (Exception) { real.AD_Nv_LoginHours = ""; }
                    try { real.AD_Nv_LoginScript = nativeDeUser.LoginScript; } catch (Exception) { real.AD_Nv_LoginScript = ""; }
                    try { real.AD_Nv_LoginWorkstations = nativeDeUser.LoginWorkstations; } catch (Exception) { real.AD_Nv_LoginWorkstations = ""; }
                    try { real.AD_Nv_Manager = nativeDeUser.Manager; } catch (Exception) { real.AD_Nv_Manager = ""; }
                    try { real.AD_Nv_MaxLogins = nativeDeUser.MaxLogins; } catch (Exception) { real.AD_Nv_MaxLogins = 0; }
                    try { real.AD_Nv_MaxStorage = nativeDeUser.MaxStorage; } catch (Exception) { real.AD_Nv_MaxStorage = 0; }
                    try { real.AD_Nv_Name = nativeDeUser.Name; } catch (Exception) { real.AD_Nv_Name = ""; }
                    try { real.AD_Nv_NamePrefix = nativeDeUser.NamePrefix; } catch (Exception) { real.AD_Nv_NamePrefix = ""; }
                    try { real.AD_Nv_NameSuffix = nativeDeUser.NameSuffix; } catch (Exception) { real.AD_Nv_NameSuffix = ""; }
                    try { real.AD_Nv_OfficeLocations = nativeDeUser.OfficeLocations; } catch (Exception) { real.AD_Nv_OfficeLocations = ""; }
                    try { real.AD_Nv_OtherName = nativeDeUser.OtherName; } catch (Exception) { real.AD_Nv_OtherName = ""; }
                    try { real.AD_Nv_Parent = nativeDeUser.Parent; } catch (Exception) { real.AD_Nv_Parent = ""; }
                    try { real.AD_Nv_PasswordExpirationDate = nativeDeUser.PasswordExpirationDate.ToString(); } catch (Exception) { real.AD_Nv_PasswordExpirationDate = ""; }
                    try
                    {
                        real.AD_Nv_PasswordLastChanged = nativeDeUser.PasswordLastChanged.ToString();
                        real.passdiff = Math.Round((DateTime.Now - nativeDeUser.PasswordLastChanged).TotalDays, 2);
                    }
                    catch (Exception)
                    {
                        real.AD_Nv_PasswordLastChanged = "";
                        real.passdiff = 0;
                    }
                    try { real.AD_Nv_PasswordMinimumLength = nativeDeUser.PasswordMinimumLength; } catch (Exception) { real.AD_Nv_PasswordMinimumLength = 0; }
                    try { real.AD_Nv_PasswordRequired = nativeDeUser.PasswordRequired; } catch (Exception) { real.AD_Nv_PasswordRequired = false; }
                    try { real.AD_Nv_Picture = nativeDeUser.Picture; } catch (Exception) { real.AD_Nv_Picture = ""; }
                    try { real.AD_Nv_PostalAddresses = nativeDeUser.PostalAddresses; } catch (Exception) { real.AD_Nv_PostalAddresses = ""; }
                    try { real.AD_Nv_PostalCodes = nativeDeUser.PostalCodes; } catch (Exception) { real.AD_Nv_PostalCodes = ""; }
                    try { real.AD_Nv_Profile = nativeDeUser.Profile; } catch (Exception) { real.AD_Nv_Profile = ""; }
                    try { real.AD_Nv_RequireUniquePassword = nativeDeUser.RequireUniquePassword; } catch (Exception) { real.AD_Nv_RequireUniquePassword = false; }
                    try { real.AD_Nv_Schema = nativeDeUser.Schema; } catch (Exception) { real.AD_Nv_Schema = ""; }
                    try { real.AD_Nv_TelephoneHome = nativeDeUser.TelephoneHome; } catch (Exception) { real.AD_Nv_TelephoneHome = ""; }
                    try { real.AD_Nv_TelephoneMobile = nativeDeUser.TelephoneMobile; } catch (Exception) { real.AD_Nv_TelephoneMobile = ""; }
                    try { real.AD_Nv_TelephoneNumber = nativeDeUser.TelephoneNumber; } catch (Exception) { real.AD_Nv_TelephoneNumber = ""; }
                    try { real.AD_Nv_TelephonePager = nativeDeUser.TelephonePager; } catch (Exception) { real.AD_Nv_TelephonePager = ""; }
                    try { real.AD_Nv_Title = nativeDeUser.Title; } catch (Exception) { real.AD_Nv_Title = ""; }

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

        public static bool AddAccount2ADDS(Users data)
        {
            string domainController = ConfigurationManager.AppSettings["AD_SIP"];
            string container = ConfigurationManager.AppSettings["AD_Container"];
            string adminName = ConfigurationManager.AppSettings["UADService"];
            string adminPassword = ConfigurationManager.AppSettings["PADService"];

            container = string.IsNullOrEmpty(data.User_Unit.Unit_OUName) ? container : "OU=" + data.User_Unit.Unit_OUName + ",OU=RTAF," + container;

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController, container, adminName, adminPassword);

            string error;

            try
            {
                UserPrincipal user = new UserPrincipal(pc, data.User_UserName, data.User_Password, true);

                DirectoryEntry deUser = (DirectoryEntry)user.GetUnderlyingObject();
                ActiveDs.IADsUser nativeDeUser = (ActiveDs.IADsUser)deUser.NativeObject;

                nativeDeUser.AccountDisabled = false;
                nativeDeUser.Department = data.User_Unit.Unit_FullName;
                nativeDeUser.Description = data.User_FirstNameEn + " " + data.User_LastNameEn;
                nativeDeUser.EmailAddress = data.User_Email;
                nativeDeUser.FirstName = data.User_FirstName;
                nativeDeUser.FullName = data.User_Rank.Rank_Name + data.User_FirstName + " " + data.User_LastName;
                nativeDeUser.IsAccountLocked = false;
                nativeDeUser.LastName = data.User_LastName;
                nativeDeUser.SetPassword(data.User_Password);
                nativeDeUser.TelephoneMobile = data.User_Tel;
                nativeDeUser.Title = data.User_Position;

                deUser.Close();

                user.SamAccountName = data.User_UserName;
                user.GivenName = data.User_FirstName;
                user.EmailAddress = data.User_Email;
                user.Name = data.User_UserName;
                user.Surname = data.User_LastName;
                user.UserPrincipalName = data.User_Email;
                user.Enabled = true;
                user.Save();

                return true;
            }
            catch (PrincipalException ex)
            {
                error = "PrincipalException ==> Global_Class --> ConnectRTAFService --> AddAccount2ADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Global_Class --> ConnectRTAFService --> AddAccount2ADDS()";
                Log_Error._writeErrorFile(error, ex);

                return false;
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
                    DirectoryEntry deUser = (DirectoryEntry)user.GetUnderlyingObject();
                    ActiveDs.IADsUser nativeDeUser = (ActiveDs.IADsUser)deUser.NativeObject;

                    nativeDeUser.AccountDisabled = !disable;

                    deUser.Close();

                    user.Enabled = disable;
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