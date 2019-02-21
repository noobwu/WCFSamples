using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.VideoMall.Infrastructure.Service.Interface;
using Artech.VideoMall.Infrastructure.BusinessEntity;
using System.Web.Security;
using System.ServiceModel;
using Artech.VideoMall.Common;

namespace Artech.VideoMall.Infrastructure.Service
{
[ServiceBehavior(Namespace =Constants.DataContractNamespace)]
public class MembershipService : IMembershipService
{
    public MembershipProviderData GetProviderData()
    {
        return new MembershipProviderData
        {
            ApplicationName = Membership.Provider.ApplicationName,
            EnablePasswordReset = Membership.Provider.EnablePasswordReset,
            EnablePasswordRetrieval = Membership.Provider.EnablePasswordRetrieval,
            MaxInvalidPasswordAttempts = Membership.Provider.MaxInvalidPasswordAttempts,
            MinRequiredNonAlphanumericCharacters = Membership.Provider.MinRequiredNonAlphanumericCharacters,
            MinRequiredPasswordLength = Membership.Provider.MinRequiredPasswordLength,
            PasswordAttemptWindow = Membership.Provider.PasswordAttemptWindow,
            PasswordFormat = Membership.Provider.PasswordFormat,
            PasswordStrengthRegularExpression = Membership.Provider.PasswordStrengthRegularExpression,
            RequiresQuestionAndAnswer = Membership.Provider.RequiresQuestionAndAnswer,
            RequiresUniqueEmail = Membership.Provider.RequiresUniqueEmail
        };
    }

    public bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        return Membership.Provider.ChangePassword(username, oldPassword, newPassword);
    }

    public bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        return Membership.Provider.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
    }

    public MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        return Membership.Provider.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
    }

    public bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        return Membership.Provider.DeleteUser(username, deleteAllRelatedData);
    }

    public MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        return Membership.Provider.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
    }

    public MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        return Membership.Provider.FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords);
    }

    public MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        return Membership.Provider.GetAllUsers(pageIndex, pageSize, out totalRecords);
    }

    public int GetNumberOfUsersOnline()
    {
        return Membership.Provider.GetNumberOfUsersOnline();
    }

    public string GetPassword(string username, string answer)
    {
        return Membership.Provider.GetPassword(username, answer);
    }

    public MembershipUser GetUser(string username, bool userIsOnline)
    {
        return Membership.Provider.GetUser(username, userIsOnline);
    }

    public MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        return Membership.Provider.GetUser(providerUserKey, userIsOnline);
    }

    public string GetUserNameByEmail(string email)
    {
        return Membership.Provider.GetUserNameByEmail(email);
    }

    public string ResetPassword(string username, string answer)
    {
        return Membership.Provider.ResetPassword(username, answer);
    }

    public bool UnlockUser(string userName)
    {
        return Membership.Provider.UnlockUser(userName);
    }

    public void UpdateUser(MembershipUser user)
    {
        Membership.Provider.UpdateUser(user);
    }

    public bool ValidateUser(string username, string password)
    {
        return Membership.Provider.ValidateUser(username, password);
    }
}
}
