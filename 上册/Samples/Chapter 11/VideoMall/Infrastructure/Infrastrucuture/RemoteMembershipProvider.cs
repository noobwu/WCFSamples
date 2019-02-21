using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Artech.VideoMall.Infrastructure.Service.Interface;
using Microsoft.Practices.Unity.Utility;
using Artech.VideoMall.Common.Extensions;
using System.Collections.Specialized;
using Artech.VideoMall.Infrastructure.BusinessEntity;
using System.ServiceModel;
using System.Configuration;

namespace Artech.VideoMall.Infrastructure
{
public class RemoteMembershipProvider : MembershipProvider
{
    private int maxInvalidPasswordAttempts;
    private int minRequiredNonAlphanumericCharacters;
    private int minRequiredPasswordLength;
    private int passwordAttemptWindow;
    private MembershipPasswordFormat passwordFormat;
    private string passwordStrengthRegularExpression;
    private bool requiresQuestionAndAnswer;
    private bool requiresUniqueEmail;
    private  bool enablePasswordReset;
    private  bool enablePasswordRetrieval;

    public OperationInvoker<IMembershipService> Proxy { get; private set; }
    public override string ApplicationName { get; set; }
    public override int MaxInvalidPasswordAttempts 
    {
        get { return maxInvalidPasswordAttempts; } 
    }
    public override int MinRequiredNonAlphanumericCharacters
    {
        get { return minRequiredNonAlphanumericCharacters; }
    }
    public override int MinRequiredPasswordLength
    {
        get { return minRequiredPasswordLength; }
    }
    public override int PasswordAttemptWindow
    {
        get { return passwordAttemptWindow; }
    }
    public override MembershipPasswordFormat PasswordFormat
    {
        get { return passwordFormat; }
    }
    public override string PasswordStrengthRegularExpression
    {
        get { return passwordStrengthRegularExpression; }
    }
    public override bool RequiresQuestionAndAnswer
    {
        get { return requiresQuestionAndAnswer; }
    }
    public override bool RequiresUniqueEmail
    {
        get { return requiresQuestionAndAnswer; }
    }
    public override bool EnablePasswordReset
    {
        get { return enablePasswordReset; }
    }
    public override bool EnablePasswordRetrieval
    {
        get { return enablePasswordRetrieval; }
    }
    public virtual string EndpointName { get; set; }
        
    public override void Initialize(string name, NameValueCollection config)
    {
        base.Initialize(name, config);
        this.EndpointName= config["endpoint"];
        if (null == this.EndpointName)
        {
            throw new ConfigurationErrorsException("缺少必须配置属性\"endpoint\"");
        }
        this.Proxy = new OperationInvoker<IMembershipService>(this.EndpointName);

        MembershipProviderData providerData = this.Proxy.Invoke<MembershipProviderData>(proxy => proxy.GetProviderData());
        this.ApplicationName = providerData.ApplicationName;
        maxInvalidPasswordAttempts = providerData.MaxInvalidPasswordAttempts;
        minRequiredNonAlphanumericCharacters = providerData.MinRequiredNonAlphanumericCharacters;
        minRequiredPasswordLength = providerData.MinRequiredPasswordLength;
        passwordAttemptWindow = providerData.PasswordAttemptWindow;
        passwordFormat = providerData.PasswordFormat;
        passwordStrengthRegularExpression = providerData.PasswordStrengthRegularExpression;
        requiresQuestionAndAnswer = providerData.RequiresQuestionAndAnswer;
        requiresUniqueEmail = providerData.RequiresUniqueEmail;
        enablePasswordReset = providerData.EnablePasswordReset;
        enablePasswordRetrieval = providerData.EnablePasswordRetrieval;
    }

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        return this.Proxy.Invoke<bool>(proxy=>proxy.ChangePassword(username, oldPassword, newPassword));
    }

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        return this.Proxy.Invoke<bool>(proxy => proxy.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer));
    }

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        IMembershipService proxy = ChannelFactories.GetFactory<IMembershipService>(this.EndpointName).CreateChannel();                
        try
        {
            MembershipUser user = proxy.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
            (proxy as ICommunicationObject).Close();
            return user;
        }
        catch (Exception ex)
        {
            OperationInvoker.HandleException(ex, proxy as ICommunicationObject);
            throw;
        }
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        return this.Proxy.Invoke<bool>(proxy => proxy.DeleteUser(username, deleteAllRelatedData));
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        IMembershipService proxy = ChannelFactories.GetFactory<IMembershipService>(this.EndpointName).CreateChannel();
        try
        {
            MembershipUserCollection users = proxy.FindUsersByEmail(emailToMatch, pageIndex,pageSize,out totalRecords);
            (proxy as ICommunicationObject).Close();
            return users;
        }
        catch (Exception ex)
        {
            OperationInvoker.HandleException(ex, proxy as ICommunicationObject);
            throw;
        }
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        IMembershipService proxy = ChannelFactories.GetFactory<IMembershipService>(this.EndpointName).CreateChannel();
        try
        {
            MembershipUserCollection users = proxy.FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords);
            (proxy as ICommunicationObject).Close();
            return users;
        }
        catch (Exception ex)
        {
            OperationInvoker.HandleException(ex, proxy as ICommunicationObject);
            throw;
        }
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        IMembershipService proxy = ChannelFactories.GetFactory<IMembershipService>(this.EndpointName).CreateChannel();
        try
        {
            MembershipUserCollection users = proxy.GetAllUsers(pageIndex, pageSize, out totalRecords);
            (proxy as ICommunicationObject).Close();
            return users;
        }
        catch (Exception ex)
        {
            OperationInvoker.HandleException(ex, proxy as ICommunicationObject);
            throw;
        }
    }

    public override int GetNumberOfUsersOnline()
    {
        return this.Proxy.Invoke<int>(proxy => proxy.GetNumberOfUsersOnline());
    }

    public override string GetPassword(string username, string answer)
    {
        return this.Proxy.Invoke<string>(proxy => proxy.GetPassword(username, answer));
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
        return this.Proxy.Invoke<MembershipUser>(proxy => proxy.GetUser(username, userIsOnline));
    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        return this.Proxy.Invoke<MembershipUser>(proxy => proxy.GetUser(providerUserKey, userIsOnline));
    }

    public override string GetUserNameByEmail(string email)
    {
        return this.Proxy.Invoke<string>(proxy => proxy.GetUserNameByEmail(email));
    }        

    public override string ResetPassword(string username, string answer)
    {
        return this.Proxy.Invoke<string>(proxy => proxy.ResetPassword(username, answer));
    }

    public override bool UnlockUser(string username)
    {
        return this.Proxy.Invoke<bool>(proxy => proxy.UnlockUser(username));
    }

    public override void UpdateUser(MembershipUser user)
    {
            this.Proxy.Invoke(proxy => proxy.UpdateUser(user));
    }

    public override bool ValidateUser(string username, string password)
    {
        return this.Proxy.Invoke<bool>(proxy => proxy.ValidateUser(username, password));
    }
}
}
