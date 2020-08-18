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
    }
}