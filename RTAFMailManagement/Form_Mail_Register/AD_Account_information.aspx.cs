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
            AD_EmployeeId.Text = data.AD_EmployeeId.ToString();
            AD_SamAccountName.Text = data.AD_SamAccountName.ToString();
            AD_GivenName.Text = data.AD_GivenName.ToString();
            AD_DisplayName.Text = data.AD_DisplayName.ToString();
            AD_DistinguishedName.Text = data.AD_DistinguishedName.ToString();
            AD_EmailAddress.Text = data.AD_EmailAddress.ToString();
            AD_HomeDirectory.Text = data.AD_HomeDirectory.ToString();
            AD_HomeDrive.Text = data.AD_HomeDrive.ToString();
            AD_LastBadPasswordAttempt.Text = data.AD_LastBadPasswordAttempt.ToString();
            AD_Name.Text = data.AD_Name.ToString();
            AD_MiddleName.Text = data.AD_MiddleName.ToString();
            AD_Surname.Text = data.AD_Surname.ToString();
            AD_PasswordNeverExpires.Text = data.AD_PasswordNeverExpires.ToString();
            AD_PasswordNotRequired.Text = data.AD_PasswordNotRequired.ToString();
            AD_ScriptPath.Text = data.AD_ScriptPath.ToString();
            AD_Enabled.Text = data.AD_Enabled.ToString();
            AD_lastLogIn.Text = data.AD_lastLogIn.ToString();
            AD_lastPasswordSet.Text = data.AD_lastPasswordSet.ToString();
            AD_AccountExpirationDate.Text = data.AD_AccountExpirationDate.ToString();
            AD_AccountLockoutTime.Text = data.AD_AccountLockoutTime.ToString();
            AD_BadLogonCount.Text = data.AD_BadLogonCount.ToString();
            AD_UserCannotChangePassword.Text = data.AD_UserCannotChangePassword.ToString();
            AD_UserPrincipalName.Text = data.AD_UserPrincipalName.ToString();

            AD_Nv_AccountDisabled.Text = data.AD_Nv_AccountDisabled.ToString();
            AD_Nv_AccountExpirationDate.Text = data.AD_Nv_AccountExpirationDate.ToString();
            AD_Nv_ADsPath.Text = data.AD_Nv_ADsPath.ToString();
            AD_Nv_BadLoginAddress.Text = data.AD_Nv_BadLoginAddress.ToString();
            AD_Nv_BadLoginCount.Text = data.AD_Nv_BadLoginCount.ToString();
            AD_Nv_Department.Text = data.AD_Nv_Department.ToString();
            AD_Nv_Description.Text = data.AD_Nv_Description.ToString();
            AD_Nv_Division.Text = data.AD_Nv_Division.ToString();
            AD_Nv_EmailAddress.Text = data.AD_Nv_EmailAddress.ToString();
            AD_Nv_EmployeeID.Text = data.AD_Nv_EmployeeID.ToString();
            AD_Nv_FaxNumber.Text = data.AD_Nv_FaxNumber.ToString();
            AD_Nv_FirstName.Text = data.AD_Nv_FirstName.ToString();
            AD_Nv_FullName.Text = data.AD_Nv_FullName.ToString();
            AD_Nv_GraceLoginsAllowed.Text = data.AD_Nv_GraceLoginsAllowed.ToString();
            AD_Nv_GraceLoginsRemaining.Text = data.AD_Nv_GraceLoginsRemaining.ToString();
            AD_Nv_GUID.Text = data.AD_Nv_GUID.ToString();
            AD_Nv_HomeDirectory.Text = data.AD_Nv_HomeDirectory.ToString();
            AD_Nv_HomePage.Text = data.AD_Nv_HomePage.ToString();
            AD_Nv_IsAccountLocked.Text = data.AD_Nv_IsAccountLocked.ToString();
            AD_Nv_Languages.Text = data.AD_Nv_Languages.ToString();
            AD_Nv_LastFailedLogin.Text = data.AD_Nv_LastFailedLogin.ToString();
            AD_Nv_LastLogin.Text = data.AD_Nv_LastLogin.ToString();
            AD_Nv_LastLogoff.Text = data.AD_Nv_LastLogoff.ToString();
            AD_Nv_LastName.Text = data.AD_Nv_LastName.ToString();
            AD_Nv_LoginHours.Text = data.AD_Nv_LoginHours.ToString();
            AD_Nv_LoginScript.Text = data.AD_Nv_LoginScript.ToString();
            AD_Nv_LoginWorkstations.Text = data.AD_Nv_LoginWorkstations.ToString();
            AD_Nv_Manager.Text = data.AD_Nv_Manager.ToString();
            AD_Nv_MaxLogins.Text = data.AD_Nv_MaxLogins.ToString();
            AD_Nv_MaxStorage.Text = data.AD_Nv_MaxStorage.ToString();
            AD_Nv_Name.Text = data.AD_Nv_Name.ToString();
            AD_Nv_NamePrefix.Text = data.AD_Nv_NamePrefix.ToString();
            AD_Nv_NameSuffix.Text = data.AD_Nv_NameSuffix.ToString();
            AD_Nv_OfficeLocations.Text = data.AD_Nv_OfficeLocations.ToString();
            AD_Nv_OtherName.Text = data.AD_Nv_OtherName.ToString();
            AD_Nv_Parent.Text = data.AD_Nv_Parent.ToString();
            AD_Nv_PasswordExpirationDate.Text = data.AD_Nv_PasswordExpirationDate.ToString();
            AD_Nv_PasswordLastChanged.Text = data.AD_Nv_PasswordLastChanged.ToString();
            AD_Nv_PasswordMinimumLength.Text = data.AD_Nv_PasswordMinimumLength.ToString();
            AD_Nv_PasswordRequired.Text = data.AD_Nv_PasswordRequired.ToString();
            AD_Nv_Picture.Text = data.AD_Nv_Picture.ToString();
            AD_Nv_PostalAddresses.Text = data.AD_Nv_PostalAddresses.ToString();
            AD_Nv_PostalCodes.Text = data.AD_Nv_PostalCodes.ToString();
            AD_Nv_Profile.Text = data.AD_Nv_Profile.ToString();
            AD_Nv_RequireUniquePassword.Text = data.AD_Nv_RequireUniquePassword.ToString();
            AD_Nv_Schema.Text = data.AD_Nv_Schema.ToString();
            AD_Nv_TelephoneHome.Text = data.AD_Nv_TelephoneHome.ToString();
            AD_Nv_TelephoneMobile.Text = data.AD_Nv_TelephoneMobile.ToString();
            AD_Nv_TelephoneNumber.Text = data.AD_Nv_TelephoneNumber.ToString();
            AD_Nv_TelephonePager.Text = data.AD_Nv_TelephonePager.ToString();
            AD_Nv_Title.Text = data.AD_Nv_Title.ToString();
        }

        protected void Close_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Mail_Register/Search_User_Accounts");
        }
    }
}