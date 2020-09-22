using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using RTAFMailManagement.Managers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTAFMailManagement.Form_Mail_Register
{
    public partial class AD_Account_information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string User_IdGvm = code[1];
                    string User_IdCard = code[2];
                    string User_Id = code[3];

                    Users data = new Users_Mananer().GetUserById(User_Id);

                    DisplayInfo(ConnectRTAFService.GetInfomationsAccountWithADDS(data.User_UserName, ""));

                }
            }
        }

        private void DisplayInfo(AD_Real data)
        {
            if (data != null)
            {
                AD_EmployeeId.Text = data.AD_EmployeeId;
                AD_SamAccountName.Text = data.AD_SamAccountName;
                AD_GivenName.Text = data.AD_GivenName;
                AD_DisplayName.Text = data.AD_DisplayName;
                AD_DistinguishedName.Text = data.AD_DistinguishedName;
                AD_EmailAddress.Text = data.AD_EmailAddress;
                AD_HomeDirectory.Text = data.AD_HomeDirectory;
                AD_HomeDrive.Text = data.AD_HomeDrive;
                AD_LastBadPasswordAttempt.Text = DateTimeUtility.convertFullDateTimeToPageRealServer(data.AD_LastBadPasswordAttempt);
                AD_Name.Text = data.AD_Name;
                AD_MiddleName.Text = data.AD_MiddleName;
                AD_Surname.Text = data.AD_Surname;
                AD_PasswordNeverExpires.Text = data.AD_PasswordNeverExpires.ToString();
                AD_PasswordNotRequired.Text = data.AD_PasswordNotRequired.ToString();
                AD_ScriptPath.Text = data.AD_ScriptPath;
                AD_Enabled.Text = data.AD_Enabled.ToString();
                AD_lastLogIn.Text = DateTimeUtility.convertFullDateTimeToPageRealServer(data.AD_lastLogIn);
                AD_lastPasswordSet.Text = DateTimeUtility.convertFullDateTimeToPageRealServer(data.AD_lastPasswordSet);
                AD_AccountExpirationDate.Text = data.AD_AccountExpirationDate;
                AD_AccountLockoutTime.Text = data.AD_AccountLockoutTime;
                AD_BadLogonCount.Text = data.AD_BadLogonCount.ToString();
                AD_UserCannotChangePassword.Text = data.AD_UserCannotChangePassword.ToString();
                AD_UserPrincipalName.Text = data.AD_UserPrincipalName;

                AD_Nv_AccountDisabled.Text = data.AD_Nv_AccountDisabled.ToString();
                AD_Nv_AccountExpirationDate.Text = DateTimeUtility.convertFullDateTimeToPageRealServer(data.AD_Nv_AccountExpirationDate);
                AD_Nv_ADsPath.Text = data.AD_Nv_ADsPath;
                AD_Nv_BadLoginAddress.Text = data.AD_Nv_BadLoginAddress;
                AD_Nv_BadLoginCount.Text = data.AD_Nv_BadLoginCount.ToString();
                AD_Nv_Department.Text = data.AD_Nv_Department;
                AD_Nv_Description.Text = data.AD_Nv_Description;
                AD_Nv_Division.Text = data.AD_Nv_Division;
                AD_Nv_EmailAddress.Text = data.AD_Nv_EmailAddress;
                AD_Nv_EmployeeID.Text = data.AD_Nv_EmployeeID;
                AD_Nv_FaxNumber.Text = data.AD_Nv_FaxNumber;
                AD_Nv_FirstName.Text = data.AD_Nv_FirstName;
                AD_Nv_FullName.Text = data.AD_Nv_FullName;
                AD_Nv_GraceLoginsAllowed.Text = data.AD_Nv_GraceLoginsAllowed.ToString();
                AD_Nv_GraceLoginsRemaining.Text = data.AD_Nv_GraceLoginsRemaining.ToString();
                AD_Nv_GUID.Text = data.AD_Nv_GUID;
                AD_Nv_HomeDirectory.Text = data.AD_Nv_HomeDirectory;
                AD_Nv_HomePage.Text = data.AD_Nv_HomePage;
                AD_Nv_IsAccountLocked.Text = data.AD_Nv_IsAccountLocked.ToString();
                AD_Nv_Languages.Text = data.AD_Nv_Languages;
                AD_Nv_LastFailedLogin.Text = DateTimeUtility.convertFullDateTimeToPageRealServer(data.AD_Nv_LastFailedLogin);
                AD_Nv_LastLogin.Text = DateTimeUtility.convertFullDateTimeToPageRealServer(data.AD_Nv_LastLogin);
                AD_Nv_LastLogoff.Text = data.AD_Nv_LastLogoff;
                AD_Nv_LastName.Text = data.AD_Nv_LastName;
                AD_Nv_LoginHours.Text = data.AD_Nv_LoginHours;
                AD_Nv_LoginScript.Text = data.AD_Nv_LoginScript;
                AD_Nv_LoginWorkstations.Text = data.AD_Nv_LoginWorkstations;
                AD_Nv_Manager.Text = data.AD_Nv_Manager;
                AD_Nv_MaxLogins.Text = data.AD_Nv_MaxLogins.ToString();
                AD_Nv_MaxStorage.Text = data.AD_Nv_MaxStorage.ToString();
                AD_Nv_Name.Text = data.AD_Nv_Name;
                AD_Nv_NamePrefix.Text = data.AD_Nv_NamePrefix;
                AD_Nv_NameSuffix.Text = data.AD_Nv_NameSuffix;
                AD_Nv_OfficeLocations.Text = data.AD_Nv_OfficeLocations;
                AD_Nv_OtherName.Text = data.AD_Nv_OtherName;
                AD_Nv_Parent.Text = data.AD_Nv_Parent;
                AD_Nv_PasswordExpirationDate.Text = DateTimeUtility.convertFullDateTimeToPageRealServer(data.AD_Nv_PasswordExpirationDate);
                AD_Nv_PasswordLastChanged.Text = DateTimeUtility.convertFullDateTimeToPageRealServer(data.AD_Nv_PasswordLastChanged);
                AD_Nv_PasswordMinimumLength.Text = data.AD_Nv_PasswordMinimumLength.ToString();
                AD_Nv_PasswordRequired.Text = data.AD_Nv_PasswordRequired.ToString();
                AD_Nv_Picture.Text = "";
                AD_Nv_PostalAddresses.Text = data.AD_Nv_PostalAddresses;
                AD_Nv_PostalCodes.Text = data.AD_Nv_PostalCodes;
                AD_Nv_Profile.Text = data.AD_Nv_Profile;
                AD_Nv_RequireUniquePassword.Text = data.AD_Nv_RequireUniquePassword.ToString();
                AD_Nv_Schema.Text = data.AD_Nv_Schema;
                AD_Nv_TelephoneHome.Text = data.AD_Nv_TelephoneHome;
                AD_Nv_TelephoneMobile.Text = data.AD_Nv_TelephoneMobile;
                AD_Nv_TelephoneNumber.Text = data.AD_Nv_TelephoneNumber;
                AD_Nv_TelephonePager.Text = data.AD_Nv_TelephonePager;
                AD_Nv_Title.Text = data.AD_Nv_Title;
            }
        }

        protected void Close_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Mail_Register/Search_User_Accounts");
        }
    }
}