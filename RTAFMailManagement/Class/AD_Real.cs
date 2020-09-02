using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Class
{
    public class AD_Real
    {
        public string AD_EmployeeId { get; set; }
        public string AD_SamAccountName { get; set; }
        public string AD_GivenName { get; set; }
        public string AD_DisplayName { get; set; }
        public string AD_DistinguishedName { get; set; }
        public string AD_EmailAddress { get; set; }
        public string AD_HomeDirectory { get; set; }
        public string AD_HomeDrive { get; set; }
        public string AD_LastBadPasswordAttempt { get; set; }
        public string AD_Name { get; set; }
        public string AD_MiddleName { get; set; }
        public string AD_Surname { get; set; }
        public bool AD_PasswordNeverExpires { get; set; }
        public bool AD_PasswordNotRequired { get; set; }
        public string AD_ScriptPath { get; set; }
        public bool AD_Enabled { get; set; }
        public string AD_lastLogIn { get; set; }
        public string AD_lastPasswordSet { get; set; }
        public string AD_AccountExpirationDate { get; set; }
        public string AD_AccountLockoutTime { get; set; }
        public int AD_BadLogonCount { get; set; }
        public bool AD_UserCannotChangePassword { get; set; }
        public string AD_UserPrincipalName { get; set; }
        public bool AD_Nv_AccountDisabled { get; set; }
        public string AD_Nv_AccountExpirationDate { get; set; }
        public string AD_Nv_ADsPath { get; set; }
        public string AD_Nv_BadLoginAddress { get; set; }
        public int AD_Nv_BadLoginCount { get; set; }
        public string AD_Nv_Department { get; set; }
        public string AD_Nv_Description { get; set; }
        public string AD_Nv_Division { get; set; }
        public string AD_Nv_EmailAddress { get; set; }
        public string AD_Nv_EmployeeID { get; set; }
        public string AD_Nv_FaxNumber { get; set; }
        public string AD_Nv_FirstName { get; set; }
        public string AD_Nv_FullName { get; set; }
        public int AD_Nv_GraceLoginsAllowed { get; set; }
        public int AD_Nv_GraceLoginsRemaining { get; set; }
        public string AD_Nv_GUID { get; set; }
        public string AD_Nv_HomeDirectory { get; set; }
        public string AD_Nv_HomePage { get; set; }
        public bool AD_Nv_IsAccountLocked { get; set; }
        public dynamic AD_Nv_Languages { get; set; }
        public string AD_Nv_LastFailedLogin { get; set; }
        public string AD_Nv_LastLogin { get; set; }
        public string AD_Nv_LastLogoff { get; set; }
        public string AD_Nv_LastName { get; set; }
        public dynamic AD_Nv_LoginHours { get; set; }
        public string AD_Nv_LoginScript { get; set; }
        public dynamic AD_Nv_LoginWorkstations  { get; set; }
        public string AD_Nv_Manager { get; set; }
        public int AD_Nv_MaxLogins { get; set; }
        public int AD_Nv_MaxStorage { get; set; }
        public string AD_Nv_Name { get; set; }
        public string AD_Nv_NamePrefix { get; set; }
        public string AD_Nv_NameSuffix { get; set; }
        public dynamic AD_Nv_OfficeLocations { get; set; }
        public string AD_Nv_OtherName { get; set; }
        public string AD_Nv_Parent { get; set; }
        public string AD_Nv_PasswordExpirationDate { get; set; }
        public string AD_Nv_PasswordLastChanged { get; set; }
        public int AD_Nv_PasswordMinimumLength { get; set; }
        public bool AD_Nv_PasswordRequired { get; set; }
        public dynamic AD_Nv_Picture { get; set; }
        public dynamic AD_Nv_PostalAddresses { get; set; }
        public dynamic AD_Nv_PostalCodes { get; set; }
        public string AD_Nv_Profile { get; set; }
        public bool AD_Nv_RequireUniquePassword { get; set; }
        public string AD_Nv_Schema { get; set; }
        public dynamic AD_Nv_TelephoneHome { get; set; }
        public dynamic AD_Nv_TelephoneMobile { get; set; }
        public dynamic AD_Nv_TelephoneNumber { get; set; }
        public dynamic AD_Nv_TelephonePager { get; set; }
        public string AD_Nv_Title { get; set; }
    }
}